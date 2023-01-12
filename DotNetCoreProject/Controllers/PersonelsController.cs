using DotNetCoreProject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNetCoreProject.Controllers
{
    public class PersonelsController : Controller
    {
        private readonly PersonelsRepository personelRepository;


        public PersonelsController()
        {
            personelRepository = new PersonelsRepository();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetirHepsi()
        {
            var mahir = personelRepository.GetAll();
            var jsonData = JsonConvert.SerializeObject(mahir);
            return Json(jsonData);
        }

        public IActionResult GetirId (int kullaniciId)
        {
            var test = personelRepository.GetById(kullaniciId);
            var jsonData = JsonConvert.SerializeObject(test);
            return Json(jsonData);
        }
    }
}
