using System;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.BLL
{
    /// <summary>
    /// 职工股管理的监控办公室
    /// </summary>
    public class MonitorOffice
    {
        ShareOS.SQLServerDAL.MonitorOffice dal = new SQLServerDAL.MonitorOffice();
        ShareOS.SQLServerDAL.MonitorOffice daMonitor = new SQLServerDAL.MonitorOffice();
        ShareOS.BLL.SharesBonusManage dal_bonus = new SharesBonusManage();

        /// <summary>
        /// 获取股权期初数。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <returns></returns>
        public int GetSharesInitialAmount(int issueNumber)
        {
            return dal.GetSharesInitialAmount(issueNumber);
        }

        /// <summary>
        /// 获取某期股东总数。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <returns></returns>
        public int GetSharesholderAmount(int issueNumber)
        {
            return dal.GetSharesholderAmount(issueNumber);
        }

        /// <summary>
        /// 获取某股权交易期的股价
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <returns></returns>
        public decimal GetSharePrice(int issueNumber)
        {
            ShareOS.Model.SharesIssueConfig config = dal_bonus.SelectConfig(issueNumber);
            return config.SharePrice;
        }

        /// <summary>
        /// 获取某期清退所有股权的人员数。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <returns></returns>
        public int GetPersonNumberOfClearShare(int issueNumber)
        {
            return dal.GetPersonNumberOfClearShare(issueNumber);
        }

        /// <summary>
        /// 获取某期清退的股权数量总数。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <returns></returns>
        public int GetSharesAmountToClear(int issueNumber)
        {
            return dal.GetSharesAmountToClear(issueNumber);
        }

        /// <summary>
        /// 获取某期配发的红股总数量。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <returns></returns>
        public int GetBonusShareAmountToAllocate(int issueNumber)
        {
            return dal.GetBonusShareAmountToAllocate(issueNumber);
        }

        /// <summary>
        /// 获取某期配发的红股总数量。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <returns></returns>
        public decimal GetDividendAmountToAllocate(int issueNumber)
        {
            return dal.GetDividendAmountToAllocate(issueNumber);
        }

        /// <summary>
        /// 获取某期职工个人购买股权的总数量。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <returns></returns>
        public int GetAmountOfShareholderBuyShare(int issueNumber)
        {
            return dal.GetAmountOfShareholderBuyShare(issueNumber);
        }

        /// <summary>
        /// 获取指定股权代理人名下的股东人数。
        /// </summary>
        /// <param name="agentShn">股东代理人的股东号</param>
        /// <returns></returns>
        public int GetAgencyCount(int agentShn)
        {
            return dal.GetAgencyPersonCount(agentShn);
        }

        /// <summary>
        /// <para>获取某期红股转让总数量</para>
        /// <para>仅包括红股转让后，仍有持股的部分。完全清退股权人员的红股部分不包含在内。</para>
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <returns></returns>
        public int GetAmountOfBonusShareToSell(int issueNumber)
        {
            return dal.GetAmountOfBonusShareToSell(issueNumber);
        }

        /// <summary>
        /// 当前期新股东数目。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <returns></returns>
        public int GetNumberOfBeNewShareholder(int issueNumber)
        {
            return dal.GetNumberOfBeNewShareholder(issueNumber);
        }

        /// <summary>
        /// 获取指定交易期清退人员数。
        /// </summary>
        /// <param name="issueNumber">交易期</param>
        /// <returns></returns>
        public int GetNumberOfClearedShareholder(int issueNumber)
        {
            return daMonitor.GetNumberOfClearedShareholder(issueNumber);
        }

        /// <summary>
        /// 获取股权交易期数最后一期的值。
        /// </summary>
        /// <returns></returns>
        public int GetLastIssueNumber()
        {
            return daMonitor.GetLastIssueNumber();
        }
    }
}
