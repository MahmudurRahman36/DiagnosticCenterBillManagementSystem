using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.BLL.Models;
using DiagnosticCenterBillManagementSystem.DAL;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class PaymentManager
    {
        PaymentGateway paymentGateway=new PaymentGateway();

        public Payment GetTestByBillNumber(string billNumber)
        {
            return paymentGateway.GetTestByBillNumber(billNumber);
        }

        public Payment GetTestByMobileNo(string mobileNo)
        {
            return paymentGateway.GetTestByMobileNo(mobileNo);
        }

        public bool SetPaymentInformationByMobileNo(string mobileNo)
        {
            return paymentGateway.SetPaymentInformationByMobileNo(mobileNo);
        }

        public bool SetPaymentInformation(List<string> billNumberList)
        {
            bool result = false;
            foreach (string billNumber in billNumberList)
            {
                result = paymentGateway.SetPaymentInformation(billNumber);
            }

            return result;
        }

        public bool GetAllTestByBillNumber(string billNumber)
        {
            return paymentGateway.GetAllTestByBillNumber(billNumber);
        }

        public bool GetAllTestByMobileNo(string mobileNo)
        {
            return paymentGateway.GetAllTestByMobileNo(mobileNo);
        }

        public List<string> GetBillNumberByMobileNumber(string mobileNumber)
        {
            return paymentGateway.GetBillNumberByMobileNumber(mobileNumber);
        }
        
    }
}