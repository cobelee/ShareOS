using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ImportBankAccount : System.Web.UI.Page
{
    ShareOS.BLL.ShareholderManage bll_shm = new ShareOS.BLL.ShareholderManage();
    ShareOS.BLL.ShareOwnershipManage bll_shareOwnership = new ShareOS.BLL.ShareOwnershipManage();
    ShareOS.BLL.MonitorOffice bll_office = new ShareOS.BLL.MonitorOffice();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    protected void Page_UnLoad(object sender, EventArgs e)
    {
        bll_shareOwnership.Dispose();
    }

    private void Init_Load()
    {
    }

    protected override void OnError(EventArgs e)
    {
        System.Exception error = Server.GetLastError();
        if (error != null)
            Response.Redirect("~/ErrorPage.aspx?Error=" + error.InnerException.Message + "&urlFrom=" + Request.Url.ToString());
    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        IQueryable<Tiyi.ShareOS.SQLServerDAL.Shareholder> listshder = bll_shm.SelectShareholder();

        System.Web.HttpPostedFile file = FileUpload1.PostedFile;
        System.IO.Stream stream = file.InputStream;
        System.IO.StreamReader reader = new System.IO.StreamReader(stream, System.Text.Encoding.Default);

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        string line = string.Empty;
        int lineNumber = 0;
        while (!reader.EndOfStream)
        {
            line = reader.ReadLine();

            lineNumber++;
            if (lineNumber == 1)
                continue;

            string[] arrayLine;
            arrayLine = line.Split(',');
            if (arrayLine == null || arrayLine.Count() < 5)
                continue;

            int shareholderNumber = 0;
            int.TryParse(arrayLine[0], out shareholderNumber);

            string accountHolder = string.Empty;
            accountHolder = arrayLine[2];   // 读取账户名称
            string bankName = arrayLine[3];  // 读取开户银行名称
            string accountNumber = arrayLine[4];  // 读取账户号码


            var sh = (from c in listshder where c.ShareholderNumber == shareholderNumber select c).FirstOrDefault();
            if (sh != null && sh.ShareholderName==arrayLine[1])
            {
                sh.AccountHolder = accountHolder;
                sh.BankName = bankName;
                sh.AccountNumber = accountNumber;
            }

            sb.AppendLine(line);
        }

        bll_shm.Submit();

        if (lineNumber >= 2)
        {
            tbImportData.Text = sb.ToString();
            lbImportRowCount.Text = (lineNumber - 1).ToString();
            Panel1.Visible = true;
        }
        else
        {
            tbImportData.Text = "无数据导入";
        }

    }

    // 在股东列表中查找指定股东号的股东，并更新银行账户信息。
    protected void FillAccountInfo(int shareholderNumber, string accountHolder, string bankName, string accountNumber, IQueryable<Tiyi.ShareOS.SQLServerDAL.Shareholder> listSher)
    {
        foreach (Tiyi.ShareOS.SQLServerDAL.Shareholder sh in listSher)
        {
            if (sh.ShareholderNumber == shareholderNumber)
            {
                sh.AccountHolder = accountHolder;
                sh.BankName = bankName;
                sh.AccountNumber = accountNumber;
                break;
            }
        }
    }
}