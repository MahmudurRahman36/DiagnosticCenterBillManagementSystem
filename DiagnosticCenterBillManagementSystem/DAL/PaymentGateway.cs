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
    public class PaymentGateway:CommonGateway
    {
        public Payment GetTestByBillNumber(string billNumber)
        {
            Payment payment = new Payment();
            double amount = 0;
            payment.IsDataExist = false;
            GenarateConnection();
            string query = "SELECT * FROM TestRequestView WHERE BillNumber =@BillNumber and PaymentStatus =@PaymentStatus";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.Add("@BillNumber", SqlDbType.VarChar);
            Command.Parameters["@BillNumber"].Value = billNumber;
            Command.Parameters.Add("@PaymentStatus", SqlDbType.VarChar);
            Command.Parameters["@PaymentStatus"].Value = "0";
            Connection.Open();
            Reader = Command.ExecuteReader();

            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    amount = amount + Convert.ToDouble(Reader["Fee"]);
                    payment.Amount = amount.ToString();
                    payment.DueDate = Reader["PrintDate"].ToString();
                    payment.BillNumber = Reader["BillNumber"].ToString();
                    payment.IsDataExist = true;
                }               
            }
            Connection.Close();
            return payment;
        }
        public Payment GetTestByMobileNo(string mobileNo)
        {
            Payment payment = new Payment();
            double amount = 0;
            payment.IsDataExist = false;
            GenarateConnection();
            string query = "SELECT * FROM TestRequestView WHERE MobileNo =@MobileNo and PaymentStatus =@PaymentStatus";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.Add("@MobileNo", SqlDbType.VarChar);
            Command.Parameters["@MobileNo"].Value = mobileNo;
            Command.Parameters.Add("@PaymentStatus", SqlDbType.VarChar);
            Command.Parameters["@PaymentStatus"].Value = "0";
            Connection.Open();
            Reader = Command.ExecuteReader();

            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    amount = amount + Convert.ToDouble(Reader["Fee"]);
                    payment.Amount = amount.ToString();
                    payment.DueDate = Reader["PrintDate"].ToString();
                    payment.BillNumber = Reader["BillNumber"].ToString();
                    payment.IsDataExist = true;
                }

            }
            Connection.Close();
            return payment;
        }
        public bool GetAllTestByBillNumber(string billNumber)
        {
            bool isDataExist = false;

            GenarateConnection();
            string query = "SELECT * FROM TestRequestView WHERE BillNumber =@BillNumber";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.Add("@BillNumber", SqlDbType.VarChar);
            Command.Parameters["@BillNumber"].Value = billNumber;
            Connection.Open();
            Reader = Command.ExecuteReader();

            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    isDataExist = true;
                }
            }
            Connection.Close();
            return isDataExist;
        }
        public bool GetAllTestByMobileNo(string mobileNo)
        {
            bool isDataExist = false;

            GenarateConnection();
            string query = "SELECT * FROM TestRequestView WHERE MobileNo =@MobileNo";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.Add("@MobileNo", SqlDbType.VarChar);
            Command.Parameters["@MobileNo"].Value = mobileNo;

            Connection.Open();
            Reader = Command.ExecuteReader();

            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    isDataExist = true;
                }

            }
            Connection.Close();
            return isDataExist;
        }
        public bool SetPaymentInformation(string billNumber)
        {

                GenarateConnection();
                using (Connection)
                {
                    Connection.Open();
                    string query = "UPDATE TestRequests set PaymentStatus =@PaymentStatus where BillNumber = @BillNumber;";

                    Command = new SqlCommand(query, Connection);
                    Command.Parameters.Clear();

                    Command.Parameters.Add("@PaymentStatus", SqlDbType.VarChar);
                    Command.Parameters["@PaymentStatus"].Value = "1";
                    Command.Parameters.Add("@BillNumber", SqlDbType.VarChar);
                    Command.Parameters["@BillNumber"].Value = billNumber;
                    try
                    {
                        Command.ExecuteNonQuery();
                        Connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }           

        }
        public bool SetPaymentInformationByMobileNo(string mobileNo)
        {

            GenarateConnection();
            using (Connection)
            {
                Connection.Open();
                string query = "UPDATE TestRequests set PaymentStatus =@PaymentStatus where MobileNo = @MobileNo;";

                Command = new SqlCommand(query, Connection);
                Command.Parameters.Clear();

                Command.Parameters.Add("@PaymentStatus", SqlDbType.VarChar);
                Command.Parameters["@PaymentStatus"].Value = "1";
                Command.Parameters.Add("@MobileNo", SqlDbType.VarChar);
                Command.Parameters["@MobileNo"].Value = mobileNo;
                try
                {
                    Command.ExecuteNonQuery();
                    Connection.Close();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }
        public List<string> GetBillNumberByMobileNumber(string mobileNumber)
        {
            List<string> billNumberList = new List<string>();
            string billNumber = "";
            string newBillNumber="";

            GenarateConnection();
            string query = "SELECT * FROM TestRequestView WHERE MobileNo =@MobileNo and PaymentStatus =@PaymentStatus";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.Add("@MobileNo", SqlDbType.VarChar);
            Command.Parameters["@MobileNo"].Value = mobileNumber;
            Command.Parameters.Add("@PaymentStatus", SqlDbType.VarChar);
            Command.Parameters["@PaymentStatus"].Value = "0";

            Connection.Open();
            Reader = Command.ExecuteReader();

            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    newBillNumber = Reader["BillNumber"].ToString();
                    if (!billNumber.Equals(newBillNumber))
                    {
                        billNumberList.Add(newBillNumber);
                        billNumber = newBillNumber;
                    }
                    
                }
            }
            Connection.Close();
            return billNumberList;
        } 
    }
}