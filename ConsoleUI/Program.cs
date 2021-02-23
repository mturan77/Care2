using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car4 = new Car();
            car4.CarId = 4;
            car4.BrandId = 2;
            car4.CarName = "Araç4";
            car4.ColorId = 2;
            car4.DailyPrice = 150;
            car4.Description = "";
            car4.ModelId = 2;
            car4.ModelYear = 2020;

            Car car5 = new Car();
            car5.CarId = 5;
            car5.BrandId = 1;
            car5.CarName = "Araç5";
            car5.ColorId = 5;
            car5.DailyPrice = 250;
            car5.Description = "";
            car5.ModelId = 4;
            car5.ModelYear = 2019;

            Car car6 = new Car();
            car6.CarId = 6;
            car6.BrandId = 2;
            car6.CarName = "Araç6";
            car6.ColorId = 5;
            car6.DailyPrice = 250;
            car6.Description = "";
            car6.ModelId = 4;
            car6.ModelYear = 2019;

            CarManager carManager = new CarManager(new InMemoryCarDal());
            
            carManager.Add(car4);
            carManager.Add(car5);
            carManager.Add(car6);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);
                
            }
            Console.WriteLine("------------");

            
            foreach (var car in carManager.GetByBrand(1))
            {
                Console.WriteLine(car.CarName);

            }
            Console.WriteLine("------------");


            carManager.Update(car5,car6);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);

            }
            Console.WriteLine("------------");

            carManager.Delete(car4);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);

            }
            Console.WriteLine("------------");
        }
    }
}
