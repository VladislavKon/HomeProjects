using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.data.models
{
    public class Car
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string shortDesc { get; set; }
        public string Desc { get; set; }
        public string img { get; set; }
        public uint Price { get; set; }
        public bool IsAveilable { get; set; }
        public bool IsFavour { get; set; }
        public Category CarCategory { get; set; }
    }
}
