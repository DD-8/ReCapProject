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
    public class ModelManager : IModelService
    {
        private IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        public IDataResult<List<Model>> GetAll()
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Model> GetById(int modelId)
        {
            return new SuccessDataResult<Model>(_modelDal.Get(c => c.Id == modelId), Messages.Listed);
        }

        public IResult Add(Model model)
        {
            _modelDal.Add(model);
            return new SuccessResult(Messages.Added);
        }

        public IResult Update(Model model)
        {
            _modelDal.Update(_modelDal.Get(c => c.Id == model.Id));
            return new SuccessResult(Messages.Updated);
        }

        public IResult Delete(Model model)
        {
            _modelDal.Delete(_modelDal.Get(c => c.Id == model.Id));
            return new SuccessResult(Messages.Deleted);
        }
    }
}
