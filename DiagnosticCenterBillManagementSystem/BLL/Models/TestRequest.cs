using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.BLL.Models
{
    [Serializable]
    public class TestRequest
    {
        public int ID { set; get; }
        public int PatientID { set; get; }
        public int TestID { set; get; }
        public double BillNumber { set; get; }
        public string PrintDate { set; get; }
        public string PaymentStatus { set; get; }
        public Patient Patient { get; set; }
        public Test Test { get; set; }
    }
}