<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StartPage.aspx.cs" Inherits="DiagnosticCenterBillMgmtApp.UI.StartPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Start</title>
    <link href="../CSS/StartPage.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
    <div class="startheader">
    
        <span class="auto-style4">Welcome to</span><br />
        <span class="auto-style2"><strong>Diagnostic Center Bill Management System</strong></span><br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        Developed by<br />
        <span class="auto-style3"><strong>CodeHunters<br />
        <br />
        </strong></span>
        <asp:Button ID="startButton" runat="server" Text="Start" CssClass="button" OnClick="startButton_Click" />
        <br />
    
    </div>
    </form>
    <div class="footer">
        <span class="auto-style6"><strong><span class="auto-style8">Course Name:
        <br class="auto-style6" />
        </span><span class="auto-style9">Web Programming Using .Net</span></strong><br />
        </span>
        <br />
        <img alt="bdjobs training logo." class="auto-style5" src="../Images/bdjobstraininglogo.png" /><br />
        <span class="auto-style6">Top Up IT Training Program and ITES Foundation Skills Training Program</span><br class="auto-style6" />
        <span class="auto-style6">LICT, Bangladesh Computer Council</span></div>
</body>
</html>
