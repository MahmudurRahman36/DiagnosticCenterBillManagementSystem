using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystem.BLL;
using DiagnosticCenterBillManagementSystem.BLL.Models;

namespace DiagnosticCenterBillManagementSystem.UI
{
    public partial class PaymentUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            paymentButton.Enabled = false;
            paymentButton.BackColor = Color.DodgerBlue;
            paymentButton.ForeColor = Color.White;

            if (!IsPostBack)
            {
                billNumberDropDownList.Visible = false;
                payAllCheckBox.Visible = false;
                mobileNumberLabel.Visible = false;
                payAllCheckBox.Checked = true;
                Label10.Visible = false;
            }
        }

        PaymentManager paymentManager = new PaymentManager();

        public Payment Payment
        {
            get
            {
                if (HttpContext.Current.Session["Payment"] == null)
                {
                    HttpContext.Current.Session["Payment"] = new Payment();
                }
                return HttpContext.Current.Session["Payment"] as Payment;
            }
            set { HttpContext.Current.Session["Payment"] = value; }
        }
        public List<string> BillNumberList 
        {
            get
            {
                if (HttpContext.Current.Session["BillNumberList"] == null)
                {
                    HttpContext.Current.Session["BillNumberList"] = new List<string>();
                }
                return HttpContext.Current.Session["BillNumberList"] as List<string>;
            }
            set { HttpContext.Current.Session["BillNumberList"] = value; }
        }


        protected void searchButton_Click(object sender, EventArgs e)
        {
            searchNotifiatonLabel.Text = "";
            payNotifiatonLabel.Text = "";
            amountTextBox.Text = "";
            dueDateTextBox.Text = "";

            string billNo = billNoTextBox.Text;
            string mobileNo = mobileNoTextBox.Text;
            string billNumberFromDropdown = billNumberDropDownList.SelectedValue;
            if (!billNo.Equals(""))
            {
                Payment = paymentManager.GetTestByBillNumber(billNo);
                BillNumberList = new List<string>();
                BillNumberList.Add(Payment.BillNumber);
                if (Payment.IsDataExist)
                {
                    amountTextBox.Text = Payment.Amount;
                    dueDateTextBox.Text = Payment.DueDate;
                }
                else if (paymentManager.GetAllTestByBillNumber(billNo))
                {
                    searchNotifiatonLabel.Text = "All due has already paid for this Bill Number";
                    searchNotifiatonLabel.ForeColor = Color.Green;
                }
                else
                {
                    searchNotifiatonLabel.Text = "No Data Present of this Bill Number";
                    searchNotifiatonLabel.ForeColor = Color.Red;
                }
            }
            else if (!mobileNo.Equals(""))
            {
                Payment = paymentManager.GetTestByMobileNo(mobileNo);
                BillNumberList = paymentManager.GetBillNumberByMobileNumber(mobileNo);
                if (BillNumberList.Count == 1)
                {
                    if (Payment.IsDataExist)
                    {
                        amountTextBox.Text = Payment.Amount;
                        dueDateTextBox.Text = Payment.DueDate;
                    }
                }
                else if(BillNumberList.Count>1)
                {
                    Label10.Visible = true;
                    amountTextBox.Text = Payment.Amount;
                    dueDateTextBox.Text = Payment.DueDate;
                    billNumberDropDownList.Visible = true;
                    payAllCheckBox.Visible = true;
                    mobileNumberLabel.Visible = true;
                    mobileNumberLabel.Text = mobileNo;
                    mobileNoTextBox.Text = "";
                    billNumberDropDownList.DataSource = BillNumberList;
                    billNumberDropDownList.DataBind();
                }
                else if (paymentManager.GetAllTestByMobileNo(mobileNo))
                {
                    searchNotifiatonLabel.Text = "All due has already paid for this mobile number";
                    searchNotifiatonLabel.ForeColor = Color.Green;
                }
                else
                {
                    searchNotifiatonLabel.Text = "No Data Present of this Mobile Number";
                    searchNotifiatonLabel.ForeColor = Color.Red;
                }
            }
            else if(!billNumberFromDropdown.Equals(""))
            {
                if(payAllCheckBox.Checked){
                    Payment = paymentManager.GetTestByMobileNo(mobileNumberLabel.Text);
                    BillNumberList = paymentManager.GetBillNumberByMobileNumber(mobileNumberLabel.Text);
                    if (Payment.IsDataExist)
                    {
                        amountTextBox.Text = Payment.Amount;
                        dueDateTextBox.Text = Payment.DueDate;
                    }
                    else
                    {
                        searchNotifiatonLabel.Text = "No Data Present of this Mobile Number";
                        searchNotifiatonLabel.ForeColor = Color.Red;
                    }
                }
                else
                {
                    Payment = paymentManager.GetTestByBillNumber(billNumberFromDropdown);
                    BillNumberList = new List<string>();
                    BillNumberList.Add(Payment.BillNumber);
                    if (Payment.IsDataExist)
                    {
                        amountTextBox.Text = Payment.Amount;
                        dueDateTextBox.Text = Payment.DueDate;
                    }
                }
                
            }
            else
            {
                searchNotifiatonLabel.Text = "Please give either Bill number or mobile number";
                searchNotifiatonLabel.ForeColor = Color.Red;
            }
        }

        protected void homeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void testTypeSetupButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("TestTypeSetupUI.aspx");
        }

        protected void testSetupButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("TestSetupUI.aspx");
        }

        protected void testRequestEntry_Click(object sender, EventArgs e)
        {
            Response.Redirect("TestRequestEntryUI.aspx");
        }

        protected void paymentButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaymentUI.aspx");
        }

        protected void testWiseReportButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("TestWiseReportUI.aspx");
        }

        protected void typeWiseReportButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("TypeWiseReportUI.aspx");
        }

        protected void unpaidBillReportButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("UnpaidBillReportUI.aspx");
        }
        protected void payButton_Click(object sender, EventArgs e)
        {
            searchNotifiatonLabel.Text = "";
            payNotifiatonLabel.Text = "";
            if (BillNumberList.Count==0)
            {
                payNotifiatonLabel.Text = "Please search a Bill first";
                payNotifiatonLabel.ForeColor = Color.Red;
            }
            else
            {
                bool result = paymentManager.SetPaymentInformation(BillNumberList);
                if (result)
                {
                    payNotifiatonLabel.Text = "Bill Payment has been Successfull";
                    payNotifiatonLabel.ForeColor = Color.Green;
                    Payment = new Payment();
                    billNoTextBox.Text = "";
                    mobileNoTextBox.Text = "";
                    billNumberDropDownList.Items.Clear();
                    billNumberDropDownList.Visible = false;
                    Label10.Visible = false;
                    payAllCheckBox.Visible = false;
                    mobileNumberLabel.Visible = false;
                    payAllCheckBox.Checked = false;
                    BillNumberList = new List<string>();
                    amountTextBox.Text = "";
                    dueDateTextBox.Text = "";
                }
                else
                {
                    payNotifiatonLabel.Text =
                        "There is some error while saving payment status. Please type again.";
                    payNotifiatonLabel.ForeColor = Color.Red;
                }
            }
        }
    }
}