using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Database
{
    public class DataSource
    {
        string strConnection;
        public DataSource()
        {
            strConnection = getConnectionString();
        }
        public string getConnectionString()
        {
            string strConnection = "server=tayduky123.database.windows.net;database=PRM391;uid=liquid8796;pwd=Qwerty8796";
            return strConnection;
        }
        public string checkLoginAdmin(string email, string password)
        {
            string user = "";
            string SQL = "select * from Admin where email=@Email and password=@Pass";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Pass", password);
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    user = reader.GetValue(2).ToString();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }
        public bool AddNewProps(string id, string name, string image, string desc, string quantity, string status)
        {
            bool result;
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "insert Props values(@ID,@Name,@Image,@Desc,@Quantity,@Status)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Image", image);
            cmd.Parameters.AddWithValue("@Desc", desc);
            cmd.Parameters.AddWithValue("@Quantity", quantity);
            cmd.Parameters.AddWithValue("@Status", status);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
        public bool AddNewCaster(string id, string password, string name, string image, string desc, string phone, string email, string status)
        {
            bool result;
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "insert Caster values(@ID,@Pass,@Name,@Image,@Desc,@Phone,@Email,@Status)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Pass", password);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Image", image);
            cmd.Parameters.AddWithValue("@Desc", desc);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Status", status);
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
