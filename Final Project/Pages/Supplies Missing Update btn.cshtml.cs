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

        public IActionResult OnPost()
        {
            try
            {
                UpdateQuantity();
                return RedirectToPage("/Supplies Missing");  // Redirect to the same page after the update
            }
            catch (Exception ex)
            {
                // Handle the exception and provide feedback to the user or log the error
                return Content($"Error: {ex.Message}");
            }
        }

        private void UpdateQuantity()
        {
            string conStr = "Data Source=HOZIEN-DELL-G15\\SQLEXPRESS;Initial Catalog=ERP_SYS;Integrated Security=True;Encrypt=False";

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand($"UPDATE Supplies SET Quantity = Quantity + {Quantity} WHERE Supplies_ID = '{Supplies_ID}'", connection))
                {

                    cmd.ExecuteNonQuery();
                }

                connection.Close();
            }
        }


    }

}
