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
    public class SharesBonus : ISharesBonus
    {
        protected Model.SharesIssueConfig Parse(SqlDataReader Reader)
        {
            DBTable.SharesIssueConfig table = new ShareOS.SQLServerDAL.DBTable.SharesIssueConfig();

            Model.SharesIssueConfig mSharesIssueConfig = new Model.SharesIssueConfig();
            mSharesIssueConfig.SICId = Convert.ToInt32(Reader[table.SICId.Text]);
            mSharesIssueConfig.IssueNumber = Convert.ToInt32(Reader[table.IssueNumber.Text]);
            mSharesIssueConfig.IssueYear = Convert.ToInt32(Reader[table.IssueYear.Text]);
            mSharesIssueConfig.Bonus = Convert.ToDecimal(Reader[table.Bonus.Text]);
            mSharesIssueConfig.DPD = Convert.ToDateTime(Reader[table.DPD.Text]);
            mSharesIssueConfig.SharePrice = Convert.ToDecimal(Reader[table.SharePrice.Text]);
            mSharesIssueConfig.IsDistributed = Convert.ToBoolean(Reader[table.IsDistributed.Text]);

            return mSharesIssueConfig;
        }

        #region ISharesBonus ��Ա

        /// <summary>
        /// �����Ȩ�����������á�
        /// </summary>
        /// <param name="issueNumber">����.</param>
        /// <param name="bonus">�����������ÿ10�ɷ�������ң�x Ԫ/10�ɡ�</param>
        /// <param name="sharePrice">���������ÿ�ɹɼۡ�y Ԫ/�ɡ�</param>
        /// <param name="DPD">�����ɷ����ڡ�</param>
        /// <returns></returns>
        public bool InsertSharesIssueConfig(int issueNumber, decimal bonus, decimal sharePrice, DateTime DPD)
        {
            bool returnValue = false;
            DBProcedure.Insert_SharesIssueConfig prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Insert_SharesIssueConfig();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_IssueNumber.ParameterName, issueNumber);
            prdHelper.SetInputValue(prdCmdText.PARM_IssueYear.ParameterName, DPD.Year);
            prdHelper.SetInputValue(prdCmdText.PARM_Bonus.ParameterName, bonus);
            prdHelper.SetInputValue(prdCmdText.PARM_DPD.ParameterName, DPD);
            prdHelper.SetInputValue(prdCmdText.PARM_SharePrice.ParameterName, sharePrice);

            returnValue = prdHelper.ExecuteNonQuery();
            prdHelper.Dispose();
            return returnValue;
        }

        

        /// <summary>
        /// ɾ����Ȩ�����������á�
        /// </summary>
        /// <param name="issueNumber">��Ȩ��������</param>
        /// <returns></returns>
        public bool DeleteSharesIssueConfig(int issueNumber)
        {
            bool returnValue = false;
            DBProcedure.Delete_SharesIssueConfig prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Delete_SharesIssueConfig();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_IssueNumber.ParameterName, issueNumber);

            returnValue = prdHelper.ExecuteNonQuery();
            prdHelper.Dispose();
            return returnValue;
        }

        

        /// <summary>
        /// ��ѯָ����Ȩ�����ڵ�������Ϣ��
        /// [���]��ShareIssueConfigDA�е�ͬ�����������
        /// </summary>
        /// <param name="issueNumber"></param>
        /// <returns></returns>
        public Model.SharesIssueConfig SelectConfig(int issueNumber)
        {
            ShareOS.Model.SharesIssueConfig config = new ShareOS.Model.SharesIssueConfig();
            DBProcedure.Select_ShareIssueConfig_One prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_ShareIssueConfig_One();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_IssueNumber.ParameterName, issueNumber);
            using (SqlDataReader reader = prdHelper.ExecuteReader())
            {
                if (reader.Read())
                {
                    config = Parse(reader);
                }
            }
            prdHelper.Dispose();

            return config;
        }

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="issueNumber">��Ȩ��������</param>
        /// <returns></returns>
        public bool PayBonus(int issueNumber)
        {
            bool returnValue = false;
            DBProcedure.Insert_BonusRecord prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Insert_BonusRecord();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_IssueNumber.ParameterName, issueNumber);

            prdHelper.ExecuteNonQuery();

            returnValue = Convert.ToBoolean(prdHelper.ReturnValue);
            prdHelper.Dispose();
            return returnValue;
        }

        /// <summary>
        /// ��ȡ��Ȩ�����������һ�ڵ�ֵ��
        /// </summary>
        /// <returns></returns>
        public int GetLastIssueNumber()
        {
            int returnValue = 0;
            DBProcedure.Select_SharesLastIssueNumber prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_SharesLastIssueNumber();
            
            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);

            prdHelper.ExecuteNonQuery();

            returnValue = Convert.ToInt32(prdHelper.ReturnValue);
            prdHelper.Dispose();
            return returnValue;
        }

        /// <summary>
        /// ��ȡĳһ��Ȩ���������йɶ��ķֺ��¼��
        /// </summary>
        /// <param name="issueNumber">��Ȩ�����ڡ�</param>
        /// <returns></returns>
        public DataTable SelectBonusRecord(int issueNumber)
        {
            DataTable bonusRecord = new DataTable();
            DBProcedure.Select_Bonus_List_By_Issue prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_Bonus_List_By_Issue();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_IssueNumber.ParameterName, issueNumber);

            using (SqlDataReader reader = prdHelper.ExecuteReader())
            {
                Common.DBUtility.SqlDataReaderHelper readerHelper = new SqlDataReaderHelper(reader);
                readerHelper.LoopReadToTable(out bonusRecord);
            }
            prdHelper.Dispose();

            return bonusRecord;
        }

        /// <summary>
        /// ��ȡĳ�ɶ�����ֺ��¼��
        /// </summary>
        /// <param name="shareholder">�ɶ���</param>
        /// <returns></returns>
        public DataTable SelectBonusRecord(ShareOS.Model.Shareholder shareholder)
        {
            DataTable bonusRecord = new DataTable();
            DBProcedure.Select_Person_Bonus_Record prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_Person_Bonus_Record();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_ShareholderNumber.ParameterName, shareholder.ShareholderNumber);

            using (SqlDataReader reader = prdHelper.ExecuteReader())
            {
                Common.DBUtility.SqlDataReaderHelper readerHelper = new SqlDataReaderHelper(reader);
                readerHelper.LoopReadToTable(out bonusRecord);
            }
            prdHelper.Dispose();

            return bonusRecord;
        }

        #endregion
    }
}