<%@ Page Title="股权变动查询" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="ShareOwnershipChange.aspx.cs" Inherits="Admin_ShareOwnershipChange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        股权变动查询</h1>
    股权交易期数：<asp:DropDownList ID="ddlIssueNumber" runat="server">
    </asp:DropDownList>
    <asp:Button ID="btnQuery" runat="server" Text="  查询  "  />
    <asp:GridView ID="gvOwnershipChange" runat="server" Width="625px" AutoGenerateColumns="False"
        AllowSorting="True" DataSourceID="odsChange" EmptyDataText="查询结果为空" EnableTheming="True">
        <Columns>
            <asp:BoundField DataField="ShareholderNumber" HeaderText="股东号" SortExpression="ShareholderNumber" />
            <asp:BoundField DataField="ShareholderName" HeaderText="姓名" SortExpression="ShareholderName" />
            <asp:TemplateField HeaderText="性别">
                <ItemTemplate>
                    <asp:Label ID="lbSex" runat="server" Text='<%#Convert.ToBoolean(Eval("Sex")) ? "男" : "女" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="20px" />
            </asp:TemplateField>
            <asp:BoundField DataField="PeifaBonusShares" HeaderText="配发红股" />
            <asp:BoundField DataField="ZhuanrangBonusShares" HeaderText="红股转让" />
            <asp:BoundField DataField="GerenGuomaiShares" HeaderText="个人购买" SortExpression="GerenGuomaiShares"
                DataFormatString="{0:N0}">
                <ItemStyle HorizontalAlign="Right" Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="ShareTotals" HeaderText="当前股权数">
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="EntrustedAgentName" HeaderText="代理人" SortExpression="EntrustedAgentName" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsChange" runat="server" SelectMethod="GetShareOwnershipChange"
        TypeName="ShareOS.BLL.ShareOwnershipManage">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlIssueNumber" Name="issueNumber" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
