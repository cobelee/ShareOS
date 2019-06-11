<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.SessionState" %>
<%@ Import Namespace="System.Security.Principal" %>


<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // 在应用程序启动时运行的代码

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  在应用程序关闭时运行的代码

    }

    protected void Application_AuthenticateRequest(Object sender, EventArgs e)
    {
        HttpContext context = HttpContext.Current;
        if (context.User != null) //&& context.User.Identity.IsAuthenticated) 
        {
            //Create a generic identity.
            GenericIdentity userIdentity = new GenericIdentity(context.User.Identity.Name, "Forms");

            //Create a generic principal.
            string[] users = ((System.Web.Security.FormsIdentity)context.User.Identity).Ticket.UserData.Split(',');

            GenericPrincipal userPrincipal = new GenericPrincipal(userIdentity, users);

            //Set the new Principal to the Current User
            context.User = userPrincipal;
        }
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // 在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // 在新会话启动时运行的代码

    }

    void Session_End(object sender, EventArgs e) 
    {
        // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
        // 或 SQLServer，则不会引发该事件。

    }
       
</script>
