<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DiagnosticCenterBillMgmtApp.UI.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <fieldset style="border-color: skyblue; display: inline-block; padding: 0px;">
                <table style="border: none" cellspacing="0px" cellpadding="0px">
                    <tr>
                        <td>
                            <object
                                classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"
                                codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,42,0"
                                id="Banner"
                                width="800" height="187">
                                <param name="movie" value="Banner.swf">
                                <param name="bgcolor" value="#FFFFFF">
                                <param name="quality" value="high">
                                <param name="seamlesstabbing" value="false">
                                <param name="allowscriptaccess" value="samedomain">
                                <embed
                                    type="application/x-shockwave-flash"
                                    pluginspage="http://www.adobe.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash"
                                    name="Banner"
                                    width="800" height="187"
                                    src="/Banner/Banner.swf"
                                    bgcolor="#FFFFFF"
                                    quality="high"
                                    seamlesstabbing="false"
                                    allowscriptaccess="samedomain">
                                    <noembed>
                                    </noembed>
                                </embed>
                            </object>
                        </td>
                    </tr>
                   <tr>
                       <td>
                           <div align="center" style="font-size: x-large">
                               <br />
                               Select your service<br />
                           </div>
                           <table class="auto-style1">
                               <tr>
                                   <td style="text-align: center">
                                       <asp:Button ID="testTypeSetupButton" runat="server" Text="Test Type Setup" Width="200px" OnClick="testTypeSetupButton_Click" />
                                   </td>
                               </tr>
                               <tr>
                                   <td style="text-align: center">
                                       <asp:Button ID="testSetupButton" runat="server" Text="Test Setup" Width="200px" OnClick="testSetupButton_Click" />
                                   </td>
                               </tr>
                               <tr>
                                   <td style="text-align: center">
                                       <asp:Button ID="testRequestEntryButton" runat="server" Text="Test Request Entry" Width="200px" OnClick="testRequestEntryButton_Click" />
                                   </td>
                               </tr>
                               <tr>
                                   <td style="text-align: center">
                                       <asp:Button ID="paymentButton" runat="server" Text="Payment" Width="200px" OnClick="paymentButton_Click" />
                                   </td>
                               </tr>
                               <tr>
                                   <td style="text-align: center">
                                       <asp:Button ID="testWiseReportButton" runat="server" Text="Test Wise Report" Width="200px" OnClick="testWiseReportButton_Click" />
                                   </td>
                               </tr>
                               <tr>
                                   <td style="text-align: center">
                                       <asp:Button ID="typeWiseReportButton" runat="server" Text="Type Wise Report" Width="200px" OnClick="typeWiseReportButton_Click" />
                                   </td>
                               </tr>
                               <tr>
                                   <td style="text-align: center">
                                       <asp:Button ID="unpaidBillReportButton" runat="server" Text="Unpaid Bill Report" Width="200px" OnClick="unpaidBillReportButton_Click" />
                                       </td>
                               </tr>
                               <tr>
                                   <td style="text-align: center">&nbsp;&nbsp;&nbsp;<asp:Button ID="goToStartButton" runat="server" Text="Start Page" Width="200px" OnClick="goToStartButton_Click" />
                                       &nbsp; &nbsp;</td>
                               </tr>
                               <tr>
                                   <td style="text-align: center">&nbsp;</td>
                               </tr>
                           </table>
                           
                       </td>
                   </tr>
                    <tr>
                        <td style="text-align: center; background-color: lightblue;">Copywight &#169 2017
                        </td>
                    </tr>
                   
                </table>

            </fieldset>
        </div>
    </form>
</body>
</html>
