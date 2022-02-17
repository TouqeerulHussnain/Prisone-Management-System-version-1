using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PrisonerManagementSystem_
{
    class DataAccessLayer
    {
        public static int loginSecure = 0;
        public static int MasterLogin = 0;
        //8888888888888888888888888888888888888888888888888888888888888888888888888888
        //----------------------------Start---PRISONER--------------------------------
        //8888888888888888888888888888888888888888888888888888888888888888888888888888
        #region Prisoner

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
        public static SqlDataReader GetThroughtDataReader()//------------connected layer with datareader
        {
            string qry = "select * from Prisoner_T;";
            SqlConnection connection = GetConnection();

            SqlCommand cmd = new SqlCommand(qry, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public static SqlDataReader GetPrisonerIds()//------------connected layer with datareader
        {
            string qry = "select PId from Prisoner_T";
            SqlConnection connection = GetConnection();

            SqlCommand cmd = new SqlCommand(qry, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public static SqlDataReader GetPrisonerSelectedIds(int pid)//------------connected layer with datareader
        {
            string qry = "select * from Prisoner_T where PId = @pid";
            SqlConnection connection = GetConnection();

            SqlCommand cmd = new SqlCommand(qry, connection);
            cmd.Parameters.AddWithValue("@pid", pid);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public static DataSet GetThroughtDataAdapter()//-----------Disconnected laye through dataset
        {
            string qry = "select * from Prisoner_T;";
            SqlConnection connection = GetConnection();

            SqlCommand cmd = new SqlCommand(qry, connection);
            DataSet db = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(db, "Tb_data");
            return db;
        }
        public static DataSet GetPrisonerIdsThoughtAdapter()//-----------Disconnected laye through dataset
        {
            string qry = "select PId from Prisoner_T;";
            SqlConnection connection = GetConnection();

            SqlCommand cmd = new SqlCommand(qry, connection);
            DataSet db = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(db, "Tb_data");
            return db;
        }
        public static void DeleteRecord(int Pid)
        {
            string qry = "delete Prisoner_T  where Pid =@Pid";
            SqlConnection con = GetConnection();

            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Pid", Pid);
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
        public static DataSet SearchReg(int id)
        {
            string qry = "select * from Prisoner_T where PId like @id";
            SqlConnection con = GetConnection();

            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(data, "Search_Pdata");
            return data;

        }
        public static void AddRecord(int PId, string PName, string PCnic, string DateOfEntry, string DateOfRelease, string Crime, string PAddress, string PRelativeName, string PRPhone)
        {
            string qry = "insert into Prisoner_T values(@PId,@PName,@PCnic,@DateOfEntry,@DateOfRelease,@Crime,@PAddress,@PRelativeName,@PRPhone)";
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand(qry, con);

            cmd.Parameters.AddWithValue("@PId", PId);
            cmd.Parameters.AddWithValue("@PName", PName);
            cmd.Parameters.AddWithValue("@PCnic", PCnic);
            cmd.Parameters.AddWithValue("@DateOfEntry", DateOfEntry);
            cmd.Parameters.AddWithValue("@DateOfRelease", DateOfRelease);
            cmd.Parameters.AddWithValue("@Crime", Crime);
            cmd.Parameters.AddWithValue("@PAddress", PAddress);
            cmd.Parameters.AddWithValue("@PRelativeName", PRelativeName);
            cmd.Parameters.AddWithValue("@PRPhone", PRPhone);
            cmd.ExecuteNonQuery();

        }

        public static void Update(int PId, string PName, string PCnic, string DateOfEntry, string DateOfRelease, string Crime, string PAddress, string PRelativeName, string PRPhone)
        {
            //string qry = "update ABC2 set regNo = @updateReg, name = @Updatename,  number = @updatenumber where name =@serach";
            string qry = "update Prisoner_T set PId=@PId,PName=@PName,PCnic=@PCnic,DateOfEntry=@DateOfEntry,DateOfRelease=@DateOfRelease,Crime=@Crime,PAddress=@PAddress,PRelativeName=@PRelativeName,PRPhone=@PRPhone where PId = @Update";
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand(qry, con);

            cmd.Parameters.AddWithValue("@update", PId);
            cmd.Parameters.AddWithValue("@PId", PId);
            cmd.Parameters.AddWithValue("@PName", PName);
            cmd.Parameters.AddWithValue("@PCnic", PCnic);
            cmd.Parameters.AddWithValue("@DateOfEntry", DateOfEntry);
            cmd.Parameters.AddWithValue("@DateOfRelease", DateOfRelease);
            cmd.Parameters.AddWithValue("@Crime", Crime);
            cmd.Parameters.AddWithValue("@PAddress", PAddress);
            cmd.Parameters.AddWithValue("@PRelativeName", PRelativeName);
            cmd.Parameters.AddWithValue("@PRPhone", PRPhone);
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
        //----------------------------END---PRISONER----------------------------------
        //8888888888888888888888888888888888888888888888888888888888888888888888888888


 }
}
