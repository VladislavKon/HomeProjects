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
    public class HomeController:Controller
    {
        private ICars _carRep;        

        public HomeController(ICars carRep)
        {            
            _carRep = carRep;
        }
        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                favCars = _carRep.GetFav
            };
            return View(homeCars);
        }
    }
}
