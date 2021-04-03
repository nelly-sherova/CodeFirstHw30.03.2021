using codeFirstHW.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace codeFirstHW.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        [MinLength(3)]
        [MaxLength(50)]
        [Required(ErrorMessage = "Название продукта не может быть мешь 3 и больше 50 символов")]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Формат цены введен непрвильно!")]
        public decimal Price { get; set; }
        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Ошибка в категории!")]
        public virtual Category Category { get; set; }
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
    }
}
