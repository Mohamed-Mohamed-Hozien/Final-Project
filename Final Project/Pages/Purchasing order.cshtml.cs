using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;


namespace Final_Project.Pages
{
    public class Purchasing_orderModel : PageModel
    {
        private readonly ILogger<Purchasing_orderModel>
    _logger;
        private readonly DB db;
        public Purchasing_orderModel(ILogger<Purchasing_orderModel>
            logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }
        [BindProperty]
        public List<string> P_O_ID { get; set; } = new List<string>();
        [BindProperty]
        public List<string> Purchasing_state { get; set; } = new List<string>();
        [BindProperty] 
        public List<string> Payment_ID { get; set; } = new List<string>();
        [BindProperty]
        public List<string> E_ID { get; set; } = new List<string>();
        [BindProperty]
        public List<string> Supplies_ID { get; set; } = new List<string>();
        public void OnGet()
        {
            db.getPurchasing_Order(P_O_ID, Purchasing_state, Payment_ID, E_ID, Supplies_ID);
        }
        public bool CompareCounts(string[] suppliesIds, int[] counts)
        {
            if (suppliesIds == null || counts == null || suppliesIds.Length != counts.Length)
            {
                
                return false;
            }

            string ConString = "Data Source=HOZIEN-DELL-G15\\SQLEXPRESS;Initial Catalog=ERP_SYS;Integrated Security=True;Encrypt=False";

            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();

              
                string querystring = "SELECT count (supplies_id) , supplies_id FROM Supplies WHERE supplies_id IN ({@SuppliesIds})";

                using (SqlCommand cmd = new SqlCommand(querystring, con))
                {
                    cmd.Parameters.AddWithValue("@SuppliesIds", string.Join(",", suppliesIds));
                    int counter = 0; 
                    try
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //string supplyId = reader["supplies_id"].ToString();
                                int countFromDatabase = Convert.ToInt32(reader["count"]);

                            
                                for (int i = 0;i < suppliesIds.Length;i++)
                                {
                                    if (counts[i] == countFromDatabase) counter++; 

                                }
                                
                            }
                        }

                        return counter == suppliesIds.Length; 

                    }
                    catch (SqlException ex)
                    {
                        //_logger.LogError(ex, "Error querying data in the database.");

                        return false;
                    }
                }
            }
        }


    }
}
