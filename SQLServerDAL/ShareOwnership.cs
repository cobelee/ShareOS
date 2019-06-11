using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using ShareOS.IDAL;
using ShareOS.SQLServerDAL.DS;
using Common.DBUtility;

namespace ShareOS.SQLServerDAL
{
    public partial class ShareOwnership : IShareOwnership
    {
        #region IShareOwnership 成员

        /// <summary>
        /// 股权增减。
        /// </summary>
        /// <param name="shareholderNumber">股东号。</param>
        /// <param name="sharesChanges">股权改变量。正数代表股权增加，负数代表股权减少。</param>
        /// <param name="originalSharePrice">原始股价，即为购买股权时价格。</param>
        /// <param name="causeOfChange">股权数变动原因</param>
        /// <param name="isPrincipal">是否是自己出资购买的</param>
        /// <param name="operatorName">操作员名称。</param>
        /// <returns></returns>
        public bool Change(int shareholderNumber, decimal sharesChanges, decimal originalSharePrice, string causeOfChange, bool isPrincipal, string operatorName)
        {
            bool returnValue = false;
            DBProcedure.Reg_ShareOwnership prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Reg_ShareOwnership();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_ShareholderNumber.ParameterName, shareholderNumber);
            prdHelper.SetInputValue(prdCmdText.PARM_SharesChanges.ParameterName, sharesChanges);
            prdHelper.SetInputValue(prdCmdText.PARM_OriginalSharePrice.ParameterName, originalSharePrice);
            prdHelper.SetInputValue(prdCmdText.PARM_CauseOfChange.ParameterName, causeOfChange);
            prdHelper.SetInputValue(prdCmdText.PARM_IsPrincipal.ParameterName, isPrincipal);
            prdHelper.SetInputValue(prdCmdText.PARM_RegDate.ParameterName, System.DateTime.Now);
            prdHelper.SetInputValue(prdCmdText.PARM_Operator.ParameterName, operatorName);

            returnValue = prdHelper.ExecuteNonQuery();
            prdHelper.Dispose();
            return returnValue;
        }

        /// <summary>
        /// 以股东持有的股数为基数，按一定的派股比例给所有股东派股。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <param name="rationScale">派股比例，如100股派送8股，则派股比例填0.08。</param>
        /// <param name="sharePrice">派股的股价，也就是当期的股价。</param>
        /// <param name="operatorName">操作人员。</param>
        public void ScalRationedShares(int issueNumber, decimal rationScale, decimal sharePrice, string operatorName)
        {
            DBProcedure.ScaleRationedShares prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.ScaleRationedShares();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_IssueNumber.ParameterName, issueNumber);
            prdHelper.SetInputValue(prdCmdText.PARM_Scale.ParameterName, rationScale);
            prdHelper.SetInputValue(prdCmdText.PARM_SharePrice.ParameterName, sharePrice);
            prdHelper.SetInputValue(prdCmdText.PARM_Operator.ParameterName, operatorName);

