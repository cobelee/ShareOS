using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CreateShareholder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SEA_Shareholder1.ShareholderCreated += new EventHandler(SEA_Shareholder1_ShareholderCreated);
    }

    void SEA_Shareholder1_ShareholderCreated(object sender, EventArgs e)
    {
        AjaxMessageBox1.Show("新股东已创建成功");
    }

    protected override void OnError(EventArgs e)
    {
        System.Exception error = Server.GetLastError();
        if (error != null)
            Response.Redirect("~/ErrorPage.aspx?Error=" + error.InnerException.Message + "&urlFrom=" + Request.Url.ToString());
    }
}