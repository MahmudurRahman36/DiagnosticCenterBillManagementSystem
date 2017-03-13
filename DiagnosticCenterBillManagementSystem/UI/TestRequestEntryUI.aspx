<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestRequestEntryUI.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UI.TestRequestEntryUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    
    <title>Test Request Entry</title>

    
        

    <link href="../css/pikaday.css" rel="stylesheet"/>
    <%--<link href="../css/site.css" rel="stylesheet"/>--%>
    <link href="../css/theme.css" rel="stylesheet"/>
    <link href="../css/triangle.css" rel="stylesheet"/>
    <script src="../pikaday.js"></script>
    <link href="../Styles/navigation-style.css" rel="stylesheet" />
    <link href="../css/DiagMgmtSystem.css" rel="stylesheet" />

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
                                            <legend>Test Request Entry</legend>
                                            <fieldset class="fieldset-2">
                                                <table>
                                                    <tr>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="Label6" runat="server" Text="Name of the Patient"></asp:Label>
                                                        </td>
                                                        <td colspan="2">
                <asp:TextBox ID="nameTextBox" name="nameTextBox" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="Label9" runat="server" Text="Date of Birth"></asp:Label>
                                                        </td>
                                                        <td colspan="2">
                <asp:TextBox ID="dateOfBirthDatePicker" name="dateOfBirthDatePicker" runat="server" ></asp:TextBox>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="Label10" runat="server" Text="Mobile No."></asp:Label>
                                                        </td>
                                                        <td colspan="2">
                <asp:TextBox ID="mobileNoTextBox" name="mobileNoTextBox" runat="server" ></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="Label11" runat="server" Text="Select Test"></asp:Label>
                                                        </td>
                                                        <td colspan="2">
                <asp:DropDownList ID="testDropDownList" name="testDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="testDropDownList_SelectedIndexChanged">
                </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">&nbsp;</td>
                                                        <td style="text-align: right">
                                                            <asp:Label ID="Label12" runat="server" Text="Fee"></asp:Label>
&nbsp;<asp:TextBox ID="feeTextBox" runat="server" ReadOnly="True" Width="115px" Font-Size="Medium"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                        <td colspan="2" style="text-align: right">
                <asp:Button ID="addButton" runat="server" Text="ADD" OnClick="addButton_Click" style="margin-left: 0px" Width="68px"/>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" style="text-align: center">
                <asp:Label ID="notificationLabel" runat="server" ></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                            <br/>
                                            <br/>

            <asp:GridView ID="testSetupGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="gvDetails_PageIndexChanging" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Size="Large">
                <Columns>
                    <asp:TemplateField HeaderText="SL">
                        <ItemTemplate>
                            <%#Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TestName" HeaderText="Test"/>
                    <asp:BoundField DataField="Fee" HeaderText="Fee"/>
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
                <asp:Button ID="saveButton" runat="server" Text="SAVE" OnClick="saveButton_Click"/>
                &nbsp;<asp:Label ID="Label7" runat="server" Text="Total" Font-Size="Large"></asp:Label>
                <asp:TextBox ID="totalTextBox" runat="server" ReadOnly="True" Width="115px" Font-Size="Medium"></asp:TextBox>
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
                        nameTextBox: "required",
                        dateOfBirthDatePicker: "required",

                        testDropDownList: "required",
                        mobileNoTextBox: {
                            required: true,
                            number: true
                        }
                    },

                    messages: {
                        testNameTextBox: " Please provide Test name",
                        dateOfBirthDatePicker: "Please provide Date of Birth",
                        mobileNoTextBox: {
                            required: "Please Provide Contact No",
                            number: "Please Provide Contact No in Number",
                        },
                        testDropDownList: " Please Select Test name"
                    }
                });
            var picker = new Pikaday(
                    {
                        field: document.getElementById('dateOfBirthDatePicker'),
                        firstDay: 1,
                        format: 'DD-MM-YYYY',
                        yearRange: [1900, 2030]
                        //theme: 'dark-theme'
                    });
        });
</script>
</body>
</html>