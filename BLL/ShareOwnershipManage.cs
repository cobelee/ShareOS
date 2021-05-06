using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ShareOS.IDAL;

namespace ShareOS.BLL
{
    public class ShareOwnershipManage
    {
        private IShareOwnership dal = ShareOS.DALFactory.DataAccess.CreateShareOwnership();
        private Tiyi.ShareOS.SQLServerDAL.ShareOwnershipDA daShareOwnership = new Tiyi.ShareOS.SQLServerDAL.ShareOwnershipDA();
        private Tiyi.ShareOS.SQLServerDAL.ShareIssueConfigDA daConfig = new Tiyi.ShareOS.SQLServerDAL.ShareIssueConfigDA();
        public void Dispose()
        {
            daShareOwnership.Dispose();
            daConfig.Dispose();
        }

        protected bool Change(int shareholderNumber, decimal sharesChanges, decimal originalSharePrice, string causeOfChange, bool isPrincipal, string operatorName)
        {
            return daShareOwnership.ChangeGuQuanShu(shareholderNumber, sharesChanges, originalSharePrice, causeOfChange, isPrincipal, operatorName);
        }

        /// <summary>
        /// 以股东持有的股数为基数，按一定的派股比例给所有股东派发红股。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <param name="rationScale">派股比例，如100股派送8股，则派股比例填0.08。</param>
        /// <param name="sharePrice">派股的股价，也就是当期的股价。</param>
        /// <param name="operatorName">操作人员。</param>
        public void ScalRationedShares(int issueNumber, decimal rationScale, decimal sharePrice, string operatorName)
        {
            dal.ScalRationedShares(issueNumber, rationScale, sharePrice, operatorName);
        }

        /// <summary>
        /// 撤销股权增减操作。
        /// </summary>
        /// <param name="regId">股权增减记录号。</param>
        /// <returns></returns>
        public bool CancelChange(int regId)
        {
            return dal.CancelChange(regId);
        }

        /// <summary>
        /// 获取所有股东股权报告。
        /// </summary>
        /// <returns></returns>
        public DataTable GetShareOwnershipReport(int issueNumber)
        {
            return daShareOwnership.GetShareOwnershipReport(issueNumber);
        }

        /// <summary>
        /// 获取选定股东的股权报告
        /// </summary>
        /// <param name="shareholderNumbers">股东号列表</param>
        /// <returns></returns>
        public DataTable GetShareOwnershipReport(int[] shareholderNumbers)
        {
            return daShareOwnership.GetShareOwnershipReportTable(shareholderNumbers);
        }

        /// <summary>
        /// 获取指定股东的清退股权记录。
        /// </summary>
        /// <param name="sharehoderNumber">股东号。</param>
        /// <returns></returns>
        public Tiyi.ShareOS.SQLServerDAL.ShareOwnership GetPersonalClearingRecord(int sharehoderNumber)
        {
            return daShareOwnership.GetPersonalClearingRecord(sharehoderNumber);
        }

        /// <summary>
        /// 获取购买股权个人总出资额
        /// </summary>
        /// <param name="shareholderNumber">股东号</param>
        /// <returns></returns>
        public decimal GetPersonalSharesOriginalValue(int shareholderNumber)
        {
            return daShareOwnership.GetPersonalSharesOriginalValue(shareholderNumber);
        }

        public List<PersonClearingReportItem> GetPersonClearingReport(int[] shareholderNumbers)
        {
            List<Tiyi.ShareOS.SQLServerDAL.ShareholderCurrentShares> personShareReport = daShareOwnership.GetShareOwnershipReport(shareholderNumbers);

            List<PersonClearingReportItem> clearingReport = new List<PersonClearingReportItem>();
            foreach (Tiyi.ShareOS.SQLServerDAL.ShareholderCurrentShares sh in personShareReport)
            {
                PersonClearingReportItem item = new PersonClearingReportItem();
                item.姓名 = sh.ShareholderName;
                item.股东号 = sh.ShareholderNumber;
                item.BarCode = sh.BarCode;
                item.工号 = sh.JobNumber;
                item.性别 = sh.Sex ? "男" : "女";
                item.身份证号 = sh.IdentityCard;
                item.人员类别 = sh.PersonType;
                item.代理人 = sh.EntrustedAgentName;
                item.所在单位 = sh.Department;

                Tiyi.ShareOS.SQLServerDAL.ShareOwnership record = this.GetPersonalClearingRecord(item.股东号);
                if (record != null)
                {
                    item.退出时间 = record.RegDate.Value;
                    item.退出股权数 = System.Math.Abs(record.SharesChanges.Value);
                    item.交易价格 = record.OriginalSharePrice.Value;
                    item.总股值 = item.退出股权数 * item.交易价格;
                    item.个人出资 = this.GetPersonalSharesOriginalValue(item.股东号);
                    item.税前收益 = item.总股值 - item.个人出资;
                    item.个人所得税 = Math.Round(item.税前收益 * 0.2m, 2);  // 个人所得税建议参数化
                    item.实际回款 = item.总股值 - item.个人所得税;
                }
                else
                {
                    item.退出时间 = DateTime.Now;
                    item.退出股权数 = 0m;
                    item.交易价格 = 0m;
                    item.总股值 = 0m;
                    item.个人出资 = 0m;
                    item.税前收益 = 0m;
                    item.个人所得税 = 0m;  // 个人所得税建议参数化
                    item.实际回款 = 0m;
                }
                clearingReport.Add(item);

            }
            return clearingReport;
        }

