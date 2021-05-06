using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_LogOffIdentity : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void cbSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cbSelectAll = sender as CheckBox;
        foreach (GridViewRow row in gvRegister.Rows)
        {
            (row.Cells[0].FindControl("cbSelect") as CheckBox).Checked = cbSelectAll.Checked;
        }
    }
    protected void btnLogoutStatus_Click(object sender, EventArgs e)
    {
        ShareOS.BLL.ShareholderRegister bll_sr = new ShareOS.BLL.ShareholderRegister();

        int checkCount = 0;
        bool haveLogout = false;

        foreach (GridViewRow row in gvRegister.Rows)
        {
            if ((row.Cells[0].FindControl("cbSelect") as CheckBox).Checked)
            {
                int shareholderNumber = Convert.ToInt32(gvRegister.DataKeys[row.RowIndex].Value);
                ShareOS.BLL.Shareholder person = bll_sr.GetShareholder(shareholderNumber);
                person.SetStatus(ShareOS.Model.ShareholderStatus.退出人员);
                checkCount++;
                haveLogout = true;
            }

        }
        if (checkCount == 0 || gvRegister.Rows.Count == 0)
        {
            ajaxMessageBox1.MessageText = "请勾选股东";
            ajaxMessageBox1.Show();
        }
        if (haveLogout)
        {
            ajaxMessageBox1.MessageText = "操作成功！";
            ajaxMessageBox1.Show();
        }
        gvRegister.DataBind();
    }
}