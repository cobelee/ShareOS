using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SyncDepName : System.Web.UI.Page
{
    ShareOS.BLL.ShareOwnershipManage bll_Shares = new ShareOS.BLL.ShareOwnershipManage();
    ShareOS.BLL.ShareIssueManage bll_Issue = new ShareOS.BLL.ShareIssueManage();
    ShareOS.BLL.ShareholderManage bll_shareholder = new ShareOS.BLL.ShareholderManage();
    Tiyi.MyDesktop.BLL.DepManage bll_dep = new Tiyi.MyDesktop.BLL.DepManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }

    }

    private void Init_Load()
    {
        Load_DepName();
        Load_sharehoder();

    }



    protected void Page_Unload(object sender, EventArgs e)
    {
        bll_Shares.Dispose();
        bll_Issue.Dispose();
        bll_shareholder.Dispose();
    }

    private void Load_DepName()
    {
        var deps = bll_dep.GetDep();
        ddlDep.Items.Clear();
        foreach (var dep in deps)
        {
            ddlDep.Items.Add(dep.DepName);
        }
        ddlDep.Items.Insert(0, "--所有部门--");
        ddlDep.SelectedIndex = 0;
    }

    private void Load_sharehoder()
    {
        Tiyi.ShareOS.SQLServerDAL.SharesIssueConfig config = bll_Issue.GetIssueConfigByYear(DateTime.Now.Year);
        if (config != null)
        {
            System.Data.DataTable sharesReport = bll_Shares.GetShareOwnershipReport((int)config.IssueNumber);
            DataView dv = sharesReport.DefaultView;
            dv.Sort = "Department";
            if (ddlDep.SelectedIndex > 0)
            {
                dv.RowFilter = "Department like '%" + ddlDep.SelectedValue + "%'";
            }
            gvShareOwnership.DataSource = dv;
            gvShareOwnership.DataBind();
        }
    }

    protected void gvShareOwnership_Sorting(object sender, GridViewSortEventArgs e)
    {
        e.SortExpression = "Department";
        gvShareOwnership.DataBind();
    }


    protected void btnQuery_Click(object sender, EventArgs e)
    {
        Load_sharehoder();
    }

    protected void cbSelectAll_CheckedChanged(object sender, EventArgs e)
    {

        CheckBox cbSelectAll = sender as CheckBox;
        //GridView gv = cbSelectAll.Parent.Parent as GridView;
        foreach (GridViewRow row in gvShareOwnership.Rows)
        {
            CheckBox cbSelect = row.Cells[0].FindControl("cbSelect") as CheckBox;
            cbSelect.Checked = cbSelectAll.Checked;
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        List<string> shNumList = new List<string>();
        foreach (GridViewRow row in gvShareOwnership.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox cbSelect = row.Cells[0].FindControl("cbSelect") as CheckBox;
                if (cbSelect.Checked)
                {
                    string shNum = gvShareOwnership.DataKeys[row.RowIndex].Value.ToString();
                    shNumList.Add(shNum);
                }
            }

        }
        Session["ShareholderNumbers"] = string.Join(",", shNumList.ToArray());
        Server.Transfer("PrintBSLogReport_PrintView.aspx", true);
    }
}