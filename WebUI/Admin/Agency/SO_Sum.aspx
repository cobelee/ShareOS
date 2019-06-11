<%@ Page Title="代理股权数汇总" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="SO_Sum.aspx.cs" Inherits="Admin_SO_Sum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <h1>代理股权数汇总</h1>
            <br />
            <p>
                股权总数：<asp:Label ID="lbShO" runat="server" Text="" ></asp:Label><br />
                计算方法：将历年所有进出股权数相加汇总。
            </p>
            <asp:HiddenField ID="hfIssueNumber" runat="server" />
            <br />
            <asp:GridView ID="gvAgent" runat="server" AutoGenerateColumns="False"
                DataKeyNames="ShareholderId" ShowFooter="True">
                <Columns>
                    <asp:TemplateField HeaderText="No.">
                        <ItemTemplate>
                            <asp:Literal ID="ltlIndex" runat="server" Text='<%# (Container.DisplayIndex+1).ToString() %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ShareholderNumber" HeaderText="股东号" SortExpression="ShareholderNumber"
                        ReadOnly="true">
                        <ItemStyle Width="45px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="JobNumber" HeaderText="工号" SortExpression="JobNumber"
                        ReadOnly="true" />
                    <asp:BoundField DataField="ShareholderName" HeaderText="股东代表" SortExpression="ShareholderName"
                        ReadOnly="true">
                        <ItemStyle Width="40px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="性别" SortExpression="Sex">
                        <ItemTemplate>
                            <asp:Label ID="lbSex" runat="server" Text='<%#Convert.ToBoolean(Eval("Sex")) ? "男" : "女" %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="代理人数">
                        <ItemTemplate>
                            <asp:Literal ID="ltlCount" runat="server" Text='<%# GetCount(Convert.ToInt32(Eval("ShareholderNumber"))) %>'></asp:Literal>
                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="期初股权总数">
                        <ItemTemplate>
                            <asp:Literal ID="ltlQichuShares" runat="server" Text='<%# GetQichuShares(Convert.ToInt32(Eval("ShareholderNumber"))) %>'></asp:Literal>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Literal ID="ltlQichuSharesSum" runat="server" Text='<%# GetQichuSharesSum() %>'></asp:Literal>
                        </FooterTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="期末股权总数">
                        <ItemTemplate>
                            <asp:Literal ID="ltlShareTotals" runat="server" Text='<%# GetShareTotals(Convert.ToInt32(Eval("ShareholderNumber"))) %>'></asp:Literal>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Literal ID="ltlShareTotalsSum" runat="server" Text='<%# GetShareTotalsSum() %>'></asp:Literal>
                        </FooterTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>

                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="Label1" runat="server" Text="该代理人下无任何股东。"></asp:Label>
                </EmptyDataTemplate>
                <FooterStyle HorizontalAlign="Right" />
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

