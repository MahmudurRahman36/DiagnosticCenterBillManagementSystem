using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagementSystem.DAL
{
    public class TestTypeSetupGateway:CommonGateway
    {
        public bool SetTestTypeName(string testType)
        {
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();
                string query = "insert into Types(TypeName) values (@TypeName);";

                Command = new SqlCommand(query, Connection);
                Command.Parameters.Clear();

                Command.Parameters.Add("@TypeName", SqlDbType.VarChar);
                Command.Parameters["@TypeName"].Value = testType;
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
        public DataSet GetTestTypeInformation()
        {
            GenarateConnection();
            DataSet = new DataSet();
            using (Connection)
            {
                Connection.Open();
                string query = "select * from Types order by TypeName";
                Command = new SqlCommand(query, Connection);
                DataAdapter = new SqlDataAdapter(Command);
                DataAdapter.Fill(DataSet);
                Connection.Close();
            }
            return DataSet;
        }

        public int GetTestTypeId(string testType)
        {
            GenarateConnection();
            string query = "SELECT * FROM Types WHERE TypeName =@TypeName";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.Add("@TypeName", SqlDbType.VarChar);
            Command.Parameters["@TypeName"].Value = testType;
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