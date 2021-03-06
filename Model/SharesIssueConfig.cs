using System;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.Model
{
    /// <summary>
    /// 在此处插入对生成类的说明。
    /// </summary>
    [Serializable]
    public class SharesIssueConfig
    {
        private Int32 mSICId;        // Id，程序内部使用
        private Int32 mIssueNumber;        // 期数，股权交易第几期。
        private Int32 mIssueYear;        // 年份，股权交易年份。
        private System.Decimal mBonus;        // 红利，红利派发方法，元/10股。
        private System.DateTime mDPD;        // Divident Payment Date 红利派发日期。
        private System.Decimal mSharePrice;        // 股价，股权交易价格。
        private Boolean mIsDistributed;        // 当期红利是否已分配.

        public SharesIssueConfig()
        {
            InitSharesIssueConfig();
        }

        private void InitSharesIssueConfig()
        {
        }

        /// <summary>
        /// Id，程序内部使用
        /// </summary>
        public Int32 SICId
        {
            get { return mSICId; }
            set { mSICId = value; }
        }

        /// <summary>
        /// 期数，股权交易第几期。
        /// </summary>
        public Int32 IssueNumber
        {
            get { return mIssueNumber; }
            set { mIssueNumber = value; }
        }

        /// <summary>
        /// 年份，股权交易年份。
        /// </summary>
        public Int32 IssueYear
        {
            get { return mIssueYear; }
            set { mIssueYear = value; }
        }

        /// <summary>
        /// 红利，红利派发方法，元/10股。
        /// </summary>
        public Decimal Bonus
        {
            get { return mBonus; }
            set { mBonus = value; }
        }

        /// <summary>
        /// Divident Payment Date 红利派发日期。
        /// </summary>
        public DateTime DPD
        {
            get { return mDPD; }
            set { mDPD = value; }
        }

        /// <summary>
        /// 股价，股权交易价格。
        /// </summary>
        public Decimal SharePrice
        {
            get { return mSharePrice; }
            set { mSharePrice = value; }
        }

        /// <summary>
        /// 当期红利是否已分配.
        /// </summary>
        public Boolean IsDistributed
        {
            get { return mIsDistributed; }
            set { mIsDistributed = value; }
        }

    }
}
