using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JakubKazimierskiLab6.Models;

namespace JakubKazimierskiLab6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        List<CarViewModels> cars;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            cars = new List<CarViewModels>();
            cars.Add(new CarViewModels("Focus", "Ford", 72000, "~/Content/Images/focus.png"));
            cars.Add(new CarViewModels("Golf", "Volkswagen", 800000, "../Content/Images/golf.png"));//mozna zamiennie .. ~
            cars.Add(new CarViewModels("Civic", "Honda", 82000, "~/Content/Images/civic.png"));
            cars.Add(new CarViewModels("Megane", "Renault", 62000, "~/Content/Images/megane.png"));
        }

        public IActionResult GetAllCars()
        {
            return View(cars);
        }

        public IActionResult GetListOfModels()
        {
           // lista modeli
            List<string> models = new List<string>();

            //pobranie kazdwgo modelu
            foreach(CarViewModels car in cars)
            {
                models.Add(car.Model);
            }

            //lista modeli do zwracanego widoku
            return View(models);

        }

        public IActionResult GetCarByModel(string model)
        {
            //wyszukanie modelu o danej nazwie
            CarViewModels car = cars.Where(c => c.Model.ToLower() == model.ToLower()).FirstOrDefault();

            //przekazanie widoku samochodu do zwracanego widoku
            return View(car);
        }

        //rodzaj requestu do kontrolera, zapytanie pobrania informacji
        [HttpGet]
        public IActionResult ContactForm()
        {
            return View();
        }

        //zapytanie wyslania informacji
        [HttpPost]
        public IActionResult ContactForm(ContactFormViewModel formViewModel)
        {
            string fullName = formViewModel.FirstName + " " + formViewModel.LastName;
            ViewBag.UserName = fullName;//ulotne dane
            return View("ContactFormGreetings");
        }

        public IActionResult Index()
        {
            //define variable
            string name = "Jakub Kazimierski";
            //give controller reference to viev
            return View("Index", name);
        }

        public IActionResult InterestingLinks()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
