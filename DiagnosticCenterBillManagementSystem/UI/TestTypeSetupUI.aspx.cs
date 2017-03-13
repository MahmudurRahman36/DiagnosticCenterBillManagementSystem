using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystem.BLL;

namespace DiagnosticCenterBillManagementSystem.UI
{
    public partial class TestTypeSetupUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            testTypeSetupButton.Enabled = false;
            testTypeSetupButton.BackColor = Color.DodgerBlue;
            testTypeSetupButton.ForeColor = Color.White;
            if (!IsPostBack)
            {
                GetTestTypeInformation();
            }
        }

        TestTypeSetupManager testTypeSetupManager=new TestTypeSetupManager();

        protected void saveButton_Click(object sender, EventArgs e)
        {
            notificationLabel.Text = "";
            try
            {

                string testTypeName = typeNameTextBox.Text;
                if (testTypeName.Equals(""))
                {
                    notificationLabel.Text = "Please insert a Type Name.";
                    notificationLabel.ForeColor=Color.Red;
                }
                else
                {                                    
                bool result = testTypeSetupManager.SetTestTypeName(testTypeName);

                if (result)
                {
                    notificationLabel.Text = "Test Type Name Successfully Saved";
                    notificationLabel.ForeColor = Color.Green;
                    typeNameTextBox.Text = "";
                    GetTestTypeInformation();
                }
                else
                {
                    notificationLabel.Text = "Test Type Name already exist.";
                    notificationLabel.ForeColor = Color.Red;
                }
                }
            }
            catch (Exception exception)
            {
                notificationLabel.Text = "Failed to Save Test Type Name";
                notificationLabel.ForeColor = Color.Red;
            }
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void GetTestTypeInformation()
        {
            DataSet dataSet = testTypeSetupManager.GetTestTypeInformation();
            testTypeGridView.DataSource = dataSet;
            testTypeGridView.DataBind();
        }
        protected void gvDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            testTypeGridView.PageIndex = e.NewPageIndex;
            GetTestTypeInformation();
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

    }
}