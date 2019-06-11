<%@ Page Title="所有股东股权" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="ShareOwnershipListAll.aspx.cs" Inherits="Admin_ShareOwnershipListAll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        所有股东股权</h1>
    <p>
        股东总数：<asp:Label ID="lbSh" runat="server" Text=""></asp:Label><br />
        股权总数：<asp:Label ID="lbShO" runat="server" Text=""></asp:Label></p>
    <asp:HiddenField ID="hfIssueNumber" runat="server" />
    <asp:GridView ID="gvShareOwnership" runat="server" AllowSorting="True" ShowFooter="True"
        Width="625px" DataSourceID="odsSO" AutoGenerateColumns="False" OnDataBound="gvShareOwnership_DataBound">
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
            <asp:BoundField DataField="ShareTotals" HeaderText="股权数" SortExpression="ShareTotals"
                DataFormatString="{0:N0}">
                <ItemStyle HorizontalAlign="Right" Width="100px" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsSO" runat="server" SelectMethod="GetShareOwnershipReport"
        TypeName="ShareOS.BLL.ShareOwnershipManage">
        <SelectParameters>
            <asp:ControlParameter ControlID="hfIssueNumber" Name="issueNumber" 
                PropertyName="Value" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
