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
        public DataTable Read(string tableName) { 
        
        DataTable dt = new DataTable();

            string Query = "select ID from "+tableName;
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
    }
}
