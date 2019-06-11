<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintClearingReport_PrintView.aspx.cs" Inherits="Admin_Trade_PrintClearingReport_PrintView" EnableTheming="false" Theme="" StylesheetTheme="" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>打印个人股权清退报告</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:HiddenField ID="hfShareholderNumbers" runat="server" Value="" />
            <rsweb:ReportViewer ID="reportPrinter" runat="server" Height="800px" Width="100%">
                <LocalReport ReportPath="RDLCFile\ClearingShares.rdlc" OnSubreportProcessing="ReportViewer1_SubreportProcessing"  >
                </LocalReport>
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
