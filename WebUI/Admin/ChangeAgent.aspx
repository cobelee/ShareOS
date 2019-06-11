<%@ Page Title="变更股东代理人" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true"
    CodeFile="ChangeAgent.aspx.cs" Inherits="Admin_ChangeAgent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <h1>
                变更股东代理人</h1>
            根据股东代理人筛选：<asp:DropDownList ID="ddlAgents" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAgents_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            股东代理人变更为：<asp:DropDownList ID="ddlSetAgent" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSetAgent_SelectedIndexChanged">
            </asp:DropDownList>
            （该操作可批量变更股东代理人）
            <asp:GridView ID="gvRegister" runat="server" DataSourceID="odsShareholders" AutoGenerateColumns="False"
                DataKeyNames="ShareholderId" OnRowUpdating="gvRegister_RowUpdating" AllowSorting="True">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="cbSelect" runat="server" />
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="ShareholderNumber" HeaderText="股东号" SortExpression="ShareholderNumber"
                        ReadOnly="true">
                        <ItemStyle Width="45px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="JobNumber" HeaderText="工号" SortExpression="JobNumber"
                        ReadOnly="true" />
                    <asp:BoundField DataField="ShareholderName" HeaderText="姓名" SortExpression="ShareholderName"
                        ReadOnly="true">
                        <ItemStyle Width="40px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="性别" SortExpression="Sex">
                        <ItemTemplate>
                            <asp:Label ID="lbSex" runat="server" Text='<%#Convert.ToBoolean(Eval("Sex")) ? "男" : "女" %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PersonType" HeaderText="人员类别" SortExpression="PersonType"
                        ReadOnly="true" />
                    <asp:BoundField DataField="Status" HeaderText="股东状态" SortExpression="Status" ReadOnly="true" />
                    <asp:TemplateField HeaderText="委托代理人" SortExpression="EntrustedAgentName">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlAgent" runat="server" DataSourceID="odsAgent" DataTextField="ShareholderName"
                                DataValueField="ShareholderNumber">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="odsAgent" runat="server" SelectMethod="Select" TypeName="ShareOS.BLL.EntrustedAgent">
                            </asp:ObjectDataSource>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbEntrustedAgent" runat="server" Text='<%#Eval("EntrustedAgentName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" EditText="变更代理人" />
                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="Label1" runat="server" Text="该代理人下无任何股东。"></asp:Label>
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:ObjectDataSource ID="odsShareholders" runat="server" SelectMethod="SelectShareholderTable"
                TypeName="ShareOS.BLL.ShareholderRegister" DataObjectTypeName="ShareOS.Model.Shareholder"
                UpdateMethod="Update" OnSelecting="odsShareholders_Selecting"></asp:ObjectDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
