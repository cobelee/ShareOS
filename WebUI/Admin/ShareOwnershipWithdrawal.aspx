<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="ShareOwnershipWithdrawal.aspx.cs" Inherits="Admin_ShareOwnershipWithdrawal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        股权清退报表</h1>
    股权交易期数：<asp:DropDownList ID="ddlIssueNumber" runat="server">
    </asp:DropDownList>
    <asp:Button ID="btnQuery" runat="server" Text="  查询  " OnClick="btnQuery_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnExport" runat="server" Text=" 导出 Excel 报表 " OnClick="btnExport_Click" />
    <asp:GridView ID="gvOwnershipChange" runat="server" Width="625px" AutoGenerateColumns="False"
        AllowSorting="True" DataSourceID="odsChange" EmptyDataText="查询结果为空" EnableTheming="True">
        <Columns>
            <asp:BoundField DataField="ShareholderNumber" HeaderText="股东号" SortExpression="ShareholderNumber" />
            <asp:BoundField DataField="JobNumber" HeaderText="工号" SortExpression="JobNumber" />
            <asp:BoundField DataField="ShareholderName" HeaderText="姓名" SortExpression="ShareholderName" />
            <asp:TemplateField HeaderText="性别">
                <ItemTemplate>
                    <asp:Label ID="lbSex" runat="server" Text='<%#Convert.ToBoolean(Eval("Sex")) ? "男" : "女" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="40px" />
            </asp:TemplateField>
            <asp:BoundField DataField="PersonType" HeaderText="人员类别" SortExpression="PersonType" />
            <asp:BoundField DataField="EntrustedAgentName" HeaderText="代理人" SortExpression="EntrustedAgentName" />
            <asp:BoundField DataField="SharesChanges" HeaderText="股权变动" SortExpression="SharesChanges"
                DataFormatString="{0:N2}">
                <ItemStyle HorizontalAlign="Right" Width="100px" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsChange" runat="server" SelectMethod="GetSharesWithdrawal"
        TypeName="ShareOS.BLL.ShareOwnershipManage">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlIssueNumber" Name="issueNumber" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
