using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.IDAL
{
    /// <summary>
    /// 股权管理接口。
    /// </summary>
    public interface IShareOwnership
    {
        /// <summary>
        /// 股权增减。
        /// </summary>
        /// <param name="shareholderNumber">股东号。</param>
        /// <param name="sharesChanges">股权改变量。正数代表股权增加，负数代表股权减少。</param>
        /// <param name="originalSharePrice">原始股价，即为购买股权时价格。</param>
        /// <param name="operatorName">股权变动操作者。</param>
        /// <returns></returns>
        bool Change(int shareholderNumber, decimal sharesChanges, decimal originalSharePrice, string causeOfChange, bool isPrincipal, string operatorName);

        /// <summary>
        /// 以股东持有的股数为基数，按一定的派股比例给所有股东派股。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <param name="rationScale">派股比例，如100股配送8股，则派股比例填0.08。</param>
        /// <param name="sharePrice">派股的股价，也就是当期的股价。</param>
        /// <param name="operatorName">操作人员。</param>
        void ScalRationedShares(int issueNumber, decimal rationScale, decimal sharePrice, string operatorName);

        /// <summary>
        /// 撤销股权增减操作。
        /// </summary>
        /// <param name="regId">股权增减记录号。</param>
        /// <returns></returns>
        bool CancelChange(int regId);

        /// <summary>
        /// 获取所有股东股权报告。
        /// </summary>
        /// <returns></returns>
        DataTable GetShareOwnershipReport();

        /// <summary>
        /// 获取股东个人的股权增减历史记录报告。
        /// </summary>
        /// <param name="shareholderNumber">股东号。</param>
        /// <returns></returns>
        DataTable GetPersonalShareOwnershipReport(int shareholderNumber);

        /// <summary>
        /// 获取某个时间段内股权退出记录。
        /// </summary>
        /// <param name="beginDate">时间段开始日期，时间段包含该日期。</param>
        /// <param name="endDate">时间段结束日期，时间段包含该日期。</param>
        /// <returns></returns>
        DataTable GetShareOwnershipWithdrawal(DateTime beginDate, DateTime endDate);

        /// <summary>
        /// 获取某指定股权交易期的股权清退报告。
        /// </summary>
        /// <param name="issueNumber">股权交易期。</param>
        /// <returns></returns>
        DataTable GetSharesWithdrawal(int issueNumber);

        /// <summary>
        /// 获取个人股权退出清算报告。
        /// </summary>
        /// <param name="regId">股权退出记录号。</param>
        /// <returns>返回数据表类型。</returns>
        DataTable GetPersonWithdrawalReportTable(int regId);

        /// <summary>
        /// 获取个人股权退出清算报告。
        /// </summary>
        /// <param name="regId">股权退出记录号。</param>
        /// <returns>返回 SharesWithDrawalReport 类。</returns>
        ShareOS.Model.SharesWithdrawalReport GetPersonWithdrawalReport(int regId);

        /// <summary>
        /// 获取指定股权交易期数的股权变化报告。
        /// </summary>
        /// <param name="issueNumber">股权交易期数.</param>
        /// <returns></returns>
        DataTable GetShareOwnershipChange(int issueNumber);

        /// <summary>
        /// 获取当前股价.
        /// </summary>
        /// <returns></returns>
        decimal GetCurrentSharePrice();

        /// <summary>
        /// 获取股东当前持股总数。
        /// </summary>
        /// <param name="shareholderNumber">股东号。</param>
        /// <returns></returns>
        decimal GetPersonalShareTotals(int shareholderNumber);

        /// <summary>
        /// 获取全体股权总数。
        /// </summary>
        /// <returns></returns>
        int GetCorporateShareTotals();

        /// <summary>
        /// 股权受让申请。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <param name="shareholderNumber">股东号。</param>
        /// <param name="sharesAmount">申请受让股权数量。</param>
        /// <param name="dateForApply">申请日期。</param>
        /// <returns></returns>
        bool ApplyFor(int issueNumber, int shareholderNumber, int sharesAmount);

        /// <summary>
        /// 撤销股权受让申请。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <param name="shareholderNumber">股东号。</param>
        /// <returns></returns>
        bool CancelApplyFor(int issueNumber, int shareholderNumber);


        /// <summary>
        /// 获取股权申请受让报告。
        /// </summary>
        /// <param name="issueNumber">指定股权交易期数。</param>
        /// <returns></returns>
        DataTable GetShareOwnershipApplyReport(int issueNumber);

        /// <summary>
        /// 获取股权委托代理人持股统计表。
        /// </summary>
        /// <returns></returns>
        DataTable GetShareOwnershipStatisticsReportByEntrustedAgent();

        /// <summary>
        /// 更新股权申请受让数额。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <param name="shareholderNumber">股东号。</param>
        /// <param name="sharesAmount">申请受让股权数量。</param>
        /// <param name="dateForApply">申请日期。</param>
        /// <returns></returns>
        bool UpdateSharesAmountApplyFor(int issueNumber, int shareholderNumber, int sharesAmount);
    }
}
