using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using ShareOS.IDAL;
using Common.DBUtility;
using ShareOS.SQLServerDAL.DS;

namespace ShareOS.SQLServerDAL
{
    public class FundAccount : IFundAccount
    {
        protected Model.FundAccountRecord Parse(SqlDataReader Reader)
        {
            DBTable.FundAccount table = new ShareOS.SQLServerDAL.DBTable.FundAccount();

            Model.FundAccountRecord record = new Model.FundAccountRecord();
            record.FundAccountId= Convert.ToInt32(Reader[table.FundAccountId.Text]);
            record.IssueNumber = Convert.ToInt32(Reader[table.IssueNumber.Text]);
            record.ShareholderNumber = Convert.ToInt32(Reader[table.ShareholderNumber.Text]);
            record.ChangeMoney = Convert.ToDecimal(Reader[table.ChangeMoney.Text]);
            record.ChangeReason = Reader[table.ChangeReason.Text].ToString();
            record.ChangeDate = Convert.ToDateTime(Reader[table.ChangeDate.Text]);
            
            return record;
        }


        #region IFundAccount 成员

        /// <summary>
        /// 插入个人资金帐户记录
        /// </summary>
        /// <param name="accountRecord"></param>
        /// <returns></returns>
        public bool InsertFundAccountRecord(int issueNumber, int shareholderNumber, decimal money, string changeReason, DateTime changeDate)
        {
            bool returnValue = false;

            DBProcedure.Insert_FundAccount prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Insert_FundAccount();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_IssueNumber.ParameterName, issueNumber);
            prdHelper.SetInputValue(prdCmdText.PARM_ShareholderNumber.ParameterName, shareholderNumber);
            prdHelper.SetInputValue(prdCmdText.PARM_ChangeMoney.ParameterName, money);
            prdHelper.SetInputValue(prdCmdText.PARM_ChangeReason.ParameterName, changeReason);
            prdHelper.SetInputValue(prdCmdText.PARM_ChangeDate.ParameterName, changeDate);

            returnValue = prdHelper.ExecuteNonQuery();

            prdHelper.Dispose();

            return returnValue;
        }

        /// <summary>
        /// 获取个人历年资金帐户变动记录报告。
        /// </summary>
        /// <param name="sharehoderNumber">股东号。</param>
        /// <returns></returns>
        public System.Data.DataTable SelectPersonFundAccount(int shareholderNumber)
        {
            DataTable returnTable;
            DBProcedure.Select_Person_FundAccount prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_Person_FundAccount();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_ShareholderNumber.ParameterName, shareholderNumber);

            SqlDataReaderHelper readerHelper = new SqlDataReaderHelper(prdHelper.ExecuteReader());
            readerHelper.LoopReadToTable(out returnTable);

            prdHelper.Dispose();
            return returnTable;
        }

        /// <summary>
        /// 更新个人资金变动记录。
        /// </summary>
        /// <param name="accountRecord">资金帐户记录。</param>
        /// <returns></returns>
        public bool UpdateFundAccountRecord(ShareOS.Model.FundAccountRecord accountRecord)
        {
            bool returnValue = false;
            DBProcedure.Update_FundAccount prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Update_FundAccount();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_FundAccountId.ParameterName, accountRecord.FundAccountId);
            prdHelper.SetInputValue(prdCmdText.PARM_IssueNumber.ParameterName, accountRecord.IssueNumber);
            prdHelper.SetInputValue(prdCmdText.PARM_ShareholderNumber.ParameterName, accountRecord.ShareholderNumber);
            prdHelper.SetInputValue(prdCmdText.PARM_ChangeMoney.ParameterName, accountRecord.ChangeMoney);
            prdHelper.SetInputValue(prdCmdText.PARM_ChangeReason.ParameterName, accountRecord.ChangeReason);
            prdHelper.SetInputValue(prdCmdText.PARM_ChangeDate.ParameterName, accountRecord.ChangeDate);

            returnValue = prdHelper.ExecuteNonQuery();
            prdHelper.Dispose();
            return returnValue;
        }

        #endregion
    }
}
