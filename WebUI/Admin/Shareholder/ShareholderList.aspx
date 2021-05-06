<%@ Page Title="股东信息查询" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ShareholderList.aspx.cs" Inherits="Admin_Shareholder_ShareholderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h1>股东信息查询</h1>
    <div style="padding: 20px; border: 1px solid #696969; margin: 10px 0;">
        本页面查询股东信息，非股东在本页不展示。
    </div>
    <div style="padding: 20px; border: 1px solid #696969; margin: 10px 0;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">

            <ContentTemplate>
                <asp:GridView ID="gvShareholderList" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="ShareholderNumber" OnRowCommand="gvShareholderList_RowCommand" OnRowEditing="gvShareholderList_RowEditing"
                    OnRowCancelingEdit="gvShareholderList_RowCancelingEdit" OnRowUpdating="gvShareholderList_RowUpdating">
                    <Columns>
                        <asp:BoundField DataField="ShareholderNumber" HeaderText="股东号" SortExpression="ShareholderNumber" ReadOnly="True" />
                        <asp:BoundField DataField="JobNumber" HeaderText="工号" SortExpression="JobNumber" ReadOnly="True" />
                        <asp:BoundField DataField="ShareholderName" HeaderText="姓名" SortExpression="ShareholderName" ReadOnly="True" />
                        <asp:TemplateField HeaderText="性别">
                            <ItemTemplate>
                                <asp:Label ID="lbSex" runat="server" Text='<%#Convert.ToBoolean(Eval("Sex")) ? "男" : "女" %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="40px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="IdentityCard" HeaderText="身份证号" SortExpression="IdentityCard" ReadOnly="True" />
                        <asp:BoundField DataField="PersonType" HeaderText="人员类别" SortExpression="PersonType" ReadOnly="True" />
                        <asp:BoundField DataField="Status" HeaderText="股东状态" SortExpression="Status" ReadOnly="True" />
                        <asp:BoundField DataField="DepName" HeaderText="部门" SortExpression="DepName" ReadOnly="True" />
                        <asp:BoundField DataField="AccountHolder" HeaderText="户名" SortExpression="AccountHolder" />
                        <asp:BoundField DataField="BankName" HeaderText="开户行" SortExpression="BankName" />
                        <asp:BoundField DataField="AccountNumber" HeaderText="银行账户" SortExpression="AccountNumber" />
                        <asp:TemplateField HeaderText="账户冻结标志">
                            <ItemTemplate>
                                <asp:Literal ID="ltlFrozen" runat="server" Text='<%# Convert.ToBoolean(Eval("FrozenTag"))?"账户冻结":"" %>'></asp:Literal>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="true" EditText="编辑" CancelText="取消" UpdateText="更新" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsSH" runat="server" SelectMethod="SelectShareholder" TypeName="ShareOS.BLL.ShareholderManage"
                    DataObjectTypeName="Tiyi.ShareOS.SQLServerDAL.Shareholder" UpdateMethod="Update"></asp:ObjectDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

