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
        PMS.BLL.Personnel bll_Person = new PMS.BLL.Personnel();
        Tiyi.PMS.PersonnelRollSoapClient ws_person = new Tiyi.PMS.PersonnelRollSoapClient();
        ReportPrinter reportPrinter;

        public BuySharesApplication()
        {
            InitializeComponent();
        }

        protected void DataBind_ShareOwnership(int issueNumber)
        {
            DataTable tableReport = bll_ownership.GetShareOwnershipReport(issueNumber);
            AddDepartmentColumn(tableReport);
            DataView dv = tableReport.DefaultView;

            dgvShareOwnership.DataSource = dv;
            dgvShareOwnership.Columns["BarCode"].Visible = false;
        }

        protected void AddDepartmentColumn(DataTable tableReport)
        {
            //DataColumn col = new DataColumn("Department", typeof(string));
            //tableReport.Columns.Add(col);
            foreach (DataRow row in tableReport.Rows)
            {
                string jobNumber = Convert.ToString(row["JobNumber"]);
                Tiyi.PMS.GetPersonInfoByJobNumberRequestBody body = new Tiyi.PMS.GetPersonInfoByJobNumberRequestBody(jobNumber);
                Tiyi.PMS.GetPersonInfoByJobNumberRequest request = new Tiyi.PMS.GetPersonInfoByJobNumberRequest(body);
                row["Department"] = ws_person.GetPersonInfoByJobNumber(request).Body.GetPersonInfoByJobNumberResult.Department;
            }
        }

        #region ��ʼ������
        private void BuySharesApplication_Load(object sender, EventArgs e)
        {
            cbbIssueNumber_DataBind();
            if (cbbIssueNumber.Items.Count > 0)
                cbbIssueNumber.SelectedIndex = 0;

            DataBind_ShareOwnership(Convert.ToInt32(cbbIssueNumber.SelectedItem));

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
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //ȷ�Ϲ�Ȩ���������Ƿ���ȷ��
            ShareOS.Model.SharesIssueConfig config = bll_bonus.SelectConfig(Convert.ToInt32(cbbIssueNumber.SelectedItem));


            string confirmInfo = @"��ȷ�Ϲ�Ȩ����������
---------------------------------
������ǰѡ��Ĺ�Ȩ��������Ϊ�� " + config.IssueNumber.ToString() + @" �ڡ�
    ��Ȩ������ݣ�" + config.IssueYear.ToString() + @" �ꡣ
    ��ǰ�ɼ�Ϊ�� " + config.SharePrice.ToString() + @" Ԫ��
---------------------------------
��������Ϣ��ȷ���밴��ȷ�ϡ�������Ϣ����ȷ����㡰ȡ������
�����ֺ���������У����÷ֺ������";

            if (MessageBox.Show(this, confirmInfo, "ȷ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                //���ñ���ģ��·����
                LocalReport report = new LocalReport();
                report.ReportPath = "ReportShareApplication.rdlc";

                reportPrinter = new ReportPrinter(report);


                //���ر�������Դ��
                string dataSourceName = reportPrinter.LocalReport.GetDataSourceNames()[0];
                DataTable tableSource = bll_ownership.GetShareOwnershipReport(Convert.ToInt32(cbbIssueNumber.SelectedValue));
                DataTable tableTarget = tableSource.Copy();
                tableTarget.Clear();

                foreach (DataGridViewRow row in dgvShareOwnership.SelectedRows)
                {
                    DataRow newrow = tableTarget.NewRow();
                    for (int i = 0; i <= 10; i++)
                    {
                        newrow[i] = row.Cells[i].Value;
                    }
                    tableTarget.Rows.Add(newrow);
                }

                reportPrinter.LocalReport.DataSources.Add(new ReportDataSource(dataSourceName, tableTarget));

                //���ñ�������ֵ��
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