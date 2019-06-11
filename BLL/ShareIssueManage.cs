using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShareOS.BLL
{
    /// <summary>
    /// 股权期配置管理
    ///
    /// </summary>
    public class ShareIssueManage
    {
        private Tiyi.ShareOS.SQLServerDAL.ShareIssueConfigDA da = new Tiyi.ShareOS.SQLServerDAL.ShareIssueConfigDA();

        /// <summary>
        /// 释放由本类占用的所有资源
        /// </summary>
        public void Dispose()
        {
            da.Dispose();
        }

        /// <summary>
        /// 在数据库中新增交易期配置信息。
        /// </summary>
        /// <param name="shareIssue">股东对象。</param>
        /// <returns></returns>
        public Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig OpenShareIssue(Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig shareIssue)
        {
            shareIssue.IsOpen = true;
            return da.CreateShareIssueConfig(shareIssue);
        }

        /// <summary>
        /// 保存现金派息配置信息。此操作非派息操作。
        /// </summary>
        /// <param name="issueNumber">股权交易期数</param>
        /// <param name="dividend">派息，每10股现金派息金额。</param>
        /// <returns></returns>
        public bool SaveDividendConfig(int issueNumber, decimal dividend)
        {
            return da.SaveDividendConfig(issueNumber, dividend);
        }

        /// <summary>
        /// 查询股权交易配置信息。
        /// </summary>
        /// <returns></returns>
        public Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig GetIssueConfigByYear(int year)
        {
            return da.GetIssueConfigByYear(year);
        }

        /// <summary>
        /// 查询指定股权交易期的配置信息。
        /// </summary>
        /// <param name="issueNumber"></param>
        /// <returns></returns>
        public Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig GetIssueConfig(int issueNumber)
        {
            return da.GetIssueConfig(issueNumber);
        }

        /// <summary>
        /// 查询股权交易配置信息。
        /// </summary>
        /// <returns></returns>
        public IQueryable<Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig> GetAllIssueConfigs()
        {
            return da.GetAllIssueConfigs();
        }

        /// <summary>
        /// issueNumber 的股东
        /// </summary>
        /// <param name="issueNumber">股权交易期数</param>
        /// <returns></returns>
        public bool ExistConfig(Int32 issueNumber)
        {
            return da.ExistConfig(issueNumber);
        }
    }
}
