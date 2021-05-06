using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Shareholder_ShareholderList : System.Web.UI.Page
{
    ShareOS.BLL.ShareholderManage bll_shm = new ShareOS.BLL.ShareholderManage();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void Init_Load()
    {
        var shs = bll_shm.SelectShareholder();
        gvShareholderList.DataSource = shs;
        gvShareholderList.DataBind();
        bll_shm.Dispose();
    }

    private void BindGV()
    {
        var shs = bll_shm.SelectShareholder();
        gvShareholderList.DataSource = shs;
        gvShareholderList.DataBind();
        bll_shm.Dispose();
    }


    protected void gvShareholderList_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void gvShareholderList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvShareholderList.EditIndex = e.NewEditIndex;
        BindGV();
    }

    protected void gvShareholderList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvShareholderList.EditIndex = -1;
        BindGV();
    }

    protected void gvShareholderList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var shNumber = Convert.ToInt32(e.Keys["ShareholderNumber"]);
        var sh = bll_shm.SelectShareholder(shNumber);
        sh.AccountHolder = e.NewValues["AccountHolder"].ToString();
        sh.BankName = e.NewValues["BankName"].ToString();
        sh.AccountNumber = e.NewValues["AccountNumber"].ToString();
        bll_shm.Update(sh);
        gvShareholderList.EditIndex = -1;
        BindGV();
    }
}