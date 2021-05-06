<%@ Page Title="配置股东代表" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ConfigAgent.aspx.cs" Inherits="Admin_ConfigAgent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <h1>配置股东代表</h1>
            <br />
            <br />
            <div>
            <asp:Label ID="lb" runat="server" Text="新增股东代理人" ForeColor="#003300"></asp:Label>&nbsp;&nbsp;请输入代理人股东号：
            <asp:TextBox ID="tbAgent" runat="server" Text="" placeholder="股东代理人的股东号"></asp:TextBox>
            <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" />
                </div>
            <asp:GridView ID="gvAgent" runat="server" AutoGenerateColumns="False" Width="640px"
                DataKeyNames="ShareholderId" OnRowCommand="gvAgent_RowCommand">
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
                    <asp:BoundField DataField="ShareholderName" HeaderText="姓名" SortExpression="ShareholderName"
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
                    <asp:BoundField DataField="PersonType" HeaderText="人员类别" SortExpression="PersonType"
                        ReadOnly="true" />
                    <asp:BoundField DataField="Status" HeaderText="股东状态" SortExpression="Status" ReadOnly="true" />
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <asp:LinkButton ID="hlDelete" runat="server" Text="删除代理人" CommandName="DeleteAgent" CommandArgument='<%# Eval("ShareholderNumber") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" EditText="变更代理人" />
                </Columns>
                <EmptyDataTemplate>
                    <asp:Label ID="Label1" runat="server" Text="该代理人下无任何股东。"></asp:Label>
                </EmptyDataTemplate>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

