using Final_Project.Models;
using Final_Project.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Final_Project.Pages;
namespace Final_Project.Pages
{
    public class InventoryModel : PageModel
    {

        private readonly ILogger<InventoryModel>
    _logger;
        private readonly DB db;
        public InventoryModel(ILogger<InventoryModel>
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
