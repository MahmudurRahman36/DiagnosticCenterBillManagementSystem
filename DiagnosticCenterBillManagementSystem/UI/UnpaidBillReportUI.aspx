<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnpaidBillReportUI.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UI.UnpaidBillReportUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Unpaid Bill Report</title>



    <link href="../css/pikaday.css" rel="stylesheet" />
    <%--<link href="../css/site.css" rel="stylesheet" />--%>
    <link href="../css/theme.css" rel="stylesheet" />
    <link href="../css/triangle.css" rel="stylesheet" />
    <script src="../pikaday.js"></script>
    <link href="../Styles/navigation-style.css" rel="stylesheet" />
    <link href="../css/DiagMgmtSystem.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 800px;
            height: 184px;
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
                                    <img alt="Banner" class="auto-style1" src="../Banner/Banner.png" /></td>
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
                                                    <legend>Unpaid Bill Report</legend>
                                                    <fieldset class="fieldset-2">
                                                        <table>
                                                            <tr>
                                                                <td style="text-align: left">
                                                                    <asp:Label ID="Label2" runat="server" Text="From Date"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="fromDateTextBox" name="fromDateTextBox" runat="server" Height="16px"></asp:TextBox>
                                                                </td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left">

                                                                    <asp:Label ID="Label3" runat="server" Text="To Date"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="toDateTextBox" name="toDateTextBox" runat="server" Height="16px"></asp:TextBox>

                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="showButton" runat="server" Text="Show" OnClick="showButton_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">

                                                                    <asp:Label ID="notificationLabel" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                    <br />
                                                    <br />
                                                    <asp:GridView ID="UnpaidBillReportGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="gvDetails_PageIndexChanging" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Size="Large">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="SL">
                                                                <ItemTemplate>
                                                                    <%#Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="BillNumber" HeaderText="Bill Number" />
                                                            <asp:BoundField DataField="MobileNo" HeaderText="Contact No" />
                                                            <asp:BoundField DataField="PatientName" HeaderText="Patient Name" />
                                                            <asp:BoundField DataField="BillAmount" HeaderText="Bill Amount" />
                                                        </Columns>
                                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                        <RowStyle ForeColor="#000066" />
                                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                    </asp:GridView>
                                                    <br />


                                                    <table align="center">
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="pdfButton" runat="server" Text="PDF" OnClick="pdfButton_Click" Font-Size="Large" Height="29px" />
                                                            </td>
                                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Label ID="Label8" runat="server" Text="Total"></asp:Label>
                                                                &nbsp;
                                                        <asp:TextBox ID="totalAmountTextBox" runat="server" Font-Size="Medium"></asp:TextBox>

                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
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
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="../js/bootstrap.min.js"></script>

    <script src="../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../Scripts/jquery.validate.min.js"></script>
    <script>
        var picker = new Pikaday(
                    {
                        field: document.getElementById('fromDateTextBox'),
                        firstDay: 1,
                        format: 'DD-MM-YYYY',
                        yearRange: [1900, 2099]
                        //theme: 'dark-theme'
                    });

        var picker = new Pikaday(
                    {
                        field: document.getElementById('toDateTextBox'),
                        firstDay: 1,
                        format: 'DD-MM-YYYY',
                        yearRange: [1900, 2099]
                        //theme: 'dark-theme'
                    });
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
    </script>
</body>
</html>
