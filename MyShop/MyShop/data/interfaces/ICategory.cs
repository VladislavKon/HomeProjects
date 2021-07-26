using MyShop.data.models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyShop.data.interfaces
{
    public interface ICategory
    {
        IEnumerable<Category> Categories { get; }
    }
}
