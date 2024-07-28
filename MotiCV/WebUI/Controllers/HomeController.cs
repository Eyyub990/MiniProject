using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactPostService contactPostService;

        public HomeController(IContactPostService contactPostService)
        {
            this.contactPostService = contactPostService;
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(string name, string email, string subject, string content)
        {
            var response = contactPostService.Add(name, email, subject, content);

            return Json(new{
                error = false,
                message = response
            });
        }


    }
}
