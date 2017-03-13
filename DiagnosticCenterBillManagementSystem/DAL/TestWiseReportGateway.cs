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
    public class TestWiseReportGateway : CommonGateway
    {
        public List<TestWiseReport> GetTestInfoByDate(double fromDate, double todate)
        {
            List<TestWiseReport> testWiseReportList = new List<TestWiseReport>();
            GetDateConfiguration dateConfiguration = new GetDateConfiguration();
            int totalTest = 0;
            double totalAmount = 0;
            string test = "";

            GenarateConnection();
            string query = "SELECT * FROM TestWiseReportView ORDER BY TestName,PrintDate";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();

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
                        if (test.Equals(Reader["TestName"].ToString()))
                        {
                            totalTest = totalTest + 1;
                            totalAmount = totalAmount + Convert.ToDouble(Reader["Fee"]);
                        }
                        else
                        {
                            if (!test.Equals(""))
                            {
                                TestWiseReport testWiseReport = new TestWiseReport();
                                testWiseReport.TestName = test;
                                testWiseReport.TotalAmount = totalAmount;
                                testWiseReport.TotalTest = totalTest;
                                testWiseReportList.Add(testWiseReport);
                            }
                            test = Reader["TestName"].ToString();
                            totalTest = 1;
                            totalAmount = Convert.ToDouble(Reader["Fee"]);
                        }
                    }
                }
                TestWiseReport testWiseReportForLast = new TestWiseReport();
                testWiseReportForLast.TestName = test;
                testWiseReportForLast.TotalAmount = totalAmount;
                testWiseReportForLast.TotalTest = totalTest;
                testWiseReportList.Add(testWiseReportForLast);
            }
            Connection.Close();
            return testWiseReportList;
        }

        public List<TestWiseReport> GetAllTestDropdown()
        {
            List<TestWiseReport> TestList = new List<TestWiseReport>();
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();

                string query = "select * from Tests ORDER BY TestName;";
                Command = new SqlCommand(query, Connection);
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    TestWiseReport test = new TestWiseReport();
                    test.TestName = Reader["TestName"].ToString();
                    test.TotalAmount = 0;
                    test.TotalTest = 0;
                    TestList.Add(test);
                }
                Connection.Close();
            }
            return TestList;
        }
    }
}