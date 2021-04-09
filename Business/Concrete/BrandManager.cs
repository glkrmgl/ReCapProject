using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length<2)
            {
                return new ErrorResult("Brand Name Invalid!");

            }

            _brandDal.Add(brand);
            return new SuccessResult("Brand Name Valid!");
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult("Marka Silindi!");
        }

       

        public IDataResult<List<Brand>> GetAll()
        {
            if(DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);

            }

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<Brand>> GetByBrandId(int brandid)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(p => p.BrandId == brandid));
        }

        public IResult Update(Brand brand)
        {
            return new SuccessResult("Marka Güncellendi");
        }
    }
}
