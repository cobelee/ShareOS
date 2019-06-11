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
    public class EntrustedAgent : IEntrustedAgent
    {
        protected Model.EntrustedAgent Parse(SqlDataReader Reader)
        {
            DBTable.Shareholder table = new ShareOS.SQLServerDAL.DBTable.Shareholder();

            Model.EntrustedAgent mShareholder = new Model.EntrustedAgent();
            mShareholder.ShareholderId = Convert.ToInt32(Reader[table.ShareholderId.Text]);
            mShareholder.ShareholderNumber = Convert.ToInt32(Reader[table.ShareholderNumber.Text]);
            mShareholder.JobNumber = Reader[table.JobNumber.Text].ToString().Trim();
            mShareholder.ShareholderName = Reader[table.ShareholderName.Text].ToString().Trim();
            mShareholder.Sex = Convert.ToBoolean(Reader[table.Sex.Text]);
            mShareholder.IdentityCard = Reader[table.IdentityCard.Text].ToString().Trim();
            mShareholder.PersonType = Reader[table.PersonType.Text].ToString().Trim();
            mShareholder.Status = Reader[table.Status.Text].ToString().Trim() == ShareholderStatus.股东.ToString() ? ShareholderStatus.股东 : ShareholderStatus.非股东;
            mShareholder.EntrustedAgent = Convert.ToInt32(Reader[table.EntrustedAgent.Text]);
            return mShareholder;
        }

        #region IEntrustedAgent 成员

        /// <summary>
        /// 新增委托代理人（股东代表）.
        /// </summary>
        /// <param name="shareholder">委托代理人（股东代表）.</param>
        /// <returns></returns>
        public bool Insert(ShareOS.Model.EntrustedAgent entrustedAgent)
        {
            bool returnValue = false;
            DBProcedure.Insert_EntrustedAgent prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Insert_EntrustedAgent();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_ShareholderNumber.ParameterName, entrustedAgent.ShareholderNumber);

            returnValue = prdHelper.ExecuteNonQuery();
            prdHelper.Dispose();
            return returnValue;
        }

        /// <summary>
        /// 新增委托代理人（股东代表）.
        /// </summary>
        /// <param name="agentShn">委托代理人（股东代表）的股东号.</param>
        /// <returns></returns>
        public bool Create(int agentShn)
        {
            bool returnValue = false;
            DBProcedure.Insert_EntrustedAgent prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Insert_EntrustedAgent();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_ShareholderNumber.ParameterName, agentShn);

            returnValue = prdHelper.ExecuteNonQuery();
            prdHelper.Dispose();
            return returnValue;
        }

        /// <summary>
        /// 获取所有委托代理人（股东代表）列表.
        /// </summary>
        /// <returns></returns>
        public IList<ShareOS.Model.EntrustedAgent> Select()
        {
            IList<ShareOS.Model.EntrustedAgent> shareholders = new List<Model.EntrustedAgent>();
            DBProcedure.Select_EntrustedAgent_All prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_EntrustedAgent_All();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            using (SqlDataReader reader = prdHelper.ExecuteReader())
            {
                while (reader.Read())
                {
                    ShareOS.Model.EntrustedAgent shareholder = Parse(reader);
                    shareholders.Add(shareholder);
                }
            }
            prdHelper.Dispose();

            return shareholders;
        }

        /// <summary>
        /// 删除委托代理人（股东代表）。
        /// </summary>
        /// <param name="shareholderNumber">股东号.</param>
        /// <returns></returns>
        public bool Delete(int shareholderNumber)
        {
            bool returnValue = false;
            DBProcedure.Delete_EntrustedAgent prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Delete_EntrustedAgent();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_ShareholderNumber.ParameterName, shareholderNumber);

            returnValue = prdHelper.ExecuteNonQuery();
            prdHelper.Dispose();
            return returnValue;
        }

        /// <summary>
        /// 设置某股东设置股权管理代理人。
        /// </summary>
        /// <param name="shareholderId">股东代号，非股东号。</param>
        /// <param name="entrustedAgent">委托代理人。</param>
        public void ActFor(int shareholderId, ShareOS.Model.EntrustedAgent entrustedAgent)
        {
            DBProcedure.Update_Shareholder_AgentRelation prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Update_Shareholder_AgentRelation();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_ShareholderId.ParameterName, shareholderId);
            prdHelper.SetInputValue(prdCmdText.PARM_EntrustedAgent.ParameterName, entrustedAgent.ShareholderNumber);

            prdHelper.ExecuteNonQuery();
            prdHelper.Dispose();
        }

        /// <summary>
        /// 是否存在委托代理人。
        /// </summary>
        /// <param name="shareholderNumber">委托代理人的股东号。</param>
        /// <returns></returns>
        public bool Exist(int shareholderNumber)
        {
            bool IsExist = false;
            DBProcedure.Select_EntrustedAgent_One prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_EntrustedAgent_One();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_EntrustedAgentNumber.ParameterName, shareholderNumber);
            using (SqlDataReader reader = prdHelper.ExecuteReader())
            {
                if (reader.Read())
                {
                    IsExist = true;
                }
            }
            prdHelper.Dispose();

            return IsExist;
        }

        /// <summary>
        /// 为股权代理人分配助理。
        /// </summary>
        /// <param name="agentShareholderNumber">股权代理人股东号。</param>
        /// <param name="assistantJobNumber">助理工号。</param>
        public void SetAssistant(int agentShareholderNumber, string assistantJobNumber)
        {
            DBProcedure.Set_Agent_Assistant prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Set_Agent_Assistant();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_AgentShareholderNumber.ParameterName, agentShareholderNumber);
            prdHelper.SetInputValue(prdCmdText.PARM_AssistantJobNumber.ParameterName, assistantJobNumber);

            prdHelper.ExecuteNonQuery();
            prdHelper.Dispose();
        }

        /// <summary>
        /// 获取股东代理人的助理。
        /// </summary>
        /// <param name="agentShareholderNumber">股权代理人股东号.</param>
        /// <returns></returns>
        public DataTable SelectAssistant(int agentShareholderNumber)
        {
            DataTable assist = new DataTable("AgentAssistant");
            DBProcedure.Select_Agent_Assistant prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_Agent_Assistant();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_AgentShareholderNumber.ParameterName, agentShareholderNumber);

            prdHelper.ExecuteAdapter().Fill(assist);
            prdHelper.Dispose();
            return assist;
        }

        /// <summary>
        /// 删除股权代理人的助理。
        /// </summary>
        /// <param name="agentShareholderNumber">股权代理人股东号。</param>
        /// <param name="assistantJobNumber">助理工号。</param>
        public bool DeleteAssistant(int agentShareholderNumber, string assistantJobNumber)
        {
            bool returnValue = false;
            DBProcedure.Delete_Agent_Assistant prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Delete_Agent_Assistant();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_AgentShareholderNumber.ParameterName, agentShareholderNumber);
            prdHelper.SetInputValue(prdCmdText.PARM_AssistantJobNumber.ParameterName, assistantJobNumber);

            returnValue = prdHelper.ExecuteNonQuery();
            prdHelper.Dispose();
            return returnValue;
        }

        /// <summary>
        /// 获取某指定助理所对应的代理人。
        /// </summary>
        /// <param name="assistantJobNumber">助理工号。</param>
        /// <returns></returns>
        public int GetAgentShareholderNumber(string assistantJobNumber)
        {
            int agent = 0;
            DBProcedure.Select_Assistant_Agent prdCmdText = new ShareOS.SQLServerDAL.DBProcedure.Select_Assistant_Agent();

            SQLProcedure prdHelper = new SQLProcedure(ConnectionString.ConnectionStringShares, prdCmdText.Text);
            prdHelper.SetInputValue(prdCmdText.PARM_AssistantJobNumber.ParameterName, assistantJobNumber);

            using (SqlDataReader reader = prdHelper.ExecuteReader())
            {
                if (reader.Read())
                {
                    agent = Convert.ToInt32(reader["AgentShareholderNumber"]);
                }
            }
            prdHelper.Dispose();
            return agent;
        }

        #endregion
    }
}
