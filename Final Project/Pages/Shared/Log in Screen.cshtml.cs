using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Final_Project.Models;
using System.Data;

namespace Final_Project.Pages.Shared
{

    public class Log_in_ScreenModel : PageModel
    {
        private readonly ILogger<Log_in_ScreenModel> _logger;
        private readonly DB db;
        public Log_in_ScreenModel(ILogger<Log_in_ScreenModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }
        [BindProperty]
        public string idInput { get; set; }
        [BindProperty]
        public string passInput { get; set; }
        [BindProperty]
        public object dt { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            Console.Write(idInput + " " + passInput);
            dt = db.getRole(idInput, passInput);

            Console.WriteLine(dt.ToString());



        }
    }
}
