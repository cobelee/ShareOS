<%@ Page Title="配置股权管理助理" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ConfigAssistant.aspx.cs" Inherits="EntrustedAgent_ConfigAssistant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>
        配置股权管理助理</h1>
    <p class="post-footer">
        您是股东代理人，拥有查询代理股东信息的权限，其它人无法查询您代理的股东信息。同时，您也可以设置一位助理，他（她）将拥有与您等同的查询权限。<br />
        注意事项1：该授权仅在股权管理系统中有效。<br />
        注意事项2：同一位员工，无法<b>同时</b>成为多位股权代理人的助理，因此，当有多位股东代理人设置同一位员工为助理时，后设置的有效。
    </p>
    <asp:HiddenField ID="hfAgentShareholderNumber" runat="server" />
    <asp:Panel ID="pnlAssignAssistant" runat="server" Height="40px">
        输入助理的工号：<asp:TextBox ID="tbJobNumber" runat="server"></asp:TextBox>
        <asp:Button ID="btnAssign" runat="server" Text="授权" OnClick="btnAssign_Click" />
    </asp:Panel>
    <asp:Panel ID="pnlConfirm" runat="server" Visible="false">
        <asp:Label ID="lbConfirmMessage" runat="server" Text="Label"></asp:Label><br />
        <asp:Button ID="btnConfirm" runat="server" Text="确认授权" OnClick="btnConfirm_Click" />
    </asp:Panel>
    <asp:GridView ID="gvAssistant" runat="server" DataSourceID="odsAssistant" AutoGenerateColumns="False"
        DataKeyNames="Assistant">
        <Columns>
            <asp:BoundField DataField="Assistant" HeaderText="代理工号" />
            <asp:TemplateField HeaderText="代理姓名">
                <ItemTemplate>
                    <asp:Label ID="lbName" runat="server" Text='<%#GetName(Eval("Assistant").ToString()) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument='<%#Eval("Assistant").ToString() %>'
                        OnClick="lbtnDelete_Click" OnClientClick="return confirm('你确定要删除吗？');">删除</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            未设置股权管理助理！
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsAssistant" runat="server" SelectMethod="SelectAssistant"
        TypeName="ShareOS.BLL.EntrustedAgent" DeleteMethod="DeleteAssistant">
        <DeleteParameters>
            <asp:Parameter Name="agentShareholderNumber" Type="Int32" />
            <asp:Parameter Name="assistantJobNumber" Type="String" />
        </DeleteParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="hfAgentShareholderNumber" Name="agentShareholderNumber"
                PropertyName="Value" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
