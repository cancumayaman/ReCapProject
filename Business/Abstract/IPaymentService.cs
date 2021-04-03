using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IPaymentService
    {
        IDataResult<List<Payment>> GetAll();
        IResult Add(Payment payment);
        IResult Delete(Payment payment);
        IResult Update(Payment payment);
        IDataResult<Payment> GetByCustomerId(int id);
    }
}
