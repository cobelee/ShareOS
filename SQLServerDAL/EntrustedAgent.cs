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
            mShareholder.Status = Reader[table.Status.Text].ToString().Trim() == ShareholderStatus.�ɶ�.ToString() ? ShareholderStatus.�ɶ� : ShareholderStatus.�ǹɶ�;
            mShareholder.EntrustedAgent = Convert.ToInt32(Reader[table.EntrustedAgent.Text]);
            return mShareholder;
        }

        #region IEntrustedAgent ��Ա

        /// <summary>
        /// ����ί�д����ˣ��ɶ�������.
        /// </summary>
        /// <param name="shareholder">ί�д����ˣ��ɶ�������.</param>
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
        /// ����ί�д����ˣ��ɶ�������.
        /// </summary>
        /// <param name="agentShn">ί�д����ˣ��ɶ��������Ĺɶ���.</param>
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
        /// ��ȡ����ί�д����ˣ��ɶ��������б�.
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
        /// ɾ��ί�д����ˣ��ɶ���������
        /// </summary>
        /// <param name="shareholderNumber">�ɶ���.</param>
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
        /// ����ĳ�ɶ����ù�Ȩ���������ˡ�
        /// </summary>
        /// <param name="shareholderId">�ɶ����ţ��ǹɶ��š�</param>
        /// <param name="entrustedAgent">ί�д����ˡ�</param>
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
        /// �Ƿ����ί�д����ˡ�
        /// </summary>
        /// <param name="shareholderNumber">ί�д����˵Ĺɶ��š�</param>
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
        /// Ϊ��Ȩ�����˷���������
        /// </summary>
        /// <param name="agentShareholderNumber">��Ȩ�����˹ɶ��š�</param>
        /// <param name="assistantJobNumber">�������š�</param>
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
        /// ��ȡ�ɶ������˵�������
        /// </summary>
        /// <param name="agentShareholderNumber">��Ȩ�����˹ɶ���.</param>
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
        /// ɾ����Ȩ�����˵�������
        /// </summary>
        /// <param name="agentShareholderNumber">��Ȩ�����˹ɶ��š�</param>
        /// <param name="assistantJobNumber">�������š�</param>
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
        /// ��ȡĳָ����������Ӧ�Ĵ����ˡ�
        /// </summary>
        /// <param name="assistantJobNumber">�������š�</param>
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