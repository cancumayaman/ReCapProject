using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            Thread.Sleep(5000);
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int id)
        {
            var result = _carService.GetByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbybrandid")]
        public IActionResult GetByBrandId(int id)
        {
            var result = _carService.GetCarsByBrandId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycolorid")]
        public IActionResult GetByColorId(int id)
        {
            var result = _carService.GetCarsByColorId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails(int id)
        {
            if (id == 0)
            {
                var result1 = _carService.GetCarDetails();
                if (result1.Success)
                {
                    return Ok(result1);
                }
                return BadRequest(result1);

            }
            else
            {
                var result = _carService.GetCarDetails(p => p.Id == id);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
          
        }
        [HttpGet("getcardetailsbybrand")]
        public IActionResult GetCarDetailsByBrand(int brandId)
        {
            var result = _carService.GetCarDetailsByBrand(p=>p.BrandId==brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcardetailsbycolor")]
        public IActionResult GetCarDetailsByColor(int colorId)
        {
            var result = _carService.GetCarDetailsByColor(p => p.ColorId == colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
