using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.data.models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name ="Имя")]
        [StringLength(10)]
        [Required(ErrorMessage ="Длина Имени не менее 3 символов")]
        public string name { get; set; }
        [Display(Name = "Фамилия")]
        [StringLength(10)]
        [Required(ErrorMessage = "Длина Фамилии не менее 4 символов")]
        public string surname { get; set; }
        [Display(Name = "Адресс")]
        [StringLength(20)]
        [Required(ErrorMessage = "Длина адреса не менее 5 символов")]
        public string adress { get; set; }
        [Display(Name = "Телефон")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        [Required(ErrorMessage = "Длина номера не менее 10 символов")]
        public string phone { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(30)]
        [Required(ErrorMessage = "длина email не менее 8 символов")]
        public string email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}
