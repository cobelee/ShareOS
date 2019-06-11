using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShareOS.SQLServerDAL
{
    /// <summary>
    /// 职工股管理的监控办公室
    /// </summary>
    public class MonitorOffice
    {
        Tiyi.ShareOS.SQLServerDAL.ShareDataContext dbContext = new Tiyi.ShareOS.SQLServerDAL.ShareDataContext(Tiyi.ShareOS.SQLServerDAL.Connection.GetConnectionString());

        /// <summary>
        /// 获取股权期初数。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <returns></returns>
        public int GetSharesInitialAmount(int issueNumber)
        {

            int amount = 0;
            var initialAmount = from changeRecord in dbContext.ShareOwnership
                                where changeRecord.IssueNumber < issueNumber
                                select changeRecord;
            amount = Convert.ToInt32(initialAmount.Sum(o => o.SharesChanges));

            return amount;
        }

        /// <summary>
        /// 获取某期股东总数。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <returns></returns>
        public int GetSharesholderAmount(int issueNumber)
        {
            int amount = 0;
            var query = from shareholder in dbContext.Shareholder
                        where (from share in dbContext.ShareOwnership
                               where share.IssueNumber == issueNumber && share.ShareholderNumber == shareholder.ShareholderNumber
                               orderby share.RegDate descending
                               select share.ShareTotals).First() > 0
                        select shareholder;
            amount = query.Count();
            return amount;
        }

        /// <summary>
        /// 获取某期清退所有股权的人员数。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <returns></returns>
        public int GetPersonNumberOfClearShare(int issueNumber)
        {
            int amount = 0;
            var query = from changeRecord in dbContext.ShareOwnership
                        where changeRecord.IssueNumber == issueNumber && changeRecord.SharesChanges < 0 && changeRecord.ShareTotals == 0
                        select changeRecord;
            amount = query.Count();
            return amount;
        }

        /// <summary>
        /// 获取某期清退的股权数量总数。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <returns></returns>
        public int GetSharesAmountToClear(int issueNumber)
        {
            int amount = 0;
            var query = from records in dbContext.ShareOwnership
                        where records.IssueNumber == issueNumber && records.CauseOfChange == "退股" && records.ShareTotals == 0
                        select records;
            amount = Convert.ToInt32(query.Sum(o => o.SharesChanges));
            return amount;
        }

        /// <summary>
        /// 获取某期派发的红股总数量。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <returns></returns>
        public int GetBonusShareAmountToAllocate(int issueNumber)
        {
            int amount = 0;
            var query = from records in dbContext.ShareOwnership
                        where records.IssueNumber == issueNumber && records.CauseOfChange == "配发红股" && records.SharesChanges > 0
                        select records;
            amount = Convert.ToInt32(query.Sum(o => o.SharesChanges));
            return amount;
        }

        /// <summary>
        /// 获取某期派发的现金股息总金额。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <returns></returns>
        public decimal GetDividendAmountToAllocate(int issueNumber)
        {
            decimal amount = 0;
            var query = from records in dbContext.BonusRecord
                        where records.IssueNumber == issueNumber
                        select records;
            amount = query.Sum(o => o.CashBonus) ?? 0;
            return amount;
        }

        /// <summary>
        /// 获取某期职工个人购买股权的总数量。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <returns></returns>
        public int GetAmountOfShareholderBuyShare(int issueNumber)
        {
            int amount = 0;
            var query = from records in dbContext.ShareOwnership
                        where records.IssueNumber == issueNumber && records.CauseOfChange == "个人购买" && records.SharesChanges > 0
                        select records;
            amount = Convert.ToInt32(query.Sum(o => o.SharesChanges));
            return amount;
        }

        /// <summary>
        /// <para>获取某期红股转让总数量</para>
        /// <para>仅包括红股转让后，仍有持股的部分。完全清退股权人员的红股部分不包含在内。</para>
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <returns></returns>
        public int GetAmountOfBonusShareToSell(int issueNumber)
        {
            int amount = 0;
            var query = from records in dbContext.ShareOwnership
                        where records.IssueNumber == issueNumber && records.CauseOfChange == "红股转让" && records.SharesChanges < 0
                        select records;
            amount = Convert.ToInt32(query.Sum(o => o.SharesChanges));
            return amount;
        }


        /// <summary>
        /// 当前期新股东数目。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <returns></returns>
        public int GetNumberOfBeNewShareholder(int issueNumber)
        {
            int amount = 0;
            var query = from records in dbContext.ShareOwnership
                        where records.IssueNumber == issueNumber && records.SharesChanges == records.ShareTotals
                        select records;
            amount = query.Count();
            return amount;
        }

        /// <summary>
        /// 获取指定交易期清退人员数。
        /// </summary>
        /// <param name="issueNumber">交易期</param>
        /// <returns></returns>
        public int GetNumberOfClearedShareholder(int issueNumber)
        {
            int amount = 0;
            var query = from records in dbContext.ShareOwnership
                        where records.IssueNumber == issueNumber && records.CauseOfChange == "退股"
                        select records;
            amount = query.Count();
            return amount;
        }


        /// <summary>
        /// 获取指定股权代理人名下的股东人数。
        /// </summary>
        /// <param name="agentShn">股东代理人的股东号</param>
        /// <returns></returns>
        public int GetAgencyPersonCount(int agentShn)
        {
            int amount = 0;
            var query = from records in dbContext.Shareholder
                        where records.EntrustedAgent == agentShn && records.Status == "股东"
                        select records;
            amount = query.Count();
            return amount;
        }

        /// <summary>
        /// [TODO] 获取指定股权代理人名下的代理股权总数。
        /// </summary>
        /// <param name="agentShn">股东代理人的股东号</param>
        /// <returns></returns>
        public int GetAgencySOAmount(int agentShn)
        {
            int amount = 0;
            //var query = from records in dbContext.ShareOwnership
            //            where records.EntrustedAgent == agentShn && records.Status == "股东"
            //            select records;
            //amount = query.Count();
            return amount;
        }

        /// <summary>
        /// 获取股权交易期数最后一期的值。
        /// </summary>
        /// <returns></returns>
        public int GetLastIssueNumber()
        {
            int returnValue = 0;
            var query = from c in dbContext.SharesIssueConfig
                        orderby c.IssueNumber descending
                        select c;
            Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig config = query.FirstOrDefault();

            if (config != null)
                returnValue = (int)(config.IssueNumber);

            return returnValue;
        }
    }
}
