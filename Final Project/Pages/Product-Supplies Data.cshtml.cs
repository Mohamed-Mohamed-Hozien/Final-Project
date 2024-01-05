using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;


namespace Final_Project.Pages
{
    public class Product_Supplies_DataModel : PageModel
    {
        private readonly ILogger<Product_Supplies_DataModel> _logger;

        public Product_Supplies_DataModel(ILogger<Product_Supplies_DataModel> logger)
        {
            _logger = logger;
        }
        public DataTable dt { get; set; }
        [BindProperty]
        public List<string> P_ID { get; set; } = new List<string>();
        [BindProperty]
        public List<string> Name { get; set; } = new List<string>();
        [BindProperty]
        public List<string> Price { get; set; } = new List<string>();
        [BindProperty]
        public List<string> Quantity { get; set; } = new List<string>();
        [BindProperty]
        public List<string> Supplies_ID { get; set; } = new List<string>();
        [BindProperty]
        public List<string> Supplies_Quantity { get; set; } = new List<string>();
        [BindProperty]
        public List<string> Supply_State { get; set; } = new List<string>();
        public void OnGet()
        {
            string ConString = "Data Source=HOZIEN-DELL-G15\\SQLEXPRESS;Initial Catalog=ERP_SYS;Integrated Security=True;Encrypt=False";

            using (SqlConnection con = new SqlConnection(ConString))
            {
                string querystring = "select P.P_ID, P.Name, P.Price, P.Quantity, P.Supplies_ID, P.Supplies_Quantity, S.state from Product P, Supplies S where S.Supplies_ID = P.Supplies_ID;";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(querystring, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        try
                        {

                            while (reader.Read())
                            {
                                P_ID.Add(reader[0].ToString());
                                Name.Add(reader[1].ToString());
                                Price.Add(reader[2].ToString());
                                Quantity.Add(reader[3].ToString());
                                Supplies_ID.Add(reader[4].ToString());
                                Supplies_Quantity.Add(reader[5].ToString());
                                Supply_State.Add(reader[6].ToString());

                            }

                        }
                        catch (SqlException ex)
                        {
                            _logger.LogError(ex, "Error reading data from the database.");

                        }
                    }
                }
            }
        }
    }
}
