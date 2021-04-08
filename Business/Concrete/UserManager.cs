using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entity.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
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
      [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
           

            _userDal.Add(user);
            return new SuccessResult(user.FirstName + " " + user.LastName + " added successfully");
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(user.FirstName+" "+user.LastName+" deleted successfully");
        }

        public IDataResult<List<User>> GetAllUsers()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IDataResult<User> GetUserById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.Id == id));
        }

        

        public IResult Update(UserForRegisterDto user)
        {
            var id = _userDal.Get(p => p.Email == user.Email).Id;
            byte[] passwordHash, passwordSalt;
            
            
            HashingHelper.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);
            var userInfo = new User
            {
                Id = id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userDal.Update(userInfo);
            return new SuccessResult(user.FirstName + " " + user.LastName + " updated successfully");
        }

       public IDataResult<UserInfo> GetUserByMail(string mail)
        {
            return new SuccessDataResult<UserInfo>(_userDal.GetUserInfo(mail));
        }

       
    }
}
