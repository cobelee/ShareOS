using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinUI
{
    public partial class EntrustedAgentManage : Form
    {
        ShareOS.BLL.ShareholderRegister bll_Register = new ShareOS.BLL.ShareholderRegister();
        ShareOS.BLL.EntrustedAgent bll_EntrustedAgent = new ShareOS.BLL.EntrustedAgent();
        protected DataView dvShareholders, dvEntrustedAgent;

        public EntrustedAgentManage()
        {
            InitializeComponent();
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

        protected void DataBind_EntrustedAgent()
        {
            IList<ShareOS.Model.EntrustedAgent> eas = bll_EntrustedAgent.Select();
            IList<ShareOS.Model.Shareholder> shareholders = new List<ShareOS.Model.Shareholder>();

            foreach (ShareOS.Model.EntrustedAgent ea in eas)
            {
                shareholders.Add(ea as ShareOS.Model.Shareholder);
            }
            DataTable dtShareholders = bll_Register.ConvertToDataTable(shareholders);
            dvEntrustedAgent = dtShareholders.DefaultView;
            dgvEntrustedAgent.DataSource = dvEntrustedAgent;

            dgvEntrustedAgent.Columns["编号"].Visible = false;
            dgvEntrustedAgent.Columns["身份证号"].Visible = false;
            dgvEntrustedAgent.Columns["人员类别"].Visible = false;
            dgvEntrustedAgent.Columns["股东状态"].Visible = false;
            dgvEntrustedAgent.Columns["委托代理人"].Visible = false;

        }

        private void EntrustedAgentManage_Load(object sender, EventArgs e)
        {
            DataBind_Shareholders();
            DataBind_EntrustedAgent();
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            dvShareholders.RowFilter = "姓名 LIKE '%" + tbName.Text.Trim() + "%'";
        }

        private void btnSetAgent_Click(object sender, EventArgs e)
        {
            if (dgvShareholder.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvShareholder.SelectedRows)
                {
                    int shareholderNumber = 0;
                    shareholderNumber = Convert.ToInt32(row.Cells["股东号"].Value);
                    ShareOS.Model.Shareholder shareholder = bll_Register.GetShareholder(shareholderNumber);
                    ShareOS.Model.EntrustedAgent ea = new ShareOS.Model.EntrustedAgent();
                    shareholder.CopyTo(ea as ShareOS.Model.Shareholder);
                    bll_EntrustedAgent.Insert(ea);

                }
                DataBind_EntrustedAgent();
            }
        }

        private void btnCancelAgent_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvEntrustedAgent.SelectedRows)
            {
                int sharehoderNumber = 0;
                sharehoderNumber = Convert.ToInt32(row.Cells["股东号"].Value);
                bll_EntrustedAgent.Delete(sharehoderNumber);
            }
            DataBind_EntrustedAgent();
        }
    }
}