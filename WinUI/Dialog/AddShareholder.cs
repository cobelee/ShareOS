using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinUI.Dialog
{
    public partial class AddShareholder : Form
    {
        ShareOS.BLL.PersonType bll_personType;
        private ShareOS.Model.Shareholder shareholder;
        private bool isToEdit;

        public bool IsToEdit
        {
            get { return isToEdit; }
            set { isToEdit = value; }
        }

        public ShareOS.Model.Shareholder Shareholder
        {
            get { return shareholder; }
            set { shareholder = value; }
        }

        public AddShareholder()
        {
            InitializeComponent();
            isToEdit = false;
            shareholder = new ShareOS.Model.Shareholder();
            bll_personType = new ShareOS.BLL.PersonType();
        }

        private void DataBind_PersonType()
        {
            IList<ShareOS.Model.PersonType> personTypes = bll_personType.GetPersonTypes();
            
            cbbPersonType.Items.Clear();
            foreach (ShareOS.Model.PersonType pt in personTypes)
            {
                cbbPersonType.Items.Add(pt.PersonTypeName);
            }
            if (cbbPersonType.Items.Count > 0)
            {
                cbbPersonType.SelectedIndex = 0;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            shareholder.ShareholderNumber = Convert.ToInt32(nudShareholderNumber.Value);
            shareholder.JobNumber = tbJobNumber.Text;
            shareholder.ShareholderName = tbName.Text;
            shareholder.Sex = rbtnMale.Checked ? true : false;
            shareholder.IdentityCard = tbIdentityCard.Text;
            shareholder.PersonType = cbbPersonType.SelectedItem.ToString();
            shareholder.Status = rbtnIsShare.Checked ? ShareOS.Model.ShareholderStatus.股东 : ShareOS.Model.ShareholderStatus.非股东;
        }

        private void AddShareholder_Load(object sender, EventArgs e)
        {
            DataBind_PersonType();
            if (IsToEdit)
            {
                Load_Shareholder();
            }
        }

        private void Load_Shareholder()
        {
            if (isToEdit)
            {
                nudShareholderNumber.Value = Convert.ToDecimal(shareholder.ShareholderNumber);
                tbJobNumber.Text = shareholder.JobNumber;
                tbName.Text = shareholder.ShareholderName;
                if (shareholder.Sex)
                {
                    rbtnMale.Checked = true;
                }
                else
                {
                    rbtnFemale.Checked = true;
                }
                tbIdentityCard.Text = shareholder.IdentityCard;
                cbbPersonType.SelectedItem = shareholder.PersonType;
                if (shareholder.Status == ShareOS.Model.ShareholderStatus.股东)
                {
                    rbtnIsShare.Checked = true;
                }
                else
                {
                    rbtnIsNotShare.Checked = true;
                }
            }
        }
    }
}