using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Tiyi.ShareOS;
using System.Linq;

namespace WinUI.Print
{
    public partial class InvestmentCertification : Form
    {
        ShareOS.BLL.ShareOwnershipManage bll_som = new ShareOS.BLL.ShareOwnershipManage();
        ShareOS.BLL.ShareIssueManage bll_Issue = new ShareOS.BLL.ShareIssueManage();
        ReportPrinter reportPrinter;

        public InvestmentCertification()
        {
            InitializeComponent();
        }

        private void InvestmentCertification_Load(object sender, EventArgs e)
        {
            cbbIssueNumber_DataBind();
            if (cbbIssueNumber.Items.Count > 0)
            {
                cbbIssueNumber.SelectedIndex = 0;
                int issueNumber = Convert.ToInt32(cbbIssueNumber.SelectedItem);
                var config = bll_Issue.GetIssueConfig(issueNumber);
                lbIssue.Text = config.DisplayText;
            }


        }

        /// <summary>
        /// 股权期数下拉框绑定数据。
        /// </summary>
        private void cbbIssueNumber_DataBind()
        {
            var issues = bll_Issue.GetAllIssueConfigs();
            issues = issues.OrderByDescending(a => a.IssueNumber);
            cbbIssueNumber.Items.Clear();

            foreach (var issue in issues)
            {
                cbbIssueNumber.Items.Add(issue.IssueNumber);
            }
        }

        private void cbbIssueNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void cbHideBonus_CheckedChanged(object sender, EventArgs e)
        {
            DataView dv = dgvShareholder.DataSource as DataView;
            if (cbHideBonus.Checked)
            {
                dv.RowFilter = "ShareTotals>0";
            }
            else
            {
                dv.RowFilter = "";
            }

        }

        protected void Load_Data()
        {
            int currentIssueNumber = 0;

            currentIssueNumber = (int)cbbIssueNumber.SelectedItem;
            var config = bll_Issue.GetIssueConfig(currentIssueNumber);
            lbIssue.Text = config.DisplayText;
            DataTable dtShareOwnershipChange = bll_som.GetShareOwnershipChange(currentIssueNumber);
            DataTable newTable = dtShareOwnershipChange.Copy();
            if (cbHideBonus.Checked)
            {
                newTable = RemoveHongguAllSelled(dtShareOwnershipChange);
            }

            DataView dvShareOwnershipChange = newTable.DefaultView;

            dgvShareholder.DataSource = dvShareOwnershipChange;
        }

        /// <summary>
        /// 移除配发红股全部转让的人
        /// </summary>
        protected DataTable RemoveHongguAllSelled(DataTable tableReport)
        {
            if (tableReport == null)
                return null;

            DataTable newTable = tableReport.Copy();
            newTable.Clear();

            int rowCount = tableReport.Rows.Count;
            int cellCount = tableReport.Columns.Count;
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                decimal bonusShares = 0m;
                decimal.TryParse(tableReport.Rows[rowIndex]["PeifaBonusShares"].ToString(), out bonusShares);

                decimal bonusExit = 0m;
                decimal.TryParse(tableReport.Rows[rowIndex]["ZhuanrangBonusShares"].ToString(), out bonusExit);

                if (Math.Abs(bonusExit) != bonusShares)
                {
                    DataRow newRow = newTable.NewRow();
                    for (int i = 0; i < cellCount; i++)
                    {
                        newRow[i] = tableReport.Rows[rowIndex][i];
                    }
                    newTable.Rows.Add(newRow);
                }

            }
            return newTable;
        }

        /// <summary>
        /// 数据报表打印器 绑定数据报表及数据。
        /// </summary>
        /// <param name="row"></param>
        protected void ReportPrinter_DataBind()
        {
            //设置报表模版路径。
            LocalReport report = new LocalReport();
            report.ReportPath = "出资证明书.rdlc";
            report.DisplayName = "出资证明书";

            reportPrinter = new ReportPrinter(report);


            //加载报表数据源。将选中的人员组成新的数据表，并传递给报表打印器。
            string reportDataSourceName0 = reportPrinter.LocalReport.GetDataSourceNames()[0];

            DataTable tableSource = bll_som.GetShareOwnershipChange(Convert.ToInt32(cbbIssueNumber.SelectedItem));
            DataTable tableTarget = tableSource.Copy();
            tableTarget.Clear();

            foreach (DataGridViewRow row in dgvShareholder.SelectedRows)
            {
                DataRow newrow = tableTarget.NewRow();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    newrow[i] = row.Cells[i].Value;
                }
                tableTarget.Rows.Add(newrow);
            }

            reportPrinter.LocalReport.DataSources.Add(new ReportDataSource(reportDataSourceName0, tableTarget));

            //设置报表参数值。
            ReportParameter[] parameters = new ReportParameter[4];
            parameters[0] = new ReportParameter("PARM_CompanyName", Properties.Settings.Default.CompanyName);
            parameters[1] = new ReportParameter("PARM_IssueNumber", cbbIssueNumber.SelectedItem.ToString());
            var config = bll_Issue.GetIssueConfig(Convert.ToInt32(cbbIssueNumber.SelectedItem));
            parameters[2] = new ReportParameter("PARM_SharePrice", config.SharePrice.ToString());
            parameters[3] = new ReportParameter("PARM_IssueYear", config.IssueYear.ToString());

            report.SetParameters(parameters);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ReportPrinter_DataBind();


            PrintPreview icp = new PrintPreview();
            icp.PageCount = reportPrinter.LocalReport.GetTotalPages();
            icp.PrintPreviewControl.Document = reportPrinter.PrintDocument;
            icp.MdiParent = this.MdiParent;
            icp.Show();
            icp.WindowState = FormWindowState.Maximized;
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            DataView dv = dgvShareholder.DataSource as DataView;
            dv.Sort = "EntrustedAgentName,DepName";
        }

        private void btnSortDep_Click(object sender, EventArgs e)
        {
            DataView dv = dgvShareholder.DataSource as DataView;
            dv.Sort = "DepName,EntrustedAgentName";
        }
    }
}