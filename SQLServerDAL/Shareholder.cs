using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using ShareOS.Model;
using ShareOS.IDAL;
using ShareOS.SQLServerDAL.DS;
using Common.DBUtility;

namespace ShareOS.SQLServerDAL
{
    public class Shareholder : IShareholderRegister, IShareholder
    {
        protected Model.Shareholder Parse(SqlDataReader Reader)
        {
            DBTable.Shareholder table = new ShareOS.SQLServerDAL.DBTable.Shareholder();

            Model.Shareholder mShareholder = new Model.Shareholder();
            mShareholder.ShareholderId = Convert.ToInt32(Reader[table.ShareholderId.Text]);
            mShareholder.ShareholderNumber = Convert.ToInt32(Reader[table.ShareholderNumber.Text]);
            mShareholder.JobNumber = Reader[table.JobNumber.Text].ToString().Trim();
            mShareholder.ShareholderName = Reader[table.ShareholderName.Text].ToString().Trim();
            mShareholder.Sex = Convert.ToBoolean(Reader[table.Sex.Text]);
            mShareholder.IdentityCard = Reader[table.IdentityCard.Text].ToString().Trim();
            mShareholder.PersonType = Reader[table.PersonType.Text].ToString().Trim();
            string status = Reader[table.Status.Text].ToString().Trim();
            switch (status)
            {
                case "�ɶ�": mShareholder.Status = ShareholderStatus.�ɶ�;
                    break;
                case "�˳���Ա": mShareholder.Status = ShareholderStatus.�˳���Ա;
                    break;
                default: mShareholder.Status = ShareholderStatus.�ǹɶ�;
                    break;
            }
            mShareholder.EntrustedAgent = Convert.ToInt32(Reader[table.EntrustedAgent.Text]);
            return mShareholder;
        }

        #region IShareholderRegister ��Ա

        /// <summary>
        /// �����ɶ�.
        /// </summary>
        /// <param name="shareholder">�ɶ�.</param>
        /// <returns></returns>
        public bool InsertShareholder(ShareOS.Model.Shareholder shareholder)
        {
            bool returnValue = false;
            DBProcedure.Insert_Shareholder prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Insert_Shareholder();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_ShareholderNumber.ParameterName, shareholder.ShareholderNumber);
            prdHelper.SetInputValue(prdCmdText.PARM_JobNumber.ParameterName, shareholder.JobNumber);
            prdHelper.SetInputValue(prdCmdText.PARM_ShareholderName.ParameterName, shareholder.ShareholderName);
            prdHelper.SetInputValue(prdCmdText.PARM_Sex.ParameterName, shareholder.Sex ? 1 : 0);
            prdHelper.SetInputValue(prdCmdText.PARM_IdentityCard.ParameterName, shareholder.IdentityCard);
            prdHelper.SetInputValue(prdCmdText.PARM_PersonType.ParameterName, shareholder.PersonType);
            prdHelper.SetInputValue(prdCmdText.PARM_Status.ParameterName, shareholder.Status.ToString());
            prdHelper.SetInputValue(prdCmdText.PARM_EntrustedAgent.ParameterName, 0);

            returnValue = prdHelper.ExecuteNonQuery();
            prdHelper.Dispose();
            return returnValue;
        }

        public ShareOS.Model.Shareholder SelectShareholder(int shareholderNumber)
        {
            ShareOS.Model.Shareholder shareholder = new Model.Shareholder();
            DBProcedure.Select_Shareholder_One prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_Shareholder_One();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_ShareholderNumber.ParameterName, shareholderNumber);
            using (SqlDataReader reader = prdHelper.ExecuteReader())
            {
                if (reader.Read())
                {
                    shareholder = Parse(reader);
                }
            }
            prdHelper.Dispose();

