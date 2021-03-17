using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class FuelTypeManager : IFuelTypeService
    {
        private readonly IFuelTypeDal _fuelTypeDal;

        public FuelTypeManager(IFuelTypeDal fuelTypeDal)
        {
            _fuelTypeDal = fuelTypeDal;
        }

        public IDataResult<List<FuelType>> GetAll()
        {
            return new SuccessDataResult<List<FuelType>>(_fuelTypeDal.GetAll(), Messages.Listed);
        }

        public IDataResult<FuelType> GetById(int fuelTypeId)
        {
            return new SuccessDataResult<FuelType>(_fuelTypeDal.Get(f=> f.Id==fuelTypeId), Messages.Listed);
        }

        public IResult Add(FuelType fuelType)
        {
            _fuelTypeDal.Add(fuelType);
            return new SuccessResult(Messages.Added);
        }

        public IResult Update(FuelType fuelType)
        {
            _fuelTypeDal.Update(_fuelTypeDal.Get(c => c.Id == fuelType.Id));
            return new SuccessResult(Messages.Updated);
        }

        public IResult Delete(FuelType fuelType)
        {
            _fuelTypeDal.Delete(_fuelTypeDal.Get(c => c.Id == fuelType.Id));
            return new SuccessResult(Messages.Deleted);
        }
    }
}
