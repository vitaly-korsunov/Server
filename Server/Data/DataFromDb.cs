using Server.Moduls;
using System.Data;
using System.Data.SqlClient;

namespace Server.Data
{
    public class DataFromDb
    {
        public static string getconnection()
        {
            // var AppName = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnectionString"];
            var config = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json").Build();

            string roundTheCodeSync = config.GetSection("ConnectionStrings")["DefaultConnectionString"];

            return roundTheCodeSync;
        }


        public static DataSet GetStudents()
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection con = new SqlConnection(getconnection()))
            {
                con.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    DataTable dt = new DataTable("Students");
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetStudents";
                    cmd.CommandTimeout = 0;
                    cmd.Connection = con;
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataSet);
                    dataSet.Tables.Add(dt);
                }
            }
            return dataSet;
        }

        internal static DataSet CreateStudent(Student value)
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection con = new SqlConnection(getconnection()))
            {
                con.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    DataTable dt = new DataTable("Students");
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spCreateStudents";
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add(new SqlParameter("@name", value.name));
                    cmd.Parameters.Add(new SqlParameter("@department", value.department));
                    cmd.Parameters.Add(new SqlParameter("@bdate", DateTime.Parse(value.bdate)));
                    cmd.Parameters.Add(new SqlParameter("@gender", value.gender));
                    cmd.Parameters.Add(new SqlParameter("@level", value.level));
                    cmd.Connection = con;
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataSet);
                    dataSet.Tables.Add(dt);
                }
            }
            return dataSet;
        }

        internal static bool DeleteStudent(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(getconnection()))
                {
                    con.Open();
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "spDeleteStudents";
                    sqlCommand.CommandTimeout = 0;
                    sqlCommand.Parameters.Add(new SqlParameter("@Id", id));
                    sqlCommand.Connection = con;
                    sqlCommand.ExecuteScalar();
                    return true;
                }
            }
            catch { Exception ex; }
            {
                return true;
            }

        }

        internal static DataSet GetDepartments()
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection con = new SqlConnection(getconnection()))
            {
                con.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    DataTable dt = new DataTable("Students");
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetDepartments";
                    cmd.CommandTimeout = 0;
                    cmd.Connection = con;
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataSet);
                    dataSet.Tables.Add(dt);
                }
            }
            return dataSet;
        }

        internal static DataSet UpdateStudent(Student value)
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection con = new SqlConnection(getconnection()))
            {
                con.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    DataTable dt = new DataTable("Students");
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spUpdateStudent";
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add(new SqlParameter("@Id", value.Id));
                    cmd.Parameters.Add(new SqlParameter("@name", value.name));
                    cmd.Parameters.Add(new SqlParameter("@department", value.department));
                    cmd.Parameters.Add(new SqlParameter("@bdate", DateTime.Parse(value.bdate)));
                    cmd.Parameters.Add(new SqlParameter("@gender", value.gender));
                    cmd.Parameters.Add(new SqlParameter("@level", value.level));
                    cmd.Connection = con;
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataSet);
                    dataSet.Tables.Add(dt);
                }
            }
            return dataSet;
        }
    }
}

