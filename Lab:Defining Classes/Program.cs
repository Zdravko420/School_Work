using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
  public  class StartUp
    {
        static void Main(string[] args)
        {
            List<string> alltires = new List<string>();
            List<Tire[]> tireSets = new List<Tire[]>();
            List<Engine> allEngines = new List<Engine>();
            List<Car> cars = new List<Car>();
            string command = Console.ReadLine();
            while (true)
            {
                if (command == "No more tires")
                {
                    break;
                }
                else
                {
                    alltires.Add(command);
                }
                command = Console.ReadLine();
            }
            for (int i = 0; i < alltires.Count; i++)
            {
                double[] set = alltires[i]
                               .Split(" ")
                               .Select(double.Parse)
                               .ToArray();
                Tire[] tires = new Tire[4]
                {
                     new Tire((int)set[0],set[1]),
                     new Tire((int)set[2],set[3]),
                     new Tire((int)set[4],set[5]),
                     new Tire((int)set[6],set[7]),
                };
                tireSets.Add(tires);
            }
            command = Console.ReadLine();
            while (true)
            {
                if (command == "Engines done")
                {
                    break;
                }
                else
                {
                    string[] nums = command.Split(" ").ToArray();
                    allEngines.Add(new Engine(int.Parse(nums[0]), double.Parse(nums[1])));
                }
                command = Console.ReadLine();
            }
            command = Console.ReadLine();
            while (true)
            {
                if (command == "Show special")
                {
                    Func<Car, bool> filter = c => c.Year >= 2017 &&
                                          c.Engine.HorsePower > 330 &&
                                          c.Tires.Sum(t => t.Pressure) >= 9 &&
                                          c.Tires.Sum(t => t.Pressure) <= 10;
                    foreach (Car car in cars.Where(filter))
                    {
                        car.Drive(20);
                       
                        Console.WriteLine($"Make:{car.Make}\nModel :{car.Model}\nYear: {car.Year}\nHorsePowers: {car.Engine.HorsePower}\nFuelQuantity: {car.FuelQuantity}");
                    }
                    break;
                }
                else
                {
                    string[] carInfo = command.Split(" ").ToArray();
                    cars.Add(new Car(carInfo[0], carInfo[1], int.Parse(carInfo[2]), double.Parse(carInfo[3]), double.Parse(carInfo[4]), allEngines[int.Parse(carInfo[5])], tireSets[int.Parse(carInfo[6])]));
                    command = Console.ReadLine();
                }
                
            }
           
            
        }

    }
}
    