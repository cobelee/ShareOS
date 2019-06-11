using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ErrorPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Error"] != null)
            {
                ltlErrorMessage.Text = Request.QueryString["Error"];
            }
        }
    }
    protected void btnGoBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.QueryString["urlFrom"]);
    }
}