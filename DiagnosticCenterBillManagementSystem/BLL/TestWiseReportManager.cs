using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.BLL.Models;
using DiagnosticCenterBillManagementSystem.DAL;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class TestWiseReportManager
    {
        TestWiseReportGateway testWiseReportGateway = new TestWiseReportGateway();

        public List<TestWiseReport> GetTestInfoByDate(double fromDate, double todate)
        {
            List<TestWiseReport> testWiseReportList = testWiseReportGateway.GetTestInfoByDate(fromDate, todate);
            List<TestWiseReport> allTestWiseList = testWiseReportGateway.GetAllTestDropdown();
            List<TestWiseReport> newTestWiseList = new List<TestWiseReport>();
            int totalNoOfTest = 0;
            double totalAmount = 0;
            foreach (TestWiseReport newTest in allTestWiseList)
            {
                foreach (TestWiseReport test in testWiseReportList)
                {
                    if (test.TestName.Equals(newTest.TestName))
                    {
                        newTest.TestName = test.TestName;
                        newTest.TotalTest = test.TotalTest;
                        newTest.TotalAmount = test.TotalAmount;
                    }
                }
                newTestWiseList.Add(newTest);
            }
            return newTestWiseList;
        }

    }
}