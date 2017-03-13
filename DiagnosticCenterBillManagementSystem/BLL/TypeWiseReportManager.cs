using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.BLL.Models;
using DiagnosticCenterBillManagementSystem.DAL;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class TypeWiseReportManager
    {
        TypeWiseReportGateway typeWiseReportGateway = new TypeWiseReportGateway();
        public List<TypeWiseReport> GetTypeInfoByDate(double fromDate, double todate)
        {
            List<TypeWiseReport> typeWiseReportList = typeWiseReportGateway.GetTestTypeInfoByDate(fromDate, todate);
            List<TypeWiseReport> allTypeWiseList = typeWiseReportGateway.GetTestTypeList();
            List<TypeWiseReport> newTypeWiseList = new List<TypeWiseReport>();
            int totalNoOfTest = 0;
            double totalAmount = 0;
            foreach (TypeWiseReport newType in allTypeWiseList)
            {
                foreach (TypeWiseReport type in typeWiseReportList)
                {
                    if (type.TestTypeName.Equals(newType.TestTypeName))
                    {
                        newType.TestTypeName = type.TestTypeName;
                        newType.TotalNoOfTest = type.TotalNoOfTest;
                        newType.TotalAmount = type.TotalAmount;
                    }
                }
                newTypeWiseList.Add(newType);
            }
            return newTypeWiseList;
        }      
    }
}