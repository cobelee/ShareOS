using System;
using System.Collections.Generic;
using System.Text;

namespace ShareOS.Model
{
    public class SharesWithdrawalReport
    {
        private DateTime withdrawalDate;
        private int withdrawalSharesAmount;
        private decimal currentSharePrice;
        private decimal withdrawalSharesCurrentValue;
        private decimal withdrawalSharesOriginalValue;
        private decimal taxRate;
        private decimal incomTax;
        private decimal pretaxProfits;
        private decimal aftertaxProfits;
        private decimal returnCash;

        public SharesWithdrawalReport()
        {
            taxRate = 0m;
            Calculate();
        }

        public SharesWithdrawalReport(decimal taxRate)
        {
            this.taxRate = taxRate;
            Calculate();
        }

        /// <summary>
        /// 获取退股后实际返还现金。
        /// </summary>
        public decimal ReturnCash
        {
            get { return returnCash; }
        }

        /// <summary>
        /// 计算个人所得税及收益。
        /// </summary>
        protected void Calculate()
        {
            pretaxProfits = withdrawalSharesCurrentValue - withdrawalSharesOriginalValue;
            incomTax = pretaxProfits * taxRate;
            aftertaxProfits = pretaxProfits - incomTax;
            returnCash = withdrawalSharesCurrentValue - incomTax;
        }

        /// <summary>
        /// 获取个人所得税额。
        /// </summary>
        public decimal IncomTax
        {
            get { return incomTax; }
        }


        /// <summary>
        /// 获取退出股权的税后实际收益。
        /// </summary>
        public decimal AftertaxProfits
        {
            get
            {
                return aftertaxProfits;
            }
        }

        /// <summary>
        /// 获取退出股权实现的税前增益。
        /// </summary>
        public decimal PretaxProfits
        {
            get
            {
                return pretaxProfits;
            }
        }

        /// <summary>
        /// <para>获取 或 设置 个人所得税率。</para>
        /// <para>若为20%，则值为0.2。</para>
        /// </summary>
        public decimal TaxRate
        {
            get { return taxRate; }
            set { taxRate = value; Calculate(); }
        }

        /// <summary>
        /// 获取或设置 退出股权对应的原始股值。
        /// </summary>
        public decimal WithdrawalSharesOriginalValue
        {
            get { return withdrawalSharesOriginalValue; }
            set { withdrawalSharesOriginalValue = value; Calculate(); }
        }

        /// <summary>
        /// 获取或设置 退出股权对应的交易市值。
        /// </summary>
        public decimal WithdrawalSharesCurrentValue
        {
            get { return withdrawalSharesCurrentValue; }
            set { withdrawalSharesCurrentValue = value; Calculate(); }
        }


        /// <summary>
        /// 获取或设置 退出股权时股权交易价格。
        /// </summary>
        public decimal CurrentSharePrice
        {
            get { return currentSharePrice; }
            set { currentSharePrice = value; }
        }

        /// <summary>
        /// 获取或设置 退出股权数量。
        /// </summary>
        public int WithdrawalSharesAmount
        {
            get { return withdrawalSharesAmount; }
            set { withdrawalSharesAmount = value; }
        }

        /// <summary>
        /// 获取或设置 退出股权日期。
        /// </summary>
        public DateTime WithdrawalDate
        {
            get { return withdrawalDate; }
            set { withdrawalDate = value; }
        }
    }
}
