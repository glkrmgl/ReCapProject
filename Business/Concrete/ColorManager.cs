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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {

            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErrorResult("Color Name Invalid!");

            }

            _colorDal.Add(color);
            return new SuccessResult("Color Name Valid!");
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult("Renk Silindi!");
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);

            }

            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<Color>> GetByColorId(int colorid)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(p => p.ColorId == colorid));
        }

        public IResult Update(Color color)
        {
            return new SuccessResult("Renk Güncellendi");
        }
    }
}
