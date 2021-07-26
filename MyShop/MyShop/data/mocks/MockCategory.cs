using MyShop.data.interfaces;
using MyShop.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.data.mocks
{
    public class MockCategory : ICategory
    {
        public IEnumerable<Category> Categories 
        { 
            get
            {
                return new List<Category>
                {
                    new Category { CategoryName = "Электромобили", Desc = "Автомобиль на электродвигателе" },
                    new Category { CategoryName = "Автомобили на ДВС", Desc="Автомобиль на двигателе внутреннего сгорания"}
                };
            } 
        }
    }
}
