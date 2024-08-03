using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Services;
using Services.Skills;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactPostService contactPostService;
        private readonly IServiceService serviceService;
        private readonly ISkillService skillService;

        public HomeController(IContactPostService contactPostService,
            IServiceService serviceService,
            ISkillService skillService)
        {
            this.contactPostService = contactPostService;
            this.serviceService = serviceService;
            this.skillService = skillService;
        }


        public async Task<IActionResult> Index()
        {
            var services = await serviceService.GetAllAsync();
            var skills = await skillService.GetAllAsync();

            var vm = new HomeGetAllViewModel
            {
                Skills = skills,
                Services = services
            };


            return View(vm);
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
