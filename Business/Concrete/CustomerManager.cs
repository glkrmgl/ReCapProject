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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            if (customer.CompanyName.Length < 2)
            {
                return new ErrorResult(Messages.CompanyNameInvalid);

            }

            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }


        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult("Müşteri Silindi!");
        }

        public IDataResult<List<Customer>> GetAll(Customer customer)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), "Kullanıcılar Listesi Getirildi!");
        }

        public IDataResult<List<Customer>> GetByUserId(int userid)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(p => p.UserId == userid), "... müşteri getirildi!");

        }

        public IResult Update(Customer customer)
        {
            return new SuccessResult("Müşteri Güncellendi");
        }
    }

}