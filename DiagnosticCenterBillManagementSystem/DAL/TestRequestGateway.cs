using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.BLL.Models;

namespace DiagnosticCenterBillManagementSystem.DAL
{
    public class TestRequestGateway:CommonGateway
    {
        public List<Test> GetTestDropdownList()
        {
            List<Test> TestList = new List<Test>();
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();

                string query = "select * from Tests;";
                Command = new SqlCommand(query, Connection);
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    Test test=new Test();
                    test.TestId = (int) Reader["ID"];
                    test.TestName = Reader["TestName"].ToString();
                    TestList.Add(test);
                }
                Connection.Close();
            }
            return TestList;
        }
        public int GetPatientID(Patient patient)
        {
            int id = 0;
            GenarateConnection();
            string query = "SELECT * FROM Patients WHERE Name =@Name and MobileNo=@MobileNo and DateOfBirth=@DateOfBirth";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.Add("@Name", SqlDbType.VarChar);
            Command.Parameters["@Name"].Value = patient.Name;
            Command.Parameters.Add("@DateOfBirth", SqlDbType.VarChar);
            Command.Parameters["@DateOfBirth"].Value = patient.DateOfBirth;
            Command.Parameters.Add("@MobileNo", SqlDbType.VarChar);
            Command.Parameters["@MobileNo"].Value = patient.MobileNo;
            Connection.Open();
            Reader = Command.ExecuteReader();

            if (Reader.HasRows)
            {
                Reader.Read();

                id = Convert.ToInt32(Reader["ID"].ToString());
                Reader.Close();
            }
            Connection.Close();
            return id;
        }
        public Test GetTestinformation(int testID)
        {
            Test testSetup=new Test();
            GenarateConnection();
            string query = "SELECT * FROM Tests WHERE ID =@testID";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.Add("@testID", SqlDbType.VarChar);
            Command.Parameters["@testID"].Value = testID;
            Connection.Open();
            Reader = Command.ExecuteReader();

            if (Reader.HasRows)
            {
                Reader.Read();

                testSetup.TestId = Convert.ToInt32(Reader["ID"].ToString());
                testSetup.TestName = Reader["TestName"].ToString();
                testSetup.Fee = Convert.ToInt32(Reader["Fee"].ToString());
                Reader.Close();
            }
            Connection.Close();
            return testSetup;
        }
        public int GetPatientID(string patientName)
        {
            int id = 0;
            GenarateConnection();
            string query = "SELECT * FROM Patients WHERE Name =@patientName";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.Add("@patientName", SqlDbType.VarChar);
            Command.Parameters["@patientName"].Value = patientName;
            Connection.Open();
            Reader = Command.ExecuteReader();

            if (Reader.HasRows)
            {
                Reader.Read();

                id = Convert.ToInt32(Reader["ID"].ToString());
                Reader.Close();
            }
            Connection.Close();
            return id;
        }
        public bool SetPatientInformation(Patient patient)
        {
            bool patientSaved = false;

                GenarateConnection();
                using (Connection)
                {
                    Connection.Open();
                    string query =
                        "insert into Patients(Name,DateOfBirth,MobileNo) values (@Name,@DateOfBirth,@MobileNo);";

                    Command = new SqlCommand(query, Connection);
                    Command.Parameters.Clear();

                    Command.Parameters.Add("@Name", SqlDbType.VarChar);
                    Command.Parameters["@Name"].Value = patient.Name;
                    Command.Parameters.Add("@DateOfBirth", SqlDbType.VarChar);
                    Command.Parameters["@DateOfBirth"].Value = patient.DateOfBirth;
                    Command.Parameters.Add("@MobileNo", SqlDbType.VarChar);
                    Command.Parameters["@MobileNo"].Value = patient.MobileNo;
                    try
                    {
                        Command.ExecuteNonQuery();
                        Connection.Close();
                        patientSaved = true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                return patientSaved;
        }
        public bool SetTestRequestInformation(List<Test> testList,int patientID, double billNumber,string printDate)
        {
            bool testRequestSaved = false;
            foreach (Test test in testList)
            {
                GenarateConnection();
                using (Connection)
                {
                    Connection.Open();
                    string query =
                        "insert into TestRequests(PatientID,TestID,BillNumber,PrintDate,PaymentStatus) values (@PatientID,@TestID,@BillNumber,@PrintDate,@PaymentStatus);";

                    Command = new SqlCommand(query, Connection);
                    Command.Parameters.Clear();

                    Command.Parameters.Add("@PatientID", SqlDbType.Int);
                    Command.Parameters["@PatientID"].Value = patientID;
                    Command.Parameters.Add("@TestID", SqlDbType.Int);
                    Command.Parameters["@TestID"].Value = test.TestId;
                    Command.Parameters.Add("@BillNumber", SqlDbType.VarChar);
                    Command.Parameters["@BillNumber"].Value = billNumber;
                    Command.Parameters.Add("@PrintDate", SqlDbType.VarChar);
                    Command.Parameters["@PrintDate"].Value = printDate;
                    Command.Parameters.Add("@PaymentStatus", SqlDbType.VarChar);
                    Command.Parameters["@PaymentStatus"].Value = "0";
                    try
                    {
                        Command.ExecuteNonQuery();
                        Connection.Close();
                        testRequestSaved = true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                } 
            }
            return testRequestSaved;
        }

        public double GetBillNumber()
        {
            double billnumber = 1001;
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();

                string query = "select * from TestRequests;";
                Command = new SqlCommand(query, Connection);
                Reader = Command.ExecuteReader();
                if (Reader.HasRows) { 
                while (Reader.Read())
                {
                    billnumber = Convert.ToDouble(Reader["BillNumber"].ToString());
                    billnumber = billnumber + 1;
                }
                }

                Connection.Close();
            }
            return billnumber;
        }
    }
}