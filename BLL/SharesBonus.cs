using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using ShareOS.IDAL;
using ShareOS.Model;

namespace ShareOS.BLL
{
    public class SharesBonusManage
    {
        private ISharesBonus dal = ShareOS.DALFactory.DataAccess.CreateSharesBonus();

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
            return dal.InsertSharesIssueConfig(issueNumber, bonus, sharePrice, DPD);
        }

        /// <summary>
        /// ɾ����Ȩ�����������á�
        /// </summary>
        /// <param name="issueNumber">��Ȩ��������</param>
        /// <returns></returns>
        public bool DeleteSharesIssueConfig(int issueNumber)
        {
            return dal.DeleteSharesIssueConfig(issueNumber);
        }

        /// <summary>
        /// ��ѯָ����Ȩ�����ڵ�������Ϣ��
        /// </summary>
        /// <param name="issueNumber">��Ȩ����������</param>
        /// <returns></returns>
        public Model.SharesIssueConfig SelectConfig(int issueNumber)
        {
            return dal.SelectConfig(issueNumber);
        }

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="issueNumber">��Ȩ��������</param>
        /// <returns></returns>
        public bool PayBonus(int issueNumber)
        {
            return dal.PayBonus(issueNumber);
        }

        /// <summary>
        /// ��ȡ��Ȩ�����������һ�ڵ�ֵ��
        /// <para>[���]�÷��������� MonitorOffice ����</para>
        /// </summary>
        /// <returns></returns>
        public int GetLastIssueNumber()
        {
            return dal.GetLastIssueNumber();
        }

        /// <summary>
        /// ��ȡĳһ��Ȩ���������йɶ��ķֺ��¼��
        /// </summary>
        /// <param name="issueNumber">��Ȩ�����ڡ�</param>
        /// <returns></returns>
        public DataTable SelectBonusRecord(int issueNumber)
        {
            return dal.SelectBonusRecord(issueNumber);
        }

        /// <summary>
        /// ��ȡĳ�ɶ�����ֺ��¼��
        /// </summary>
        /// <param name="shareholder">�ɶ���</param>
        /// <returns></returns>
        public DataTable SelectBonusRecord(ShareOS.Model.Shareholder shareholder)
        {
            return dal.SelectBonusRecord(shareholder);
        }
    }
}