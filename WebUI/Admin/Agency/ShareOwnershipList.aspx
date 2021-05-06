<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="ShareOwnershipList.aspx.cs" Inherits="Admin_ShareOwnershipList" Title="代理股权查询" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>代理股权查询</h1>
    <h3>选择股东代理人：<asp:DropDownList ID="ddlAgents" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAgents_SelectedIndexChanged">
    </asp:DropDownList>
    </h3>
    <p class="post-footer">
        股东人数：<asp:Label ID="lbCountOfShareholder" runat="server" Text="Label"></asp:Label>
        位<br />
        (提示：点击列名，可排序。)
    </p>
    <asp:GridView ID="gvShareOwnership" runat="server" AllowSorting="True" AutoGenerateColumns="False"
        OnSorting="gvShareOwnership_Sorting" ShowFooter="True" Width="100%">
        <Columns>
            <asp:BoundField DataField="ShareholderNumber" HeaderText="股东号" SortExpression="ShareholderNumber" />
            <asp:BoundField DataField="JobNumber" HeaderText="工号" SortExpression="JobNumber" />
            <asp:BoundField DataField="ShareholderName" HeaderText="姓名" SortExpression="ShareholderName">
                <ItemStyle Width="50px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="性别">
                <ItemTemplate>
                    <asp:Label ID="lbSex" runat="server" Text='<%#Convert.ToBoolean(Eval("Sex")) ? "男" : "女" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="人员类别">
                <ItemTemplate>
                    <asp:Label ID="lbPersonType" runat="server" Text='<%#Eval("PersonType") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="身份证号">
                <ItemTemplate>
                    <asp:Label ID="lbIdentityCard" runat="server" Text='<%#Eval("IdentityCard") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ShareTotals" HeaderText="股权数" SortExpression="ShareTotals"
                DataFormatString="{0:N0}">
                <ItemStyle HorizontalAlign="Right" Width="120px" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
