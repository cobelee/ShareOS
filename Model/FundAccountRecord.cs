using System;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.Model
{
    /// <summary>
    /// 在此处插入对生成类的说明。
    /// </summary>
    [Serializable]
    public class FundAccountRecord
    {
        private Int32 mFundAccountId;        // 资金帐户变动记录Id.
        private Int32 mIssueNumber;        // 股权交易期数.
        private Int32 mShareholderNumber;        // 股东号。
        private System.Decimal mChangeMoney;        // 帐户资金。正为帐户资金增加，负为帐户资金减少。
        private String mChangeReason;        // 帐户变动原因。比如：购股、分红。
        private System.DateTime mChangeDate;        // 记录变动日期。

        public FundAccountRecord()
        {
            InitFundAccount();
        }

        private void InitFundAccount()
        {
            mChangeReason = string.Empty;
        }

        /// <summary>
        /// 资金帐户变动记录Id.
        /// </summary>
        public Int32 FundAccountId
        {
            get { return mFundAccountId; }
            set { mFundAccountId = value; }
        }

        /// <summary>
        /// 股权交易期数.
        /// </summary>
        public Int32 IssueNumber
        {
            get { return mIssueNumber; }
            set { mIssueNumber = value; }
        }

        /// <summary>
        /// 股东号。
        /// </summary>
        public Int32 ShareholderNumber
        {
            get { return mShareholderNumber; }
            set { mShareholderNumber = value; }
        }

        /// <summary>
        /// 帐户资金。正为帐户资金增加，负为帐户资金减少。
        /// </summary>
        public System.Decimal ChangeMoney
        {
            get { return mChangeMoney; }
            set { mChangeMoney = value; }
        }

        /// <summary>
        /// 帐户变动原因。比如：购股、分红。
        /// </summary>
        public String ChangeReason
        {
            get { return mChangeReason; }
            set { mChangeReason = value; }
        }

        /// <summary>
        /// 记录变动日期。
        /// </summary>
        public System.DateTime ChangeDate
        {
            get { return mChangeDate; }
            set { mChangeDate = value; }
        }

    }
}
