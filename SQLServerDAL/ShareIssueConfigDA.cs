using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiyi.ShareOS.SQLServerDAL
{
    public class ShareIssueConfigDA : IDisposable
    {
        ShareDataContext dbContext = new ShareDataContext(Tiyi.ShareOS.SQLServerDAL.Connection.GetConnectionString());

        /// <summary>
        /// 释放由本类占用的所有资源
        /// </summary>
        public void Dispose()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
                dbContext = null;
            }

            GC.SuppressFinalize(this);
        }

        ~ShareIssueConfigDA()
        {
            this.Dispose();
        }


        /// <summary>
        /// 在数据库中新增交易期配置信息。
        /// </summary>
        /// <param name="shareIssue">股东对象。</param>
        /// <returns></returns>
        public Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig CreateShareIssueConfig(Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig shareIssue)
        {
            if (shareIssue != null)
            {
                if (this.ExistConfig((int)(shareIssue.IssueNumber)))
                    throw new Exception("无法开启交易期，第" + shareIssue.IssueNumber + "期已存在。");
                else
                {
                    dbContext.SharesIssueConfig.InsertOnSubmit(shareIssue);
                    dbContext.SubmitChanges();
                }
            }
            return shareIssue;
        }

        /// <summary>
        /// 查询股权交易配置信息。
        /// </summary>
        /// <returns></returns>
        public Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig GetIssueConfigByYear(int year)
        {
            var query = from m in dbContext.SharesIssueConfig
                        where m.IssueYear == year
                        select m;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// 查询指定股权交易期的配置信息。
        /// </summary>
        /// <param name="issueNumber"></param>
        /// <returns></returns>
        public Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig GetIssueConfig(int issueNumber)
        {
            var query = from m in dbContext.SharesIssueConfig
                        where m.IssueNumber == issueNumber
                        select m;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// 查询股权交易配置信息。
        /// </summary>
        /// <returns></returns>
        public IQueryable<Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig> GetAllIssueConfigs()
        {
            var query = from m in dbContext.SharesIssueConfig

                        select m;
            return query.AsQueryable<Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig>();
        }

        /// <summary>
        /// 保存现金派息配置信息。此操作非派息操作。
        /// </summary>
        /// <param name="issueNumber">股权交易期数</param>
        /// <param name="dividend">派息，每10股现金派息金额。</param>
        /// <returns></returns>
        public bool SaveDividendConfig(int issueNumber, decimal dividend)
        {
            bool result = false;
            if (this.ExistConfig((int)(issueNumber)))
            {
                SharesIssueConfig config = this.GetIssueConfig(issueNumber);
                config.Bonus = dividend;
                dbContext.SubmitChanges();
                result = true;
            }
            return result;
        }

        /// <summary>
        /// issueNumber 的股东
        /// </summary>
        /// <param name="issueNumber">股权交易期数</param>
        /// <returns></returns>
        public bool ExistConfig(Int32 issueNumber)
        {
            bool exist = false;
            var query = from m in dbContext.SharesIssueConfig
                        where m.IssueNumber == issueNumber
                        select m;
            if (query.Count() > 0)
            {
                exist = true;
            }
            return exist;
        }
    }
}
