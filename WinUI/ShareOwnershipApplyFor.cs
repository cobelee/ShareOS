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

        private void dgvShareOwnershipApply_DataBind()
        {
            DataTable dtSharesApply = bll_som.GetShareOwnershipApplyReport(Convert.ToInt32(cbbIssueNumber.SelectedItem));
            dgvShareOwnershipApply.Columns.Add("ShareholderNumber", "�ɶ���");
            dgvShareOwnershipApply.Columns.Add("JobNumber", "����");
            dgvShareOwnershipApply.Columns.Add("ShareholderName", "����");
            dgvShareOwnershipApply.Columns.Add("Sex", "�Ա�");
            dgvShareOwnershipApply.Columns.Add("PersonType", "��Ա���");
            dgvShareOwnershipApply.Columns.Add("EntrustedAgent", "��Ȩ������");
            dgvShareOwnershipApply.Columns.Add("TotalShares", "��ǰ�ܹ�Ȩ��");
            dgvShareOwnershipApply.Columns.Add("SharesApplyFor", "�����Ȩ����");

            foreach (DataRow dataRow in dtSharesApply.Rows)
            {
                DataGridViewRow row = new DataGridViewRow();
                string sex = string.Empty;
                sex = Convert.ToBoolean(dataRow["Sex"]) ? "��" : "Ů";
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
                    MessageBox.Show(this, "�����ظ����룡", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        string sex = shareholder.Sex ? "��" : "Ů";
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
                MessageBox.Show(this, "�ɶ������ڣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tbShareholderNumber.Text = string.Empty;
            tbShareholderNumber.Focus();
        }

        private void ShareOwnershipApplyFor_Shown(object sender, EventArgs e)
        {
            tbShareholderNumber.Focus();
            lbMessage.Text = "������ʹ��ɨ��ǹ¼�룬����ɨ��ǰ��\r\n���������ڹɶ��������";
        }

        private void ShareOwnershipApplyFor_Load(object sender, EventArgs e)
        {
            cbbIssueNumber_DataBind();
            if (cbbIssueNumber.Items.Count > 0)
                cbbIssueNumber.SelectedIndex = 0;

            dgvShareOwnershipApply_DataBind();
        }

        /// <summary>
        /// �ж��Ƿ��ظ����롣
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
            if (MessageBox.Show(this, "ȷʵҪ������Ȩ����������", "ȷ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (DataGridViewRow row in dgvShareOwnershipApply.SelectedRows)
                {
                    bll_som.CancelApplyFor(Convert.ToInt32(cbbIssueNumber.SelectedItem), Convert.ToInt32(row.Cells["ShareholderNumber"].Value));
                    dgvShareOwnershipApply.Rows.Remove(row);
                }
            }
        }




        /// <summary>
        /// ����Excel�ĵ���
        /// </summary>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "��Ȩ����������ܱ�";
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
        /// ����Excel�ĵ���
        /// </summary>
        /// <param name="fileName">����Excel�ĵ����ļ����������ļ�·����</param>
        private void ExportExcel(string fileName)
        {
            //���� Excel �ĵ�ʵ����
            XlsDocument xlsDoc = new XlsDocument();
            xlsDoc.FileName = System.IO.Path.GetFileName(fileName);

            //���� Excel �ĵ�����.
            xlsDoc.SummaryInformation.Author = "Cobe lee";
            xlsDoc.SummaryInformation.Title = "��Ȩ����������ܱ�";
            xlsDoc.SummaryInformation.Comments = "This workbook generated by ZPITC! http://www.tiyi.biz";
            xlsDoc.SummaryInformation.Subject = "��Ȩ����������ܱ�";
            xlsDoc.DocumentSummaryInformation.Company = Properties.Settings.Default.CompanyName;

            //���� Excel �ĵ��е� Sheet ����
            Worksheet sheet = xlsDoc.Workbook.Worksheets.Add("Sheet1");
            xlsDoc.Workbook.Worksheets.Add("Sheet2");
            xlsDoc.Workbook.Worksheets.Add("Sheet3");
            Cells cells = sheet.Cells;

            //���� Sheet ���е�һ��������
            int firstRow = 1;
            FormatCell(cells.Add(firstRow, 1, "�ɶ���"));
            FormatCell(cells.Add(firstRow, 2, "����"));
            FormatCell(cells.Add(firstRow, 3, "����"));
            FormatCell(cells.Add(firstRow, 4, "�Ա�"));
            FormatCell(cells.Add(firstRow, 5, "��Ա���"));
            FormatCell(cells.Add(firstRow, 6, "��Ȩ������"));
            FormatCell(cells.Add(firstRow, 7, "��ǰ�ܹ�Ȩ��"));
            FormatCell(cells.Add(firstRow, 8, "����������"));
            FormatCell(cells.Add(firstRow, 9, "����������"));

            int lastRow = 0;

            //���������С�
            foreach (DataGridViewRow row in dgvShareOwnershipApply.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    FormatCell(cells.Add(row.Index + 2, cell.ColumnIndex + 1, cell.Value));
                }
                FormatCell(cells.Add(row.Index + 2, 9, string.Empty));

                lastRow = row.Index +2;
            }

            cells.Add(lastRow + 2, 2, @"˵�����޸�ʱ���뱣�֡����򡱺͡����������䣬����ù�Ȩ�����������д�ڡ�������������һ�У��������Ϊcsv�ļ���");

            string path = System.IO.Path.GetDirectoryName(fileName);
            try
            {
                xlsDoc.Save(path, true);
            }
            catch
            {
                MessageBox.Show("�ļ� \"" + xlsDoc.FileName + "\" ������������򿪣�\n��رո��ļ��������ԣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// ���� CSV �ĵ���
        /// </summary>
        /// <param name="fileName">���� CSV �ĵ����ļ����������ļ�·����</param>
        private void ExportCSV(string fileName)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName, false, Encoding.Unicode);

            sw.WriteLine("�ɶ���,����,����,�Ա�,��Ա���,��Ȩ������,��ǰ�ܹ�Ȩ��,����������,����������");
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
        /// ���� XML �ĵ���
        /// </summary>
        /// <param name="fileName">���� XML �ĵ����ļ����������ļ�·����</param>
        private void ExportXML(string fileName)
        {
            DataTable table = new DataTable("Sheet1");
            table.Columns.Add("�ɶ���");
            table.Columns.Add("����");
            table.Columns.Add("����");
            table.Columns.Add("�Ա�");
            table.Columns.Add("��Ա���");
            table.Columns.Add("��Ȩ������");
            table.Columns.Add("��ǰ�ܹ�Ȩ��");
            table.Columns.Add("����������");
            table.Columns.Add("����������");
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