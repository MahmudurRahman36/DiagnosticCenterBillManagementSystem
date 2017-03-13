using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagementSystem.BLL.Models;

namespace DiagnosticCenterBillManagementSystem.DAL
{
    public class TestSetupGateway:CommonGateway
    {
        public List<Types> GetTestTypeDropdownList()
        {
            List<Types> typeList = new List<Types>();
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();

                string query = "select * from Types;";
                Command = new SqlCommand(query, Connection);
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    Types typeName=new Types();
                    typeName.ID = Convert.ToInt32(Reader["ID"]);
                    typeName.TypeName = Reader["TypeName"].ToString();
                    typeList.Add(typeName);
                }
                Connection.Close();
            }
            return typeList;
        }

        public DataSet GetAllTestInformation()
        {
            GenarateConnection();
            DataSet = new DataSet();
            using (Connection)
            {
                Connection.Open();
                Command = new SqlCommand("select * from TestView order by Name", Connection);
                DataAdapter = new SqlDataAdapter(Command);
                DataAdapter.Fill(DataSet);
                Connection.Close();
            }
            return DataSet;
        }

        public bool SetTestInformation(Test testSetup)
        {
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();
                string query =
                    "insert into Tests(TestName,Fee,TestTypeID) values (@TestName,@Fee,@TestTypeID);";

                Command = new SqlCommand(query, Connection);
                Command.Parameters.Clear();

                Command.Parameters.Add("@TestName", SqlDbType.VarChar);
                Command.Parameters["@TestName"].Value = testSetup.TestName;
                Command.Parameters.Add("@Fee", SqlDbType.Decimal);
                Command.Parameters["@Fee"].Value = testSetup.Fee;
                Command.Parameters.Add("@TestTypeID", SqlDbType.Int);
                Command.Parameters["@TestTypeID"].Value = testSetup.TestTypeId;
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

        public int GetTestId(string testName)
        {
            GenarateConnection();
            string query = "SELECT * FROM Tests WHERE TestName =@TestName";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.Add("@TestName", SqlDbType.VarChar);
            Command.Parameters["@TestName"].Value = testName;
            Connection.Open();
            Reader = Command.ExecuteReader();

            int id = 0;
            if (Reader.HasRows)
            {
                Reader.Read();
                id = Convert.ToInt32(Reader["ID"].ToString());
                Reader.Close();
            }
            Connection.Close();
            return id;
        }
        

    }
}