<%@ Page Title="打印个人股权清算报告" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="PrintClearingReport.aspx.cs" Inherits="Admin_Trade_PrintClearingReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>打印个人股权清算报告</h1>
    <h4></h4>
    <div>
        当前年份：<asp:Literal ID="ltlYear" runat="server"></asp:Literal>年&nbsp;&nbsp;第
        <asp:Literal ID="ltlIssueNumber" runat="server"></asp:Literal>
        期
    </div>
    <div>
        <asp:Button ID="btnPrint" runat="server" Text="打印股权清退报告" OnClick="btnPrint_Click"></asp:Button></div>
    <asp:GridView ID="gvClearing" runat="server" AllowSorting="True" ShowFooter="True"
        Width="625px" AutoGenerateColumns="False" DataKeyNames="ShareholderNumber">
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
            <asp:BoundField DataField="SharesChanges" HeaderText="退出股数" SortExpression="SharesChanges" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="ShareTotals" HeaderText="当前股权数" SortExpression="ShareTotals"
                DataFormatString="{0:N0}">
                <ItemStyle HorizontalAlign="Right" Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="DepName" HeaderText="部门" SortExpression="DepName" />
        </Columns>
    </asp:GridView>
</asp:Content>

