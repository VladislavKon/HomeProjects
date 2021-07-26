using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.data.models
{
    public class ShopCartItem
    {
        public int id { get; set; }
        public Car car { get; set; }
        public uint price { get; set; }
        public string ShopCartId { get; set; }
    }
}
