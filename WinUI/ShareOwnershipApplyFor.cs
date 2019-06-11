using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using org.in2bits.MyXls;

namespace WinUI
{
    public partial class ShareOwnershipApplyFor : Form
    {
        ShareOS.BLL.ShareholderRegister bll_sr = new ShareOS.BLL.ShareholderRegister();
        ShareOS.BLL.ShareOwnershipManage bll_som = new ShareOS.BLL.ShareOwnershipManage();
        ShareOS.BLL.SharesBonusManage bll_bonus = new ShareOS.BLL.SharesBonusManage();

        public ShareOwnershipApplyFor()
        {
            InitializeComponent();
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

        private void dgvShareOwnershipApply_DataBind()
        {
            DataTable dtSharesApply = bll_som.GetShareOwnershipApplyReport(Convert.ToInt32(cbbIssueNumber.SelectedItem));
            dgvShareOwnershipApply.Columns.Add("ShareholderNumber", "股东号");
            dgvShareOwnershipApply.Columns.Add("JobNumber", "工号");
            dgvShareOwnershipApply.Columns.Add("ShareholderName", "姓名");
            dgvShareOwnershipApply.Columns.Add("Sex", "性别");
            dgvShareOwnershipApply.Columns.Add("PersonType", "人员类别");
            dgvShareOwnershipApply.Columns.Add("EntrustedAgent", "股权受托人");
            dgvShareOwnershipApply.Columns.Add("TotalShares", "当前总股权数");
            dgvShareOwnershipApply.Columns.Add("SharesApplyFor", "申请股权数量");

            foreach (DataRow dataRow in dtSharesApply.Rows)
            {
                DataGridViewRow row = new DataGridViewRow();
                string sex = string.Empty;
                sex = Convert.ToBoolean(dataRow["Sex"]) ? "男" : "女";
                object[] values = { dataRow["ShareholderNumber"], 
                    dataRow["JobNumber"], 
                    dataRow["ShareholderName"], 
                    sex, 
                    dataRow["PersonType"], 
                    dataRow["EntrustedAgent"], 
                    dataRow["TotalShares"], 
                    dataRow["SharesAmountApply"] };
                dgvShareOwnershipApply.Rows.Add(values);
            }

        }

        private void btnApplyFor_Click(object sender, EventArgs e)
        {
            int shareholderNumber = 0;
            int.TryParse(tbShareholderNumber.Text, out shareholderNumber);
            if (bll_sr.ExistShareholder(shareholderNumber))
            {
                if (ExistInGridView(shareholderNumber))
                {
                    MessageBox.Show(this, "请勿重复申请！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int sharesAmount = 0;
                    ShareOS.Model.Shareholder shareholder = bll_sr.GetShareholder(shareholderNumber);

                    Dialog.ApplyForShares applyShares = new WinUI.Dialog.ApplyForShares();
                    applyShares.Shareholder = shareholder;
                    if (applyShares.ShowDialog(this) == DialogResult.OK)
                    {
                        sharesAmount = applyShares.SharesAmountApplyFor;
                        bll_som.ApplyFor(Convert.ToInt32(cbbIssueNumber.SelectedItem), shareholderNumber, sharesAmount);
                        string entruestedAgentName = (bll_sr.GetShareholder(shareholder.EntrustedAgent)).ShareholderName;
                        string sex = shareholder.Sex ? "男" : "女";
                        object[] values = { shareholder.ShareholderNumber,
                        shareholder.JobNumber, 
                        shareholder.ShareholderName,
                        sex,
                        shareholder.PersonType,
                        entruestedAgentName,
                        bll_som.GetPersonalShareTotals(shareholder.ShareholderNumber),
                        sharesAmount};
                        int rowIndex = dgvShareOwnershipApply.Rows.Add(values);
                        dgvShareOwnershipApply.FirstDisplayedScrollingRowIndex = rowIndex;
                        dgvShareOwnershipApply.Rows[rowIndex].Selected = true;
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "股东不存在！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tbShareholderNumber.Text = string.Empty;
            tbShareholderNumber.Focus();
        }

        private void ShareOwnershipApplyFor_Shown(object sender, EventArgs e)
        {
            tbShareholderNumber.Focus();
            lbMessage.Text = "　　若使用扫描枪录入，请在扫描前将\r\n输入光标置于股东号输入框。";
        }

        private void ShareOwnershipApplyFor_Load(object sender, EventArgs e)
        {
            cbbIssueNumber_DataBind();
            if (cbbIssueNumber.Items.Count > 0)
                cbbIssueNumber.SelectedIndex = 0;

            dgvShareOwnershipApply_DataBind();
        }

        /// <summary>
        /// 判断是否重复申请。
        /// </summary>
        /// <param name="shareholderNumber"></param>
        /// <returns></returns>
        private bool ExistInGridView(int shareholderNumber)
        {
            bool returnValue = false;
            foreach (DataGridViewRow row in dgvShareOwnershipApply.Rows)
            {
                if (shareholderNumber == Convert.ToInt32(row.Cells["ShareholderNumber"].Value))
                {
                    returnValue = true;
                    row.Selected = true;
                    break;
                }
            }
            return returnValue;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "确实要撤销股权受让申请吗？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (DataGridViewRow row in dgvShareOwnershipApply.SelectedRows)
                {
                    bll_som.CancelApplyFor(Convert.ToInt32(cbbIssueNumber.SelectedItem), Convert.ToInt32(row.Cells["ShareholderNumber"].Value));
                    dgvShareOwnershipApply.Rows.Remove(row);
                }
            }
        }




        /// <summary>
        /// 导出Excel文档。
        /// </summary>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "股权受让申请汇总表";
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                if (saveFileDialog1.FilterIndex == 1)
                {
                    saveFileDialog1.DefaultExt = "xls";
                    ExportExcel(saveFileDialog1.FileName);
                    
                }

                if (saveFileDialog1.FilterIndex == 2)
                {
                    saveFileDialog1.DefaultExt = "csv";
                    ExportCSV(saveFileDialog1.FileName);
                }

                if (saveFileDialog1.FilterIndex == 3)
                {
                    saveFileDialog1.DefaultExt = "xml";
                    ExportXML(saveFileDialog1.FileName);
                }
            }
        }

        /// <summary>
        /// 导出Excel文档。
        /// </summary>
        /// <param name="fileName">导出Excel文档的文件名，包含文件路径。</param>
        private void ExportExcel(string fileName)
        {
            //定义 Excel 文档实例。
            XlsDocument xlsDoc = new XlsDocument();
            xlsDoc.FileName = System.IO.Path.GetFileName(fileName);

            //定义 Excel 文档属性.
            xlsDoc.SummaryInformation.Author = "Cobe lee";
            xlsDoc.SummaryInformation.Title = "股权受让申请汇总表";
            xlsDoc.SummaryInformation.Comments = "This workbook generated by ZPITC! http://www.tiyi.biz";
            xlsDoc.SummaryInformation.Subject = "股权受让申请汇总表";
            xlsDoc.DocumentSummaryInformation.Company = Properties.Settings.Default.CompanyName;

            //定义 Excel 文档中的 Sheet 表。
            Worksheet sheet = xlsDoc.Workbook.Worksheets.Add("Sheet1");
            xlsDoc.Workbook.Worksheets.Add("Sheet2");
            xlsDoc.Workbook.Worksheets.Add("Sheet3");
            Cells cells = sheet.Cells;

            //定义 Sheet 表中第一行列名。
            int firstRow = 1;
            FormatCell(cells.Add(firstRow, 1, "股东号"));
            FormatCell(cells.Add(firstRow, 2, "工号"));
            FormatCell(cells.Add(firstRow, 3, "姓名"));
            FormatCell(cells.Add(firstRow, 4, "性别"));
            FormatCell(cells.Add(firstRow, 5, "人员类别"));
            FormatCell(cells.Add(firstRow, 6, "股权受托人"));
            FormatCell(cells.Add(firstRow, 7, "当前总股权数"));
            FormatCell(cells.Add(firstRow, 8, "申请受让数"));
            FormatCell(cells.Add(firstRow, 9, "获批受让数"));

            int lastRow = 0;

            //生成数据行。
            foreach (DataGridViewRow row in dgvShareOwnershipApply.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    FormatCell(cells.Add(row.Index + 2, cell.ColumnIndex + 1, cell.Value));
                }
                FormatCell(cells.Add(row.Index + 2, 9, string.Empty));

                lastRow = row.Index +2;
            }

            cells.Add(lastRow + 2, 2, @"说明：修改时，请保持“列序”和“列名”不变，分配好股权受让数额后，填写在“获批受让数”一列，最后另存为csv文件。");

            string path = System.IO.Path.GetDirectoryName(fileName);
            try
            {
                xlsDoc.Save(path, true);
            }
            catch
            {
                MessageBox.Show("文件 \"" + xlsDoc.FileName + "\" 正被其它程序打开，\n请关闭该文件，并重试！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatCell(Cell cell)
        {
            cell.UseBorder = true;

            cell.TopLineStyle = 1;
            cell.BottomLineStyle = 1;
            cell.RightLineStyle = 1;
            cell.LeftLineStyle = 1;
            
        }

        /// <summary>
        /// 导出 CSV 文档。
        /// </summary>
        /// <param name="fileName">导出 CSV 文档的文件名，包含文件路径。</param>
        private void ExportCSV(string fileName)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName, false, Encoding.Unicode);

            sw.WriteLine("股东号,工号,姓名,性别,人员类别,股权受托人,当前总股权数,申请受让数,获批受让数");
            foreach (DataGridViewRow row in dgvShareOwnershipApply.Rows)
            {
                System.Text.StringBuilder sb = new StringBuilder();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    sb.Append(cell.Value.ToString() + ",");
                }
                sw.WriteLine(sb.ToString());
            }

            sw.Close();
        }

        /// <summary>
        /// 导出 XML 文档。
        /// </summary>
        /// <param name="fileName">导出 XML 文档的文件名，包含文件路径。</param>
        private void ExportXML(string fileName)
        {
            DataTable table = new DataTable("Sheet1");
            table.Columns.Add("股东号");
            table.Columns.Add("工号");
            table.Columns.Add("姓名");
            table.Columns.Add("性别");
            table.Columns.Add("人员类别");
            table.Columns.Add("股权受托人");
            table.Columns.Add("当前总股权数");
            table.Columns.Add("申请受让数");
            table.Columns.Add("获批受让数");
            foreach (DataGridViewRow row in dgvShareOwnershipApply.Rows)
            {
                DataRow dataRow = table.NewRow();
                for (int i = 0; i < 8; i++)
                {
                    dataRow[i] = row.Cells[i].Value.ToString();
                }
                dataRow[8] = string.Empty;
                table.Rows.Add(dataRow);
            }
            table.WriteXml(fileName, XmlWriteMode.IgnoreSchema, false);
        }
    }
}