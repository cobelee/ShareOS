using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShareOS.BLL;


namespace WinUI
{
    public partial class PersonTypeManage : Form
    {
        ShareOS.BLL.PersonType bll_personType = new PersonType();

        public PersonTypeManage()
        {
            InitializeComponent();
        }

        protected void Load_PersonType()
        {
            IList<ShareOS.Model.PersonType> personTypes = bll_personType.GetPersonTypes();
            lbxPersonType.DataSource = personTypes;
        }

        private void PersonTypeManage_Load(object sender, EventArgs e)
        {
            Load_PersonType();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbPersonTypeName.Text))
            {
                bll_personType.InsertPersonType(tbPersonTypeName.Text);
                Load_PersonType();
                ClearInputText();
            }
            else
            {
                MessageBox.Show("��Ա������Ʋ�����Ϊ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbxPersonType.SelectedItems.Count > 0)
            {
                bll_personType.DeletePersonType(lbxPersonType.SelectedItem.ToString());
                Load_PersonType();
            }
        }

        private void ClearInputText()
        {
            tbPersonTypeName.Text = string.Empty;
        }
    }
}