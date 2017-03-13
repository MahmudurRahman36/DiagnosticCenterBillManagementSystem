using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.BLL.Models
{
    public class Patient
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string DateOfBirth { set; get; }
        public string MobileNo { set; get; }
    }
}