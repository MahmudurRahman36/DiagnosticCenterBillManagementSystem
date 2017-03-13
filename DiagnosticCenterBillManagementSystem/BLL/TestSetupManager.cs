using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.BLL.Models;
using DiagnosticCenterBillManagementSystem.DAL;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class TestSetupManager
    {
        TestSetupGateway testSetupGateway=new TestSetupGateway();


        public List<Types> GetTestTypeDropdownList()
        {
            List<Types> TestTypeList = testSetupGateway.GetTestTypeDropdownList();
            return TestTypeList;
        }

        public DataSet GetAllTestInformation()
        {
            DataSet dataSet = testSetupGateway.GetAllTestInformation();
            return dataSet;
        }

        public bool SetTestInformation(Test testSetup)
        {
            if (IsTestExist(testSetup.TestName))
            {
                return false;
            }
            else
            {
                bool result = testSetupGateway.SetTestInformation(testSetup);
                return result;
            }

        }
        public bool IsTestExist(string testName)
        {

            int testId = testSetupGateway.GetTestId(testName);
            if (testId != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}