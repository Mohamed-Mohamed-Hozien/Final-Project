using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Data;
using System.Data.SqlClient;
namespace Final_Project.Models
{
      
    public class DB
    {
        public SqlConnection con {  get; set; }
        public DB() {
            string conStr = "Data Source=Eng_Ziad;Initial Catalog=project;Integrated Security=True";
            con = new SqlConnection(conStr);       
        
        }
        public DataTable Read(string tableName, string Column) { 
        
        DataTable dt = new DataTable();

            string Query = "select "+ Column +" from " + tableName ;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {

            }
            finally { con.Close();
            }
            return dt;
        }

        public DataTable TestingQuery(string Q)
        {
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }
            return dt;
        }
    }
}
