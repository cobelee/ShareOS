<%@ Page Title="在职人员年度结算" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="YearlySettlement.aspx.cs" Inherits="Admin_Finance_YearlySettlement" %>

<asp:Content ID="Head1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h1>在职人员年度结算</h1>
    股权交易期数：<asp:DropDownList ID="ddlIssueNumber" runat="server">
    </asp:DropDownList>
    <asp:Button ID="btnQuery" runat="server" Text="  查询  " />&nbsp;&nbsp;<asp:Button ID="btnGenerate" runat="server" Text="开始年度结算" OnClick="btnGenerate_Click" />
    <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" Width="100%" AutoGenerateColumns="False"
        ShowFooter="True" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="#">
                <ItemTemplate>
                    <asp:Literal ID="ltlIndex" runat="server" Text='<%# Container.DisplayIndex+1 %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ShareholderNumber" HeaderText="股东号" />
            <asp:BoundField DataField="JobNumber" HeaderText="工号" />
            <asp:BoundField DataField="ShareholderName" HeaderText="姓名" />
            <asp:TemplateField HeaderText="性别">
                <ItemTemplate>
                    <asp:Literal ID="lbSex" runat="server" Text='<%# Convert.ToBoolean(Eval("Sex"))?"男":"女" %>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Status" HeaderText="股东身份" />
            <asp:BoundField DataField="DepName" HeaderText="所在部门" />
            <asp:BoundField DataField="OpeningShares" HeaderText="期初股权" NullDisplayText="0" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N0}" />
            <asp:BoundField DataField="DonateShares" HeaderText="本期派股" NullDisplayText="0.00" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" />
            <asp:BoundField DataField="SellingShares" HeaderText="转让数额" NullDisplayText="0.0000" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" />
            <asp:BoundField DataField="SharePrice" HeaderText="当期股价" NullDisplayText="0.0000" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N4}" />
            <asp:BoundField DataField="Amount" HeaderText="转让金额" NullDisplayText="0.00" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" />
            <asp:BoundField DataField="IncomeTax" HeaderText="扣除个税" NullDisplayText="0.00" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" />
            <asp:BoundField DataField="Yingfa" HeaderText="应发" NullDisplayText="0.00" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}"
                FooterText="8888" FooterStyle-HorizontalAlign="Right" FooterStyle-Font-Bold="true"></asp:BoundField>
            <asp:BoundField DataField="ClosingShares" HeaderText="期末股权" NullDisplayText="0" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N0}" />
        </Columns>
    </asp:GridView>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetSettlementReport" TypeName="ShareOS.BLL.FinanceReport"
        FilterExpression="Status='股东'">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlIssueNumber" Name="issueNumber" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

