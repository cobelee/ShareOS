using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ImportShareChanges : System.Web.UI.Page
{
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
        lbCurrentPrice.Text = bll_office.GetSharePrice(bll_office.GetLastIssueNumber()).ToString();
    }

    protected override void OnError(EventArgs e)
    {
        System.Exception error = Server.GetLastError();
        if (error != null)
            Response.Redirect("~/ErrorPage.aspx?Error=" + error.InnerException.Message + "&urlFrom=" + Request.Url.ToString());
    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        System.Web.HttpPostedFile file = FileUpload1.PostedFile;
        System.IO.Stream stream = file.InputStream;
        System.IO.StreamReader reader = new System.IO.StreamReader(stream, System.Text.Encoding.Default);

        decimal sharePrice = bll_office.GetSharePrice(bll_office.GetLastIssueNumber());
        string jobNumber = User.Identity.Name;

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
            if (arrayLine == null || arrayLine.Count() < 2)
                continue;

            int shareholderNumber = 0;
            int.TryParse(arrayLine[0], out shareholderNumber);

            decimal changes = 0m;
            decimal.TryParse(arrayLine[1], out changes);
            if (changes < 0)
                throw new Exception("股权数值要求大于0");

            switch (ddlChangeType.Text)
            {
                case "配发红股": break;
                case "退股": break;
                case "红股转让": bll_shareOwnership.HongguZhuanrang(shareholderNumber, changes, sharePrice, jobNumber);
                    break;
                case "个人购买": bll_shareOwnership.BuyShares(shareholderNumber, changes, sharePrice, jobNumber);
                    break;
            }

            sb.AppendLine(line);
        }

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
}