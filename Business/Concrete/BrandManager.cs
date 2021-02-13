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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public IResult Add(Brand brand)
        {
            if (brand.Name.Length < 2)
            {
                return new ErrorResult(Messages.InvalidBrandName);
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.Added);
        }
        public IResult Delete(Brand brand)
        {
            var brandToDelete = _brandDal.Get(c => c.Id == brand.Id);
            if (brandToDelete == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _brandDal.Delete(brandToDelete);
            return new Result(true, Messages.Deleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var brandToGetAll = _brandDal.GetAll();
            if (brandToGetAll == null)
            {
                return new ErrorDataResult<List<Brand>>(Messages.NotFound);
            }
            return new SuccessDataResult<List<Brand>>(brandToGetAll, Messages.Listed);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            var brandToGetById = _brandDal.Get(c => c.Id == brandId);
            if (brandToGetById == null)
            {
                return new ErrorDataResult<Brand>(Messages.NotFound);
            }
            return new SuccessDataResult<Brand>(brandToGetById, Messages.Listed);
        }

        public IResult Update(Brand brand)
        {
            var brandToUpdate = _brandDal.Get(c => c.Id == brand.Id);
            if (brandToUpdate == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _brandDal.Update(brandToUpdate);
            return new Result(true, Messages.Updated);
        }
    }
}
