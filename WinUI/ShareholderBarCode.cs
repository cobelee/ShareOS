using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cobainsoft.Windows.Forms;

namespace WinUI
{
    public partial class ShareholderBarCode : Form
    {
        ShareOS.BLL.ShareholderRegister bll_sr = new ShareOS.BLL.ShareholderRegister();
        Cobainsoft.Windows.Forms.BarcodeControl barcode = new BarcodeControl();

        public ShareholderBarCode()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IList<ShareOS.Model.Shareholder> shareholders = bll_sr.GetShareholderList();
            foreach (ShareOS.Model.Shareholder shareholder in shareholders)
            {
                System.IO.MemoryStream barCodeStream = new System.IO.MemoryStream();
                barcode.Data = shareholder.ShareholderNumber.ToString().PadLeft(8, '0');
                barcode.Caption = barcode.Data;
                barcode.MakeImage(System.Drawing.Imaging.ImageFormat.Png, 1, 70, true, false, null, barCodeStream);
                bll_sr.UpdateBarCode(shareholder.ShareholderNumber, barCodeStream.ToArray());
                barCodeStream.Close();
            }
            MessageBox.Show("条形码已生成完毕");
        }

        private void ShareholderBarCode_Load(object sender, EventArgs e)
        {
            barcode.BarcodeType = BarcodeType.CODE128A;
            barcode.CopyRight = "股东号";
            barcode.TextPosition = BarcodeTextPosition.Below;
        }


    }
}