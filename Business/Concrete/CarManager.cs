﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int id)
        {
            return _carDal.GetCarsByBrandId(c => c.BrandId == id);
        }

        public List<Car> GetAllByColorId(int id)
        {
            return _carDal.GetCarsByColorId(c => c.ColorId == id);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice <= max && c.DailyPrice >= min);        }

        public Car GetById(int id)
        {
            return _carDal.Get(c => c.Id == id);
        }
    }
}