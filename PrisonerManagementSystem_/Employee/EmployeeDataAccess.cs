using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace PrisonerManagementSystem_.Employee
{
    class EmployeeDataAccess
    {

        //8888888888888888888888888888888888888888888888888888888888888888888888888888
        //---------------------------Start EMPLOYEE-----------------------------------
        //8888888888888888888888888888888888888888888888888888888888888888888888888888
        #region Employee
        public static SqlConnection GetConnection()
        {

            string str = "data source =DESKTOP-285AUGF ;initial catalog =PrisonerSystem_1; integrated security = true;";
            SqlConnection connection = new SqlConnection(str);
            try
            {
                connection.Open();


            }
            catch (Exception)
            {

                MessageBox.Show("Error");
            }
            return connection;
        }
        public static SqlDataReader Get_E_ThroughtDataReader()//------------connected layer with datareader
        {
            string qry = "select * from Employee_T;";
            SqlConnection connection = GetConnection();

            SqlCommand cmd = new SqlCommand(qry, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public static SqlDataReader Get_E_Reader_Ids()//------------connected layer with datareader
        {
            string qry = "select EId from Employee_T";
            SqlConnection connection = GetConnection();

            SqlCommand cmd = new SqlCommand(qry, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public static SqlDataReader Get_E_Reader_SelectedIds(int EId)//------------connected layer with datareader
        {
            string qry = "select * from Employee_T where EId = @EId";
            SqlConnection connection = GetConnection();

            SqlCommand cmd = new SqlCommand(qry, connection);
            cmd.Parameters.AddWithValue("@EId", EId);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public static DataSet Get_E_ThroughtDataAdapter()//-----------Disconnected laye through dataset
        {
            string qry = "select * from Employee_T;";
            SqlConnection connection = GetConnection();

            SqlCommand cmd = new SqlCommand(qry, connection);
            DataSet db = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(db, "Tb_data");
            return db;
        }
        public static DataSet Get_E_ThroughtDataAdapter(int id)//-----------Disconnected laye through dataset
        {
            string qry = "select * from Employee_T where EId = @Id";
            SqlConnection connection = GetConnection();

            SqlCommand cmd = new SqlCommand(qry, connection);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            DataSet db = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(db, "Tb_data");
            return db;
        }
        public static DataSet Get_E_IdsThoughtAdapter()//-----------Disconnected laye through dataset
        {
            string qry = "select EId from Employee_T;";
            SqlConnection connection = GetConnection();

            SqlCommand cmd = new SqlCommand(qry, connection);
            DataSet db = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(db, "Tb_data");
            return db;
        }
        public static void Delete_E_Record(int EId)
        {
            string qry = "delete Employee_T  where EId =@EId";
            SqlConnection con = GetConnection();

            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@EId", EId);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Done");


            }
            catch (Exception)
            {

                MessageBox.Show("Error");
            }
        }
        public static DataSet Search_E_Reg(int EId)
        {
            string qry = "select * from Employee_T where EId like @EId";
            SqlConnection con = GetConnection();

            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@EId", EId);
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(data, "Search_Edata");
            return data;

        }
        public static DataSet Login_Employee(int EId, string EPassword)
        {
            string qry = "select * from Employee_T where EId like @EId and EPassword =@EPassword ";
            SqlConnection con = GetConnection();

            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@EId", EId);
            cmd.Parameters.AddWithValue("@EPassword", EPassword);
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(data, "Search_Edata");
            return data;

        }
        public static void Add_E_Record(int EId, string EName, string ECnic, string EPassword, string EdDesignation, string EAddress, string EPhone)
        {
            string qry = "insert into Employee_T values(@EId,@EName,@ECnic,@EPassword,@EdDesignation,@EAddress,@EPhone)";
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand(qry, con);

            cmd.Parameters.AddWithValue("@EId", EId);
            cmd.Parameters.AddWithValue("@EName", EName);
            cmd.Parameters.AddWithValue("@ECnic", ECnic);
            cmd.Parameters.AddWithValue("@EPassword", EPassword);
            cmd.Parameters.AddWithValue("@EdDesignation", EdDesignation);
            cmd.Parameters.AddWithValue("@EAddress", EAddress);
            cmd.Parameters.AddWithValue("@EPhone", EPhone);
            cmd.ExecuteNonQuery();

        }
     
        public static void Update_E_(int EId, string EName, string ECnic, string EPassword, string EdDesignation, string EAddress, string EPhone)
        {
            string qry = "update Employee_T set EId=@EId,EName=@EName,ECnic=@ECnic,EPassword=@EPassword,EdDesignation=@EdDesignation,EAddress=@EAddress,EPhone=@EPhone where EId= @update";
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand(qry, con);

            cmd.Parameters.AddWithValue("@update", EId);
            cmd.Parameters.AddWithValue("@EId", EId);
            cmd.Parameters.AddWithValue("@EName", EName);
            cmd.Parameters.AddWithValue("@ECnic", ECnic);
            cmd.Parameters.AddWithValue("@EPassword", EPassword);
            cmd.Parameters.AddWithValue("@EdDesignation", EdDesignation);
            cmd.Parameters.AddWithValue("@EAddress", EAddress);
            cmd.Parameters.AddWithValue("@EPhone", EPhone);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Done");


            }
            catch (Exception)
            {

                MessageBox.Show("Error");
            }

        }

        #endregion

        //8888888888888888888888888888888888888888888888888888888888888888888888888888
        //---------------------------End EMPLOYEE-------------------------------------
        //8888888888888888888888888888888888888888888888888888888888888888888888888888
   
    }
}
