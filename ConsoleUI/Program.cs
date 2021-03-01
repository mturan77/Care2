using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("-------Care-------");
            Console.WriteLine("Ne yapmak istersiniz?");
            Console.WriteLine(" 1- Araçları Listele \n 2- Yeni Araç Ekle \n 3- Araç GÜncelle \n 4- Araç Sil");
            Console.WriteLine("-------Care-------");
            Console.Write("Seçim:");
            var choose = Convert.ToInt32(Console.ReadLine());

            
            switch (choose)
            {
                case 1:
                    Console.WriteLine("-------Care-------");
                    Console.WriteLine("Ne yapmak istersiniz?");
                    Console.WriteLine(" 1- Tüm Araçları Listele \n 2- Araçları Markalarına Göre Listele \n 3- Araçları Markalarına Göre Listele");
                    Console.WriteLine("-------Care-------");
                    Console.Write("Seçim:");
                    var detail = Convert.ToInt32(Console.ReadLine());

                    switch (detail)
                    {
                        case 1:
                            Console.WriteLine("-------Care-------");
                            Console.Write("Marka Idleri");
                            GetCars(carManager);
                            
                            break;
                        case 2:
                            Console.WriteLine("-------Care-------");
                            GetAllCarbyBrandId(carManager);
                            Console.WriteLine("-------Care-------");
                            Console.Write("Kaç Numaralı Id:");
                            var brandIdd = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("-------Care-------");
                            GetCarsbyBrandId(carManager, brandIdd);
                            Console.WriteLine("-------Care-------");
                            break;
                        case 3:
                            Console.WriteLine("-------Care-------");
                            GetAllCarbyColorId(carManager);
                            Console.WriteLine("-------Care-------");
                            Console.Write("Kaç Numaralı Id:");
                            var colorIdd = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("-------Care-------");
                            GetCarsbyColorId(carManager, colorIdd);
                            Console.WriteLine("-------Care-------");
                            break;

                    }

                    break;
                    
               
                case 2:
                    Console.WriteLine("-------Care-------");
                    GetCars(carManager);
                    Console.WriteLine("-------Care-------");
                    Console.Write("Kaçıncı Araç (Araçx şeklinde belirtin):");
                    car.CarName = Console.ReadLine();
                    Console.Write("Marka Id:");
                    car.BrandId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Model Id:");
                    car.ModelId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Renk Id:");
                    car.ColorId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Model Yılı:");
                    car.ModelYear = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Günlük Fiyat:");
                    car.DailyPrice = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Açıklama:");
                    AddCar(car, carManager);
                    break;

                case 3:

                    Console.WriteLine("-------Care-------");
                    GetCars(carManager);
                    Console.WriteLine("-------Care-------");
                    Console.Write("Araç Id:");
                    car.CarId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Kaçıncı Araç (Araçx şeklinde belirtin):");
                    car.CarName = Console.ReadLine();
                    Console.Write("Marka Id:");
                    car.BrandId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Model Id:");
                    car.ModelId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Renk Id:");
                    car.ColorId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Model Yılı:");
                    car.ModelYear = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Günlük Fiyat:");
                    car.DailyPrice = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Açıklama:");
                    car.Description = Console.ReadLine();
                    UpdateCar(car, carManager);
                    break;
                case 4:
                    Console.WriteLine("-------Care-------");
                    GetCars(carManager);
                    Console.WriteLine("-------Care-------");
                    Console.Write("Araç Id:");
                    car.CarId = Convert.ToInt32(Console.ReadLine());
                    DeleteCar(car, carManager);
                    break;
            }

            
            
        }

        private static void GetCarsbyBrandId( CarManager carManager, int brandIdd)
        {
            foreach (var carr in carManager.GetByBrand(brandIdd))
            {
                Console.WriteLine(carr.CarName);
            }
        }

        private static void GetCarsbyColorId(CarManager carManager, int colorIdd)
        {
            foreach (var carr in carManager.GetByColor(colorIdd))
            {
                Console.WriteLine(carr.CarName);
            }
        }
        private static void GetAllCarbyBrandId(CarManager carManager)
        {
            foreach (var carr in carManager.GetAll())
            {
                Console.WriteLine("{0}'Marka Idli Araç",carr.BrandId);
            }
        }

        private static void GetAllCarbyColorId(CarManager carManager)
        {
            foreach (var carr in carManager.GetAll())
            {
                Console.WriteLine("{0}'Renk Idli Araç", carr.ColorId);
            }
        }

        private static void GetCars(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} id numaralı {1} isimli araç",car.CarId,car.CarName);
            }

        }

        private static void DeleteCar(Car car, CarManager carManager)
        {

            Car car1 = carManager.GetAll().SingleOrDefault(p => p.CarId == car.CarId);
            Console.WriteLine("Araç Siliniyor...");
            carManager.Delete(car1);
            Console.WriteLine("-------Care-------");
            GetCars(carManager);
            Console.WriteLine("-------Care-------");
        }

        private static void UpdateCar(Car car1, CarManager carManager)
        {
            Console.WriteLine("Araç Güncelleniyor...");
            carManager.Update(car1);
            Console.WriteLine("-------Care-------");
            GetCars(carManager);
            Console.WriteLine("-------Care-------");
        }

        private static void AddCar(Car car1, CarManager carManager)
        {
            Console.WriteLine("Araç Kaydediliyor...");
            carManager.Add(car1);
            Console.WriteLine("-------Care-------");
            GetCars(carManager);
            Console.WriteLine("-------Care-------");

        }

       
    }
}
