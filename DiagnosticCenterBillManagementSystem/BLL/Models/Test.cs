using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.BLL.Models
{
    public class Test
    {
        public int TestId { set; get; }
        public string TestName { get; set; }
        public double Fee { get; set; }
        public int TestTypeId { get; set; }

        public Test()
        {
            
        }
        public Test(string testName,double fee,int testTypeId)
        {
            TestName = testName;
            Fee = fee;
            TestTypeId = testTypeId;
        }
    }
}