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
        #region IShareOwnership ��Ա

        /// <summary>
        /// ��Ȩ������
        /// </summary>
        /// <param name="shareholderNumber">�ɶ��š�</param>
        /// <param name="sharesChanges">��Ȩ�ı���������������Ȩ���ӣ�����������Ȩ���١�</param>
        /// <param name="originalSharePrice">ԭʼ�ɼۣ���Ϊ�����Ȩʱ�۸�</param>
        /// <param name="causeOfChange">��Ȩ���䶯ԭ��</param>
        /// <param name="isPrincipal">�Ƿ����Լ����ʹ����</param>
        /// <param name="operatorName">����Ա���ơ�</param>
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
        /// �Թɶ����еĹ���Ϊ��������һ�����ɹɱ��������йɶ��ɹɡ�
        /// </summary>
        /// <param name="issueNumber">��Ȩ����������</param>
        /// <param name="rationScale">�ɹɱ�������100������8�ɣ����ɹɱ�����0.08��</param>
        /// <param name="sharePrice">�ɹɵĹɼۣ�Ҳ���ǵ��ڵĹɼۡ�</param>
        /// <param name="operatorName">������Ա��</param>
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
        /// ������Ȩ����������
        /// </summary>
        /// <param name="regId">��Ȩ������¼�š�</param>
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
        /// ��ȡ���йɶ���Ȩ���档
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
        /// ��ȡ�ɶ����˵Ĺ�Ȩ������ʷ��¼���档
        /// </summary>
        /// <param name="shareholderNumber">�ɶ��š�</param>
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
        /// ��ȡ��Ȩί�д����˳ֹ�ͳ�Ʊ���
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
        /// ��ȡָ����Ȩ���������Ĺ�Ȩ�仯���档
        /// </summary>
        /// <param name="issueNumber">��Ȩ��������.</param>
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
        /// ��ȡ��ǰ�ɼ�.
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
        /// [���]��ȡĳ��ʱ����ڹ�Ȩ�˳���¼��
        /// <para>�ɷ��� GetSharesWithdrawal ���</para>
        /// </summary>
        /// <param name="beginDate">ʱ��ο�ʼ���ڣ�ʱ��ΰ��������ڡ�</param>
        /// <param name="endDate">ʱ��ν������ڣ�ʱ��ΰ��������ڡ�</param>
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
        /// ��ȡĳָ����Ȩ�����ڵĹ�Ȩ���˱��档
        /// </summary>
        /// <param name="issueNumber">��Ȩ�����ڡ�</param>
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
        /// ��ȡ���˹�Ȩ�˳����㱨�档
        /// </summary>
        /// <param name="regId">��Ȩ�˳���¼�š�</param>
        /// <returns>�������ݱ����͡�</returns>
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
        /// ��ȡ���˹�Ȩ�˳����㱨�档
        /// </summary>
        /// <param name="regId">��Ȩ�˳���¼�š�</param>
        /// <returns>���� SharesWithDrawalReport �ࡣ</returns>
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
        /// ��ȡ�ɶ���ǰ�ֹ�������
        /// [���]����ShareOwnershipDA�е�ͬ�����������
        /// </summary>
        /// <param name="shareholderNumber">�ɶ��š�</param>
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
        /// ��ȡȫ���Ȩ������
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
        /// ��Ȩ�������롣
        /// </summary>
        /// <param name="issueNumber">��Ȩ����������</param>
        /// <param name="shareholderNumber">�ɶ��š�</param>
        /// <param name="sharesAmount">�������ù�Ȩ������</param>
        /// <param name="dateForApply">�������ڡ�</param>
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
        /// ������Ȩ�������롣
        /// </summary>
        /// <param name="issueNumber">��Ȩ����������</param>
        /// <param name="shareholderNumber">�ɶ��š�</param>
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
        /// ��ȡ��Ȩ�������ñ��档
        /// </summary>
        /// <param name="issueNumber">ָ����Ȩ����������</param>
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
        /// ���¹�Ȩ�����������
        /// </summary>
        /// <param name="issueNumber">��Ȩ����������</param>
        /// <param name="shareholderNumber">�ɶ��š�</param>
        /// <param name="sharesAmount">�������ù�Ȩ������</param>
        /// <param name="dateForApply">�������ڡ�</param>
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