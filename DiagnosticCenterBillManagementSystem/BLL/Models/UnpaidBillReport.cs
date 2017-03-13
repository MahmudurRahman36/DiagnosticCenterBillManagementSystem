using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.BLL.Models
{
    public class UnpaidBillReport
    {
        public string BillNumber { get; set; }
        public string MobileNo { get; set; }
        public string PatientName { get; set; }
        public double BillAmount { get; set; }
    }
}