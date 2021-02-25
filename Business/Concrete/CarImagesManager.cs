using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        ICarImagesDal _carImagesDal;
        ICarService _carService;
        public CarImagesManager(ICarImagesDal carImagesDal, ICarService carService)
        {
            _carImagesDal = carImagesDal;
            _carService = carService;
        }
        public IResult Add(CarImages carImages)
        {

            IResult result = BusinessRules.Run(CheckCarImageCountExceed(carImages.CarId));
            if (result != null)
            {
                return result;
            }

            string uniquePath = GuidOperation();
            carImages.CarId = carImages.CarId;
            carImages.ImagePath = uniquePath;
            carImages.Date = DateTime.Now;
            _carImagesDal.Add(carImages);

            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(CarImages carImages)
        {
            _carImagesDal.Delete(carImages);
            return new SuccessResult(Messages.ImageUpdated);
        }

        public IDataResult<List<CarImages>> GetAllCarImages()
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll());
        }

        public IDataResult<CarImages> GetImagesByCarId(int id)
        {
            var result = _carImagesDal.Get(p => p.CarId == id);
            if (result == null)
            {
                return new SuccessDataResult<CarImages>(new CarImages { CarId = id, ImagePath = "Default.png", Date = DateTime.Now });
            }
            return new SuccessDataResult<CarImages>(result);
        }

        public IResult Update(CarImages carImages)
        {
            string uniquePath = GuidOperation();
            carImages.CarId = carImages.CarId;
            carImages.ImagePath = uniquePath;
            carImages.Date = DateTime.Now;
           
            _carImagesDal.Update(carImages);
            return new SuccessResult();
        }
        private IResult CheckCarImageCountExceed(int carId)
        {
            if (_carImagesDal.GetAll(p => p.CarId == carId).Count>5)
            {
                return new ErrorResult(Messages.CarImagesCountExceed);
            }
            return new SuccessResult();
        }
        private string GuidOperation()
        {
            string unique = Guid.NewGuid().ToString();
            return unique + ".jpg";
        }
       
    }
}
