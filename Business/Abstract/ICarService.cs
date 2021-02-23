using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        void Add(List<Car> carList);
        void Update(Car car,Car carToUpdate);
        void Delete(Car car);

        List<Car> GetByBrand(int BrandId);
    }
}
