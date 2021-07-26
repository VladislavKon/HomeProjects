using Microsoft.AspNetCore.Mvc;
using MyShop.data.interfaces;
using MyShop.data.models;
using MyShop.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICars _cars;
        private readonly ICategory _category;

        public CarsController(ICars iCars, ICategory iCategory)
        {
            _cars = iCars;
            _category = iCategory;
        }
        [Route("Cars/ViewList")]
        [Route("Cars/ViewList/{category}")]
        public ViewResult ViewList(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                cars = _cars.GetCars.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _cars.GetCars.Where(i => i.CarCategory.CategoryName.Equals("Электромобили"));
                    currCategory = "Электромобили";
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _cars.GetCars.Where(i => i.CarCategory.CategoryName.Equals("Автомобили на ДВС"));
                    currCategory = "Автомобили на ДВС";
                }
                                
            }
            var carObj = new CarsListViewModel
            {
                AllCars = cars,
                currentCategory = currCategory
            };
            ViewBag.Title = "Страница с автомобилями";
            
            return View(carObj);
           
        }
    }
}
