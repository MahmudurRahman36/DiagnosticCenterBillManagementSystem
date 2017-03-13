<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestSetupUI.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UI.TestSetupUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    
    <title>Test Setup</title>

    <link href="../css/DiagMgmtSystem.css" rel="stylesheet" />

    <link href="../Styles/navigation-style.css" rel="stylesheet" />
    <style type="text/css">
        /*.auto-style1 {
            width: 800px;
            height: 184px;
        }*/
    </style>
</head>
<body>
<div class="form-group col-md-8 col-md-offset-2">
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
                                            <legend>Test Setup</legend>
                                            <fieldset class="fieldset-2">
                                                <table>
                                                    <tr>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="Label5" runat="server" Text="Test Name"></asp:Label>
                                                        </td>
                                                        <td>
                <strong>
                    <asp:TextBox ID="testNameTextBox" name="testNameTextBox" runat="server"></asp:TextBox>
                </strong>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="Label6" runat="server" Text="Fee"></asp:Label>
                                                        </td>
                                                        <td>
                <strong>
                    <asp:TextBox ID="feeTextBox" name="feeTextBox" runat="server"></asp:TextBox>
                </strong>
                                                        </td>
                                                        <td>BDT</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="Label7" runat="server" Text="Test Type"></asp:Label>
                                                        </td>
                                                        <td>
                <strong>
                    <asp:DropDownList ID="testTypeDropDownList" name="testTypeDropDownList" runat="server" >
                    </asp:DropDownList>
                </strong>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: right">
                                                            &nbsp;</td>
                                                        <td style="text-align: right">
                <strong>
                    <asp:Button ID="saveButton" runat="server" OnClick="saveButton_Click" Text="Save"/>
                </strong>
                                                        </td>
                                                        <td style="text-align: right">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" style="text-align: center">
                <strong>
                    <asp:Label ID="notificationLabel" runat="server"></asp:Label>
                </strong>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                            <br/>
                                            <br/>
            <asp:GridView ID="testSetupGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="gvDetails_PageIndexChanging" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                <Columns>
                    <asp:TemplateField HeaderText="SL">
                        <ItemTemplate>
                            <%#Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="Test Name"/>
                    <asp:BoundField DataField="Fee" HeaderText="Fee"/>
                    <asp:BoundField DataField="TypeName" HeaderText="Type"/>
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

                                            <br/>
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
    $(document)
        .ready(function() {
            $("#form1")
                .validate({
                    rules: {
                        testNameTextBox: "required",
                        feeTextBox: {
                            required: true,
                            number: true,
                            range: [0, 10000000000000]
                        },
                        testTypeDropDownList: "required"
                    },

                    messages: {
                        testNameTextBox: " Please provide Test name",
                        feeTextBox: {
                            required: "Please Provide Fee",
                            number: "Please Provide Fee in Number",
                            range: "Please Provide Fee in Positive Value"
                        },
                        testTypeDropDownList: " Please Select Test Type name"
                    }
                });
        });
</script>
</body>
</html>