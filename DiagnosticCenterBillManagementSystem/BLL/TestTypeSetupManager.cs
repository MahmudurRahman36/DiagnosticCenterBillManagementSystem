using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.DAL;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class TestTypeSetupManager
    {
        TestTypeSetupGateway testTypeSetupGateway = new TestTypeSetupGateway();
        public bool SetTestTypeName(string testType)
        {
            if (IsTestTypeExist(testType))
            {
                return false;
            }
            else
            {
                bool result=testTypeSetupGateway.SetTestTypeName(testType);
                return result;
            }

        }

        public DataSet GetTestTypeInformation()
        {
            DataSet dataSet = testTypeSetupGateway.GetTestTypeInformation();
            return dataSet;
        }

        public bool IsTestTypeExist(string testType)
        {
            
            int testTypeId = testTypeSetupGateway.GetTestTypeId(testType);
            if (testTypeId != 0)
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