using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using ShareOS.Model;

namespace ShareOS.IDAL
{
    public interface IEntrustedAgent
    {
        /// <summary>
        /// ����ί�д����ˣ��ɶ�������.
        /// </summary>
        /// <param name="shareholder">ί�д����ˣ��ɶ�������.</param>
        /// <returns></returns>
        bool Insert(ShareOS.Model.EntrustedAgent entrustedAgent);

        /// <summary>
        /// ����ί�д����ˣ��ɶ�������.
        /// </summary>
        /// <param name="agentShn">ί�д����ˣ��ɶ��������Ĺɶ���.</param>
        /// <returns></returns>
        bool Create(int agentShn);

        /// <summary>
        /// ��ȡ����ί�д����ˣ��ɶ��������б�.
        /// </summary>
        /// <returns></returns>
        IList<EntrustedAgent> Select();

        /// <summary>
        /// ɾ��ί�д����ˣ��ɶ���������
        /// </summary>
        /// <param name="shareholderNumber">�ɶ���.</param>
        /// <returns></returns>
        bool Delete(int shareholderNumber);


        void ActFor(int shareholderId, ShareOS.Model.EntrustedAgent entrustedAgent);

        /// <summary>
        /// �Ƿ����ί�д����ˡ�
        /// </summary>
        /// <param name="shareholderNumber">ί�д����˵Ĺɶ��š�</param>
        /// <returns></returns>
        bool Exist(int shareholderNumber);

        /// <summary>
        /// Ϊ��Ȩ�����˷���������
        /// </summary>
        /// <param name="agentShareholderNumber">��Ȩ�����˹ɶ��š�</param>
        /// <param name="assistantJobNumber">�������š�</param>
        void SetAssistant(int agentShareholderNumber, string assistantJobNumber);

        /// <summary>
        /// ��ȡ�ɶ������˵�������
        /// </summary>
        /// <param name="agentShareholderNumber">��Ȩ�����˹ɶ���.</param>
        /// <returns></returns>
        DataTable SelectAssistant(int agentShareholderNumber);

        /// <summary>
        /// ��ȡĳָ����������Ӧ�Ĵ����ˡ�
        /// </summary>
        /// <param name="assistantJobNumber">�������š�</param>
        /// <returns></returns>
        int GetAgentShareholderNumber(string assistantJobNumber);

        /// <summary>
        /// ɾ����Ȩ�����˵�������
        /// </summary>
        /// <param name="agentShareholderNumber">��Ȩ�����˹ɶ��š�</param>
        /// <param name="assistantJobNumber">�������š�</param>
        bool DeleteAssistant(int agentShareholderNumber, string assistantJobNumber);
    }
}