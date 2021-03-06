﻿using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Abstract.EntitiesDals;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.CarName.Length>2&&car.DailyPrice>0)
            {
                _carDal.Add(car);
            }
            else
            {
                throw new Exception();
            }
            
        }

        public void Add(List<Car> carList)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
        
        public List<Car> GetByBrand(int brandId)
        {
            return _carDal.GetAll(p=>p.BrandId==brandId);
        }

        public List<Car> GetByColor(int colorId)
        {
            return _carDal.GetAll(p => p.ColorId == colorId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
                //.Update(car,carToUpdate);
        }

        Car ICarService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
