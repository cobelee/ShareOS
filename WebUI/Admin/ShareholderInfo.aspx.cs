using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ShareholderInfo : System.Web.UI.Page
{
    ShareOS.BLL.MonitorOffice bll_office = new ShareOS.BLL.MonitorOffice();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void Init_Load()
    {
        hfIssueNumber.Value = bll_office.GetLastIssueNumber().ToString();
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        lbSh.Text = GridView1.Rows.Count.ToString();
    }
}