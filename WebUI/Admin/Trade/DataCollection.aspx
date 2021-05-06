<%@ Page Title="股权转让受让数据采集" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="DataCollection.aspx.cs" Inherits="Admin_ShareOwnershipChange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>股权转让受让数据采集</h1>
    <div style="padding: 20px; margin: 10px 0;">
        <h2>提示：</h2>
        <h4>此表内容复制到Excel软件中，并制作成腾讯文档，并在干事群中共享，各单位干事共同协作采集必要数据，方便后期导入。</h4>
    </div>
    股权交易期数：<asp:DropDownList ID="ddlIssueNumber" runat="server">
    </asp:DropDownList>
    <asp:Button ID="btnQuery" runat="server" Text="  查询  " />
    <asp:GridView ID="gvOwnershipChange" runat="server" AutoGenerateColumns="False"
        AllowSorting="True" DataSourceID="odsChange" EmptyDataText="查询结果为空" EnableTheming="True">
        <Columns>
            <asp:TemplateField HeaderText="#">
                <ItemTemplate>
                    <asp:Literal ID="ltlIndex" runat="server" Text='<%# Container.DisplayIndex+1 %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="DepName" HeaderText="部门" SortExpression="DepName" />
            <asp:BoundField DataField="ShareholderNumber" HeaderText="股东号" SortExpression="ShareholderNumber">
                <ItemStyle Width="50px" />
            </asp:BoundField>
            <asp:BoundField DataField="JobNumber" HeaderText="工号" SortExpression="JobNumber" />
            <asp:BoundField DataField="ShareholderName" HeaderText="姓名" SortExpression="ShareholderName" />
            <asp:TemplateField HeaderText="性别">
                <ItemTemplate>
                    <asp:Label ID="lbSex" runat="server" Text='<%#Convert.ToBoolean(Eval("Sex")) ? "男" : "女" %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="20px" />
            </asp:TemplateField>
            <asp:BoundField DataField="QichuShares" DataFormatString="{0:N0}" HeaderText="期初持股" SortExpression="QichuShares"
                ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="PeifaBonusShares" DataFormatString="{0:N2}" HeaderText="派发红股">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField HeaderText="申请转让" />
            <asp:BoundField HeaderText="申请受让" />

            <asp:BoundField DataField="AccountHolder" HeaderText="户名" />
            <asp:BoundField DataField="BankName" HeaderText="开户行" />
            <asp:BoundField DataField="AccountNumber" HeaderText="账户号码" />
            <asp:BoundField HeaderText="数据核对确认" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsChange" runat="server" SelectMethod="GetDataCollectionTable"
        TypeName="ShareOS.BLL.FinanceReport">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlIssueNumber" Name="issueNumber" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
