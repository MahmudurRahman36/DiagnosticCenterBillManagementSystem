using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.BLL.Models;
using DiagnosticCenterBillManagementSystem.DAL;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class TestRequestManager
    {
        TestRequestGateway testRequestGateway=new TestRequestGateway();

        public List<Test> GetTestDropdownList()
        {
            return testRequestGateway.GetTestDropdownList();
        }

        public Test GetTestinformation(int testID)
        {
            return testRequestGateway.GetTestinformation(testID);
        }

        public double GetBillNumber()
        {
            return testRequestGateway.GetBillNumber();
        }

        public string GetPrintDate()
        {
            string today = DateTime.Today.Date.Day + "-" + DateTime.Today.Date.Month + "-" + DateTime.Today.Date.Year;
            return today;
        }

        public bool SetTestRequestInformation(List<Test> testList, Patient patient, int testReqestListLength)
        {
            if (testReqestListLength == 0)
            {
                return true;
            }

            int patientID = testRequestGateway.GetPatientID(patient);
            if (patientID == 0)
            {
                testRequestGateway.SetPatientInformation(patient);
                patientID = testRequestGateway.GetPatientID(patient);
            }
            return testRequestGateway.SetTestRequestInformation(testList, patientID, GetBillNumber(), GetPrintDate());

        }     
    }
}