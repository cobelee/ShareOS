using System;
using System.Collections.Generic;
using System.Text;
using ShareOS.IDAL;

namespace ShareOS.BLL
{
    public class FundAccount
    {
        private IFundAccount dal = ShareOS.DALFactory.DataAccess.CreateFundAccount();

        /// <summary>
        /// ��������ʽ��ʻ���¼
        /// </summary>
        /// <param name="accountRecord"></param>
        /// <returns></returns>
        public bool InsertFundAccountRecord(int issueNumber, int shareholderNumber, decimal money, string changeReason, DateTime changeDate)
        {
            return dal.InsertFundAccountRecord(issueNumber, shareholderNumber, money, changeReason, changeDate);
        }

        /// <summary>
        /// ��ȡ���������ʽ��ʻ��䶯��¼���档
        /// </summary>
        /// <param name="sharehoderNumber">�ɶ��š�</param>
        /// <returns></returns>
        public System.Data.DataTable SelectPersonFundAccount(int sharehoderNumber)
        {
            return dal.SelectPersonFundAccount(sharehoderNumber);
        }

        /// <summary>
        /// ���¸����ʽ�䶯��¼��
        /// </summary>
        /// <param name="accountRecord">�ʽ��ʻ���¼��</param>
        /// <returns></returns>
        public bool UpdateFundAccountRecord(ShareOS.Model.FundAccountRecord accountRecord)
        {
            return dal.UpdateFundAccountRecord(accountRecord);
        }
    }
}