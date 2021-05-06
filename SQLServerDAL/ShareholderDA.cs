using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiyi.ShareOS.SQLServerDAL
{
    public class ShareholderDA : IDisposable
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

        ~ShareholderDA()
        {
            this.Dispose();
        }

        /// <summary>
        /// 提交以使数据库更改生效。
        /// </summary>
        public void Submit()
        {
            dbContext.SubmitChanges();
        }

        ///// <summary>
        ///// 获取现有银行数量。
        ///// </summary>
        ///// <returns></returns>
        //public int GetCountOfBank()
        //{
        //    int count = 0;
        //    var query = from s in dbContext.Bank
        //                select s;
        //    count = query.Count();
        //    return count;
        //}

        /// <summary>
        /// 在数据库中新增股东对象。
        /// </summary>
        /// <param name="shareholder">股东对象。</param>
        /// <returns></returns>
        public Tiyi.ShareOS.SQLServerDAL.Shareholder CreateShareholder(Tiyi.ShareOS.SQLServerDAL.Shareholder shareholder)
        {
            if (shareholder != null)
            {
                if (this.ExistShareholder(shareholder.ShareholderNumber))
                    throw new Exception("数据库中已存在股东号为 " + shareholder.ShareholderNumber + " 的股东,无法插创建新记录");
                else
                {
                    dbContext.Shareholder.InsertOnSubmit(shareholder);
                    dbContext.SubmitChanges();
                }
            }
            return shareholder;
        }

        /// <summary>
        /// 获取指定股东号的股东信息。
        /// </summary>
        /// <param name="shareholderNumber">股东号。</param>
        /// <returns></returns>
        public Tiyi.ShareOS.SQLServerDAL.Shareholder SelectShareholder(int shareholderNumber)
        {
            var query = from item in dbContext.Shareholder
                        where item.ShareholderNumber == shareholderNumber
                        select item;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// 获取指定工号的股东信息。
        /// </summary>
        /// <param name="jobNumber">工号。</param>
        /// <returns></returns>
        public Tiyi.ShareOS.SQLServerDAL.Shareholder SelectShareholder(string jobNumber)
        {
            var query = from item in dbContext.Shareholder
                        where item.JobNumber == jobNumber
                        select item;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// 获取所有股东列表.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Tiyi.ShareOS.SQLServerDAL.Shareholder> SelectShareholder()
        {
            var query = from item in dbContext.Shareholder
                        where item.Status == "股东" || item.Status == "待退股东"
                        select item;
            return query;
        }


        /// <summary>
        /// 在数据库中更新股东部门信息。
        /// </summary>
        /// <param name="shareHolders">股东对象列表</param>
        public void Update(IQueryable<Tiyi.ShareOS.SQLServerDAL.Shareholder> shareHolders)
        {
            if (shareHolders != null && shareHolders.Count() > 0)
                dbContext.SubmitChanges();
        }

        /// <summary>
        /// 更新股东银行账户信息
        /// </summary>
        /// <param name="shareholder"></param>
        public void Update(Tiyi.ShareOS.SQLServerDAL.Shareholder shareholder)
        {
            var gd = SelectShareholder(shareholder.ShareholderNumber);
            if (gd == null)
                return;

            gd.AccountHolder = shareholder.AccountHolder;
            gd.BankName = shareholder.BankName;
            gd.AccountNumber = shareholder.AccountNumber;
            dbContext.SubmitChanges();
        }

        ///// <summary>
        ///// 删除指定 storeId 的参数对。
        ///// </summary>
        ///// <param name="storeId">仓库Id.</param>
        //public void DeleteBank(int bankId)
        //{
        //    var query = from s in dbContext.Bank
        //                where s.BankId == bankId
        //                select s;
        //    foreach (var para in query)
        //    {
        //        dbContext.Bank.DeleteOnSubmit(para);
        //    }

        //    try
        //    {
        //        dbContext.SubmitChanges();
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        /// <summary>
        /// 是否存在指定jobNumber 股东
        /// </summary>
        /// <param name="jobNumber">股东</param>
        /// <returns></returns>
        public bool ExistShareholder(string jobNumber)
        {
            bool exist = false;
            var query = from m in dbContext.Shareholder
                        where m.JobNumber == jobNumber
                        select m;
            if (query.Count() > 0)
            {
                exist = true;
            }
            return exist;
        }

        /// <summary>
        /// 是否存在指定shareholderNumber 的股东
        /// </summary>
        /// <param name="shareholderNumber">股东号</param>
        /// <returns></returns>
        public bool ExistShareholder(Int32 shareholderNumber)
        {
            bool exist = false;
            var query = from m in dbContext.Shareholder
                        where m.ShareholderNumber == shareholderNumber
                        select m;
            if (query.Count() > 0)
            {
                exist = true;
            }
            return exist;
        }
    }
}
