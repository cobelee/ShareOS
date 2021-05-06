<%@ Page Title="银行打款清单" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="BankPaymentSlip.aspx.cs" Inherits="Admin_Finance_YearlySettlement" %>

<asp:Content ID="Head1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h1>银行打款清单</h1>
    <div style="padding: 20px; margin: 10px 0; width: 100%">
        股权交易期数：<asp:DropDownList ID="ddlIssueNumber" runat="server"></asp:DropDownList>
        &nbsp;&nbsp;
        选择银行：<asp:DropDownList ID="ddlBank" runat="server"></asp:DropDownList>
        &nbsp;&nbsp;
        股东身份：<asp:DropDownList ID="ddlStatus" runat="server">
            <asp:ListItem Text="全部" Value="全部" Selected="True"></asp:ListItem>
            <asp:ListItem Text="股东" Value="股东"></asp:ListItem>
            <asp:ListItem Text="待退股东" Value="待退股东"></asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnQuery" runat="server" Text="  查询  " OnClick="btnQuery_Click" />
    </div>

    &nbsp;&nbsp;<asp:Button ID="btnGenerate" runat="server" Text="开始年度结算" OnClick="btnGenerate_Click" />

    <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" Width="100%" AutoGenerateColumns="False"
        ShowFooter="True" OnRowDataBound="GridView1_RowDataBound" OnDataBinding="GridView1_DataBinding">
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
            <asp:BoundField DataField="SettlementType" HeaderText="结算类型" />
            <asp:BoundField DataField="IncomeTax" HeaderText="扣除个税" NullDisplayText="0.00" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}"
                FooterStyle-HorizontalAlign="Right" FooterStyle-Font-Bold="true" />
            <asp:BoundField DataField="Yingfa" HeaderText="进卡金额" NullDisplayText="0.00" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}"
                FooterStyle-HorizontalAlign="Right" FooterStyle-Font-Bold="true"></asp:BoundField>
            <asp:BoundField DataField="AccountHolder" HeaderText="户名" />
            <asp:BoundField DataField="BankName" HeaderText="开户行" />
            <asp:BoundField DataField="AccountNumber" HeaderText="账户号码" />
        </Columns>
    </asp:GridView>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetBankPaymentSlip" TypeName="ShareOS.BLL.FinanceReport">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlIssueNumber" Name="issueNumber" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

