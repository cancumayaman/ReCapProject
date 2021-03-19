﻿using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<List<Rental>> GetAllRentals();
        IDataResult<List<RentalDetailDto>> GetRentalDetais();
        IDataResult<Rental> GetRentalById(int id);
    }
}
