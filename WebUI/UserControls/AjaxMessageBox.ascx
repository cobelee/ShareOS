<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AjaxMessageBox.ascx.cs"
    Inherits="AjaxControl_AjaxMessageBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Label ID="hfMessage" runat="server" Text=""></asp:Label>
<asp:Panel ID="pnlMessage" runat="server" Class="MessageDialog">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" OnLoad="UpdatePanel1_Load">
        <ContentTemplate>
            <asp:Label ID="lbMessage" runat="server" Text=""></asp:Label><br />
            <div style="padding: 10px 0px 10px 0px; text-align: center;">
                <asp:Button ID="btnClose" runat="server" Text="确定" OnClick="btnClose_Click" CausesValidation="false" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
<asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="hfMessage"
    PopupControlID="pnlMessage" BackgroundCssClass="MessageDialogBackground">
</asp:ModalPopupExtender>

