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
        /// ��ȡ�˹ɺ�ʵ�ʷ����ֽ�
        /// </summary>
        public decimal ReturnCash
        {
            get { return returnCash; }
        }

        /// <summary>
        /// �����������˰�����档
        /// </summary>
        protected void Calculate()
        {
            pretaxProfits = withdrawalSharesCurrentValue - withdrawalSharesOriginalValue;
            incomTax = pretaxProfits * taxRate;
            aftertaxProfits = pretaxProfits - incomTax;
            returnCash = withdrawalSharesCurrentValue - incomTax;
        }

        /// <summary>
        /// ��ȡ��������˰�
        /// </summary>
        public decimal IncomTax
        {
            get { return incomTax; }
        }


        /// <summary>
        /// ��ȡ�˳���Ȩ��˰��ʵ�����档
        /// </summary>
        public decimal AftertaxProfits
        {
            get
            {
                return aftertaxProfits;
            }
        }

        /// <summary>
        /// ��ȡ�˳���Ȩʵ�ֵ�˰ǰ���档
        /// </summary>
        public decimal PretaxProfits
        {
            get
            {
                return pretaxProfits;
            }
        }

        /// <summary>
        /// <para>��ȡ �� ���� ��������˰�ʡ�</para>
        /// <para>��Ϊ20%����ֵΪ0.2��</para>
        /// </summary>
        public decimal TaxRate
        {
            get { return taxRate; }
            set { taxRate = value; Calculate(); }
        }

        /// <summary>
        /// ��ȡ������ �˳���Ȩ��Ӧ��ԭʼ��ֵ��
        /// </summary>
        public decimal WithdrawalSharesOriginalValue
        {
            get { return withdrawalSharesOriginalValue; }
            set { withdrawalSharesOriginalValue = value; Calculate(); }
        }

        /// <summary>
        /// ��ȡ������ �˳���Ȩ��Ӧ�Ľ�����ֵ��
        /// </summary>
        public decimal WithdrawalSharesCurrentValue
        {
            get { return withdrawalSharesCurrentValue; }
            set { withdrawalSharesCurrentValue = value; Calculate(); }
        }


        /// <summary>
        /// ��ȡ������ �˳���Ȩʱ��Ȩ���׼۸�
        /// </summary>
        public decimal CurrentSharePrice
        {
            get { return currentSharePrice; }
            set { currentSharePrice = value; }
        }

        /// <summary>
        /// ��ȡ������ �˳���Ȩ������
        /// </summary>
        public int WithdrawalSharesAmount
        {
            get { return withdrawalSharesAmount; }
            set { withdrawalSharesAmount = value; }
        }

        /// <summary>
        /// ��ȡ������ �˳���Ȩ���ڡ�
        /// </summary>
        public DateTime WithdrawalDate
        {
            get { return withdrawalDate; }
            set { withdrawalDate = value; }
        }
    }
}