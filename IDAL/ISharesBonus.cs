using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.IDAL
{
    /// <summary>
    /// ���ڹɶ��ֺ������Ľӿڡ�
    /// </summary>
    public interface ISharesBonus
    {
        /// <summary>
        /// �����Ȩ�����������á�
        /// </summary>
        /// <param name="issueNumber">����.</param>
        /// <param name="bonus">�����������ÿ10�ɷ�������ң�x Ԫ/10�ɡ�</param>
        /// <param name="sharePrice">���������ÿ�ɹɼۡ�y Ԫ/�ɡ�</param>
        /// <param name="DPD">�����ɷ����ڡ�</param>
        /// <returns></returns>
        bool InsertSharesIssueConfig(int issueNumber, decimal bonus, decimal sharePrice, DateTime DPD);

        /// <summary>
        /// ɾ����Ȩ�����������á�
        /// </summary>
        /// <param name="issueNumber">��Ȩ��������</param>
        /// <returns></returns>
        bool DeleteSharesIssueConfig(int issueNumber);

        /// <summary>
        /// ��ѯ��Ȩ����������Ϣ��
        /// </summary>
        /// <returns></returns>
        //IList<Model.SharesIssueConfig> SelectConfig();

        /// <summary>
        /// ��ѯָ����Ȩ�����ڵ�������Ϣ��
        /// </summary>
        /// <param name="issueNumber"></param>
        /// <returns></returns>
        Model.SharesIssueConfig SelectConfig(int issueNumber);

        /// <summary>
        /// ��ȡĳһ��Ȩ���������йɶ��ķֺ��¼��
        /// </summary>
        /// <param name="issueNumber">��Ȩ�����ڡ�</param>
        /// <returns></returns>
        DataTable SelectBonusRecord(int issueNumber);

        /// <summary>
        /// ��ȡĳ�ɶ�����ֺ��¼��
        /// </summary>
        /// <param name="shareholder">�ɶ���</param>
        /// <returns></returns>
        DataTable SelectBonusRecord(Model.Shareholder shareholder);

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="issueNumber">��Ȩ��������</param>
        /// <returns></returns>
        bool PayBonus(int issueNumber);

        /// <summary>
        /// ��ȡ��Ȩ�����������һ�ڵ�ֵ��
        /// </summary>
        /// <returns></returns>
        int GetLastIssueNumber();
    }
}