using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class TransmissionTypeManager : ITransmissionTypeService
    {
        private readonly ITransmissionTypeDal _transmissionTypeDal;

        public TransmissionTypeManager(ITransmissionTypeDal transmissionTypeDal)
        {
            _transmissionTypeDal = transmissionTypeDal;
        }

        public IDataResult<List<TransmissionType>> GetAll()
        {
            return new SuccessDataResult<List<TransmissionType>>(_transmissionTypeDal.GetAll(), Messages.Listed);
        }

        public IDataResult<TransmissionType> GetById(int transmissionTypeId)
        {
            return new SuccessDataResult<TransmissionType>(_transmissionTypeDal.Get(c => c.Id == transmissionTypeId), 
                Messages.Listed);
        }

        public IResult Add(TransmissionType transmissionType)
        {
            _transmissionTypeDal.Add(transmissionType);
            return new SuccessResult(Messages.Added);
        }

        public IResult Update(TransmissionType transmissionType)
        {
            _transmissionTypeDal.Update(_transmissionTypeDal.Get(c => c.Id == transmissionType.Id));
            return new SuccessResult(Messages.Updated);
        }

        public IResult Delete(TransmissionType transmissionType)
        {
            _transmissionTypeDal.Delete(_transmissionTypeDal.Get(c => c.Id == transmissionType.Id));
            return new SuccessResult(Messages.Deleted);
        }
    }
}
