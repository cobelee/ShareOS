<%@ Page Title="导入股权变动数据" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="ImportShareChanges.aspx.cs" Inherits="Admin_ImportShareChanges" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h1>
        导入股权变动数据</h1>
    <div style="padding: 20px; border: 1px solid #696969; margin: 10px 0;">
        <div style="font-size: 1.3em; font-weight: bold;">
            CSV数据文件格式</div>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/Default/Images/DataImportTemp.png"
            Width="300px" /><br />
        数据文件为csv格式，数据排布样式如上图所示。第一行标题列必须存在，但列名可自定义，不会作为数据导入。<br />
        数据共两列，第一列为股东号，不是工号；第二列为股权变动数值，一定要是正值。
    </div>
    <div>
        <div style="padding: 20px 0px;">
            请确认当前股权交易价格为：<asp:Label ID="lbCurrentPrice" runat="server" Text="0.00" ForeColor="Red"></asp:Label>，若有误，请重新设置股权交易价格后再执行导入数据。
        </div>
        <div>
            股权变动类型：<asp:DropDownList ID="ddlChangeType" runat="server">
                <asp:ListItem>配发红股</asp:ListItem>
                <asp:ListItem>退股</asp:ListItem>
                <asp:ListItem>红股转让</asp:ListItem>
                <asp:ListItem>个人购买</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="btnImport" runat="server" Text="导入数据" OnClick="btnImport_Click" OnClientClick='return confirm("开弓没有回头箭,请再次确认股价及股权变动类型是否正确！！！");' />
        </div>
        <div style="margin: 20px 0 0 0;">
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
