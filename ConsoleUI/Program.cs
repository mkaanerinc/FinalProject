using BusinessLogic.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        // SOLID
        // Open Closed Principle ==> Sonradan kod eklendiğinde varolan kodlarda değişiklik yapılmamasıdır.
        // Generic Repository Pattern

        static void Main(string[] args)
        {
            //ProductTest();

            //CategoryTest();
        }

        private static void CategoryTest()
        {
        
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var item in categoryManager.GetAll().Data)
            {
                Console.WriteLine(item.CategoryName);
            }

            //Console.WriteLine(categoryManager.GetById(2).CategoryName);

        }

        private static void ProductTest()
        {
            //ProductManager productManager = new ProductManager(new InMemoryProductDal());
            ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));


            foreach (var item in productManager.GetAll().Data)
            {
                Console.WriteLine(item.ProductName);
            }

            foreach (var item in productManager.GetAllByCategoryId(2).Data)
            {
                Console.WriteLine(item.ProductName);
            }

            foreach (var item in productManager.GetAllByUnitPrice(50, 100).Data)
            {
                Console.WriteLine(item.ProductName);
            }

            var result = productManager.GetProductDetails();

            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.ProductName + " => " + item.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
    }
}
