using MyShop.data.interfaces;
using MyShop.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.data.repository
{
    public class OrdersRepository : IOrders
    {
        private readonly AppDBContent _appDBContent;
        private readonly ShopCart _shopCart;

        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            _appDBContent = appDBContent;
            _shopCart = shopCart;
        }
        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            _appDBContent.Order.Add(order);
            _appDBContent.SaveChanges();

            var items = _shopCart.listShopItems;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarID = el.car.Id,
                    orderID = order.id,
                    price = el.car.Price
                };
                _appDBContent.OrderDetails.Add(orderDetail);
            }
            _appDBContent.SaveChanges();
        }
    }
}
