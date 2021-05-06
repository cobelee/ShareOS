using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShareOS.BLL
{
    public class FinanceReport
    {
        private ShareOS.SQLServerDAL.FinanceDAO dao = new ShareOS.SQLServerDAL.FinanceDAO();


        #region  关于生成报告的方法
        /// <summary>
        /// 在 Settlement 表中,批量生成退休离职人员的清算记录.
        /// 注意：此方法只能为退休、离职、死亡人员进行清股清算。
        /// </summary>
        /// <param name="issueNumber">股权交易期数</param>
        /// <returns></returns>
        public bool GenerateClearingReport(int issueNumber)
        {
            return dao.GenerateClearingReport(issueNumber);
        }

        /// <summary>
        /// 在 Settlement 表中,批量生成在职股东的年度结算记录.
        /// 注意：此方法只能为在职股东进行年度结算。
        /// </summary>
        /// <param name="issueNumber">股权交易期数</param>
        /// <returns></returns>
        public bool GenerateSettlementReport(int issueNumber)
        {
            return dao.GenerateSettlementReport(issueNumber);
        }
        #endregion


        #region 关于获取报告的方法

        /// <summary>
        /// 获取指定股权交易期，在职股东(除待退股东)申请转让,申请受让数据采集表。
        /// </summary>
        /// <param name="issueNumber"></param>
        /// <returns></returns>
        public DataTable GetDataCollectionTable(int issueNumber)
        {
            return dao.GetDataCollectionTable(issueNumber);
        }

        /// <summary>
        /// 获取指定交易期,股权转让结算报告。
        /// 注意：此方法可以获取所有在职股东、退休、离职、死亡人员的结算报告，在实际应用中，可根据人员类别进行筛选。
        /// </summary>
        /// <param name="issueNumber">股权交易期数.</param>
        /// <returns></returns>
        public DataTable GetSettlementReport(int issueNumber)
        {
            return dao.GetSettlementReport(issueNumber);
        }

        /// <summary>
        /// 获取指定交易期，递交银行的转账清单。
        /// 该清单包括所有在职、退休、离职、死亡人员，可按银行进行筛选，分别递交不同的银行。
        /// </summary>
        /// <param name="issueNumber">股权交易期数.</param>
        /// <returns></returns>
        public DataTable GetBankPaymentSlip(int issueNumber)
        {
            return dao.GetBankPaymentSlip(issueNumber);
        }
        #endregion

        /// <summary>
        /// 获取所有股东开户银行列表.
        /// </summary>
        /// <returns></returns>
        public IQueryable<ShareOS.SQLServerDAL.Bank> GetBankNameList()
        {
            return dao.GetBankNameList();
        }
    }
}
