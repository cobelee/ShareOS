using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinUI
{
    public partial class ShareholderRegister : Form
    {
        ShareOS.BLL.ShareholderRegister bll_Register = new ShareOS.BLL.ShareholderRegister();
        ShareOS.BLL.EntrustedAgent bll_Agent = new ShareOS.BLL.EntrustedAgent();

        public ShareholderRegister()
        {
            InitializeComponent();
        }

        private void ShareholderRegister_Load(object sender, EventArgs e)
        {
            Load_Register();
        }

        protected void Load_Register()
        {
            IList<ShareOS.Model.Shareholder> shareholders = bll_Register.GetShareholderList();
            DataTable tableShareholders = bll_Register.ConvertToDataTable(shareholders);

            dgvRegister.DataSource = tableShareholders.DefaultView;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, @"һ������£����Բ�����ɾ���ɶ����������ڴ��������
�����˴������ݡ����ߣ��ùɶ������������������ѳ�����
һ�������ݱ�����ݡ�

ȷ��ɾ�������Yes����ť��"
                                  , "��ʾ", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int shareholderId = Convert.ToInt32(dgvRegister.SelectedRows[0].Cells["���"].Value);
                bll_Register.Delete(shareholderId);
                Load_Register();
                MessageBox.Show("������ɾ��");
            }
                                    
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Dialog.AddShareholder addSH = new WinUI.Dialog.AddShareholder();
            if (addSH.ShowDialog(this) == DialogResult.OK)
            {
                bll_Register.Create(addSH.Shareholder);
                Load_Register();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvRegister.SelectedRows.Count > 0)
            {
                Dialog.AddShareholder addSH = new WinUI.Dialog.AddShareholder();
                addSH.IsToEdit = true;
                int shareholderNumber = Convert.ToInt32(dgvRegister.SelectedRows[0].Cells["�ɶ���"].Value);

                addSH.Shareholder = bll_Register.GetShareholder(shareholderNumber);

                if (addSH.ShowDialog(this) == DialogResult.OK)
                {
                    bll_Register.Update(addSH.Shareholder);
                    Load_Register();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
    
        }

        private void btnSetAgent_Click(object sender, EventArgs e)
        {
            Dialog.SelectEntrustedAgent sea = new WinUI.Dialog.SelectEntrustedAgent();

            if (sea.ShowDialog() == DialogResult.OK)
            {
                ShareOS.Model.EntrustedAgent ea = sea.SelectedEntrustedAgent;
                if (ea != null)
                {
                    foreach (DataGridViewRow row in dgvRegister.SelectedRows)
                    {
                        int shareholderId = 0;
                        shareholderId = Convert.ToInt32(row.Cells["���"].Value);

                        bll_Agent.ActFor(shareholderId, ea);
                    }
                    Load_Register();
                }
            }
            
        }
    }
}