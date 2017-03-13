using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystem.BLL;
using DiagnosticCenterBillManagementSystem.BLL.Models;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace DiagnosticCenterBillManagementSystem.UI
{
    public partial class UnpaidBillReportUI : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            unpaidBillReportButton.Enabled = false;
            unpaidBillReportButton.BackColor = Color.DodgerBlue;
            unpaidBillReportButton.ForeColor = Color.White;
        }
        UnpaidBillReportManager unpaidBillReportManager = new UnpaidBillReportManager();
        GetDateConfiguration dateConfiguration = new GetDateConfiguration();

        public List<BLL.Models.UnpaidBillReport> UnpaidBillReportList
        {
            get
            {
                if (HttpContext.Current.Session["UnpaidBillReportList"] == null)
                {
                    HttpContext.Current.Session["UnpaidBillReportList"] = new List<BLL.Models.UnpaidBillReport>();
                }
                return HttpContext.Current.Session["UnpaidBillReportList"] as List<BLL.Models.UnpaidBillReport>;
            }
            set
            {
                HttpContext.Current.Session["UnpaidBillReportList"] = value;
            }

        }
        protected void showButton_Click(object sender, EventArgs e)
        {
            string fDate = dateConfiguration.GetDate(fromDateTextBox.Text);
            string tDate = dateConfiguration.GetDate(toDateTextBox.Text);

            if (fDate.Length != 10)
            {
                notificationLabel.Text = "Please give from date in Correct Date Format";
            }
            else if (tDate.Length != 10)
            {
                notificationLabel.Text = "Please give to date in Correct Date Format";
            }
            else
            {
                double fromDate = dateConfiguration.GetDateInDouble(fDate);
                double toDate = dateConfiguration.GetDateInDouble(tDate);
                UnpaidBillReportList = new List<BLL.Models.UnpaidBillReport>();
                UnpaidBillReportList = unpaidBillReportManager.GetUnPaidReport(fromDate, toDate);
                PopulatingGridView(UnpaidBillReportList);
            }

        }

        protected void pdfButton_Click(object sender, EventArgs e)
        {
            PdfBuilder(UnpaidBillReportList);
        }
        public void PopulatingGridView(List<BLL.Models.UnpaidBillReport> unpaidBillReportList)
        {
            UnpaidBillReportGridView.DataSource = unpaidBillReportList;
            UnpaidBillReportGridView.DataBind();
            double amount = 0;
            foreach (BLL.Models.UnpaidBillReport unpaidBillReport in unpaidBillReportList)
            {
                amount = amount + unpaidBillReport.BillAmount;
            }
            totalAmountTextBox.Text = amount.ToString();
        }
        protected void gvDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            UnpaidBillReportGridView.PageIndex = e.NewPageIndex;
            PopulatingGridView(UnpaidBillReportList);
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
        public void PdfBuilder(List<BLL.Models.UnpaidBillReport> UnpaidBillReportList)
        {
            string fDate = dateConfiguration.GetDate(fromDateTextBox.Text);
            string tDate = dateConfiguration.GetDate(toDateTextBox.Text);
            int sl = 0;
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] {
                            new DataColumn("Serial No", typeof(string)),
                            new DataColumn("Bill Number", typeof(string)),
                            new DataColumn("Contact No", typeof(string)),
                            new DataColumn("Patient Name", typeof(string)),
                            new DataColumn("BillAmount", typeof(int))});
            foreach (var test in UnpaidBillReportList)
            {
                sl = sl + 1;
                dt.Rows.Add(sl.ToString(), test.BillNumber, test.MobileNo, test.PatientName, test.BillAmount);
            }

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StringBuilder sb = new StringBuilder();

                    //Generate Invoice (Bill) Header.
                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                    sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Diagnostic Center Bill Management</b></td></tr>");
                    sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Unpaid Bill Report</b></td></tr>");
                    sb.Append("<tr><td colspan = '2'></td></tr>");
                    sb.Append("<tr><td><b>From Date : </b>");
                    sb.Append(fDate);
                    sb.Append("</td><td align = 'right'><b>Date: </b>");
                    sb.Append(DateTime.Now);
                    sb.Append(" </td></tr>");
                    sb.Append("<tr><td colspan = '2'><b>To Date : </b>");
                    sb.Append(tDate);
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
                    sb.Append("'>Total Amount</td>");
                    sb.Append("<td>");
                    sb.Append(dt.Compute("sum(BillAmount)", ""));
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
                    Response.AddHeader("content-disposition", "attachment;filename=UnpaidBillReport_" + fDate + "To" + tDate + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }
    }
}