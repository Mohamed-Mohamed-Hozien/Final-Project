using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace Final_Project.Pages
{
    public class Supplies_MissingModel : PageModel
    {


        public DataTable dt { get; set; }

        public List<string> Supplies_ID { get; set; } = new List<string>();
        public List<string> Supplier_Company { get; set; } = new List<string>();
        public List<string> Description { get; set; } = new List<string>();
        public List<string> Quantity { get; set; } = new List<string>();
        public List<string> Total_cost { get; set; } = new List<string>();
        public List<string> state { get; set; } = new List<string>();
        public void OnGet()
        {
            string ConString = "Data Source=HOZIEN-DELL-G15\\SQLEXPRESS;Initial Catalog=ERP_SYS;Integrated Security=True;Encrypt=False";

            using (SqlConnection con = new SqlConnection(ConString))
            {
                string querystring = "select * from Supplies where state = 'Pending'";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(querystring, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        try
                        {

                            while (reader.Read())
                            {
                                Supplies_ID.Add(reader[0].ToString());
                                Supplier_Company.Add(reader[1].ToString());
                                Description.Add(reader[2].ToString());
                                Quantity.Add(reader[3].ToString());
                                Total_cost.Add(reader[4].ToString());
                                state.Add(reader[5].ToString());
                            }

                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex.ToString());

                        }
                    }
                }


            }


        }



    }
}
