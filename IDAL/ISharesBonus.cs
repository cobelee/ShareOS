using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.IDAL
{
    /// <summary>
    /// 关于股东分红管理类的接口。
    /// </summary>
    public interface ISharesBonus
    {
        /// <summary>
        /// 插入股权交易期数配置。
        /// </summary>
        /// <param name="issueNumber">期数.</param>
        /// <param name="bonus">红利分配数额。每10股分配人民币：x 元/10股。</param>
        /// <param name="sharePrice">分配红利后，每股股价。y 元/股。</param>
        /// <param name="DPD">红利派发日期。</param>
        /// <returns></returns>
        bool InsertSharesIssueConfig(int issueNumber, decimal bonus, decimal sharePrice, DateTime DPD);

        /// <summary>
        /// 删除股权交易期数配置。
        /// </summary>
        /// <param name="issueNumber">股权交易期数</param>
        /// <returns></returns>
        bool DeleteSharesIssueConfig(int issueNumber);

        /// <summary>
        /// 查询股权交易配置信息。
        /// </summary>
        /// <returns></returns>
        //IList<Model.SharesIssueConfig> SelectConfig();

        /// <summary>
        /// 查询指定股权交易期的配置信息。
        /// </summary>
        /// <param name="issueNumber"></param>
        /// <returns></returns>
        Model.SharesIssueConfig SelectConfig(int issueNumber);

        /// <summary>
        /// 获取某一股权交易期所有股东的分红记录。
        /// </summary>
        /// <param name="issueNumber">股权交易期。</param>
        /// <returns></returns>
        DataTable SelectBonusRecord(int issueNumber);

        /// <summary>
        /// 获取某股东历年分红记录。
        /// </summary>
        /// <param name="shareholder">股东。</param>
        /// <returns></returns>
        DataTable SelectBonusRecord(Model.Shareholder shareholder);

        /// <summary>
        /// 分配红利。
        /// </summary>
        /// <param name="issueNumber">股权交易期数</param>
        /// <returns></returns>
        bool PayBonus(int issueNumber);

        /// <summary>
        /// 获取股权交易期数最后一期的值。
        /// </summary>
        /// <returns></returns>
        int GetLastIssueNumber();
    }
}
