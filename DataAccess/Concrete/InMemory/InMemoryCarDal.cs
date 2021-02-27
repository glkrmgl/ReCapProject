using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> 
            {
               new Car{CarId=1,BrandId=01,ColorId=1, DailyPrice=150, ModelYear=2009, Description="dizel"},
               new Car{CarId=2,BrandId=02,ColorId=1, DailyPrice=125, ModelYear=2000, Description="sedan"},
               new Car{CarId=3,BrandId=02,ColorId=1, DailyPrice=200, ModelYear=2008, Description="manuel"},
               new Car{CarId=4,BrandId=03,ColorId=3, DailyPrice=400, ModelYear=2015, Description="otomatik"},
               new Car{CarId=5,BrandId=03,ColorId=5, DailyPrice=350, ModelYear=2014, Description="SUV"}
            };

        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int CarId)
        {
            return _cars.Where(c => c.CarId == CarId).ToList();
        }

        public void Update(Car car)
        {
            // GÖNDERDİĞİM ÜRÜN ID SİNE SAHİP LİSTEDEKİ ÜRÜNÜ BUL DEMEK !
            Car carToUpdate = _cars.SingleOrDefault(c=>c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