        /// <summary>
        /// 获取所有股东期初股权报告。
        /// </summary>
        /// <param name="issueNumber">股权交易期数</param>
        /// <returns></returns>
        //public DataTable GetQichuShareOwnership(int issueNumber)
        //{
        //    return daShareOwnership.GetQichuShareOwnership(issueNumber);
        //}

        /// <summary>
        /// 获取股东个人的股权增减历史记录报告。
        /// </summary>
        /// <param name="shareholderNumber">股东号。</param>
        /// <returns></returns>
        public DataTable GetPersonalShareOwnershipReport(int shareholderNumber)
        {
            return dal.GetPersonalShareOwnershipReport(shareholderNumber);
        }

        /// <summary>
        /// 获取股权委托代理人持股统计表。
        /// </summary>
        /// <returns></returns>
        public DataTable GetShareOwnershipStatisticsReportByEntrustedAgent()
        {
            return dal.GetShareOwnershipStatisticsReportByEntrustedAgent();
        }

        /// <summary>
        /// 获取指定股权交易期数的股权变化报告。
        /// </summary>
        /// <param name="issueNumber">股权交易期数.</param>
        /// <returns></returns>
        public DataTable GetShareOwnershipChange(int issueNumber)
        {
            return dal.GetShareOwnershipChange(issueNumber);
        }

        /// <summary>
        /// 个人购买股权。
        /// </summary>
        /// <param name="shareholderNumber">股东号。</param>
        /// <param name="increaseAmount">股权增持数量。数量为大于零的整数。</param>
        /// <param name="operatorName">操作者。</param>
        /// <returns></returns>
        public bool BuyShares(int shareholderNumber, decimal increaseAmount, decimal originalSharePrice, string operatorName)
        {
            bool returnValue = false;
            if (increaseAmount > 0)
            {
                returnValue = Change(shareholderNumber, increaseAmount, originalSharePrice, "个人购买", true, operatorName);
            }
            return returnValue;
        }

        /// <summary>
        /// 派发红股。
        /// </summary>
        /// <param name="shareholderNumber">股东号。</param>
        /// <param name="increaseAmount">股权增持数量。数量为大于零的整数。</param>
        /// <param name="operatorName">操作者。</param>
        /// <returns></returns>
        public bool PeiguShares(int shareholderNumber, decimal increaseAmount, decimal originalSharePrice, string operatorName)
        {
            bool returnValue = false;
            if (increaseAmount > 0)
            {
                returnValue = Change(shareholderNumber, increaseAmount, originalSharePrice, "派发红股", false, operatorName);
            }
            return returnValue;
        }

        /// <summary>
        /// 减持股权。
        /// <para>该方法也可以用于清退股权。</para>
        /// </summary>
        /// <param name="shareholderNumber">股东号。</param>
        /// <param name="decreaseAmount">股权减持数量。数量为大于零的整数。</param>
        /// <param name="operatorName">操作者。</param>
        /// <returns></returns>
        public bool Tuigu(int shareholderNumber, decimal decreaseAmount, decimal originalSharePrice, string operatorName)
        {
            bool returnValue = false;
            if (decreaseAmount > 0)
            {
                returnValue = Change(shareholderNumber, -decreaseAmount, originalSharePrice, "退股", false, operatorName);
            }
            return returnValue;
        }

        /// <summary>
        /// 批量清退股权
        /// <para>只能清退当年股权。</para>
        /// </summary>
        /// <param name="sharehoderNumbers">股东号列表</param>
        /// <param name="opeName">操作员</param>
        public void QingtuiShares_Bat(int[] sharehoderNumbers, string opeName)
        {
            daShareOwnership.QingtuiShares_Bat(sharehoderNumbers, opeName);
        }

