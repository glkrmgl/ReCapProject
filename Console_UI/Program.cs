using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace Console_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId);
                Console.WriteLine(car.Description);
                

            }

            Console.WriteLine();
            Console.WriteLine("---------------------");
            Console.WriteLine();

            ColorManager colorManager = new ColorManager(new InMemoryColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId);
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine();
            Console.WriteLine("---------------------");
            Console.WriteLine();

            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId);
                Console.WriteLine(brand.BrandName);
            }


        }

    }
}
