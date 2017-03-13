using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.BLL.Models
{
    public class Payment
    {
        public string MobileNo { get; set; }
        public string BillNumber { get; set; }
        public string Amount { get; set; }
        public string DueDate { get; set; }
        public bool IsDataExist { get; set; }
    }
}