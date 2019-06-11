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
        /// 插入个人资金帐户记录
        /// </summary>
        /// <param name="accountRecord"></param>
        /// <returns></returns>
        public bool InsertFundAccountRecord(int issueNumber, int shareholderNumber, decimal money, string changeReason, DateTime changeDate)
        {
            return dal.InsertFundAccountRecord(issueNumber, shareholderNumber, money, changeReason, changeDate);
        }

        /// <summary>
        /// 获取个人历年资金帐户变动记录报告。
        /// </summary>
        /// <param name="sharehoderNumber">股东号。</param>
        /// <returns></returns>
        public System.Data.DataTable SelectPersonFundAccount(int sharehoderNumber)
        {
            return dal.SelectPersonFundAccount(sharehoderNumber);
        }

        /// <summary>
        /// 更新个人资金变动记录。
        /// </summary>
        /// <param name="accountRecord">资金帐户记录。</param>
        /// <returns></returns>
        public bool UpdateFundAccountRecord(ShareOS.Model.FundAccountRecord accountRecord)
        {
            return dal.UpdateFundAccountRecord(accountRecord);
        }
    }
}