            prdHelper.ExecuteNonQuery();
            prdHelper.Dispose();
        }

        /// <summary>
        /// 撤销股权增减操作。
        /// </summary>
        /// <param name="regId">股权增减记录号。</param>
        /// <returns></returns>
        public bool CancelChange(int regId)
        {
            bool returnValue = false;
            DBProcedure.Delete_ShareOwnership_By_RegId prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Delete_ShareOwnership_By_RegId();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_RegId.ParameterName, regId);

            returnValue = prdHelper.ExecuteNonQuery();
            prdHelper.Dispose();
            return returnValue;
        }

        /// <summary>
        /// 获取所有股东股权报告。
        /// </summary>
        /// <returns></returns>
        public DataTable GetShareOwnershipReport()
        {
            DataTable returnTable;
            DBProcedure.Select_All_ShareOwnership prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_All_ShareOwnership();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            Common.DBUtility.SqlDataReaderHelper readerHelper = new SqlDataReaderHelper(prdHelper.ExecuteReader());
            readerHelper.LoopReadToTable(out returnTable);

            prdHelper.Dispose();
            return returnTable;
        }

        /// <summary>
        /// 获取股东个人的股权增减历史记录报告。
        /// </summary>
        /// <param name="shareholderNumber">股东号。</param>
        /// <returns></returns>
        public DataTable GetPersonalShareOwnershipReport(int shareholderNumber)
        {
            DataTable returnTable;
            DBProcedure.Select_Person_Shares_Change_Record prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_Person_Shares_Change_Record();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_ShareholderNumber.ParameterName, shareholderNumber);

            Common.DBUtility.SqlDataReaderHelper readerHelper = new SqlDataReaderHelper(prdHelper.ExecuteReader());
            readerHelper.LoopReadToTable(out returnTable);

            prdHelper.Dispose();
            return returnTable;
        }

        /// <summary>
        /// 获取股权委托代理人持股统计表。
        /// </summary>
        /// <returns></returns>
        public DataTable GetShareOwnershipStatisticsReportByEntrustedAgent()
        {
            DataTable returnTable;
            DBProcedure.Report_ShareOwnership_Statistics_By_EntrustedAgent prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Report_ShareOwnership_Statistics_By_EntrustedAgent();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            Common.DBUtility.SqlDataReaderHelper readerHelper = new SqlDataReaderHelper(prdHelper.ExecuteReader());
            readerHelper.LoopReadToTable(out returnTable);

            prdHelper.Dispose();
            return returnTable;
        }

        /// <summary>
        /// 获取指定股权交易期数的股权变化报告。
        /// </summary>
        /// <param name="issueNumber">股权交易期数.</param>
        /// <returns></returns>
        public DataTable GetShareOwnershipChange(int issueNumber)
        {
            DataTable returnTable;
            DBProcedure.Select_ShareOwnership_Change_By_IssueNumber prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_ShareOwnership_Change_By_IssueNumber();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_IssueNumber.ParameterName, issueNumber);

            Common.DBUtility.SqlDataReaderHelper readerHelper = new SqlDataReaderHelper(prdHelper.ExecuteReader());
            readerHelper.LoopReadToTable(out returnTable);

            prdHelper.Dispose();
            return returnTable;
        }

        /// <summary>
        /// 获取当前股价.
        /// </summary>
        /// <returns></returns>
        public decimal GetCurrentSharePrice()
        {
            decimal sharePrice = 0M;
            DBProcedure.Select_CurrentSharePrice prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_CurrentSharePrice();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            using (SqlDataReader reader = prdHelper.ExecuteReader())
            {
                if (reader.Read())
                {
                    sharePrice = Convert.ToDecimal(reader["SharePrice"]);
                }
            }
            prdHelper.Dispose();

            return sharePrice;
        }

        /// <summary>
        /// [否决]获取某个时间段内股权退出记录。
        /// <para>由方法 GetSharesWithdrawal 替代</para>
        /// </summary>
        /// <param name="beginDate">时间段开始日期，时间段包含该日期。</param>
        /// <param name="endDate">时间段结束日期，时间段包含该日期。</param>
        /// <returns></returns>
        public DataTable GetShareOwnershipWithdrawal(DateTime beginDate, DateTime endDate)
        {
            DataTable returnTable;
            DBProcedure.Select_ShareOwnership_Withdrawal_Record prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_ShareOwnership_Withdrawal_Record();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_BeginDate.ParameterName, beginDate);
            prdHelper.SetInputValue(prdCmdText.PARM_EndDate.ParameterName, endDate);

            Common.DBUtility.SqlDataReaderHelper readerHelper = new SqlDataReaderHelper(prdHelper.ExecuteReader());
            readerHelper.LoopReadToTable(out returnTable);

            prdHelper.Dispose();
            return returnTable;
        }

        /// <summary>
        /// 获取某指定股权交易期的股权清退报告。
        /// </summary>
        /// <param name="issueNumber">股权交易期。</param>
        /// <returns></returns>
        public DataTable GetSharesWithdrawal(int issueNumber)
        {
            DataTable returnTable;
            DBProcedure.Select_Shares_Withdrawal_Report prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_Shares_Withdrawal_Report();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_IssueNumber.ParameterName, issueNumber);

            Common.DBUtility.SqlDataReaderHelper readerHelper = new SqlDataReaderHelper(prdHelper.ExecuteReader());
            readerHelper.LoopReadToTable(out returnTable);

            prdHelper.Dispose();
            return returnTable;
        }

        /// <summary>
        /// 获取个人股权退出清算报告。
        /// </summary>
        /// <param name="regId">股权退出记录号。</param>
        /// <returns>返回数据表类型。</returns>
        public DataTable GetPersonWithdrawalReportTable(int regId)
        {
            DataTable returnTable;
            DBProcedure.Select_Person_Shares_Withdrawal_Report prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_Person_Shares_Withdrawal_Report();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_RegId.ParameterName, regId);

            Common.DBUtility.SqlDataReaderHelper readerHelper = new SqlDataReaderHelper(prdHelper.ExecuteReader());
            readerHelper.LoopReadToTable(out returnTable);

            prdHelper.Dispose();
            return returnTable;
        }

        /// <summary>
        /// 获取个人股权退出清算报告。
        /// </summary>
        /// <param name="regId">股权退出记录号。</param>
        /// <returns>返回 SharesWithDrawalReport 类。</returns>
        public ShareOS.Model.SharesWithdrawalReport GetPersonWithdrawalReport(int regId)
        {
            ShareOS.Model.SharesWithdrawalReport report = new ShareOS.Model.SharesWithdrawalReport();

            DBProcedure.Select_Person_Shares_Withdrawal_Report prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_Person_Shares_Withdrawal_Report();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_RegId.ParameterName, regId);

            using (SqlDataReader reader = prdHelper.ExecuteReader())
            {
                if (reader.Read())
                {
                    report.WithdrawalDate = Convert.ToDateTime(reader["WithdrawalDate"]);
                    report.WithdrawalSharesAmount = Convert.ToInt32(reader["WithdrawalShareAmount"]);
                    report.CurrentSharePrice = Convert.ToDecimal(reader["CurrentSharePrice"]);
                    report.WithdrawalSharesCurrentValue = Convert.ToDecimal(reader["WithdrawalSharesCurrentValue"]);
                    report.WithdrawalSharesOriginalValue = Convert.ToDecimal(reader["WithdrawalSharesOriginalValue"]);
                }
            }
            prdHelper.Dispose();

            return report;
        }

        /// <summary>
        /// 获取股东当前持股总数。
        /// [否决]由类ShareOwnershipDA中的同名方法替代。
        /// </summary>
        /// <param name="shareholderNumber">股东号。</param>
        /// <returns></returns>
        public decimal GetPersonalShareTotals(int shareholderNumber)
        {
            decimal shareTotals = 0;

            DBProcedure.Select_Person_ShareTotals prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_Person_ShareTotals();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_ShareholderNumber.ParameterName, shareholderNumber);

            using (SqlDataReader reader = prdHelper.ExecuteReader())
            {
                if (reader.Read())
                {
                    shareTotals = Convert.ToDecimal(reader["ShareTotals"]);
                }
            }
            prdHelper.Dispose();

            return shareTotals;
        }

        /// <summary>
        /// 获取全体股权总数。
        /// </summary>
        /// <returns></returns>
        public int GetCorporateShareTotals()
        {
            int shareTotals = 0;

            DBProcedure.Select_Corporate_ShareTotals prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_Corporate_ShareTotals();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);

            using (SqlDataReader reader = prdHelper.ExecuteReader())
            {
                if (reader.Read())
                {
                    shareTotals = Convert.ToInt32(reader["CorporateShareTotals"]);
                }
            }
            prdHelper.Dispose();

            return shareTotals;
        }


        /// <summary>
        /// 股权受让申请。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <param name="shareholderNumber">股东号。</param>
        /// <param name="sharesAmount">申请受让股权数量。</param>
        /// <param name="dateForApply">申请日期。</param>
        /// <returns></returns>
        public bool ApplyFor(int issueNumber, int shareholderNumber, int sharesAmount)
        {
            bool returnValue = false;
            DBProcedure.Insert_ShareOwnershipApply prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Insert_ShareOwnershipApply();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_IssueNumber.ParameterName, issueNumber);
            prdHelper.SetInputValue(prdCmdText.PARM_ShareholderNumber.ParameterName, shareholderNumber);
            prdHelper.SetInputValue(prdCmdText.PARM_SharesAmount.ParameterName, sharesAmount);
            prdHelper.SetInputValue(prdCmdText.PARM_DateOfApply.ParameterName, System.DateTime.Now);

            returnValue = prdHelper.ExecuteNonQuery();
            prdHelper.Dispose();
            return returnValue;
        }

        /// <summary>
        /// 撤销股权受让申请。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <param name="shareholderNumber">股东号。</param>
        /// <returns></returns>
        public bool CancelApplyFor(int issueNumber, int shareholderNumber)
        {
            bool returnValue = false;
            DBProcedure.Delete_ShareOwnershipApply prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Delete_ShareOwnershipApply();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_IssueNumber.ParameterName, issueNumber);
            prdHelper.SetInputValue(prdCmdText.PARM_ShareholderNumber.ParameterName, shareholderNumber);

            returnValue = prdHelper.ExecuteNonQuery();
            prdHelper.Dispose();
            return returnValue;
        }


        /// <summary>
        /// 获取股权申请受让报告。
        /// </summary>
        /// <param name="issueNumber">指定股权交易期数。</param>
        /// <returns></returns>
        public DataTable GetShareOwnershipApplyReport(int issueNumber)
        {
            DataTable returnTable;
            DBProcedure.Select_ShareOwnershipApply_By_IssueNumber prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_ShareOwnershipApply_By_IssueNumber();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_IssueNumber.ParameterName, issueNumber);

            Common.DBUtility.SqlDataReaderHelper readerHelper = new SqlDataReaderHelper(prdHelper.ExecuteReader());
            readerHelper.LoopReadToTable(out returnTable);

            prdHelper.Dispose();
            return returnTable;
        }

        /// <summary>
        /// 更新股权申请受让数额。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <param name="shareholderNumber">股东号。</param>
        /// <param name="sharesAmount">申请受让股权数量。</param>
        /// <param name="dateForApply">申请日期。</param>
        /// <returns></returns>
        public bool UpdateSharesAmountApplyFor(int issueNumber, int shareholderNumber, int sharesAmount)
        {
            bool returnValue = false;
            DBProcedure.Update_ShareOwnershipApply prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Update_ShareOwnershipApply();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_IssueNumber.ParameterName, issueNumber);
            prdHelper.SetInputValue(prdCmdText.PARM_ShareholderNumber.ParameterName, shareholderNumber);
            prdHelper.SetInputValue(prdCmdText.PARM_SharesAmount.ParameterName, sharesAmount);
            prdHelper.SetInputValue(prdCmdText.PARM_DateOfApply.ParameterName, System.DateTime.Now);

            returnValue = prdHelper.ExecuteNonQuery();
            prdHelper.Dispose();
            return returnValue;
        }

        #endregion
    }
}
