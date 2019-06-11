using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ConfigAgent : System.Web.UI.Page
{
    ShareOS.BLL.EntrustedAgent bll_agent = new ShareOS.BLL.EntrustedAgent();
    ShareOS.BLL.MonitorOffice bll_monitor = new ShareOS.BLL.MonitorOffice();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Init_Load();
        }
    }

    private void Init_Load()
    {
        IList<ShareOS.Model.EntrustedAgent> agentList = bll_agent.Select();
        gvAgent.DataSource = agentList;
        gvAgent.DataBind();
    }

    protected void gvAgent_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteAgent")
        {
            int shn = Convert.ToInt32(e.CommandArgument);
            if (shn < 1)
            {
                return;
            }
            bll_agent.Delete(shn);
            Init_Load();
        }
    }

    /// <summary>
    /// 获取指定股东代理人名下的股东人数。
    /// </summary>
    /// <param name="shareholderNumber">股东代理人的股东号</param>
    /// <returns></returns>
    protected int GetCount(int shareholderNumber)
    {
        int agencyCount = 0;
        agencyCount = bll_monitor.GetAgencyCount(shareholderNumber);
        return agencyCount;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int agencyShn = 0;
        int.TryParse(tbAgent.Text, out agencyShn);
        if (agencyShn < 1)
            return;

        bll_agent.Create(agencyShn);
        Init_Load();
    }
}