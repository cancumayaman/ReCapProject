using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<List<User>> GetAllUsers();
        IDataResult<User> GetUserById(int id);
        List<OperationClaim> GetClaims(User user);

        User GetByMail(string email);

    }
}
