using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ShareOwnershipListAll : System.Web.UI.Page
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

    protected decimal GetSharesSum()
    {
        decimal sum = 0;
        foreach (GridViewRow row in gvShareOwnership.Rows)
        {
            decimal shareTotals = 0m;
            decimal.TryParse(row.Cells[6].Text, out shareTotals);
            sum += shareTotals;
        }
        return sum;
    }
    protected void gvShareOwnership_DataBound(object sender, EventArgs e)
    {
        lbSh.Text = gvShareOwnership.Rows.Count.ToString("N0");
        lbShO.Text = GetSharesSum().ToString("N0");

    }
}