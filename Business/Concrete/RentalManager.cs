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
            if(rental.ReturnDate == null)
            {
                return new ErrorResult(Messages.NullDate);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Rental rental)
        {
            var rentalToDelete = _rentalDal.Get(c => c.Id == rental.Id);
            if (rentalToDelete == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _rentalDal.Delete(rentalToDelete);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var rentalToGetAll = _rentalDal.GetAll();
            if (rentalToGetAll == null)
            {
                return new ErrorDataResult<List<Rental>>(Messages.NotFound);
            }
            return new SuccessDataResult<List<Rental>>(rentalToGetAll, Messages.Listed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            var rentalToGetById = _rentalDal.Get(c => c.Id == rentalId);
            if (rentalToGetById == null)
            {
                return new ErrorDataResult<Rental>(Messages.NotFound);
            }
            return new SuccessDataResult<Rental>(rentalToGetById, Messages.Listed);
        }

        public IResult Update(Rental rental)
        {
            var rentalToUpdate = _rentalDal.Get(c => c.Id == rental.Id);
            if (rentalToUpdate == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _rentalDal.Update(rentalToUpdate);
            return new SuccessResult(Messages.Updated);
        }
    }
}