        /// <summary>
        /// 红股转让（减持股权）。
        /// </summary>
        /// <param name="shareholderNumber">股东号。</param>
        /// <param name="decreaseAmount">股权减持数量。数量为大于零的整数。</param>
        /// <param name="operatorName">操作者。</param>
        /// <returns></returns>
        public bool HongguZhuanrang(int shareholderNumber, decimal decreaseAmount, decimal originalSharePrice, string operatorName)
        {
            bool returnValue = false;
            if (decreaseAmount > 0)
            {
                returnValue = Change(shareholderNumber, -decreaseAmount, originalSharePrice, "红股转让", false, operatorName);
            }
            return returnValue;
        }

        /// <summary>
        /// 获取当前股价.
        /// </summary>
        /// <returns></returns>
        public decimal GetCurrentSharePrice()
        {
            return dal.GetCurrentSharePrice();
        }

        /// <summary>
        /// [否决]获取某个时间段内股权退出记录。
        /// </summary>
        /// <param name="beginDate">时间段开始日期，时间段包含该日期。</param>
        /// <param name="endDate">时间段结束日期，时间段包含该日期。</param>
        /// <returns></returns>
        public DataTable GetShareOwnershipWithdrawal(DateTime beginDate, DateTime endDate)
        {
            return dal.GetShareOwnershipWithdrawal(beginDate, endDate);
        }

        /// <summary>
        /// 获取某指定股权交易期的股权清退报告。
        /// </summary>
        /// <param name="issueNumber">股权交易期。</param>
        /// <returns></returns>
        public DataTable GetSharesWithdrawal(int issueNumber)
        {
            return dal.GetSharesWithdrawal(issueNumber);
        }

        /// <summary>
        /// 获取个人股权退出清算报告。
        /// </summary>
        /// <param name="regId">股权退出记录号。</param>
        /// <returns>返回数据表类型。</returns>
        public DataTable GetPersonWithdrawalReportTable(int regId)
        {
            return dal.GetPersonWithdrawalReportTable(regId);
        }



        /// <summary>
        /// 获取个人股权退出清算报告。
        /// </summary>
        /// <param name="regId">股权退出记录号。</param>
        /// <returns>返回 SharesWithDrawalReport 类。</returns>
        public ShareOS.Model.SharesWithdrawalReport GetPersonWithdrawalReport(int regId)
        {
            return dal.GetPersonWithdrawalReport(regId);
        }

        /// <summary>
        /// 获取股东当前持股总数。
        /// </summary>
        /// <param name="shareholderNumber">股东号。</param>
        /// <returns></returns>
        public decimal GetPersonalShareTotals(int shareholderNumber)
        {
            return daShareOwnership.GetPersonalShareTotals(shareholderNumber);
        }

        /// <summary>
        /// 获取全体股权总数。
        /// 计算方法：将历年所有股东进出的股权数相加
        /// </summary>
        /// <returns></returns>
        public int GetCorporateShareTotals()
        {
            return dal.GetCorporateShareTotals();
        }

        /// <summary>
        /// 股权受让申请。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <param name="shareholderNumber">股东号。</param>
        /// <param name="sharesAmount">申请受让股权数量。</param>
        /// <param name="dateForApply">申请日期。</param>
        /// <returns></returns>
        public bool ApplyFor(int issueNumber, int shareholderNumber, int sharesAmount)
        {
            return dal.ApplyFor(issueNumber, shareholderNumber, sharesAmount);
        }

        /// <summary>
        /// 撤销股权受让申请。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <param name="shareholderNumber">股东号。</param>
        /// <returns></returns>
        public bool CancelApplyFor(int issueNumber, int shareholderNumber)
        {
            return dal.CancelApplyFor(issueNumber, shareholderNumber);
        }


        /// <summary>
        /// 获取股权申请受让报告。
        /// </summary>
        /// <param name="issueNumber">指定股权交易期数。</param>
        /// <returns></returns>
        public DataTable GetShareOwnershipApplyReport(int issueNumber)
        {
            return dal.GetShareOwnershipApplyReport(issueNumber);
        }

        /// <summary>
        /// 更新股权申请受让数额。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <param name="shareholderNumber">股东号。</param>
        /// <param name="sharesAmount">申请受让股权数量。</param>
        /// <param name="dateForApply">申请日期。</param>
        /// <returns></returns>
        public bool UpdateSharesAmountApplyFor(int issueNumber, int shareholderNumber, int sharesAmount)
        {
            return dal.UpdateSharesAmountApplyFor(issueNumber, shareholderNumber, sharesAmount);
        }
    }
}
