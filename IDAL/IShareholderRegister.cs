using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using ShareOS.Model;

namespace ShareOS.IDAL
{
    public interface IShareholderRegister
    {
        /// <summary>
        /// 新增股东.
        /// </summary>
        /// <param name="shareholder">股东.</param>
        /// <returns></returns>
        bool InsertShareholder(ShareOS.Model.Shareholder shareholder);

        /// <summary>
        /// 获取道德观有
        /// </summary>
        /// <param name="shareholderNumber">股东号.</param>
        /// <returns></returns>
        ShareOS.Model.Shareholder SelectShareholder(int shareholderNumber);

        /// <summary>
        /// 获取lbShareholderName
        /// </summary>
        /// <param name="jobNumber">工号。</param>
        /// <returns></returns>
        ShareOS.Model.Shareholder SelectShareholder(string jobNumber);

        /// <summary>
        /// 获取所有股东列表.
        /// </summary>
        /// <returns></returns>
        IList<ShareOS.Model.Shareholder> SelectShareholder();

        /// <summary>
        /// 获取所有股东列表.
        /// </summary>
        /// <returns>返回股东列表Table</returns>
        DataTable SelectShareholderTable();

        /// <summary>
        /// 获取所有没有股权的人。
        /// </summary>
        /// <returns></returns>
        DataTable SelectShareholdersHaveNoShare();

        /// <summary>
        /// 获取某委托代理人名下管理的所有股东列表。
        /// </summary>
        /// <param name="entrustedAgent">委托代理人。</param>
        /// <returns></returns>
        IList<ShareOS.Model.Shareholder> SelectShareholder(EntrustedAgent entrustedAgent);

        /// <summary>
        /// 更新股东信息。
        /// </summary>
        /// <param name="shareholder">股东</param>
        /// <returns></returns>
        bool UpdateShareholder(ShareOS.Model.Shareholder shareholder);

        /// <summary>
        /// 更新股东号条形码图片。
        /// </summary>
        /// <param name="shareholderNumber">股东号。</param>
        /// <returns></returns>
        bool UpdateBarCode(int shareholderNumber, byte[] barCode);

        /// <summary>
        /// 删除股东。
        /// </summary>
        /// <param name="shareholderId">股东代号。（非股东号）</param>
        /// <returns></returns>
        bool DeleteShareholder(int shareholderId);

        /// <summary>
        /// 是否存在股东。
        /// </summary>
        /// <param name="shareholderNumber">股东号。</param>
        /// <returns></returns>
        bool ExistShareholder(int shareholderNumber);

        /// <summary>
        /// 是否存在股东。
        /// </summary>
        /// <param name="shareholderNumber">工号。</param>
        /// <returns></returns>
        bool ExistShareholder(string jobNumber);
    }
}
