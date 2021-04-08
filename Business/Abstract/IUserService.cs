using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(UserForRegisterDto user);
        IDataResult<List<User>> GetAllUsers();
        IDataResult<User> GetUserById(int id);
        IDataResult<UserInfo> GetUserByMail(string mail);
       
        List<OperationClaim> GetClaims(User user);

        User GetByMail(string email);

    }
}
