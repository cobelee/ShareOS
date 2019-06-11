using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Person_ShareOwnershipRecord : System.Web.UI.Page
{
    ShareOS.BLL.ShareOwnershipManage bll_som = new ShareOS.BLL.ShareOwnershipManage();
    ShareOS.BLL.ShareholderRegister bll_sr = new ShareOS.BLL.ShareholderRegister();

    protected void Page_Load(object sender, EventArgs e)
    {
        Load_ShareOwnership_Record();
    }

    protected void Load_ShareOwnership_Record()
    {
        if (User.Identity.IsAuthenticated)
        {
            if (bll_sr.ExistShareholder(User.Identity.Name))
            {
                ShareOS.Model.Shareholder shareholder = bll_sr.GetShareholder(User.Identity.Name);
                lbShareholderName.Text = shareholder.ShareholderName;
                DataTable table = bll_som.GetPersonalShareOwnershipReport(shareholder.ShareholderNumber);
                gvPersonShareOwnership.DataSource = table;
                gvPersonShareOwnership.DataBind();
            }
            else
            {
                Session["ErrorMessage"] = "非股东，无法查询相关信息！";
                Response.Redirect("~/Error.aspx");
            }
        }
        else
        {
            Session["ErrorMessage"] = "信息需要登录后才能查询！";
            Response.Redirect("~/Error.aspx");
        }

    }
}
