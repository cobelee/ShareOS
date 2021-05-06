using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShareOS.BLL
{
    /// <summary>
    /// 股东管理类
    /// </summary>
    public class ShareholderManage
    {
        private Tiyi.ShareOS.SQLServerDAL.ShareholderDA da = new Tiyi.ShareOS.SQLServerDAL.ShareholderDA();

        /// <summary>
        /// 释放由本类占用的所有资源
        /// </summary>
        public void Dispose()
        {
            da.Dispose();
        }

        /// <summary>
        /// 提交以使数据库更改生效。
        /// </summary>
        public void Submit()
        {
            da.Submit();
        }

        /// <summary>
        /// 在数据库中新增股东对象。
        /// </summary>
        /// <param name="shareholder">股东对象。</param>
        /// <returns></returns>
        public Tiyi.ShareOS.SQLServerDAL.Shareholder CreateShareholder(Tiyi.ShareOS.SQLServerDAL.Shareholder shareholder)
        {
            return da.CreateShareholder(shareholder);
        }

        /// <summary>
        /// 获取指定股东号的股东信息。
        /// </summary>
        /// <param name="shareholderNumber">股东号。</param>
        /// <returns></returns>
        public Tiyi.ShareOS.SQLServerDAL.Shareholder SelectShareholder(int shareholderNumber)
        {
            return da.SelectShareholder(shareholderNumber);
        }

        /// <summary>
        /// 获取指定工号的股东信息。
        /// </summary>
        /// <param name="jobNumber">工号。</param>
        /// <returns></returns>
        public Tiyi.ShareOS.SQLServerDAL.Shareholder SelectShareholder(string jobNumber)
        {
            return da.SelectShareholder(jobNumber);
        }

        /// <summary>
        /// 获取所有股东列表.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Tiyi.ShareOS.SQLServerDAL.Shareholder> SelectShareholder()
        {
            return da.SelectShareholder();
        }

        ///// <summary>
        ///// 获取所有银行对象。
        ///// </summary>
        ///// <returns></returns>
        //public IQueryable<Bank> GetBank()
        //{
        //    var query = from m in dbContext.Bank
        //                select m;
        //    return query.AsQueryable<Bank>();
        //}

        ///// <summary>
        ///// 根据银行编号获取仓库对象。
        ///// </summary>
        ///// <param name="bankId">银行编号。</param>
        ///// <returns></returns>
        //public Bank GetBank(int bankId)
        //{
        //    var query = from m in dbContext.Bank
        //                where m.BankId == bankId
        //                select m;
        //    return query.FirstOrDefault<Bank>();
        //}

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
        /// 在数据库中更新股东信息。
        /// </summary>
        /// <param name="shareHolders">股东对象列表</param>
        public void Update(IQueryable<Tiyi.ShareOS.SQLServerDAL.Shareholder> shareHolders)
        {
            da.Update(shareHolders);
        }

        /// <summary>
        /// 更新股东银行账户信息
        /// </summary>
        /// <param name="shareholder"></param>
        public void Update(Tiyi.ShareOS.SQLServerDAL.Shareholder shareholder)
        {
            da.Update(shareholder);
        }

        /// <summary>
        /// 是否存在指定jobNumber 股东
        /// </summary>
        /// <param name="jobNumber">股东</param>
        /// <returns></returns>
        public bool ExistShareholder(string jobNumber)
        {
            return da.ExistShareholder(jobNumber);
        }

        /// <summary>
        /// 是否存在指定shareholderNumber 的股东
        /// </summary>
        /// <param name="shareholderNumber">股东号</param>
        /// <returns></returns>
        public bool ExistShareholder(Int32 shareholderNumber)
        {
            return da.ExistShareholder(shareholderNumber);
        }
    }
}
