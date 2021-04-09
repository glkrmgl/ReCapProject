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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            
            if (rental.ReturnDate!=null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult("Araç Kiralama İşleminiz Başarılı!");
            }
            
            return new ErrorResult("Araç Kiralama İşleminiz Başarısız!/ Bu araç Başka Bir Müşteri Tarafından Kiralanmış Durumda!");
        }

        public IResult Delete(Rental rental)
        {
            return new ErrorResult("Araç Kiralama İşleminiz silindi/ iptal edildi!");
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>("Kiralanmış Araç Listesi Getirildi!");
        }

        public IDataResult<List<Rental>> GetByRentalId(int rentalid)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(p => p.RentalId == rentalid),"... kiralanmış araç getirildi!");
        }

        public IResult Update(Rental rental)
        {
            return new SuccessResult("Kiralamak İstediğiniz Araç Güncellendi!");
        }
    }
}
