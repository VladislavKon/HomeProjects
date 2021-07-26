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
    public class ShopCartController:Controller
    {
        private ICars _carRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(ICars carRep, ShopCart shopCart)
        {
            _shopCart = shopCart;
            _carRep = carRep;
        }
        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItems = items;

            var onj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };
            return View(onj);            
        }
        public RedirectToActionResult addToCart(int id)
        {
            var item = _carRep.GetCars.FirstOrDefault(i=> i.Id==id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
