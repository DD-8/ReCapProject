using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    [ValidationAspect(typeof(BrandValidator))]
    public class BrandManager : IBrandService
    {
        readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.Added);
        }
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(_brandDal.Get(c => c.Id == brand.Id));
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(c => c.Id == brandId), Messages.Listed);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(_brandDal.Get(c => c.Id == brand.Id));
            return new SuccessResult(Messages.Updated);
        }
    }
}
