using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShareOS.SQLServerDAL;
using ShareOS.SQLServerDAL.DS;
using Common.DBUtility;

namespace ShareOS.SQLServerDAL
{
    public class FinanceDAO : IDisposable
    {
        Tiyi.ShareOS.SQLServerDAL.ShareDataContext dbContext = new Tiyi.ShareOS.SQLServerDAL.ShareDataContext(Tiyi.ShareOS.SQLServerDAL.Connection.GetConnectionString());

        /// <summary>
        /// 释放由本类占用的所有资源
        /// </summary>
        public void Dispose()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
                dbContext = null;
            }

            GC.SuppressFinalize(this);
        }

        ~FinanceDAO()
        {
            this.Dispose();
        }

        /// <summary>
        /// 在 Settlement 表中,批量生成退休离职人员的清算记录.
        /// 注意：此方法只能为退休、离职、死亡人员进行清股清算。
        /// </summary>
        /// <param name="issueNumber">股权交易期数</param>
        /// <returns></returns>
        public bool GenerateClearingReport(int issueNumber)
        {
            bool returnValue = false;
            DBProcedure.GenerateClearingRecord_Mass prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.GenerateClearingRecord_Mass();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_IssueNumber.ParameterName, issueNumber);

            returnValue = prdHelper.ExecuteNonQuery();
            prdHelper.Dispose();
            return returnValue;
        }

        /// <summary>
        /// 在 Settlement 表中,批量生成在职股东的年度结算记录.
        /// 注意：此方法只能为在职股东进行年度结算。
        /// </summary>
        /// <param name="issueNumber">股权交易期数</param>
        /// <returns></returns>
        public bool GenerateSettlementReport(int issueNumber)
        {
            bool returnValue = false;
            DBProcedure.GenerateSettlementRecord_Mass prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.GenerateSettlementRecord_Mass();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_IssueNumber.ParameterName, issueNumber);

            returnValue = prdHelper.ExecuteNonQuery();
            prdHelper.Dispose();
            return returnValue;
        }

        /// <summary>
        /// 获取指定股权交易期，在职股东(除待退股东)申请转让,申请受让数据采集表。
        /// </summary>
        /// <param name="issueNumber"></param>
        /// <returns></returns>
        public DataTable GetDataCollectionTable(int issueNumber)
        {
            DataTable returnTable;
            DBProcedure.Report_DataCollection_Table prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Report_DataCollection_Table();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_IssueNumber.ParameterName, issueNumber);

            Common.DBUtility.SqlDataReaderHelper readerHelper = new SqlDataReaderHelper(prdHelper.ExecuteReader());
            readerHelper.LoopReadToTable(out returnTable);

            prdHelper.Dispose();
            return returnTable;
        }

        /// <summary>
        /// 获取指定交易期，退休、离职、死亡人员的清退报告。
        /// 注意：此方法可以获取所有在职股东、退休、离职、死亡人员的结算报告，在实际应用中，可根据人员类别进行筛选。
        /// </summary>
        /// <param name="issueNumber">股权交易期数.</param>
        /// <returns></returns>
        public DataTable GetSettlementReport(int issueNumber)
        {
            DataTable returnTable;
            DBProcedure.Report_Finance_Settlement_By_IssueNumber prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Report_Finance_Settlement_By_IssueNumber();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_IssueNumber.ParameterName, issueNumber);

            Common.DBUtility.SqlDataReaderHelper readerHelper = new SqlDataReaderHelper(prdHelper.ExecuteReader());
            readerHelper.LoopReadToTable(out returnTable);

            prdHelper.Dispose();
            return returnTable;
        }



        /// <summary>
        /// 获取指定交易期，递交银行的转账清单。
        /// 该清单包括所有在职、退休、离职、死亡人员，可按银行进行筛选，分别递交不同的银行。
        /// </summary>
        /// <param name="issueNumber">股权交易期数.</param>
        /// <returns></returns>
        public DataTable GetBankPaymentSlip(int issueNumber)
        {
            DataTable returnTable;
            DBProcedure.Report_Finance_BankPaymentSlip_By_IssueNumber prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Report_Finance_BankPaymentSlip_By_IssueNumber();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_IssueNumber.ParameterName, issueNumber);

            Common.DBUtility.SqlDataReaderHelper readerHelper = new SqlDataReaderHelper(prdHelper.ExecuteReader());
            readerHelper.LoopReadToTable(out returnTable);

            prdHelper.Dispose();
            return returnTable;
        }

        /// <summary>
        /// 获取所有股东开户银行列表.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Bank> GetBankNameList()
        {
            var query = (from item in dbContext.Shareholder
                         where item.Status == "待退股东" || item.Status == "股东"
                         select new Bank { BankName = item.BankName }).Distinct();
            return query;
        }


    }

    public class Bank
    {
        public string BankName { get; set; }
    }
}
