using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Final_Project.Pages
{
    public class PurchasingModel : PageModel
    {
        private readonly ILogger<PurchasingModel>
    _logger;
        private readonly DB db;
        public PurchasingModel(ILogger<PurchasingModel>
            logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }
        [BindProperty]
        public object l { get; set; }
        public void OnGet()
        {
            l = db.getName();
        }
    }
}
