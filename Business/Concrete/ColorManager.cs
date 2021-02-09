using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
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
        public void Add(Color color)
        {
            Console.WriteLine("Color added successfully");
            _colorDal.Add(color);
        }

        public void Delete(Color color)
        {
            Console.WriteLine("Color deleted successfully");
            _colorDal.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetByColorId(int id)
        {
            return _colorDal.Get(p => p.Id == id);
        }

        public void Update(Color color)
        {
            Console.WriteLine("Color updated successfully");
            _colorDal.Update(color);
        }
    }
}
