using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WinUI.Dialog
{
    public partial class BuyShareOwnership : Form
    {
        ShareOS.BLL.ShareOwnershipManage som = new ShareOS.BLL.ShareOwnershipManage();
        private decimal sharePrice;

        private int sharesAmount;

        /// <summary>
        /// 要购买的股权数量。
        /// </summary>
        public int SharesAmount
        {
            get { return sharesAmount; }
            set { sharesAmount = value; }
        }
        private decimal money;

        /// <summary>
        /// 股权受让款。
        /// </summary>
        public decimal Money
        {
            get { return money; }
            set { money = value; }
        }

        public BuyShareOwnership()
        {
            InitializeComponent();
            sharePrice = som.GetCurrentSharePrice();
            lbSharePrice.Text = sharePrice.ToString();
        }

        private void tbMoney_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(tbMoney.Text, @"^[0-9]{0,}\.{0,1}[0-9]{0,}$"))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbMoney as Control, "格式有误，请输入数字！");
            }
            else
            {
                errorProvider1.SetError(tbMoney as Control, string.Empty);
            }
        }

        private void nudShareOwnership_ValueChanged(object sender, EventArgs e)
        {

            tbMoney.Text = Convert.ToString(nudShareOwnership.Value * sharePrice).TrimEnd('0');
            //tbMoney.Text = string.Format("{0:N2}", tbMoney.Text);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.Validate())
            {
                sharesAmount = Convert.ToInt32(nudShareOwnership.Value);
                decimal.TryParse(tbMoney.Text, out money);
            }
        }
    }
}