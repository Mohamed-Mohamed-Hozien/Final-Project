using Final_Project.Models;
using Final_Project.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Final_Project.Pages
{
    public class Admin_ScreenModel : PageModel
    {
        private readonly ILogger<Admin_ScreenModel>
        _logger;
        private readonly DB db;
        public Admin_ScreenModel(ILogger<Admin_ScreenModel>
            logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }

        [BindProperty]
        public object l {  get; set; }

        [BindProperty]
        public string userNameInput { get; set; }
        [BindProperty]
        public string passInput { get; set; }
        [BindProperty]
        public string numberInput { get; set; }
        [BindProperty]
        public string mailInput { get; set; }
        [BindProperty]
        public string idInput { get; set; }
        [BindProperty]
        public int ssnInput { get; set; }
        [BindProperty]
        public string roleInput { get; set; }
        [BindProperty]
        public bool up {  get; set; }
        public void OnGet()
        {
           l =  db.getName();
            
        }
        
        
        



       




        public void OnPost()
        {
            Console.WriteLine(roleInput);
            Console.WriteLine(up);
            Console.WriteLine("Post is Working");
            if (up == true)

            {
                db.updateEmployee(idInput, ssnInput, mailInput, userNameInput, passInput, numberInput, roleInput);
                Console.WriteLine("THE updated DATA\n" + roleInput + " " + idInput + " " + passInput + " " + numberInput + " " + ssnInput + " " + mailInput + " " + userNameInput);


            }
            if (up == false)
            {

                db.addEmployee(idInput, ssnInput, mailInput, userNameInput, passInput, numberInput, roleInput);
                Console.WriteLine("THE ENTERED DATA\n" + roleInput + " " + idInput + " " + passInput + " " + numberInput + " " + ssnInput + " " + mailInput + " " + userNameInput);

            }


        }
        public void add()
        {

            up = false;
            Console.WriteLine("Add Button Clicked");


        }
        public void update()
        {
            up = true;
            Console.WriteLine("Update Button Clicked");

        }

    }
}
