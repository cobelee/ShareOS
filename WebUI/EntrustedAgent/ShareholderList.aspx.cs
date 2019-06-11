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

public partial class EntrustedAgent_ShareholderList : System.Web.UI.Page
{
    ShareOS.BLL.EntrustedAgent bll_ea = new ShareOS.BLL.EntrustedAgent();
    ShareOS.BLL.ShareholderRegister bll_sr = new ShareOS.BLL.ShareholderRegister();
    ShareOS.BLL.ShareOwnershipManage bll_som = new ShareOS.BLL.ShareOwnershipManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            if (bll_sr.ExistShareholder(User.Identity.Name))
            {
                ShareOS.Model.Shareholder shareholder = bll_sr.GetShareholder(User.Identity.Name);
                if (bll_ea.Exist(shareholder.ShareholderNumber))
                {
                    lbEntrustedAgentName.Text = shareholder.ShareholderName;

                    ShareOS.Model.EntrustedAgent ea = new ShareOS.Model.EntrustedAgent();
                    shareholder.CopyTo(ea as ShareOS.Model.Shareholder);
                    Load_ShareholderList(ea);
                }
                else
                {
                    if (bll_ea.IsAssistant(User.Identity.Name))
                    {
                        int agent = bll_ea.GetAgentShareholderNumber(User.Identity.Name);
                        ShareOS.Model.Shareholder shareholder2 = bll_sr.GetShareholder(agent);
                        ShareOS.Model.EntrustedAgent ea = new ShareOS.Model.EntrustedAgent();
                        shareholder2.CopyTo(ea as ShareOS.Model.Shareholder);
                        Load_ShareholderList(ea);
                    }
                    else
                    {
                        Session["ErrorMessage"] = "该信息需要股东代理人才能查询！<br />或者，经由股东代理人为您授权，方可访问。";
                        Response.Redirect("~/Error.aspx");
                    }
                }
            }
        }
        else
        {
            Session["ErrorMessage"] = "信息需要登录后才能查询！";
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void Load_ShareholderList(ShareOS.Model.EntrustedAgent entrustedAgent)
    {
        DataTable table = bll_sr.ConvertToDataTable(bll_sr.Select(entrustedAgent));
        lbCountOfShareholder.Text = table.Rows.Count.ToString();

        DataView view = table.DefaultView;
        gvShareholderList.DataSource = view;
        gvShareholderList.DataBind();
    }
    protected void gvShareholderList_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataView view = gvShareholderList.DataSource as DataView;
        view.Sort = e.SortExpression;
        gvShareholderList.DataBind();
    }
}
