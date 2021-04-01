using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brands;
        public InMemoryBrandDal()
        {
            _brands = new List<Brand>
            {
                new Brand{ BrandId=1, BrandName="Opel"},
                new Brand{ BrandId=2, BrandName="Mercedes"},
                new Brand { BrandId = 3, BrandName = "Bmw" },
                new Brand { BrandId = 4, BrandName = "toyota" },
                new Brand { BrandId = 5, BrandName = "Fiat" },
                new Brand { BrandId = 6, BrandName = "Ford" }
            };
        }

        public void Add(Brand brand)
        {
            _brands.Add(brand);
        }

        public void Delete(Brand brand)
        {
            Brand brandToDelete = _brands.SingleOrDefault(b => b.BrandId == brand.BrandId);
            _brands.Remove(brand);
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll()
        {
            return _brands;
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetById(int BrandId)
        {
            return _brands.Where(b => b.BrandId == BrandId).ToList();

        }

        public void Update(Brand brand)
        {
            
        }
    }
}
