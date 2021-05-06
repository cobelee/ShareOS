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
    public class ShareholderDAO : IShareholderRegister, IShareholder
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
                case "股东": mShareholder.Status = ShareholderStatus.股东;
                    break;
                case "退出人员": mShareholder.Status = ShareholderStatus.退出人员;
                    break;
                default: mShareholder.Status = ShareholderStatus.非股东;
                    break;
            }
            mShareholder.EntrustedAgent = Convert.ToInt32(Reader[table.EntrustedAgent.Text]);
            return mShareholder;
        }

        #region IShareholderRegister 成员

        /// <summary>
        /// 新增股东.
        /// </summary>
        /// <param name="shareholder">股东.</param>
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
        /// 获取单个股东信息。
        /// </summary>
        /// <param name="jobNumber">工号。</param>
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
        /// 获取所有股东列表.
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
        /// 获取所有股东列表.
        /// </summary>
        /// <returns>返回股东列表Table</returns>
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
        /// 获取所有没有股权的人。
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
        /// 获取某委托代理人名下管理的所有股东列表。
        /// </summary>
        /// <param name="entrustedAgent">委托代理人。</param>
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
        /// 更新股东号条形码图片。
        /// </summary>
        /// <param name="shareholderNumber">股东号。</param>
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
        /// 是否存在股东。
        /// </summary>
        /// <param name="shareholderNumber">股东号。</param>
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
        /// 是否存在股东。
        /// </summary>
        /// <param name="shareholderNumber">工号。</param>
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

        #region IShareholder 成员
        /// <summary>
        /// 设置股东的状态
        /// <para>股东状态有：股东,非股东,退出人员</para>
        /// </summary>
        /// <param name="shareholderId">股东号</param>
        /// <param name="status">股东状态有：股东,非股东,退出人员</param>
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
