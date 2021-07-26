using MyShop.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.data.interfaces
{
    public interface ICars
    {
        IEnumerable<Car> GetCars { get; }
        IEnumerable<Car> GetFav { get; }
        Car GetObjectCar(int carId);
    }
}
