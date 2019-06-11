<%@ Page Title="批量更新股东代表信息" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="UpdateEntrustedAgent.aspx.cs" Inherits="Admin_UpdateEntrustedAgent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h1>
        批量更新股东代表信息</h1>
    <div style="padding: 20px; border: 1px solid #696969; margin: 10px 0;">
        <div style="font-size: 1.3em; font-weight: bold;">
            CSV数据文件格式</div>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/Default/Images/UpdateEntrustedAgent.png"
            Width="300px" /><br />
        因《公司法》限定有限责任公司股东数为50人以内，公司自然人股东由股东代表代持股权，股东代表的选举跟随董事会换届同时改选，三年变更一次股东代表。<br />
        股东代表信息更新可以由csv文件批量导入，数据排布样式如上图所示。第一行标题列必须存在，但列名可自定义，不会作为数据导入。<br />
        数据共两列，第一列为股东号，不是工号；第二列为股权代表的股东号。
    </div>
    <div>
        <div>
            <br />
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="btnImport" runat="server" Text="导入数据" OnClick="btnImport_Click" OnClientClick='return confirm("点击确认开始执行批量更新操作！！！");' />
        </div>
        <div style="margin: 20px 0 0 0;">
            导入操作需 10 - 20 秒，请耐心等候。<br />
            <asp:TextBox ID="tbImportData" runat="server" Rows="10" TextMode="MultiLine" Height="250px"
                Width="500px"></asp:TextBox></div>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <asp:Label ID="Label1" runat="server" Text="数据导入成功！" ForeColor="Green" Font-Size="1.2em"></asp:Label><br />
            <br />
            共导入
            <asp:Label ID="lbImportRowCount" runat="server" Text=""></asp:Label>行数据。
        </asp:Panel>
    </div>
</asp:Content>
