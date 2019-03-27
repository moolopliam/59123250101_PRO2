<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormOder.aspx.cs" Inherits="Cinema.Reports.WebFormOder" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:TextBox ID="TextBox1" runat="server" placeholder="กรุณากรอกชื่อลูกค้า(Username)" Width="228px"></asp:TextBox> &nbsp;
        <asp:TextBox ID="TextBox2" runat="server" placeholder="กรุณากรอกวันที่(dd/MM/yy)" Width="222px"></asp:TextBox> &nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ค้นหา" />
        
        <br/> <br/>
 
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="1584px" Width="1277px">
        </rsweb:ReportViewer>
    </form>
</body>
</html>
