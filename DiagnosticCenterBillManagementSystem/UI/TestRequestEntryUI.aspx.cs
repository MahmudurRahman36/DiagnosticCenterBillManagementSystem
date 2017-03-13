using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystem.BLL;
using DiagnosticCenterBillManagementSystem.BLL.Models;

namespace DiagnosticCenterBillManagementSystem.UI
{
    public partial class TestRequestEntryUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            testRequestEntry.Enabled = false;
            testRequestEntry.BackColor = Color.DodgerBlue;
            testRequestEntry.ForeColor = Color.White;

            if (!IsPostBack)
            {
                TestDropdownList();
                TestList = new List<Test>();
                TestLists = new List<Test>();
                Patient = new Patient();
                PopulatingGridView();
            }
        }

        TestRequestManager testRequestManager = new TestRequestManager();
        GetDateConfiguration dateConfiguration = new GetDateConfiguration();

        public List<Test> TestList
        {
            get
            {
                if (HttpContext.Current.Session["TestList"] == null)
                {
                    HttpContext.Current.Session["TestList"] = new List<Test>();
                }
                return HttpContext.Current.Session["TestList"] as List<Test>;
            }
            set { HttpContext.Current.Session["TestList"] = value; }
        }

        public List<Test> TestLists
        {
            get
            {
                if (HttpContext.Current.Session["TestLists"] == null)
                {
                    HttpContext.Current.Session["TestLists"] = new List<Test>();
                }
                return HttpContext.Current.Session["TestLists"] as List<Test>;
            }
            set { HttpContext.Current.Session["TestLists"] = value; }
        }

        public Patient Patient
        {
            get
            {
                if (HttpContext.Current.Session["Patient"] == null)
                {
                    HttpContext.Current.Session["Patient"] = new Patient();
                }
                return HttpContext.Current.Session["Patient"] as Patient;
            }
            set { HttpContext.Current.Session["Patient"] = value; }
        }

        [WebMethod]
        protected void addButton_Click(object sender, EventArgs e)
        {
            notificationLabel.Text = "";

            string name = nameTextBox.Text;
            string dateOfbirth = dateOfBirthDatePicker.Text;
            dateOfbirth = dateConfiguration.GetDate(dateOfbirth);
            string mobileNo = mobileNoTextBox.Text;
            int testId = Convert.ToInt32(testDropDownList.SelectedValue);
            string testName = testRequestManager.GetTestinformation(testId).TestName;
            double fee = testRequestManager.GetTestinformation(testId).Fee;

            if (name.Length == 0)
            {
                notificationLabel.Text = "Please give your Name";
                notificationLabel.ForeColor = Color.Red;
            }
            else if (dateOfbirth.Length != 10)
            {
                notificationLabel.Text = "Please give date in Correct Date Format";
                notificationLabel.ForeColor = Color.Red;
            }
            else if (mobileNo.Length == 0)
            {
                notificationLabel.Text = "Please give your Mobile Number";
                notificationLabel.ForeColor = Color.Red;
            }
            else if (fee.Equals(0))
            {
                notificationLabel.Text = "Please Select a Test";
                notificationLabel.ForeColor = Color.Red;
            }
            else
            {
                Patient.Name = name;
                Patient.MobileNo = mobileNo;
                Patient.DateOfBirth = dateOfbirth;

                Test test = new Test();
                test.TestId = testId;
                test.TestName = testName;
                test.Fee = fee;
                TestList.Add(test);

                PopulatingGridView();
                notificationLabel.Text = "Test has been added to the list";
                notificationLabel.ForeColor = Color.Green;
            }
        }

        public void TestDropdownList()
        {
            testDropDownList.Items.Clear();
            List<Test> testList = testRequestManager.GetTestDropdownList();
            testDropDownList.DataSource = testList;
            testDropDownList.DataTextField = "TestName";
            testDropDownList.DataValueField = "TestId";
            testDropDownList.DataBind();
            int testID = Convert.ToInt32(testDropDownList.SelectedValue);
            feeTextBox.Text = testRequestManager.GetTestinformation(testID).Fee.ToString();
        }

        public void PopulatingGridView()
        {
            if (TestList.Count != 0)
            {
                testSetupGridView.DataSource = TestList;
                testSetupGridView.DataBind();
                double fee = 0;
                foreach (Test test in TestList)
                {
                    fee = fee + test.Fee;
                }
                totalTextBox.Text = fee.ToString();
            }
            else
            {
                testSetupGridView.DataSource = TestLists;
                testSetupGridView.DataBind();
                double fee = 0;
                foreach (Test test in TestLists)
                {
                    fee = fee + test.Fee;
                }
                totalTextBox.Text = fee.ToString();
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = "";
            if (TestLists.Count > 0 || TestList.Count > 0)
            {
                double billnumber = testRequestManager.GetBillNumber();
                string printDate = testRequestManager.GetPrintDate();
                if (TestList.Count != 0)
                {
                    TestLists = TestList;
                }

                if (testRequestManager.SetTestRequestInformation(TestLists,Patient, TestList.Count))
                {
                    TestList = new List<Test>();
                    notificationLabel.Text = "The Privous Billnumber is " + billnumber + " and print date is " +
                                             printDate;
                    notificationLabel.ForeColor = Color.Green;
                    //string billInfo = "Billnumber is " + billnumber + " and print date is " + printDate; 
                    PdfBuilder(Convert.ToInt16(billnumber - 1));
                }
                else
                {
                    notificationLabel.Text = "There is some error while entering data";
                    notificationLabel.ForeColor = Color.Red;
                }
            }
        }

        protected void testDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int testId = Convert.ToInt32(testDropDownList.SelectedValue);
            feeTextBox.Text = testRequestManager.GetTestinformation(testId).Fee.ToString();
        }

        protected void gvDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            testSetupGridView.PageIndex = e.NewPageIndex;
            PopulatingGridView();
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

        public void PdfBuilder(int billnumber)
        {
            string name = "";
            string mobileNo = "";
            int sl = 0;
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3]
            {
                new DataColumn("Serial No", typeof(string)),
                new DataColumn("Test", typeof(string)),
                new DataColumn("Fee", typeof(int))
            });
            foreach (var test in TestLists)
            {
                sl = sl + 1;
                dt.Rows.Add(sl.ToString(), test.TestName, test.Fee);
            }

            if (name.Equals(""))
            {
                name = Patient.Name;
            }

            if (mobileNo.Equals(""))
            {
                mobileNo = Patient.MobileNo;
            }

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StringBuilder sb = new StringBuilder();

                    //Generate Invoice (Bill) Header.
                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                    sb.Append(
                        "<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Diagnostic Center Bill Management</b></td></tr>");
                    sb.Append("<tr><td colspan = '2'></td></tr>");
                    sb.Append("<tr><td><b>Patient name : </b>");
                    sb.Append(name);
                    sb.Append("</td><td align = 'right'><b>Date: </b>");
                    sb.Append(DateTime.Now);
                    sb.Append(" </td></tr>");
                    sb.Append("<tr><td colspan = '2'><b>Patient Contact No : </b>");
                    sb.Append(mobileNo);
                    sb.Append("</td></tr>");
                    sb.Append("<tr><td colspan = '2'><b>Patient Bill Number : </b>");
                    sb.Append(billnumber);
                    sb.Append("</td></tr>");
                    sb.Append("</table>");
                    sb.Append("<br />");

                    //Generate Invoice (Bill) Items Grid.
                    sb.Append("<table border = '1'>");
                    sb.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        sb.Append("<th>");
                        sb.Append(column.ColumnName);
                        sb.Append("</th>");
                    }
                    sb.Append("</tr>");
                    foreach (DataRow row in dt.Rows)
                    {
                        sb.Append("<tr>");
                        foreach (DataColumn column in dt.Columns)
                        {
                            sb.Append("<td>");
                            sb.Append(row[column]);
                            sb.Append("</td>");
                        }
                        sb.Append("</tr>");
                    }
                    sb.Append("<tr><td align = 'right' colspan = '");
                    sb.Append(dt.Columns.Count - 1);
                    sb.Append("'>Total Fee</td>");
                    sb.Append("<td>");
                    sb.Append(dt.Compute("sum(Fee)", ""));
                    sb.Append("</td>");
                    sb.Append("</tr></table>");

                    //Export HTML String as PDF.
                    StringReader sr = new StringReader(sb.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 40f, 40f, 40f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=Invoice_" + billnumber + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }
    }
}