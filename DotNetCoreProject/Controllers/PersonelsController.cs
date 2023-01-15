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

        public IActionResult GetAllPersonels()
        {
            var mahir = personelRepository.GetAll();
            var jsonData = JsonConvert.SerializeObject(mahir);
            return Json(jsonData);
        }

        // [HttpPost("{kullaniciId}")]
        [HttpPost("/api/Personels/GetById/{userID}")]
        public IActionResult GetById(int userID)
        {
            var test = personelRepository.GetById(userID);
            var jsonData = JsonConvert.SerializeObject(test);
            return Json(jsonData);
        }


        [HttpPost]
        public void PersonelUpdate(Personels pers)
        {
         

            Personels test = new Personels();
            test = personelRepository.GetById(pers.Id);

            test.FirstName = pers.FirstName;
            test.LastName = pers.LastName;
            test.Email = pers.Email;
            personelRepository.Update(test);
        }
    }
}
