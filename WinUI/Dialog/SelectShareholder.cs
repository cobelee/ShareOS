using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ShareOS.BLL;

namespace WinUI.Dialog
{
    public partial class SelectShareholder : Form
    {
        ShareOS.BLL.ShareholderRegister bll_Register = new ShareOS.BLL.ShareholderRegister();
        IList<ShareOS.Model.Shareholder> selectedShareholders = new List<ShareOS.Model.Shareholder>();
        protected DataView dvShareholders;

        /// <summary>
        /// ��ǰѡ�еĹɶ����ϡ�
        /// </summary>
        public IList<ShareOS.Model.Shareholder> SelectedShareholders
        {
            get { return selectedShareholders; }
        }

        public SelectShareholder()
        {
            InitializeComponent();
            dgvShareholder.DoubleClick +=new EventHandler(btnOK_Click);
        }

        private void SelectShareholder_Load(object sender, EventArgs e)
        {
            DataBind_Shareholders();
        }

        protected void DataBind_Shareholders()
        {
            IList<ShareOS.Model.Shareholder> shareholders = bll_Register.GetShareholderList();

            DataTable dtShareholders = bll_Register.ConvertToDataTable(shareholders);

            dvShareholders = dtShareholders.DefaultView;
            dgvShareholder.DataSource = dvShareholders;

            dgvShareholder.Columns["���"].Visible = false;
            dgvShareholder.Columns["����֤��"].Visible = false;
            dgvShareholder.Columns["��Ա���"].Visible = false;
            dgvShareholder.Columns["�ɶ�״̬"].Visible = false;
            dgvShareholder.Columns["ί�д�����"].Visible = false;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvShareholder.SelectedRows)
            {
                selectedShareholders.Add(bll_Register.GetShareholder(Convert.ToInt32(row.Cells["�ɶ���"].Value)));
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            dvShareholders.RowFilter = "���� LIKE '%" + tbName.Text.Trim() + "%'";
        }
    }
}