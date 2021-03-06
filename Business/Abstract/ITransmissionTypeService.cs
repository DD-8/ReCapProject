using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ITransmissionTypeService
    {
        IDataResult<List<TransmissionType>> GetAll();
        IDataResult<TransmissionType> GetById(int transmissionTypeId);
        IResult Add(TransmissionType transmissionType);
        IResult Update(TransmissionType transmissionType);
        IResult Delete(TransmissionType transmissionType);
    }
}
