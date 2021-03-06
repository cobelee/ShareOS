using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace WinUI.Print
{
    public partial class BuySharesApplication : Form
    {
        ShareOS.BLL.ShareOwnershipManage bll_ownership = new ShareOS.BLL.ShareOwnershipManage();
        ShareOS.BLL.SharesBonusManage bll_bonus = new ShareOS.BLL.SharesBonusManage();
        ReportPrinter reportPrinter;

        public BuySharesApplication()
        {
            InitializeComponent();
        }

        protected void DataBind_ShareOwnership(int issueNumber)
        {
            DataTable tableReport = bll_ownership.GetShareOwnershipReport(issueNumber);
            DataView dv = tableReport.DefaultView;

            dgvShareOwnership.DataSource = dv;
            dgvShareOwnership.Columns["BarCode"].Visible = false;
        }


        #region 初始化加载
        private void BuySharesApplication_Load(object sender, EventArgs e)
        {
            cbbIssueNumber_DataBind();
            if (cbbIssueNumber.Items.Count > 0)
                cbbIssueNumber.SelectedIndex = 0;

            DataBind_ShareOwnership(Convert.ToInt32(cbbIssueNumber.SelectedItem));

        }

        /// <summary>
        /// 股权期数下拉框绑定数据。
        /// </summary>
        private void cbbIssueNumber_DataBind()
        {
            int currentIssueNumber = 0;
            currentIssueNumber = bll_bonus.GetLastIssueNumber();
            cbbIssueNumber.Items.Clear();
            for (int i = currentIssueNumber; i >= 0; i--)
            {
                cbbIssueNumber.Items.Add(i);
            }
        }
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //确认股权交易期数是否正确。
            ShareOS.Model.SharesIssueConfig config = bll_bonus.SelectConfig(Convert.ToInt32(cbbIssueNumber.SelectedItem));


            string confirmInfo = @"请确认股权交易期数！
---------------------------------
　　当前选择的股权交易期数为第 " + config.IssueNumber.ToString() + @" 期。
    股权交易年份：" + config.IssueYear.ToString() + @" 年。
    当前股价为： " + config.SharePrice.ToString() + @" 元。
---------------------------------
　　若信息正确，请按“确认”，若信息不正确，请点“取消”，
并到分红管理界面中，配置分红参数。";

            if (MessageBox.Show(this, confirmInfo, "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                //设置报表模版路径。
                LocalReport report = new LocalReport();
                report.ReportPath = "ReportShareApplication.rdlc";

                reportPrinter = new ReportPrinter(report);


                // 以下两行进行页面设置，设置上边距1.5cm，设置左边距 1cm, 似乎无效
                reportPrinter.PrintDocument.DefaultPageSettings.Margins.Top = 59; // 1.5cm
                reportPrinter.PrintDocument.DefaultPageSettings.Margins.Left = 39; // 1cm

                //加载报表数据源。
                string dataSourceName = reportPrinter.LocalReport.GetDataSourceNames()[0];
                DataTable tableSource = bll_ownership.GetShareOwnershipReport(Convert.ToInt32(cbbIssueNumber.SelectedValue));
                DataTable tableTarget = tableSource.Copy();
                tableTarget.Clear();

                foreach (DataGridViewRow row in dgvShareOwnership.SelectedRows)
                {
                    DataRow newrow = tableTarget.NewRow();
                    for (int i = 0; i <= 12; i++)
                    {
                        newrow[i] = row.Cells[i].Value;
                    }
                    tableTarget.Rows.Add(newrow);
                }

                reportPrinter.LocalReport.DataSources.Add(new ReportDataSource(dataSourceName, tableTarget));

                //设置报表参数值。
                ReportParameter[] parameters = new ReportParameter[4];
                if (!string.IsNullOrEmpty(Properties.Settings.Default.CompanyName))
                {
                    parameters[0] = new ReportParameter("Parm_CompanyName", Properties.Settings.Default.CompanyName);
                }
                parameters[1] = new ReportParameter("Parm_IssueNumber", config.IssueNumber.ToString());
                parameters[2] = new ReportParameter("Parm_IssueYear", config.IssueYear.ToString());
                parameters[3] = new ReportParameter("Parm_SharePrice", config.SharePrice.ToString());

                report.SetParameters(parameters);
                
                
                printPreviewDialog1.Document = reportPrinter.PrintDocument;
                printPreviewDialog1.ShowDialog();
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {

        }


    }
}