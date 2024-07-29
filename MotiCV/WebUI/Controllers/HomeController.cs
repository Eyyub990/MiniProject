using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Services;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactPostService contactPostService;
        private readonly IServiceService serviceService;

        public HomeController(IContactPostService contactPostService,
            IServiceService serviceService)
        {
            this.contactPostService = contactPostService;
            this.serviceService = serviceService;
        }


        public async Task<IActionResult> Index()
        {
            var response = await serviceService.GetAllAsync();
            return View(response);
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
