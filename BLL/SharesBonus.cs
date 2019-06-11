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
        /// 插入股权交易期数配置。
        /// </summary>
        /// <param name="issueNumber">期数.</param>
        /// <param name="bonus">红利分配数额。每10股分配人民币：x 元/10股。</param>
        /// <param name="sharePrice">分配红利后，每股股价。y 元/股。</param>
        /// <param name="DPD">红利派发日期。</param>
        /// <returns></returns>
        public bool InsertSharesIssueConfig(int issueNumber, decimal bonus, decimal sharePrice, DateTime DPD)
        {
            return dal.InsertSharesIssueConfig(issueNumber, bonus, sharePrice, DPD);
        }

        /// <summary>
        /// 删除股权交易期数配置。
        /// </summary>
        /// <param name="issueNumber">股权交易期数</param>
        /// <returns></returns>
        public bool DeleteSharesIssueConfig(int issueNumber)
        {
            return dal.DeleteSharesIssueConfig(issueNumber);
        }

        /// <summary>
        /// 查询指定股权交易期的配置信息。
        /// </summary>
        /// <param name="issueNumber">股权交易期数。</param>
        /// <returns></returns>
        public Model.SharesIssueConfig SelectConfig(int issueNumber)
        {
            return dal.SelectConfig(issueNumber);
        }

        /// <summary>
        /// 分配红利。
        /// </summary>
        /// <param name="issueNumber">股权交易期数</param>
        /// <returns></returns>
        public bool PayBonus(int issueNumber)
        {
            return dal.PayBonus(issueNumber);
        }

        /// <summary>
        /// 获取股权交易期数最后一期的值。
        /// <para>[否决]该方法已移至 MonitorOffice 类中</para>
        /// </summary>
        /// <returns></returns>
        public int GetLastIssueNumber()
        {
            return dal.GetLastIssueNumber();
        }

        /// <summary>
        /// 获取某一股权交易期所有股东的分红记录。
        /// </summary>
        /// <param name="issueNumber">股权交易期。</param>
        /// <returns></returns>
        public DataTable SelectBonusRecord(int issueNumber)
        {
            return dal.SelectBonusRecord(issueNumber);
        }

        /// <summary>
        /// 获取某股东历年分红记录。
        /// </summary>
        /// <param name="shareholder">股东。</param>
        /// <returns></returns>
        public DataTable SelectBonusRecord(ShareOS.Model.Shareholder shareholder)
        {
            return dal.SelectBonusRecord(shareholder);
        }
    }
}
