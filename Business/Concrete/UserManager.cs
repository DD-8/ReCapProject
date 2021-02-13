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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(User user)
        {
            var userToDelete = _userDal.Get(c => c.Id == user.Id);
            if (userToDelete == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _userDal.Delete(userToDelete);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            var userToGetAll = _userDal.GetAll();
            if (userToGetAll == null)
            {
                return new ErrorDataResult<List<User>>(Messages.NotFound);
            }
            return new SuccessDataResult<List<User>>(userToGetAll, Messages.Listed);
        }

        public IDataResult<User> GetById(int userId)
        {
            var userToGetById = _userDal.Get(c => c.Id == userId);
            if (userToGetById == null)
            {
                return new ErrorDataResult<User>(Messages.NotFound);
            }
            return new SuccessDataResult<User>(userToGetById, Messages.Listed);
        }

        public IResult Update(User user)
        {
            var userToUpdate = _userDal.Get(c => c.Id == user.Id);
            if (userToUpdate == null)
            {
                return new ErrorResult(Messages.NotFound);
            }
            _userDal.Update(userToUpdate);
            return new SuccessResult(Messages.Updated);
        }
    }
}
