using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using ShareOS.IDAL;
using ShareOS.Model;

namespace ShareOS.BLL
{
    public class EntrustedAgent
    {
        private IEntrustedAgent dal = ShareOS.DALFactory.DataAccess.CreateEntrustedAgent();

        public bool Insert(ShareOS.Model.EntrustedAgent entrustedAgent)
        {
            return dal.Insert(entrustedAgent);
        }

        /// <summary>
        /// ����ί�д����ˣ��ɶ�������.
        /// </summary>
        /// <param name="agentShn">ί�д����ˣ��ɶ��������Ĺɶ���.</param>
        /// <returns></returns>
        public bool Create(int agentShn)
        {
            return dal.Create(agentShn);
        }

        public IList<ShareOS.Model.EntrustedAgent> Select()
        {
            return dal.Select();
        }

        public bool Delete(int shareholderNumber)
        {
            return dal.Delete(shareholderNumber);
        }

        public void ActFor(int shareholderId, ShareOS.Model.EntrustedAgent entrustedAgent)
        {
            dal.ActFor(shareholderId, entrustedAgent);
        }

        /// <summary>
        /// �Ƿ����ί�д����ˡ�
        /// </summary>
        /// <param name="shareholderNumber">ί�д����˵Ĺɶ��š�</param>
        /// <returns></returns>
        public bool Exist(int shareholderNumber)
        {
            return dal.Exist(shareholderNumber);
        }

        /// <summary>
        /// Ϊ��Ȩ�����˷���������
        /// </summary>
        /// <param name="agentShareholderNumber">��Ȩ�����˹ɶ��š�</param>
        /// <param name="assistantJobNumber">�������š�</param>
        public void AssignAssistant(int agentShareholderNumber, string assistantJobNumber)
        {
            dal.SetAssistant(agentShareholderNumber, assistantJobNumber);
        }

        /// <summary>
        /// ��ȡ�ɶ������˵�������
        /// </summary>
        /// <param name="agentShareholderNumber">��Ȩ�����˹ɶ���.</param>
        /// <returns></returns>
        public DataTable SelectAssistant(int agentShareholderNumber)
        {
            return dal.SelectAssistant(agentShareholderNumber);
        }

        /// <summary>
        /// ɾ����Ȩ�����˵�������
        /// </summary>
        /// <param name="agentShareholderNumber">��Ȩ�����˹ɶ��š�</param>
        /// <param name="assistantJobNumber">�������š�</param>
        public bool DeleteAssistant(int agentShareholderNumber, string assistantJobNumber)
        {
            return dal.DeleteAssistant(agentShareholderNumber, assistantJobNumber);
        }

        /// <summary>
        /// ��ȡĳָ����������Ӧ�Ĵ����ˡ�
        /// </summary>
        /// <param name="assistantJobNumber">�������š�</param>
        /// <returns></returns>
        public int GetAgentShareholderNumber(string assistantJobNumber)
        {
            return dal.GetAgentShareholderNumber(assistantJobNumber);
        }

        /// <summary>
        /// �ж��Ƿ��Ǵ����˵��������ݡ�
        /// </summary>
        /// <param name="assistantJobNumber">�������š�</param>
        /// <returns></returns>
        public bool IsAssistant(string assistantJobNumber)
        {
            int agent = dal.GetAgentShareholderNumber(assistantJobNumber);
            return agent > 0 ? true : false;
        }
    }
}