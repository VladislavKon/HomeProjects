using Microsoft.EntityFrameworkCore;
using MyShop.data.interfaces;
using MyShop.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.data.repository
{
    public class CarRepository : ICars
    {
        private readonly AppDBContent appDBContent;
        public CarRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Car> GetCars => appDBContent.Car.Include(c=>c.CarCategory);

        public IEnumerable<Car> GetFav => appDBContent.Car.Where(p => p.IsFavour).Include(c => c.CarCategory);

        public Car GetObjectCar(int carId) => appDBContent.Car.FirstOrDefault(p => p.Id == carId);
       
    }
}
