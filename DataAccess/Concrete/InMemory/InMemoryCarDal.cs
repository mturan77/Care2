using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car>
            { 
            new Car{CarId=1,BrandId=1,CarName="Araç1",ColorId=1,DailyPrice=100,Description="",ModelId=1,ModelYear=1989 },
            new Car{CarId=2,BrandId=2,CarName="Araç2",ColorId=2,DailyPrice=150,Description="",ModelYear=2005,ModelId=1},
            new Car{CarId=3,BrandId=2,CarName="Araç3",ColorId=3,DailyPrice=200,ModelId=2,ModelYear=2015,Description=""}
            };
        }
        public void Add(List<Car> car)
        {
            _car.AddRange(car);
        }

        public void Delete(Car car)
        {
            Car CarToDelete=null;
            CarToDelete = _car.SingleOrDefault(p => p.CarId == car.CarId);
            _car.Remove(CarToDelete);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetByBrand(int BrandId)
        {
            return _car.Where(p => p.BrandId == BrandId).ToList();
        }

        public void Update(Car car,Car CarToUpdate)
        {
            
            Car CarTemp = _car.SingleOrDefault(p => p.CarId == car.CarId);
            CarToUpdate= _car.SingleOrDefault(p => p.CarId == CarToUpdate.CarId);
            CarToUpdate.CarId = CarTemp.CarId;
            CarToUpdate.CarName = CarTemp.CarName;
            CarToUpdate.BrandId = CarTemp.BrandId;
            CarToUpdate.ColorId = CarTemp.ColorId;
            CarToUpdate.DailyPrice = CarTemp.DailyPrice;
            CarToUpdate.ModelId = CarTemp.ModelId;
            CarToUpdate.ModelYear = CarTemp.ModelYear;
            CarToUpdate.Description = CarTemp.Description;
                       
        }
    }
}
