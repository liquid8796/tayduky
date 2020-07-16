using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using TayDuKy.DAO;

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
        public bool AddNewKiepnan(string id, string name, string desc, string location, string startTime, string endTime, string numRecord, string status)
        {
            bool result;
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "insert Misery values(@ID,@Name,@Desc,@Location,@Start,@End,@Num,@Status)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Desc", desc);
            cmd.Parameters.AddWithValue("@Location", location);
            cmd.Parameters.AddWithValue("@Start", startTime);
            cmd.Parameters.AddWithValue("@End", endTime);
            cmd.Parameters.AddWithValue("@Num", numRecord);
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

        public List<Kiepnan> getAllKiepnan()
        {
            List<Kiepnan> result = new List<Kiepnan>();
            string SQL = "select * from Misery";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Kiepnan tmp = new Kiepnan
                    {
                        id = reader.GetValue(0).ToString(),
                        name = reader.GetValue(1).ToString(),
                        desc = reader.GetValue(2).ToString(),
                        location = reader.GetValue(3).ToString(),
                        start = reader.GetValue(4).ToString(),
                        end = reader.GetValue(5).ToString(),
                        record = reader.GetValue(6).ToString(),
                        status = reader.GetValue(7).ToString(),
                    };
                    result.Add(tmp);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<Caster> getAllCaster()
        {
            List<Caster> result = new List<Caster>();
            string SQL = "select * from Caster";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Caster tmp = new Caster
                    {
                        id = reader.GetValue(0).ToString(),
                        password = reader.GetValue(1).ToString(),
                        name = reader.GetValue(2).ToString(),
                        image = reader.GetValue(3).ToString(),
                        desc = reader.GetValue(4).ToString(),
                        phone = reader.GetValue(5).ToString(),
                        email = reader.GetValue(6).ToString(),
                        status = reader.GetValue(7).ToString(),
                    };
                    result.Add(tmp);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public List<Props> getAllProps()
        {
            List<Props> result = new List<Props>();
            string SQL = "select * from Props where status=@Status";
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@Status", "available");
            try
            {
                cnn.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Props tmp = new Props
                    {
                        id = reader.GetValue(0).ToString(),
                        name = reader.GetValue(1).ToString(),
                        image = reader.GetValue(2).ToString(),
                        desc = reader.GetValue(3).ToString(),
                        quantity = reader.GetValue(4).ToString(),
                        status = reader.GetValue(5).ToString(),
                    };
                    result.Add(tmp);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool UpdateMisery(Kiepnan kiepnan)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "update Misery set name=@Name,description=@Desc,location=@Location,startTime=@Start,endTime=@End,numRecord=@Record,status=@Status where id=@ID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", kiepnan.id);
            cmd.Parameters.AddWithValue("@Name", kiepnan.name);
            cmd.Parameters.AddWithValue("@Desc", kiepnan.desc);
            cmd.Parameters.AddWithValue("@Location", kiepnan.location);
            cmd.Parameters.AddWithValue("@Start", kiepnan.start);
            cmd.Parameters.AddWithValue("@End", kiepnan.end);
            cmd.Parameters.AddWithValue("@Record", kiepnan.record);
            cmd.Parameters.AddWithValue("@Status", kiepnan.status);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }

        public bool UpdateCaster(Caster caster)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "update Caster set password=@Password,name=@Name,image=@Image,description=@Desc,phoneNo=@Phone,email=@Email,status=@Status where id=@ID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", caster.id);
            cmd.Parameters.AddWithValue("@Password", caster.password);
            cmd.Parameters.AddWithValue("@Name", caster.name);
            cmd.Parameters.AddWithValue("@Image", caster.image);
            cmd.Parameters.AddWithValue("@Desc", caster.desc);
            cmd.Parameters.AddWithValue("@Phone", caster.phone);
            cmd.Parameters.AddWithValue("@Email", caster.email);
            cmd.Parameters.AddWithValue("@Status", caster.status);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }

        public bool UpdateProps(Props props)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "update Props set name=@Name,image=@Image,description=@Desc,quantity=@Quantity,status=@Status where id=@ID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", props.id);
            cmd.Parameters.AddWithValue("@Name", props.name);
            cmd.Parameters.AddWithValue("@Image", props.image);
            cmd.Parameters.AddWithValue("@Desc", props.desc);
            cmd.Parameters.AddWithValue("@Quantity", props.quantity);
            cmd.Parameters.AddWithValue("@Status", props.status);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }

        public bool DeleteMisery(string id)
        {
            bool result;
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "delete Misery where id=@ID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", id);
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

        public bool DeleteCaster(string id)
        {
            bool result;
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "delete Caster where id=@ID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", id);
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

        public bool DeleteProps(string id)
        {
            bool result;
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "delete Props where id=@ID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", id);
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

        public bool AddNewCasterCart(string id, string casterId, string role, string roleDesc, string miseryId)
        {
            bool result;
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "insert CasterCartDetail values(@ID,@CasterID,@Role,@RoleDesc,@MiseryId)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@CasterID", casterId);
            cmd.Parameters.AddWithValue("@Role", role);
            cmd.Parameters.AddWithValue("@RoleDesc", roleDesc);
            cmd.Parameters.AddWithValue("@MiseryId", miseryId);
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

        public bool AddNewPropsCart(string id, string propsId, string quantity, string miseryId)
        {
            bool result;
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "insert PropsCartDetail values(@ID,@PropsID,@Quantity,@MiseryId)";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@PropsID", propsId);
            cmd.Parameters.AddWithValue("@Quantity", quantity);
            cmd.Parameters.AddWithValue("@MiseryId", miseryId);
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
