using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace Final_Project.Pages
{
    public class Supplies_Missing_Update_btnModel : PageModel
    {
        [BindProperty]
        public string Supplies_ID { get; set; }

        [BindProperty]
        public int Quantity { get; set; }
        public void OnGet()
        {
        }
        public object updateQuantity()
        {
            string conStr = "Data Source=HOZIEN-DELL-G15\\SQLEXPRESS;Initial Catalog=ERP_SYS;Integrated Security=True;Encrypt=False";

            using (SqlCommand cmd = new SqlCommand($"UPDATE Supplies SET Quantity = Quantity + {Quantity} WHERE Supplies_ID = '{Supplies_ID}'", new SqlConnection(conStr)))
            {
                cmd.Connection.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    return ex.Message;
                }

                cmd.Connection.Close();
            }

            return Page();
        }

        public void OnPost()
        {

            updateQuantity();
        }
    }
}
