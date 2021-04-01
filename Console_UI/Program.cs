using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace Console_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Succcess == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarId + "/" + car.BrandId);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }


            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.CarId);
            //    Console.WriteLine(car.Description);
                

            //}

            //Console.WriteLine("-------- Getdetails deneme ---------------");
            //Console.WriteLine();
            //foreach (var car in carManager.GetCarDetails())
            //{
            //    Console.WriteLine(car.BrandId+"--> "+car.DailyPrice+" "+car.Description);
            //}

            //Console.WriteLine();
            //Console.WriteLine("---------------------");
            //Console.WriteLine();

            //foreach (var car in carManager.GetCarsByBrandId(2))
            //{
            //    Console.WriteLine(car.CarId+ " : "+ car.Description);
              
            //}

            //Console.WriteLine();
            //Console.WriteLine("---------------------");
            //Console.WriteLine();

            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorId);
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine();
            Console.WriteLine("---------------------");
            Console.WriteLine();

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId);
                Console.WriteLine(brand.BrandName);
            }
           

        }

    }
}
