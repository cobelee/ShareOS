<%@ Page Title="导入银行账户信息" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="ImportBankAccount.aspx.cs" Inherits="Admin_ImportBankAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h1>导入银行账户信息</h1>
    <div style="padding: 20px; border: 1px solid #696969; margin: 10px 0;">
        <div style="font-size: 1.3em; font-weight: bold;">
            CSV数据文件格式
        </div>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/Default/Images/ImportBankAccount.jpg"
            Width="500px" /><br />
        1、数据文件为csv格式，数据排布样式如上图所示。第一行标题列必须存在，但列名可自定义，不会作为数据导入。
        数据共五列，第一列为股东号，不是工号（用于定位数据）；第二列为股东姓名（不导入）；第三列为账户名称（导入）；
        第四列为银行名称（导入）；第五列为银行账户（导入）。
        2、导入过程约持续30秒左右，请耐心等候。
    </div>
    <div>
        <div>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="btnImport" runat="server" Text="导入数据" OnClick="btnImport_Click" OnClientClick='return confirm("开弓没有回头箭,请再次确认导入的数据文件是否正确！！！");' />
        </div>
        <div style="margin: 20px 0 0 0;">
            <asp:TextBox ID="tbImportData" runat="server" Rows="10" TextMode="MultiLine" Height="250px"
                Width="500px"></asp:TextBox>
        </div>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <asp:Label ID="Label1" runat="server" Text="数据导入成功！" ForeColor="Green" Font-Size="1.2em"></asp:Label><br />
            <br />
            共导入
            <asp:Label ID="lbImportRowCount" runat="server" Text=""></asp:Label>行数据。
        </asp:Panel>
    </div>
</asp:Content>
