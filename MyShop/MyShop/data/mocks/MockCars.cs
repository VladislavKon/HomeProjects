using MyShop.data.interfaces;
using MyShop.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.data.mocks
{
    public class MockCars : ICars
    {
        MockCategory mockCategory = new MockCategory();
        public IEnumerable<Car> GetCars { get => new List<Car>
        {
            new Car { Id = 1, 
                CarName = "Mercedes-Benz CLA", 
                shortDesc= "Купе Mercedes-Benz CLA", 
                Desc = "Mercedes-Benz CLA купе — востребованная новинка 2020 и 2021 года.", 
                img = "/img/1547293078_mercedes-benz-cla-2020-1600-03.jpg", 
                Price = 3209400, 
                IsAveilable=true, 
                IsFavour = true, 
                CarCategory = mockCategory.Categories.ElementAt(1)},
            new Car { Id = 2, 
                CarName = "Porshe 911 Carrera", 
                shortDesc= "Дизайн вне времени", 
                Desc = "Неподвластный времени дизайн в современной интерпретации. Уникальный силуэт 911 характеризуется легендарной линией крыши Flyline. Она практически не изменилась с 1963 года и является главным генетическим признаком всех моделей Porsche",
                img = "/img/5ba01408ec05c4bb2c00002b.jpg", 
                Price = 8130000, 
                IsAveilable=true, 
                IsFavour = true, 
                CarCategory = mockCategory.Categories.ElementAt(1)},
            new Car { 
                Id = 3, 
                CarName = "Audi e-tron", 
                shortDesc= "Будущее начинается сейчас с Audi e-tron", 
                Desc = "С Audi e-tron вы поможете миру сделать шаг в более чистое будущее. Наш первый полностью электрический SUV станет вашим надежным и безопасным спутником в наступающей новой эре.", 
                img = "/img/porsche-911-carrera-992-2019.jpg" , 
                Price = 6280000, 
                IsAveilable=true, 
                IsFavour = false, 
                CarCategory = mockCategory.Categories.ElementAt(0)}
            };
        }

        public IEnumerable<Car> GetFav { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Car GetObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
