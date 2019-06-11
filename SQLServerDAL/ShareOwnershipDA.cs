using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tiyi.ShareOS.SQLServerDAL
{


    public class ShareOwnershipDA : IDisposable
    {
        Tiyi.ShareOS.SQLServerDAL.ShareDataContext dbContext = new Tiyi.ShareOS.SQLServerDAL.ShareDataContext(Tiyi.ShareOS.SQLServerDAL.Connection.GetConnectionString());

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

        ~ShareOwnershipDA()
        {
            this.Dispose();
        }

        /// <summary>
        /// 股权增减。
        /// </summary>
        /// <param name="shareholderNumber">股东号。</param>
        /// <param name="sharesChanges">股权改变量。正数代表股权增加，负数代表股权减少。</param>
        /// <param name="originalSharePrice">原始股价，即为购买股权时价格。</param>
        /// <param name="causeOfChange">股权数变动原因</param>
        /// <param name="isPrincipal">是否是自己出资购买的</param>
        /// <param name="operatorName">操作员名称。</param>
        /// <returns></returns>
        public bool ChangeGuQuanShu(int shareholderNumber, decimal sharesChanges, decimal originalSharePrice, string causeOfChange, bool isPrincipal, string operatorName)
        {
            Tiyi.ShareOS.SQLServerDAL.ShareOwnership guQuan = new SQLServerDAL.ShareOwnership();
            decimal sharesTotal = GetPersonalShareTotals(shareholderNumber);

            int lastIssueNumber = 0;
            var query = from c in dbContext.SharesIssueConfig
                        orderby c.IssueNumber descending
                        select c;
            Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig config = query.FirstOrDefault();

            if (config != null)
                lastIssueNumber = (int)(config.IssueNumber);

            guQuan.IssueNumber = lastIssueNumber;
            guQuan.ShareholderNumber = shareholderNumber;
            guQuan.SharesChanges = sharesChanges;
            guQuan.ShareTotals = sharesTotal + sharesChanges;
            guQuan.OriginalSharePrice = originalSharePrice;
            guQuan.CauseOfChange = causeOfChange;
            guQuan.IsPrincipal = isPrincipal;
            guQuan.RegDate = DateTime.Now;
            guQuan.Operator = operatorName;

            dbContext.ShareOwnership.InsertOnSubmit(guQuan);
            dbContext.SubmitChanges();
            return true;
        }

        /// <summary>
        /// 批量清退股权
        /// <para>只能清退当年股权。</para>
        /// </summary>
        /// <param name="sharehoderNumbers">股东号列表</param>
        /// <param name="opeName">操作员</param>
        public void QingtuiShares_Bat(int[] sharehoderNumbers, string opeName)
        {
            if (sharehoderNumbers == null || sharehoderNumbers.Count() == 0)
                return;

            var query = from m in dbContext.SharesIssueConfig
                        where m.IssueYear == DateTime.Now.Year
                        select m;
            Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig config = query.FirstOrDefault();
            if (config == null)
                return;

            decimal currentPrice = (decimal)config.SharePrice;
            int lastIssueNumber = (int)config.IssueNumber;

            foreach (int shNum in sharehoderNumbers)
            {
                decimal sharesTotal = this.GetPersonalShareTotals(shNum);

                Tiyi.ShareOS.SQLServerDAL.ShareOwnership guQuan = new SQLServerDAL.ShareOwnership();
                guQuan.IssueNumber = lastIssueNumber;
                guQuan.ShareholderNumber = shNum;
                guQuan.SharesChanges = -sharesTotal;
                guQuan.ShareTotals = 0;
                guQuan.OriginalSharePrice = currentPrice;
                guQuan.CauseOfChange = "退股";
                guQuan.IsPrincipal = false;
                guQuan.RegDate = DateTime.Now;
                guQuan.Operator = opeName;

                dbContext.ShareOwnership.InsertOnSubmit(guQuan);
            }
            dbContext.SubmitChanges();
        }

        /// <summary>
        /// 获取所有股东股权报告。
        /// </summary>
        /// <returns></returns>
        public DataTable GetShareOwnershipReport(int issueNumber)
        {
            var p = from c in dbContext.Shareholder
                    where dbContext.GetCurrentTotalSharesInIssueNumber(c.ShareholderNumber, issueNumber) > 0
                    select new ShareholderCurrentShares
                    {
                        ShareholderId = c.ShareholderId,
                        ShareholderNumber = c.ShareholderNumber,
                        BarCode = c.BarCode,
                        JobNumber = c.JobNumber,
                        ShareholderName = c.ShareholderName,
                        Sex = c.Sex == null ? true : c.Sex.Value,
                        IdentityCard = c.IdentityCard,
                        PersonType = c.PersonType,
                        EntrustedAgent = c.EntrustedAgent == null ? 0 : c.EntrustedAgent.Value,
                        EntrustedAgentName = dbContext.GetShareholderName(c.EntrustedAgent.Value),
                        QichuShares = dbContext.GetQichuSharesInIssueNumber(c.ShareholderNumber, issueNumber).GetValueOrDefault(),
                        ShareTotals = dbContext.GetCurrentTotalSharesInIssueNumber(c.ShareholderNumber, issueNumber).Value,
                        Department = c.DepName
                    };

            return LinqConvertor.ToDataTable(p);
        }

        /// <summary>
        /// 获取选定股东的股权报告
        /// </summary>
        /// <param name="sharehoderNumbers">股东号列表</param>
        /// <returns></returns>
        public DataTable GetShareOwnershipReportTable(int[] sharehoderNumbers)
        {
            if (sharehoderNumbers == null || sharehoderNumbers.Count() == 0)
                return null;


            List<ShareholderCurrentShares> listPersonShare = new List<ShareholderCurrentShares>();

            listPersonShare = GetShareOwnershipReport(sharehoderNumbers);

            if (listPersonShare.Count > 0)
                return LinqConvertor.LinqToDataTable(listPersonShare);
            else
                return null;
        }

        /// <summary>
        /// 获取选定股东的股权报告
        /// </summary>
        /// <param name="sharehoderNumbers">股东号列表</param>
        /// <returns></returns>
        public List<ShareholderCurrentShares> GetShareOwnershipReport(int[] sharehoderNumbers)
        {
            if (sharehoderNumbers == null || sharehoderNumbers.Count() == 0)
                return null;

            var query = from m in dbContext.SharesIssueConfig
                        where m.IssueYear == DateTime.Now.Year
                        select m;
            Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig config = query.FirstOrDefault();
            if (config == null)
                return null;
            int issueNumber = (int)config.IssueNumber;

            List<ShareholderCurrentShares> listPersonShare = new List<ShareholderCurrentShares>();

            foreach (int shNum in sharehoderNumbers)
            {
                var p = from c in dbContext.Shareholder
                        where c.ShareholderNumber == shNum
                        select new ShareholderCurrentShares
                        {
                            ShareholderId = c.ShareholderId,
                            ShareholderNumber = c.ShareholderNumber,
                            BarCode = c.BarCode,
                            JobNumber = c.JobNumber,
                            ShareholderName = c.ShareholderName,
                            Sex = c.Sex == null ? true : c.Sex.Value,
                            IdentityCard = c.IdentityCard,
                            PersonType = c.PersonType,
                            EntrustedAgent = c.EntrustedAgent == null ? 0 : c.EntrustedAgent.Value,
                            EntrustedAgentName = dbContext.GetShareholderName(c.EntrustedAgent.Value),
                            QichuShares = dbContext.GetQichuSharesInIssueNumber(c.ShareholderNumber, issueNumber).GetValueOrDefault(),
                            ShareTotals = dbContext.GetCurrentTotalSharesInIssueNumber(c.ShareholderNumber, issueNumber).Value,
                            Department = c.DepName
                        };

                ShareholderCurrentShares pShares = p.FirstOrDefault();
                if (pShares != null)
                    listPersonShare.Add(pShares);
            }

            return listPersonShare;
        }

        /// <summary>
        /// 获取股东最终持股总数。
        /// </summary>
        /// <param name="shareholderNumber">股东号。</param>
        /// <returns></returns>
        public decimal GetPersonalShareTotals(int shareholderNumber)
        {
            decimal shareTotals = 0;

            var query = from m in dbContext.ShareOwnership
                        where m.ShareholderNumber == shareholderNumber
                        orderby m.RegDate descending
                        select m;
            Tiyi.ShareOS.SQLServerDAL.ShareOwnership guQuan = query.FirstOrDefault();

            if (guQuan != null)
            {
                shareTotals = (decimal)(guQuan.ShareTotals);
            }

            return shareTotals;
        }

        /// <summary>
        /// 获取购买股权个人总出资额
        /// </summary>
        /// <param name="shareholderNumber">股东号</param>
        /// <returns></returns>
        public decimal GetPersonalSharesOriginalValue(int shareholderNumber)
        {
            decimal oriValue = 0;

            var query = from m in dbContext.ShareOwnership
                        where m.ShareholderNumber == shareholderNumber && m.IsPrincipal == true
                        select m;
            oriValue = query.Sum(u => u.SharesChanges.Value * u.OriginalSharePrice.Value);
            return oriValue;
        }

        /// <summary>
        /// 获取指定股东的清退股权记录。
        /// </summary>
        /// <param name="sharehoderNumber">股东号。</param>
        /// <returns></returns>
        public Tiyi.ShareOS.SQLServerDAL.ShareOwnership GetPersonalClearingRecord(int sharehoderNumber)
        {
            var query = from m in dbContext.ShareOwnership
                        where m.ShareholderNumber == sharehoderNumber && m.ShareTotals.Value == 0
                        select m;
            return query.FirstOrDefault();
        }


        ///// <summary>
        ///// 获取所有股东期初股权报告。(未实现)
        ///// </summary>
        ///// <param name="issueNumber">股权交易期数</param>
        ///// <returns></returns>
        //public DataTable GetQichuShareOwnership(int issueNumber)
        //{
        //    var query = from item in dbContext.ShareOwnership
        //                //where item.IsReadyMark == isReadyMark && item.ExchangeType == forexExchangeType
        //                select item;
        //    query = query.OrderByDescending(item => item.IssueNumber);
        //    return query.AsQueryable<db.ShareOwnership>().ToList<>();
        //}

        ///// <summary>
        ///// 获取所有股东期初股权报告。(未实现)
        ///// </summary>
        ///// <param name="issueNumber">股权交易期数</param>
        ///// <returns></returns>
        //public DataTable GetQichuShareOwnership(int issueNumber)
        //{
        //    var query = from item in dbContext.ShareOwnership
        //                //where item.IsReadyMark == isReadyMark && item.ExchangeType == forexExchangeType
        //                select item;
        //    query = query.OrderByDescending(item => item.IssueNumber);
        //    return query.AsQueryable<db.ShareOwnership>().ToList<>();
        //}

        ///// <summary>
        ///// 创建外汇兑换操作记录
        ///// </summary>
        ///// <param name="forexAccount">外汇兑换账户</param>
        ///// <param name="currencyAmount">外汇金额数量</param>
        ///// <param name="currencyType">外汇货币种类</param>
        ///// <param name="forexExchangeType">外汇兑换类型：购汇、结汇</param>
        ///// <param name="remark">备注</param>
        ///// <param name="applicant">操作人</param>
        ///// <returns></returns>
        //public ForexRecord NewForexRecord(Account forexAccount, decimal currencyAmount, string currencyType, string forexExchangeType, string remark, Operator applicant)
        //{
        //    ForexRecord record = new ForexRecord()
        //    {
        //        AccountId = forexAccount.AccountId,
        //        AccountTitle = forexAccount.AccountTitle,
        //        AccountNumber = forexAccount.AccountNumber,
        //        BankName = forexAccount.BankName,

        //        CurrencyAmount = currencyAmount,
        //        CurrencyType = currencyType,
        //        ExchangeType = forexExchangeType,
        //        Remark = remark,

        //        ApplicantJobNumber = applicant.JobNumber,
        //        ApplicantName = applicant.Name,
        //        ApplicantDate = System.DateTime.Now,

        //        ExchangeRate = (decimal)0,

        //        IsReadyMark = false,
        //        IsChargedMark = false,
        //        IsClosedMark = false,
        //        IsCanceled = false

        //    };
        //    dbContext.ForexRecord.InsertOnSubmit(record);
        //    dbContext.SubmitChanges();

        //    return record;
        //}


        ///// <summary>
        ///// 获取指定外汇准备妥当标记的 外汇兑换记录。
        ///// </summary>
        ///// <param name="isReadyMark">外汇兑换操作是否完成标记</param>
        ///// <param name="forexExchangeType">外汇兑换类型：购汇、结汇</param>
        ///// <returns></returns>
        //public IQueryable<ForexRecord> GetForexRecords_ByReadyMark(bool isReadyMark, string forexExchangeType)
        //{
        //    var query = from item in dbContext.ForexRecord
        //                where item.IsReadyMark == isReadyMark && item.ExchangeType == forexExchangeType
        //                select item;
        //    query = query.OrderByDescending(item => item.FrId);
        //    return query.AsQueryable<ForexRecord>();
        //}

        ///// <summary>
        ///// 获取指定记账标记的 外汇兑换记录。
        ///// </summary>
        ///// <param name="isChargedMark">记账标记</param>
        ///// <returns></returns>
        //public IQueryable<ForexRecord> GetForexRecords_ByChargedMark(bool isChargedMark)
        //{
        //    var query = from item in dbContext.ForexRecord
        //                where item.IsChargedMark == isChargedMark
        //                select item;
        //    query = query.OrderByDescending(item => item.FrId);
        //    return query.AsQueryable<ForexRecord>();
        //}

        ///// <summary>
        ///// 获取指定业务关闭标记的 外汇兑换记录。
        ///// </summary>
        ///// <param name="isClosedMark">业务关闭标记</param>
        ///// <returns></returns>
        //public IQueryable<ForexRecord> GetForexRecords_ByClosedMark(bool isClosedMark)
        //{
        //    var query = from item in dbContext.ForexRecord
        //                where item.IsClosedMark == isClosedMark
        //                select item;
        //    query = query.OrderByDescending(item => item.FrId);
        //    return query.AsQueryable<ForexRecord>();
        //}

        ///// <summary>
        ///// 获取已完成所有外汇兑换操作的历史记录。
        ///// </summary>
        ///// <returns></returns>
        //public IQueryable<ForexRecord> GetHistoryForexRecords()
        //{
        //    var query = from item in dbContext.ForexRecord
        //                where item.IsReadyMark == true && item.IsChargedMark == true
        //                select item;
        //    query = query.OrderByDescending(item => item.FrId);
        //    return query.AsQueryable<ForexRecord>();
        //}

        ///// <summary>
        ///// 获取指定 frId 的外汇兑换操作记录。
        ///// </summary>
        ///// <param name="frId"></param>
        ///// <returns></returns>
        //public ForexRecord GetForexRecord(long frId)
        //{
        //    var query = from item in dbContext.ForexRecord
        //                where item.FrId == frId
        //                select item;
        //    return query.FirstOrDefault<ForexRecord>();
        //}

        ///// <summary>
        ///// 确认外汇兑换操作已完成。
        ///// </summary>
        ///// <param name="newRecord">外汇兑换操作。</param>
        //public void MarkReady(ForexRecord newRecord)
        //{
        //    newRecord.ForexDate = System.DateTime.Now;
        //    dbContext.SubmitChanges();
        //}

        ///// <summary>
        ///// 标记记录已完成记账操作。
        ///// </summary>
        ///// <param name="newRecord">外汇兑换操作。</param>
        //public void MarkCharged(ForexRecord newRecord)
        //{
        //    newRecord.AccountantDate = System.DateTime.Now;
        //    dbContext.SubmitChanges();
        //}

        ///// <summary>
        ///// 标记业务完成，或业务关闭。
        ///// </summary>
        ///// <param name="newRecord">外汇业务记录。</param>
        //public void MarkClosed(ForexRecord newRecord)
        //{
        //    newRecord.IsClosedMark = true;
        //    dbContext.SubmitChanges();
        //}

        ///// <summary>
        ///// 取消业务
        ///// </summary>
        ///// <param name="newRecord">资金划转记录。</param>
        //public void CancelBusiness(long frId, string cancelReson)
        //{
        //    ForexRecord record = GetForexRecord(frId);
        //    record.CancelReson = cancelReson;
        //    record.IsCanceled = true;
        //    dbContext.SubmitChanges();
        //}

        ///// <summary>
        ///// 自动关闭业务。
        ///// <para>关闭业务已作废，且超过三天的业务</para>
        ///// </summary>
        //public void AutoCloseBusiness()
        //{
        //    var query1 = from item in dbContext.ForexRecord
        //                 where item.IsCanceled == true && (item.ApplicantDate.Value.AddDays(3) < System.DateTime.Now)
        //                 select item;
        //    foreach (ForexRecord record in query1.AsQueryable())
        //    {
        //        record.IsClosedMark = true;
        //    }
        //    dbContext.SubmitChanges();
        //}
    }

    public class ShareholderCurrentShares
    {
        public int ShareholderId { get; set; }
        public int ShareholderNumber { get; set; }
        public System.Data.Linq.Binary BarCode { get; set; }
        public string JobNumber { get; set; }
        public string ShareholderName { get; set; }
        public bool Sex { get; set; }
        public string IdentityCard { get; set; }
        public string PersonType { get; set; }
        public int EntrustedAgent { get; set; }
        public string EntrustedAgentName { get; set; }
        public decimal QichuShares { get; set; }
        public decimal ShareTotals { get; set; }
        public string Department { get; set; }
    }

    public class LinqConvertor
    {
        public static System.Data.DataTable LinqToDataTable<T>(IEnumerable<T> data)
        {
            var dt = new System.Data.DataTable();
            var ps = typeof(T).GetProperties().ToList();
            ps.ForEach(p => dt.Columns.Add(p.Name, p.PropertyType));
            foreach (T t in data)
            {
                var dr = dt.NewRow();
                var vs = from p in ps select p.GetValue(t, null);
                var ls = vs.ToList();
                int i = 0;
                ls.ForEach(c => dr[i++] = c);
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public static System.Data.DataTable ToDataTable<T>(IEnumerable<T> data)
        {
            var dt = new System.Data.DataTable();
            var ps = System.ComponentModel.TypeDescriptor.GetProperties(typeof(T));
            foreach (System.ComponentModel.PropertyDescriptor dp in ps)
                dt.Columns.Add(dp.Name, dp.PropertyType);
            foreach (T t in data)
            {
                var dr = dt.NewRow();
                foreach (System.ComponentModel.PropertyDescriptor dp in ps)
                    dr[dp.Name] = dp.GetValue(t);
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
