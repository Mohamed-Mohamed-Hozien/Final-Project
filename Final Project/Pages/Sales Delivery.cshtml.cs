using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Security.Cryptography;
using System.Data.SqlClient;
namespace Final_Project.Pages
{
    public class Sales_DeliveryModel : PageModel
    {
        private readonly ILogger<Sales_DeliveryModel> _logger;

        public Sales_DeliveryModel(ILogger<Sales_DeliveryModel> logger)
        {
            _logger = logger;
        }
        public DataTable dt { get; set; }

        public List<string> O_ID { get; set; } = new List<string>();
        public List<string> Payment_ID { get; set; } = new List<string>();
        public List<string> C_ID { get; set; } = new List<string>();
        public List<string> E_ID { get; set; } = new List<string>();
       
        public void OnGet()
        {
            getDeliveredOrders();
        }


        public void getDeliveredOrders()
        {

            string ConString = "Data Source=Eng_Ziad;Initial Catalog=ERP_SYS;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(ConString))
            {
                string querystring = "SELECT Sales_Orders.*\r\nFROM Sales_Orders\r\nJOIN Payment ON Sales_Orders.Payment_ID = Payment.Payment_ID\r\nWHERE Sales_Orders.State = 'Done' AND Payment.State = 'Paid';";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(querystring, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        try
                        {

                            while (reader.Read())
                            {
                                O_ID.Add(reader[0].ToString());
                                Payment_ID.Add(reader[1].ToString());
                                C_ID.Add(reader[2].ToString());
                                E_ID.Add(reader[3].ToString());


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
