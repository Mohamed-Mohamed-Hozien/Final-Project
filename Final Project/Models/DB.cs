﻿using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Data;
using System.Data.SqlClient;
namespace Final_Project.Models
{
      
    public class DB
    {
        public SqlConnection con {  get; set; }
        public DB() {
            string conStr = "Data Source=HOZIEN-DELL-G15\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True;Encrypt=False";
            con = new SqlConnection(conStr);       
        
        }
        public DataTable getRole(string E_ID, string Password) { 
        
        DataTable dt = new DataTable();

            string Query = "select E.Role from Employee E where E.E_ID ='" + E_ID+ "' and E.Password ='" + Password + "';";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                Console.Write(ex);
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
