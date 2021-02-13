using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.DailyPrice<=0)
            {
                return new ErrorResult(Messages.InvalidDailyPrice);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);

        }

        public IResult Delete(Car car)
        {
            var carToDelete = _carDal.Get(c=>c.Id==car.Id);
            if (carToDelete == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _carDal.Delete(carToDelete);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            var carToGetAll = _carDal.GetAll();
            if (carToGetAll == null)
            {
                return new ErrorDataResult<List<Car>>(Messages.NotFound);
            }
            return new SuccessDataResult<List<Car>>(carToGetAll, Messages.Listed);
        }

        public IDataResult<Car> GetById(int carId)
        {
            var carToGetById = _carDal.Get(c => c.Id == carId);
            if (carToGetById == null)
            {
                return new ErrorDataResult<Car>(Messages.NotFound);
            }
            return new SuccessDataResult<Car>(carToGetById, Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.Listed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            var carToGetCarsByBrandId = _carDal.GetAll(c => c.BrandId == brandId);
            if (carToGetCarsByBrandId == null)
            {
                return new ErrorDataResult<List<Car>>(Messages.NotFound);
            }
            return new SuccessDataResult<List<Car>>(carToGetCarsByBrandId, Messages.Listed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            var carToGetCarsByColorId = _carDal.GetAll(c => c.ColorId == colorId);
            if (carToGetCarsByColorId == null)
            {
                return new ErrorDataResult<List<Car>>(Messages.NotFound);
            }
            return new SuccessDataResult<List<Car>>(carToGetCarsByColorId, Messages.Listed);
        }

        public IResult Update(Car car)
        {
            var carToUpdate = _carDal.Get(c => c.Id == car.Id);
            if (carToUpdate == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _carDal.Update(carToUpdate);
            return new SuccessResult(Messages.Updated);
        }
    }
}
