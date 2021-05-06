using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SyncDepName : System.Web.UI.Page
{
    Tiyi.MyDesktop.BLL.PersonManage bll_person = new Tiyi.MyDesktop.BLL.PersonManage();
    ShareOS.BLL.ShareholderManage bll_shManage = new ShareOS.BLL.ShareholderManage();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSync_Click(object sender, EventArgs e)
    {
        var listsh = bll_shManage.SelectShareholder();


        foreach (Tiyi.ShareOS.SQLServerDAL.Shareholder sh in listsh)
        {
            var person = bll_person.GetPerson(sh.JobNumber);
            if (person == null)
                continue;
            string depName = string.Empty;

            if (person.Dept4 == "公司领导")
                depName = person.Dept4;
            else
            {
                if (person.Dept4.Contains(person.Dept3))
                    depName = person.Dept4;
                else
                    depName = person.Dept3 + person.Dept4;
            }


            sh.DepName = depName;
        }

        bll_shManage.Submit();
        lbSyncResult.Visible = true;
        lbImportRowCount.Text = "共同步 " + listsh.Count().ToString() + " 行数据。";
        lbImportRowCount.Visible = true;
    }
}