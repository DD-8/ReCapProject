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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Color color)
        {
            var colorToDelete = _colorDal.Get(c => c.Id == color.Id);
            if (colorToDelete == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _colorDal.Delete(colorToDelete);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            var colorToGetAll = _colorDal.GetAll();
            if (colorToGetAll == null)
            {
                return new ErrorDataResult<List<Color>>(Messages.NotFound);
            }
            return new SuccessDataResult<List<Color>>(colorToGetAll, Messages.Listed);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            var colorToGetById = _colorDal.Get(c => c.Id == colorId);
            if (colorToGetById == null)
            {
                return new ErrorDataResult<Color>(Messages.NotFound);
            }
            return new SuccessDataResult<Color>(colorToGetById, Messages.Listed);
        }

        public IResult Update(Color color)
        {
            var colorToUpdate = _colorDal.Get(c => c.Id == color.Id);
            if (colorToUpdate == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _colorDal.Update(colorToUpdate);
            return new SuccessResult(Messages.Updated);
        }
    }
}
