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
        /// 当前选中的股东集合。
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

            dgvShareholder.Columns["编号"].Visible = false;
            dgvShareholder.Columns["身份证号"].Visible = false;
            dgvShareholder.Columns["人员类别"].Visible = false;
            dgvShareholder.Columns["股东状态"].Visible = false;
            dgvShareholder.Columns["委托代理人"].Visible = false;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvShareholder.SelectedRows)
            {
                selectedShareholders.Add(bll_Register.GetShareholder(Convert.ToInt32(row.Cells["股东号"].Value)));
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            dvShareholders.RowFilter = "姓名 LIKE '%" + tbName.Text.Trim() + "%'";
        }
    }
}