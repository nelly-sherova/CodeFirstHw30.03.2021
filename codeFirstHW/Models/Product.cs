using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace codeFirstHW.Models
{
    public class Product
    {

        public int Id { get; set; }
       
        [Display(Name = "Название продукта не может быть мешь 3 и больше 50 символов")]
        [MinLength(3)]
        [MaxLength(50)]
        [Required(ErrorMessage = "Ошибка в названии продукта")]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Формат цены введен непрвильно!")]
        public decimal Price { get; set; }
        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Ошибка в категории!")]
        public virtual Category Category { get; set; }
        public List<SelectListItem> Categories { get; internal set; }
    }
}
