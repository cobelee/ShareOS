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
    public partial class InvestmentCertification : Form
    {
        ShareOS.BLL.ShareOwnershipManage bll_som = new ShareOS.BLL.ShareOwnershipManage();
        ShareOS.BLL.SharesBonusManage bll_bonus = new ShareOS.BLL.SharesBonusManage();
        PMS.BLL.Personnel bll_Person = new PMS.BLL.Personnel();
        ReportPrinter reportPrinter;

        public InvestmentCertification()
        {
            InitializeComponent();
        }

        private void InvestmentCertification_Load(object sender, EventArgs e)
        {
            cbbIssueNumber_DataBind();
            if (cbbIssueNumber.Items.Count > 0)
                cbbIssueNumber.SelectedIndex = 0;
        }

        /// <summary>
        /// ��Ȩ��������������ݡ�
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

        private void cbbIssueNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void cbHideBonus_CheckedChanged(object sender, EventArgs e)
        {
            Load_Data();
        }

        protected void Load_Data()
        {
            int currentIssueNumber = 0;
            currentIssueNumber = Convert.ToInt32(cbbIssueNumber.SelectedItem);
            DataTable dtShareOwnershipChange = bll_som.GetShareOwnershipChange(currentIssueNumber);
            DataTable newTable = dtShareOwnershipChange.Copy();
            if (cbHideBonus.Checked)
            {
                newTable = RemoveHongguAllSelled(dtShareOwnershipChange);
            }

            AddDepartmentColumn(newTable);

            DataView dvShareOwnershipChange = newTable.DefaultView;

            dgvShareholder.DataSource = dvShareOwnershipChange;
        }

        //����һ����λ�ֶε����ݱ�
        protected void AddDepartmentColumn(DataTable tableReport)
        {
            DataColumn col = new DataColumn("Department", typeof(string));
            tableReport.Columns.Add(col);
            foreach (DataRow row in tableReport.Rows)
            {
                string jobNumber = Convert.ToString(row["JobNumber"]);

                row["Department"] = bll_Person.GetPersonInfoByJobNumber(jobNumber).Department;
            }
        }

        /// <summary>
        /// �Ƴ��䷢���ȫ��ת�õ���
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
        /// ���ݱ�����ӡ�� �����ݱ��������ݡ�
        /// </summary>
        /// <param name="row"></param>
        protected void ReportPrinter_DataBind()
        {
            //���ñ���ģ��·����
            LocalReport report = new LocalReport();
            report.ReportPath = "����֤����.rdlc";
            report.DisplayName = "����֤����";

            reportPrinter = new ReportPrinter(report);


            //���ر�������Դ����ѡ�е���Ա����µ����ݱ��������ݸ�������ӡ����
            string reportDataSourceName0 = reportPrinter.LocalReport.GetDataSourceNames()[0];

            DataTable tableSource = bll_som.GetShareOwnershipChange(Convert.ToInt32(cbbIssueNumber.SelectedItem));
            DataTable tableTarget = tableSource.Copy();
            tableTarget.Clear();

            foreach (DataGridViewRow row in dgvShareholder.SelectedRows)
            {
                DataRow newrow = tableTarget.NewRow();
                for (int i = 0; i < row.Cells.Count - 1; i++)
                {
                    newrow[i] = row.Cells[i].Value;
                }
                tableTarget.Rows.Add(newrow);
            }

            reportPrinter.LocalReport.DataSources.Add(new ReportDataSource(reportDataSourceName0, tableTarget));

            //���ñ�������ֵ��
            ReportParameter[] parameters = new ReportParameter[3];
            parameters[0] = new ReportParameter("PARM_CompanyName", Properties.Settings.Default.CompanyName);
            parameters[1] = new ReportParameter("PARM_IssueNumber", cbbIssueNumber.SelectedItem.ToString());
            ShareOS.Model.SharesIssueConfig config = bll_bonus.SelectConfig(Convert.ToInt32(cbbIssueNumber.SelectedItem));
            parameters[2] = new ReportParameter("PARM_SharePrice", config.SharePrice.ToString());

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
            dv.Sort = "EntrustedAgentName,Department";
        }


    }
}