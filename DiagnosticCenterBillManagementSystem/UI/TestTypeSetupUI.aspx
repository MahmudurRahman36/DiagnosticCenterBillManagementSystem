<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestTypeSetupUI.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UI.TestTypeSetupUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Type Setup</title>
    <link href="../Styles/navigation-style.css" rel="stylesheet" />
    <link href="../css/DiagMgmtSystem.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form2" runat="server">
        <div align="center">
            <fieldset style="border-color: skyblue; display: inline-block; padding: 0px">
                <table style="border: none; width: 800px;" cellspacing="0px" cellpadding="0px">
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
                                    <%--<div align="center">--%>
                                    <fieldset class="fieldset-1">
                                            <legend>Test Type Setup</legend>
                                            <fieldset class="fieldset-2">
                                                <table>
                                                    <tr>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="Label121" runat="server" Text="Type Name: "></asp:Label>
                                                            </td>
                                                        <td>
                                                            <asp:TextBox ID="typeNameTextBox" name="typeNameTextBox" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            
                                                        </td>
                                                        <td style="text-align: right">
                                                            <asp:Button ID="saveButton" runat="server" OnClick="saveButton_Click" Text="Save" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: center" colspan="2">
                                                            <asp:Label ID="notificationLabel" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                            <br />
                                            &nbsp;<asp:GridView ID="testTypeGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="gvDetails_PageIndexChanging" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SL">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="TypeName" HeaderText="Type Name" />
                                                </Columns>
                                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                <RowStyle ForeColor="#000066" />
                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                <%--<SortedDescendingCellStyle BackColor="#CAC9C9" />--%>
                                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                                            </asp:GridView>

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

    </form>
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="../js/bootstrap.min.js"></script>--%>

    <script src="../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../Scripts/jquery.validate.min.js"></script>
    <script>
        $(document)
            .ready(function () {
                $("#form2")
                    .validate({
                        rules: {
                            typeNameTextBox: "required"
                        },

                        messages: {
                            typeNameTextBox: " Please provide a type name."
                        }
                    });

            });


    </script>
</body>
</html>
