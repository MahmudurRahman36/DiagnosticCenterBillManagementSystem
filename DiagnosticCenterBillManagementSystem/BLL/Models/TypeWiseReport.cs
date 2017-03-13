using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.BLL.Models
{
    public class TypeWiseReport
    {
        public string TestTypeName { get; set; }
        public int TotalNoOfTest { get; set; }
        public double TotalAmount { set; get; }
    }
}