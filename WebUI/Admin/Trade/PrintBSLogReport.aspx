<%@ Page Title="批量打印历年股权变动表" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="PrintBSLogReport.aspx.cs" Inherits="Admin_SyncDepName" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>批量打印历年股权变动表</h1>
    <h4>1、股东信息与人事数据库并非实时同步，在打印此报告前，请手动同步人员的部门信息。<br />
        2、可以以部门为单位进行打印，也可以随意选择人员进行打印。
    </h4>

    <div>
        选择部门：<asp:DropDownList ID="ddlDep" runat="server"></asp:DropDownList>
        <asp:Button ID="btnQuery" runat="server" Text="查询" OnClick="btnQuery_Click" />
        &nbsp;&nbsp;<asp:Button ID="btnPrint" runat="server" Text="打印股权变动单" OnClick="btnPrint_Click"></asp:Button>
    </div>

    <asp:GridView ID="gvShareOwnership" runat="server" AllowSorting="True" ShowFooter="True"
        Width="625px" AutoGenerateColumns="False" OnSorting="gvShareOwnership_Sorting" DataKeyNames="ShareholderNumber">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:CheckBox ID="cbSelectAll" runat="server" AutoPostBack="True" OnCheckedChanged="cbSelectAll_CheckedChanged" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="cbSelect" runat="server" />
                </ItemTemplate>
                <HeaderStyle Width="20px" />
                <ItemStyle Width="20px" />
            </asp:TemplateField>
            <asp:BoundField DataField="ShareholderNumber" HeaderText="股东号" SortExpression="ShareholderNumber">
                <ItemStyle Width="30px" />
            </asp:BoundField>
            <asp:BoundField DataField="ShareholderName" HeaderText="姓名" SortExpression="ShareholderName" />
            <asp:TemplateField HeaderText="性别">
                <ItemTemplate>
                    <asp:Label ID="lbSex" runat="server" Text='<%#Convert.ToBoolean(Eval("Sex")) ? "男" : "女" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="40px" />
            </asp:TemplateField>
            <asp:BoundField DataField="EntrustedAgentName" HeaderText="代理人" SortExpression="EntrustedAgentName" />
            <asp:BoundField DataField="ShareTotals" HeaderText="当前股权数" SortExpression="ShareTotals"
                DataFormatString="{0:N0}">
                <ItemStyle HorizontalAlign="Right" Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Department" HeaderText="部门" SortExpression="Department" />
        </Columns>
    </asp:GridView>
</asp:Content>

