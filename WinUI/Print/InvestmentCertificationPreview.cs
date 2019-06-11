using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinUI.Print
{
    public partial class PrintPreview : Form
    {
        public PrintPreview()
        {
            InitializeComponent();
        }

        public PrintPreviewControl PrintPreviewControl
        {
            get { return ppcIC; }
        }

        public int PageCount
        {
            set { lbPageCount.Text = value.ToString(); }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog(this) == DialogResult.OK)
            {
                PrintPreviewControl.Document.PrinterSettings = pd.PrinterSettings;
                PrintPreviewControl.Document.Print();
            }
        }
    }
}