            return shareholder;
        }

        /// <summary>
        /// ��ȡ�����ɶ���Ϣ��
        /// </summary>
        /// <param name="jobNumber">���š�</param>
        /// <returns></returns>
        public ShareOS.Model.Shareholder SelectShareholder(string jobNumber)
        {
            ShareOS.Model.Shareholder shareholder = new Model.Shareholder();
            DBProcedure.Select_Shareholder_By_JobNumber prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_Shareholder_By_JobNumber();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_JobNumber.ParameterName, jobNumber);
            using (SqlDataReader reader = prdHelper.ExecuteReader())
            {
                if (reader.Read())
                {
                    shareholder = Parse(reader);
                }
            }
            prdHelper.Dispose();

            return shareholder;
        }

        /// <summary>
        /// ��ȡ���йɶ��б�.
        /// </summary>
        /// <returns></returns>
        public IList<ShareOS.Model.Shareholder> SelectShareholder()
        {
            IList<ShareOS.Model.Shareholder> shareholders = new List<Model.Shareholder>();
            DBProcedure.Select_Shareholder_All prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_Shareholder_All();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            using (SqlDataReader reader = prdHelper.ExecuteReader())
            {
                while (reader.Read())
                {
                    ShareOS.Model.Shareholder shareholder = Parse(reader);
                    shareholders.Add(shareholder);
                }
            }
            prdHelper.Dispose();

            return shareholders;
        }

        /// <summary>
        /// ��ȡ���йɶ��б�.
        /// </summary>
        /// <returns>���عɶ��б�Table</returns>
        public DataTable SelectShareholderTable()
        {
            DataTable shareholders = new DataTable("Shareholders");

            DBProcedure.Select_Shareholder_All prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_Shareholder_All();
            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.ExecuteAdapter().Fill(shareholders);
            prdHelper.Dispose();

            return shareholders;
        }

        /// <summary>
        /// ��ȡ����û�й�Ȩ���ˡ�
        /// </summary>
        /// <returns></returns>
        public DataTable SelectShareholdersHaveNoShare()
        {
            DataTable shareholders = new DataTable("Shareholders");

            DBProcedure.Select_Person_Have_No_Share prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_Person_Have_No_Share();
            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.ExecuteAdapter().Fill(shareholders);
            prdHelper.Dispose();

            return shareholders;
        }

        /// <summary>
        /// ��ȡĳί�д��������¹��������йɶ��б���
        /// </summary>
        /// <param name="entrustedAgent">ί�д����ˡ�</param>
        /// <returns></returns>
        public IList<ShareOS.Model.Shareholder> SelectShareholder(ShareOS.Model.EntrustedAgent entrustedAgent)
        {
            IList<ShareOS.Model.Shareholder> shareholders = new List<Model.Shareholder>();
            DBProcedure.Select_Shareholder_By_EntrustedAgent prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_Shareholder_By_EntrustedAgent();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_EntrustedAgent.ParameterName, entrustedAgent.ShareholderNumber);
            using (SqlDataReader reader = prdHelper.ExecuteReader())
            {
                while (reader.Read())
                {
                    ShareOS.Model.Shareholder shareholder = Parse(reader);
                    shareholders.Add(shareholder);
                }
            }
            prdHelper.Dispose();

            return shareholders;
        }

        public bool UpdateShareholder(ShareOS.Model.Shareholder shareholder)
        {
            bool returnValue = false;
            DBProcedure.Update_Shareholder prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Update_Shareholder();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_ShareholderId.ParameterName, shareholder.ShareholderId);
            prdHelper.SetInputValue(prdCmdText.PARM_ShareholderNumber.ParameterName, shareholder.ShareholderNumber);
            prdHelper.SetInputValue(prdCmdText.PARM_JobNumber.ParameterName, shareholder.JobNumber);
            prdHelper.SetInputValue(prdCmdText.PARM_ShareholderName.ParameterName, shareholder.ShareholderName);
            prdHelper.SetInputValue(prdCmdText.PARM_Sex.ParameterName, shareholder.Sex ? 1 : 0);
            prdHelper.SetInputValue(prdCmdText.PARM_IdentityCard.ParameterName, shareholder.IdentityCard);
            prdHelper.SetInputValue(prdCmdText.PARM_PersonType.ParameterName, shareholder.PersonType);

            returnValue = prdHelper.ExecuteNonQuery();
            prdHelper.Dispose();
            return returnValue;
        }

        /// <summary>
        /// ���¹ɶ���������ͼƬ��
        /// </summary>
        /// <param name="shareholderNumber">�ɶ��š�</param>
        /// <returns></returns>
        public bool UpdateBarCode(int shareholderNumber, byte[] barCode)
        {
            //bool returnValue = false;
            int returnint = 0;
            DBProcedure.Update_Shareholder_BarCode prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Update_Shareholder_BarCode();

            //SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            //prdHelper.SetInputValue(prdCmdText.PARM_ShareholderNumber.ParameterName, shareholderNumber);
            //prdHelper.SetInputValue(prdCmdText.PARM_BarCode.ParameterName, barCode);


            //returnValue = prdHelper.ExecuteNonQuery();
            //if (prdHelper.LastError != string.Empty)
            //{
            //    throw new Exception(prdHelper.LastError);
            //}
            //prdHelper.Dispose();

            SqlParameter parm_shareholderNumber = new SqlParameter(prdCmdText.PARM_ShareholderNumber.ParameterName, SqlDbType.Int, 4);
            SqlParameter parm_barcode = new SqlParameter(prdCmdText.PARM_BarCode.ParameterName, SqlDbType.Image, barCode.GetLength(0));
            parm_shareholderNumber.Value = shareholderNumber;
            parm_barcode.Value = barCode;
            SqlParameter[] parms = new SqlParameter[2];
            parms.SetValue(parm_shareholderNumber, 0);
            parms.SetValue(parm_barcode, 1);
            try
            {
                returnint = SqlHelper.ExecuteNonQuery(ConnectionString.ConnectionStringShares, CommandType.StoredProcedure, prdCmdText.Text, parms);
            }
            catch (Exception ec)
            {
                throw ec;
            }
            return returnint > 0 ? true : false;
        }

        public bool DeleteShareholder(int shareholderId)
        {
            bool returnValue = false;
            DBProcedure.Delete_Shareholder prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Delete_Shareholder();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_ShareholderId.ParameterName, shareholderId);

            returnValue = prdHelper.ExecuteNonQuery();
            prdHelper.Dispose();
            return returnValue;
        }

        /// <summary>
        /// �Ƿ���ڹɶ���
        /// </summary>
        /// <param name="shareholderNumber">�ɶ��š�</param>
        /// <returns></returns>
        public bool ExistShareholder(int shareholderNumber)
        {
            bool exist = false;
            DBProcedure.Select_Shareholder_One prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_Shareholder_One();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_ShareholderNumber.ParameterName, shareholderNumber);
            using (SqlDataReader reader = prdHelper.ExecuteReader())
            {
                if (reader.Read())
                {
                    exist = true;
                }
            }
            prdHelper.Dispose();

            return exist;
        }

        /// <summary>
        /// �Ƿ���ڹɶ���
        /// </summary>
        /// <param name="shareholderNumber">���š�</param>
        /// <returns></returns>
        public bool ExistShareholder(string jobNumber)
        {
            bool exist = false;
            DBProcedure.Select_Shareholder_By_JobNumber prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_Shareholder_By_JobNumber();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_JobNumber.ParameterName, jobNumber);
            using (SqlDataReader reader = prdHelper.ExecuteReader())
            {
                if (reader.Read())
                {
                    exist = true;
                }
            }
            prdHelper.Dispose();

            return exist;
        }

        #endregion

        #region IShareholder ��Ա
        /// <summary>
        /// ���ùɶ���״̬
        /// <para>�ɶ�״̬�У��ɶ�,�ǹɶ�,�˳���Ա</para>
        /// </summary>
        /// <param name="shareholderId">�ɶ���</param>
        /// <param name="status">�ɶ�״̬�У��ɶ�,�ǹɶ�,�˳���Ա</param>
        public void SetStatus(int shareholderId, ShareholderStatus status)
        {
            DBProcedure.Update_Shareholder_Status prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Update_Shareholder_Status();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_ShareholderId.ParameterName, shareholderId);
            prdHelper.SetInputValue(prdCmdText.PARM_Status.ParameterName, status);

            prdHelper.ExecuteNonQuery();
            prdHelper.Dispose();
        }
        #endregion


    }
}