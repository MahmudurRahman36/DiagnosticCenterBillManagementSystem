using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.BLL.Models;
using DiagnosticCenterBillManagementSystem.DAL;

namespace DiagnosticCenterBillManagementSystem.BLL
{
    public class UnpaidBillReportManager
    {
        UnpaidBillReportGateway unpaidBillReportGateway =new UnpaidBillReportGateway();

        public List<UnpaidBillReport> GetUnPaidReport(double fromDate, double todate)
        {
            return unpaidBillReportGateway.GetUnPaidReport(fromDate, todate);
        }
    }
}