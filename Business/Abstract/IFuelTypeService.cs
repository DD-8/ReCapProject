using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IFuelTypeService
    {
        IDataResult<List<FuelType>> GetAll();
        IDataResult<FuelType> GetById(int fuelTypeId);
        IResult Add(FuelType fuelType);
        IResult Update(FuelType fuelType);
        IResult Delete(FuelType fuelType);
    }
}
