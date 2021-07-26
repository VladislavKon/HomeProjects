using Microsoft.AspNetCore.Mvc;
using MyShop.data.interfaces;
using MyShop.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Controllers
{
    public class OrderController:Controller
    {
        private readonly IOrders orders;
        private readonly ShopCart shopCart;

        public OrderController(IOrders orders, ShopCart shopCart)
        {
            this.orders = orders;
            this.shopCart = shopCart;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.listShopItems = shopCart.getShopItems();
            if (shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("", "У вас должны быить товары");
            }
            if (ModelState.IsValid)
            {
                orders.createOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
           
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
