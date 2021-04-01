using codeFirstHW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace codeFirstHW.Db
{
    public class SampleData
    {
        public static void InitializeCategory(DataContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { Name = "Все" },
                    new Category { Name = "Овощи" },
                    new Category { Name = "Фрукты" },
                    new Category { Name = "Мясные продукты" },
                    new Category { Name = "Молочные продукты" },
                    new Category { Name = "Мучные издения" }
                    );
                context.SaveChanges();
            }
        }
        public static void InitializeProduct(DataContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { Name = "Хлеб Маколли", CategoryId = 6, Price = 5 },
                    new Product { Name = "Картошка русская", CategoryId = 2, Price = 8 },
                    new Product { Name = "Кефир Саодат", CategoryId = 5, Price = 6 },
                    new Product { Name = "Самса", CategoryId = 5, Price = 4},
                    new Product { Name = "Клубника", CategoryId = 3, Price = 13},
                    new Product { Name = "Сосиски Pokiza", CategoryId = 4, Price = 18}
                    );
                context.SaveChanges();
            }
        }
    }
}
