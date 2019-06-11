using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinUI
{
    public partial class PreviewPersonWithdrawalReport : Form
    {
        public PreviewPersonWithdrawalReport()
        {
            InitializeComponent();
        }

        public PrintPreviewControl PrintPreviewControl
        {
            get { return printPreviewControl1; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog(this) == DialogResult.OK)
            {
                printPreviewControl1.Document.PrinterSettings = printDialog1.PrinterSettings;
                printPreviewControl1.Document.Print();
            }
        }
    }
}