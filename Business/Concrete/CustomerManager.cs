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
            _customerDal.Add(customer);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Customer customer)
        {
            var customerToDelete = _customerDal.Get(c => c.Id == customer.Id);
            if (customerToDelete == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _customerDal.Delete(customerToDelete);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var customerToGetAll = _customerDal.GetAll();
            if (customerToGetAll == null)
            {
                return new ErrorDataResult<List<Customer>>(Messages.NotFound);
            }
            return new SuccessDataResult<List<Customer>>(customerToGetAll, Messages.Listed);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            var customerToGetById = _customerDal.Get(c => c.Id == customerId);
            if (customerToGetById == null)
            {
                return new ErrorDataResult<Customer>(Messages.NotFound);
            }
            return new SuccessDataResult<Customer>(customerToGetById, Messages.Listed);
        }

        public IResult Update(Customer customer)
        {
            var customerToUpdate = _customerDal.Get(c => c.Id == customer.Id);
            if (customerToUpdate == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _customerDal.Update(customerToUpdate);
            return new SuccessResult(Messages.Updated);
        }
    }
}
