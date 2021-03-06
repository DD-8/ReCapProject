using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BodyTypeManager : IBodyTypeService
    {
        private IBodyTypeDal _bodyTypeDal;

        public BodyTypeManager(IBodyTypeDal bodyTypeDal)
        {
            _bodyTypeDal = bodyTypeDal;
        }

        public IDataResult<List<BodyType>> GetAll()
        {
            return new SuccessDataResult<List<BodyType>>(_bodyTypeDal.GetAll(), Messages.Listed);
        }

        public IDataResult<BodyType> GetById(int bodyTypeId)
        {
            return new SuccessDataResult<BodyType>(_bodyTypeDal.Get(c => c.Id == bodyTypeId), Messages.Listed);
        }

        public IResult Add(BodyType bodyType)
        {
            _bodyTypeDal.Add(bodyType);
            return new SuccessResult(Messages.Added);
        }

        public IResult Update(BodyType bodyType)
        {
            _bodyTypeDal.Update(bodyType);
            return new SuccessResult(Messages.Updated);
        }

        public IResult Delete(BodyType bodyType)
        {
            _bodyTypeDal.Delete(_bodyTypeDal.Get(c => c.Id == bodyType.Id));
            return new SuccessResult(Messages.Deleted);
        }
    }
}
