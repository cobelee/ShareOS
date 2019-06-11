using System;
using System.Data;
using System.Collections.Generic;
using ShareOS.IDAL;

namespace ShareOS.BLL
{
    public class ShareholderRegister
    {
        private IShareholderRegister dal = ShareOS.DALFactory.DataAccess.CreateShareholderRegister();

        public bool Create(ShareOS.Model.Shareholder shareholder)
        {
            return dal.InsertShareholder(shareholder);
        }

        public ShareOS.BLL.Shareholder GetShareholder(int shareholderNumber)
        {
            ShareOS.BLL.Shareholder bsh = new Shareholder();
            ShareOS.Model.Shareholder mSh = dal.SelectShareholder(shareholderNumber);
            mSh.CopyTo(bsh as ShareOS.Model.Shareholder);
            return bsh;
        }

        /// <summary>
        /// 获取单个股东信息。
        /// </summary>
        /// <param name="jobNumber">工号。</param>
        /// <returns></returns>
        public ShareOS.Model.Shareholder GetShareholder(string jobNumber)
        {
            return dal.SelectShareholder(jobNumber);
        }

        public IList<ShareOS.Model.Shareholder> GetShareholderList()
        {
            return dal.SelectShareholder();
        }

        /// <summary>
        /// 获取所有股东列表.
        /// </summary>
        /// <returns>返回股东列表Table</returns>
        public DataTable SelectShareholderTable()
        {
            return dal.SelectShareholderTable();
        }

        /// <summary>
        /// 获取所有没有股权的人。
        /// </summary>
        /// <returns></returns>
        public DataTable SelectShareholdersHaveNoShare()
        {
            return dal.SelectShareholdersHaveNoShare();
        }

        public IList<ShareOS.Model.Shareholder> Select(ShareOS.Model.EntrustedAgent entrustedAgent)
        {
            return dal.SelectShareholder(entrustedAgent);
        }

        public bool Update(ShareOS.Model.Shareholder shareholder)
        {
            return dal.UpdateShareholder(shareholder);
        }

        /// <summary>
        /// 更新股东号条形码图片。
        /// </summary>
        /// <param name="shareholderNumber">股东号。</param>
        /// <returns></returns>
        public bool UpdateBarCode(int shareholderNumber, byte[] barCode)
        {
            return dal.UpdateBarCode(shareholderNumber, barCode);
        }

        public bool Delete(int shareholderId)
        {
            return dal.DeleteShareholder(shareholderId);
        }

        /// <summary>
        /// 是否存在股东。
        /// </summary>
        /// <param name="shareholderNumber">股东号。</param>
        /// <returns></returns>
        public bool ExistShareholder(int shareholderNumber)
        {
            return dal.ExistShareholder(shareholderNumber);
        }

        /// <summary>
        /// 是否存在股东。
        /// </summary>
        /// <param name="shareholderNumber">工号。</param>
        /// <returns></returns>
        public bool ExistShareholder(string jobNumber)
        {
            return dal.ExistShareholder(jobNumber);
        }

        /// <summary>
        /// 将范形转化为数据表。
        /// </summary>
        /// <param name="shareholders">泛形结构股东列表。</param>
        /// <returns></returns>
        public DataTable ConvertToDataTable(IList<Model.Shareholder> shareholders)
        {
            DataTable dtShareholders = new DataTable("Shareholder");
            dtShareholders.Columns.Add("编号");
            dtShareholders.Columns.Add("股东号");
            dtShareholders.Columns.Add("工号");
            dtShareholders.Columns.Add("姓名");
            dtShareholders.Columns.Add("性别");
            dtShareholders.Columns.Add("身份证号");
            dtShareholders.Columns.Add("人员类别");
            dtShareholders.Columns.Add("股东状态");
            dtShareholders.Columns.Add("委托代理人");

            foreach (Model.Shareholder sh in shareholders)
            {
                DataRow row = dtShareholders.NewRow();
                row["编号"] = sh.ShareholderId;
                row["股东号"] = sh.ShareholderNumber;
                row["工号"] = sh.JobNumber;
                row["姓名"] = sh.ShareholderName;
                row["性别"] = sh.Sex ? "男" : "女";
                row["身份证号"] = sh.IdentityCard;
                row["人员类别"] = sh.PersonType;
                row["股东状态"] = sh.Status.ToString();

                Model.Shareholder wtShareholder = dal.SelectShareholder(sh.EntrustedAgent);
                row["委托代理人"] = wtShareholder.ShareholderName;

                dtShareholders.Rows.Add(row);
            }

            return dtShareholders;
        }
    }
}
