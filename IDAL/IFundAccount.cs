using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.IDAL
{
    public interface IFundAccount
    {
        /// <summary>
        /// ��������ʽ��ʻ���¼
        /// </summary>
        /// <param name="accountRecord"></param>
        /// <returns></returns>
        bool InsertFundAccountRecord(int issueNumber, int shareholderNumber, decimal money, string changeReason, DateTime changeDate);

        /// <summary>
        /// ��ȡ���������ʽ��ʻ��䶯��¼���档
        /// </summary>
        /// <param name="sharehoderNumber">�ɶ��š�</param>
        /// <returns></returns>
        DataTable SelectPersonFundAccount(int shareholderNumber);

        /// <summary>
        /// ���¸����ʽ�䶯��¼��
        /// </summary>
        /// <param name="accountRecord">�ʽ��ʻ���¼��</param>
        /// <returns></returns>
        bool UpdateFundAccountRecord(Model.FundAccountRecord accountRecord);


    }
}