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

public partial class Person_PersonInfo : System.Web.UI.Page
{
    ShareOS.BLL.ShareholderRegister bll_sr = new ShareOS.BLL.ShareholderRegister();

    protected void Page_Load(object sender, EventArgs e)
    {
        Load_Person_Info();
    }

    protected void Load_Person_Info()
    {
        if (User.Identity.IsAuthenticated)
        {
            if (bll_sr.ExistShareholder(User.Identity.Name))
            {
                ShareOS.Model.Shareholder shareholder = bll_sr.GetShareholder(User.Identity.Name);
                lbShareholderName.Text = shareholder.ShareholderName;
                lbSex.Text = shareholder.Sex ? "男" : "女";
                lbStatus.Text = shareholder.Status.ToString();
                lbShareholderNumber.Text = shareholder.ShareholderNumber.ToString();
                lbIdentityCard.Text = shareholder.IdentityCard;
                lbPersonType.Text = shareholder.PersonType;
                ShareOS.BLL.Shareholder ea = bll_sr.GetShareholder(shareholder.EntrustedAgent);
                lbEntrustedAgent.Text = ea.ShareholderName;
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
