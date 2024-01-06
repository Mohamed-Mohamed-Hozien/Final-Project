using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Final_Project.Pages
{
    public class CustomerModel : PageModel
    {
        private readonly ILogger<CustomerModel>
    _logger;
        private readonly DB db;
        public CustomerModel(ILogger<CustomerModel>
            logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }
        [BindProperty]
        public List<string> Customer_ID { get; set; } = new List<string>();
        [BindProperty]
        public List<string> Email { get; set; } = new List<string>();
        [BindProperty]
        public List<string> Bank_Account { get; set; } = new List<string>();
        public void OnGet()
        {
            db.getCustomer(Customer_ID, Email, Bank_Account);
        }
    }
}
