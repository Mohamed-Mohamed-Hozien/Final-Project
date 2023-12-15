using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Final_Project.Pages
{
    public class Admin_ScreenModel : PageModel
    {
        [BindProperty]
        public string Case {  get; set; }
        public void OnGet()
        {

        }
    }
}
