using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.BLL;
using DiagnosticCenterBillManagementSystem.BLL.Models;

namespace DiagnosticCenterBillManagementSystem.DAL
{
    public class TypeWiseReportGateway : CommonGateway
    {
        public List<TypeWiseReport> GetTestTypeInfoByDate(double fromDate, double todate)
        {
            List<TypeWiseReport> typeWiseReportList = new List<TypeWiseReport>();
            GetDateConfiguration dateConfiguration = new GetDateConfiguration();
            int totalTest = 0;
            double totalAmount = 0;
            string type = "";

            GenarateConnection();
            string query = "SELECT * FROM TypeWiseReportView ORDER BY TypeName,PrintDate";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();

            Connection.Open();
            Reader = Command.ExecuteReader();

            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    double printDate =
                        Convert.ToDouble(dateConfiguration.GetDateInDouble(Reader["PrintDate"].ToString()));
                    if (fromDate <= printDate & todate >= printDate)
                    {
                        string newtypename = Reader["TypeName"].ToString();
                        if (type.Equals(newtypename))
                        {
                            totalTest = totalTest + 1;
                            totalAmount = totalAmount + Convert.ToDouble(Reader["Fee"]);
                        }
                        else
                        {
                            if (!type.Equals(""))
                            {
                                TypeWiseReport typeWiseReport = new TypeWiseReport();
                                typeWiseReport.TestTypeName = type;
                                typeWiseReport.TotalAmount = totalAmount;
                                typeWiseReport.TotalNoOfTest = totalTest;
                                typeWiseReportList.Add(typeWiseReport);
                            }
                            type = Reader["TypeName"].ToString();
                            totalTest = 1;
                            totalAmount = Convert.ToDouble(Reader["Fee"]);
                        }
                    }
                }
                TypeWiseReport typeWiseReportForLast = new TypeWiseReport();
                typeWiseReportForLast.TestTypeName = type;
                typeWiseReportForLast.TotalAmount = totalAmount;
                typeWiseReportForLast.TotalNoOfTest = totalTest;
                typeWiseReportList.Add(typeWiseReportForLast);
            }
            Connection.Close();
            return typeWiseReportList;
        }
        public List<TypeWiseReport> GetTestTypeList()
        {
            List<TypeWiseReport> typeWiseReportList = new List<TypeWiseReport>();
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();

                string query = "select * from Types ORDER BY TypeName;";
                Command = new SqlCommand(query, Connection);
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    TypeWiseReport typeWiseReport = new TypeWiseReport();
                    typeWiseReport.TestTypeName = Reader["TypeName"].ToString();
                    typeWiseReport.TotalAmount = 0;
                    typeWiseReport.TotalNoOfTest = 0;
                    typeWiseReportList.Add(typeWiseReport);
                }
                Connection.Close();
            }
            return typeWiseReportList;
        }
    }
}