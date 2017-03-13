using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.BLL;
using DiagnosticCenterBillManagementSystem.BLL.Models;

namespace DiagnosticCenterBillManagementSystem.DAL
{
    public class UnpaidBillReportGateway:CommonGateway
    {
        public List<UnpaidBillReport> GetUnPaidReport(double fromDate, double todate)
        {
            List<UnpaidBillReport> unpaidBillReportList = new List<UnpaidBillReport>();
            GetDateConfiguration dateConfiguration = new GetDateConfiguration();

            double billAmount = 0;
            string billNumber = "";
            string mobileNo = "";
            string patientName = "";

            GenarateConnection();
            string query = "SELECT * FROM TestRequestView WHERE PaymentStatus =@PaymentStatus ORDER BY BillNumber;";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("@PaymentStatus", SqlDbType.VarChar);
            Command.Parameters["@PaymentStatus"].Value = "0";

            Connection.Open();
            Reader = Command.ExecuteReader();

            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    double printDate =
                        Convert.ToDouble(dateConfiguration.GetDateInDouble(Reader["PrintDate"].ToString()));
                    if (fromDate <= printDate & todate >= printDate)
                    {
                        if (billNumber.Equals(Reader["BillNumber"].ToString()))
                        {
                            billAmount = billAmount + Convert.ToDouble(Reader["Fee"]);

                        }
                        else
                        {
                            if (!billNumber.Equals(""))
                            {
                                UnpaidBillReport unpaidBillReport = new UnpaidBillReport();
                                unpaidBillReport.BillNumber = billNumber;
                                unpaidBillReport.BillAmount = billAmount;
                                unpaidBillReport.PatientName = patientName;
                                unpaidBillReport.MobileNo = mobileNo;
                                unpaidBillReportList.Add(unpaidBillReport);
                            }
                            billNumber = Reader["BillNumber"].ToString();
                            mobileNo = Reader["MobileNo"].ToString();
                            patientName = Reader["Name"].ToString();
                            billAmount = Convert.ToDouble(Reader["Fee"]);
                        }
                    }
                }
                UnpaidBillReport unpaidBillReports = new UnpaidBillReport();
                unpaidBillReports.BillNumber = billNumber;
                unpaidBillReports.BillAmount = billAmount;
                unpaidBillReports.PatientName = patientName;
                unpaidBillReports.MobileNo = mobileNo;
                unpaidBillReportList.Add(unpaidBillReports);
                
            }
            Connection.Close();
            return unpaidBillReportList;
        }
    }
}