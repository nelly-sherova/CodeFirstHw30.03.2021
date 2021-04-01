using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace codeFirstHW.Models
{
    public class Category
    {
        public int Id { get; set; }


        [Display(Name = "Категория: ")]
        [Required(ErrorMessage = "Ошибка: Название категории не может быть меньше 3 и больше 50 символов")]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
