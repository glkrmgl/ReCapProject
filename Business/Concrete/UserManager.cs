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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user.FirstName.Length<2)
            {
                return new ErrorResult(Messages.UserNameInvalid);

            }

            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }
    

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("Kullanıcı Silindi!");
        }

        public IDataResult<List<User>> GetAll(User user)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), "Kullanıcılar Listesi Getirildi!");
        }

        public IDataResult<List<User>> GetByUserId(int userid)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(p => p.UserId == userid),"... kullanıcı getirildi!");
            
        }

        public IResult Update(User user)
        {
            return new SuccessResult("Kullanıcı Güncellendi");
        }
    }
}
