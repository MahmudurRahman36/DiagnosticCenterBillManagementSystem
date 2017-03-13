<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentUI.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UI.PaymentUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    
    <title>Payment</title>
    <link href="../Styles/navigation-style.css" rel="stylesheet" />
    <link href="../css/DiagMgmtSystem.css" rel="stylesheet" />
    <style>
        .error {
            color: red;
            display: inline-block;
        }
    </style>
</head>
<body>
    
    
    

<div>
    <form id="form1" runat="server">
        <div>
            <div align="center">
            <fieldset style="border-color: skyblue; display: inline-block; padding: 0px">
                <table style="border: none" cellspacing="0px" cellpadding="0px">
                    <tr>
                        <td>
                            <img src="../Banner/Banner.png" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            
                            <table style="width: 800px">
                                <tr>
                                    <td style="text-align: left; width: 150px" valign="top">
                                        <table>
                                            <tr>
                                                        <td>
                                                            <asp:Button ID="homeButton" CssClass="cancel" runat="server" Text="Home" Width="150px" OnClick="homeButton_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="testTypeSetupButton" CssClass="cancel" runat="server" OnClick="testTypeSetupButton_Click" Text="Test Type Setup" Width="150px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="testSetupButton" CssClass="cancel" runat="server" Text="Test Setup" Width="150px" OnClick="testSetupButton_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="testRequestEntry" CssClass="cancel" runat="server" Text="Test Request Entry" Width="150px" OnClick="testRequestEntry_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="paymentButton" CssClass="cancel" runat="server" Text="Payment" Width="150px" OnClick="paymentButton_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="testWiseReportButton" CssClass="cancel" runat="server" Text="Test Wise Report" Width="150px" OnClick="testWiseReportButton_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="typeWiseReportButton" CssClass="cancel" runat="server" Text="Type Wise Report" Width="150px" OnClick="typeWiseReportButton_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="unpaidBillReportButton" CssClass="cancel" runat="server" Text="Unpaid Bill Report" Width="150px" OnClick="unpaidBillReportButton_Click" />
                                                        </td>
                                                    </tr>
                                        </table>
                                    </td>
                                    <td valign="top" style="text-align: center;">
                                        <fieldset class="fieldset-1">
                                            <legend>Payment</legend>
                                            <fieldset class="fieldset-2">
                                                <table>
                                                    <tr>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="Label1" runat="server" Text="Bill No."></asp:Label>
                                                        </td>
                                                        <td>
            <asp:TextBox ID="billNoTextBox" name="billNoTextBox" runat="server" Width="144px"></asp:TextBox>
                                                        </td>
                                                        <td style="text-align: left">or</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="Label7" runat="server" Text="Mobile No."></asp:Label>
                                                        </td>
                                                        <td>
            <asp:TextBox ID="mobileNoTextBox" name="mobileNoTextBox" runat="server" Width="144px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="Label10" runat="server" Text="Select Bill No." Visible="False"></asp:Label>
                                                        </td>
                                                        <td>
            <asp:DropDownList ID="billNumberDropDownList" runat="server">
            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="searchButton" runat="server" OnClick="searchButton_Click" Text="Search"/>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
            <asp:CheckBox ID="payAllCheckBox" runat="server" Text="Pay All bill for: " AutoPostBack="True" />
            <asp:Label ID="mobileNumberLabel" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
            <asp:Label ID="searchNotifiatonLabel" runat="server" ForeColor="red"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset><br />
                                            <fieldset class="fieldset-2">
                                                <table>
                                                    <tr>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="Label8" runat="server" Text="Amount"></asp:Label>
                                                        </td>
                                                        <td>
            <asp:TextBox ID="amountTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="Label9" runat="server" Text="Due Date"></asp:Label>
&nbsp; </td>
                                                        <td>
            <asp:TextBox ID="dueDateTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td>
            <asp:Button ID="payButton" runat="server" OnClick="payButton_Click" Text="Pay"/>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
            <asp:Label ID="payNotifiatonLabel" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                        </fieldset>

                                    </td>
                                </tr>
                            </table>
                            
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; background-color: lightblue">Copywight &#169 2017
                        </td>
                    </tr>
                </table>

            </fieldset>
        </div>
        </div>
        

    </form>

</div>
<%--    <script src="../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../Scripts/jquery.validate.min.js"></script>
    <script>
        $(document)
            .ready(function () {
                $("#form1")
                    .validate({
                        rules: {
                            fromDateTextBox: "required",
                            toDateTextBox: "required"
                        },

                        messages: {
                            fromDateTextBox: " Please provide From Date",
                            toDateTextBox: "Please provide To Date"
                        }
                    });
            });
    </script>--%>
</body>
</html>