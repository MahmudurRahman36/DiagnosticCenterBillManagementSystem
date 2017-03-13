using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystem.BLL;
using DiagnosticCenterBillManagementSystem.BLL.Models;

namespace DiagnosticCenterBillManagementSystem.UI
{
    public partial class TestSetupUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            testSetupButton.Enabled = false;
            testSetupButton.BackColor = Color.DodgerBlue;
            testSetupButton.ForeColor = Color.White;
            if (!IsPostBack)
            {
                GetAllTestInformation();
                TestTypeDropdownList();
            }
        }

        TestSetupManager testSetupManager=new TestSetupManager();      

        protected void saveButton_Click(object sender, EventArgs e)
        {
            notificationLabel.Text = "";

            try
            {
            string testName = testNameTextBox.Text;            
            int testTypeId= Convert.ToInt32(testTypeDropDownList.SelectedValue);
            double fee = -9999;
                try
                {
                    fee = Convert.ToDouble(feeTextBox.Text);
                }
                catch (Exception)
                {
                    notificationLabel.Text = "Please give your Fee in Number";
                    notificationLabel.ForeColor = Color.Red;

                }

            if (testName.Length == 0)
            {
                notificationLabel.Text = "Please give Test Name";
                notificationLabel.ForeColor = Color.Red;
            }          
            else if (testTypeId == 0)
            {
                notificationLabel.Text = "Error while finding Test Type";
                notificationLabel.ForeColor = Color.Red;
            }
            else if (fee < 0)
            {
                notificationLabel.Text = "Please give Test Fee In Positive Number";
                notificationLabel.ForeColor = Color.Red;
            }
            else
            {
                Test testSetup = new Test(testName, fee, testTypeId);
                bool result = testSetupManager.SetTestInformation(testSetup);

                if (result)
                {
                    notificationLabel.Text = "Test details Successfully Saved";
                    notificationLabel.ForeColor = Color.Green;
                    testNameTextBox.Text = "";
                    feeTextBox.Text = "";
                    GetAllTestInformation();
                }
                else
                {
                    notificationLabel.Text = "Test Name already exist. Plese Type a Unique Name";
                    notificationLabel.ForeColor = Color.Red;
                } 
            }
           
            }
            catch (Exception exception)
            {
                notificationLabel.Text = "Failed to Save Test details";
                notificationLabel.ForeColor = Color.Red;
            }


        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        public void TestTypeDropdownList()
        {
            List<Types> testTypeList = testSetupManager.GetTestTypeDropdownList();
            testTypeDropDownList.DataSource = testTypeList;
            testTypeDropDownList.DataTextField = "TypeName";
            testTypeDropDownList.DataValueField = "ID";
            testTypeDropDownList.DataBind();
        }

        public void GetAllTestInformation()
        {
            DataSet dataSet = testSetupManager.GetAllTestInformation();
            testSetupGridView.DataSource = dataSet;
            testSetupGridView.DataBind();

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

        protected void gvDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            testSetupGridView.PageIndex = e.NewPageIndex;
            GetAllTestInformation();
        }
    }
}