using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.IDAL
{
    public interface IFundAccount
    {
        /// <summary>
        /// 插入个人资金帐户记录
        /// </summary>
        /// <param name="accountRecord"></param>
        /// <returns></returns>
        bool InsertFundAccountRecord(int issueNumber, int shareholderNumber, decimal money, string changeReason, DateTime changeDate);

        /// <summary>
        /// 获取个人历年资金帐户变动记录报告。
        /// </summary>
        /// <param name="sharehoderNumber">股东号。</param>
        /// <returns></returns>
        DataTable SelectPersonFundAccount(int shareholderNumber);

        /// <summary>
        /// 更新个人资金变动记录。
        /// </summary>
        /// <param name="accountRecord">资金帐户记录。</param>
        /// <returns></returns>
        bool UpdateFundAccountRecord(Model.FundAccountRecord accountRecord);


    }
}
