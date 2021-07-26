using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MyShop.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.data
{
    public class DbObjects
    {
        public static void initial(AppDBContent content)
        {            
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));
            if (!content.Car.Any())
                content.AddRange(
            new Car
            {                
                CarName = "Mercedes-Benz CLA",
                shortDesc = "Купе Mercedes-Benz CLA",
                Desc = "Mercedes-Benz CLA купе — востребованная новинка 2020 и 2021 года.",
                img = "/img/1547293078_mercedes-benz-cla-2020-1600-03.jpg",
                Price = 3209400,
                IsAveilable = true,
                IsFavour = true,
                CarCategory = Categories["Автомобили на ДВС"]
            },
            new Car
            {                
                CarName = "Porshe 911 Carrera",
                shortDesc = "Дизайн вне времени",
                Desc = "Неподвластный времени дизайн в современной интерпретации. Уникальный силуэт 911 характеризуется легендарной линией крыши Flyline. Она практически не изменилась с 1963 года и является главным генетическим признаком всех моделей Porsche",
                img = "/img/5ba01408ec05c4bb2c00002b.jpg",
                Price = 8130000,
                IsAveilable = true,
                IsFavour = true,
                CarCategory = Categories["Автомобили на ДВС"]
            },
            new Car
            {                
                CarName = "Audi e-tron",
                shortDesc = "Будущее начинается сейчас с Audi e-tron",
                Desc = "С Audi e-tron вы поможете миру сделать шаг в более чистое будущее. Наш первый полностью электрический SUV станет вашим надежным и безопасным спутником в наступающей новой эре.",
                img = "/img/porsche-911-carrera-992-2019.jpg",
                Price = 6280000,
                IsAveilable = true,
                IsFavour = false,
                CarCategory = Categories["Электромобили"]
            });
            content.SaveChanges();
        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null) {
                    var list = new Category[]
                    {
                    new Category { CategoryName = "Электромобили", Desc = "Автомобиль на электродвигателе" },
                    new Category { CategoryName = "Автомобили на ДВС", Desc="Автомобиль на двигателе внутреннего сгорания"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.CategoryName, el);
                }
                return category;
            }
        }        
    }
}
