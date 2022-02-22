using System;

namespace car_test
{
  public class car
    {
        public string type_ts { get; set; }
        public double mid_fuel { get; set; }
        public double full_fuel { get; set; }
        public double speed { get; set; }
        public double current_fuel { get; set; }
        public double full_patch { get; set; }
        public double current_patch { get; set; }
        public int max_passenger { get; set; }
        public int current_passenger { get; set; }
        public double max_load { get; set; }
        public double current_load { get; set; }
    }
    class Program
    {
      public static car[] car_array = new car[0];
        
        static void Main(string[] args)
        {
            for(int i=0;i<5; i++)
            {
                add_random();
                Console.WriteLine();
                Console.WriteLine("Машина №"+(i+1));
                Console.WriteLine("Тип машины - "+car_array[i].type_ts);
                Console.WriteLine("Объем топливного бака - "+car_array[i].full_fuel);
                Console.WriteLine("Расход таплива на 100км - " + car_array[i].mid_fuel);
                Console.WriteLine("Скорость - " + car_array[i].speed);
                Console.WriteLine("Максимальное количество пассажиров - " + car_array[i].max_passenger);
                Console.WriteLine("Текущее количество пассажиров - " + car_array[i].current_passenger);
                Console.WriteLine("Максимальный груз - " + car_array[i].max_load);
                Console.WriteLine("Текущий груз - " + car_array[i].current_load);
                path_car(car_array[i]);
                Console.WriteLine("Максимальная грузоподемность - " + car_array[i].max_load);
                Console.WriteLine("Текущий груз - " + car_array[i].current_load);
                time_car(car_array[i]);
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------");
                
            }

            Console.Read();
           


        }
     public  static car[] add_array(car[] car)
        {
            car[] newcar = new car[car.Length+1];
            newcar[newcar.Length-1] = new car();
            car.CopyTo(newcar, 0);
            return newcar;
        }
      public static void add_random()
        {
          car_array=  add_array(car_array);
            Random rnd = new Random();
            car_array[car_array.Length - 1].full_fuel = rnd.Next(10, 100) + Math.Round(rnd.NextDouble(), 1);
            car_array[car_array.Length - 1].mid_fuel = rnd.Next(1, (int)Math.Round(car_array[car_array.Length - 1].full_fuel/3)) + Math.Round(rnd.NextDouble(), 1);
            car_array[car_array.Length - 1].speed= rnd.Next(10, 280) + Math.Round(rnd.NextDouble(), 1);
            car_array[car_array.Length - 1].current_fuel= rnd.Next(1, (int)Math.Round(car_array[car_array.Length - 1].full_fuel )) + Math.Round(rnd.NextDouble(), 1);
            switch (rnd.Next(1, 4))
            {
                case 1:
                    car_array[car_array.Length - 1].type_ts = "sport";
                    car_array[car_array.Length - 1].max_passenger = rnd.Next(1, 5);
                    car_array[car_array.Length - 1].current_passenger = rnd.Next(1, car_array[car_array.Length - 1].max_passenger);
                    car_array[car_array.Length - 1].max_load = rnd.Next(200, 2000) + Math.Round(rnd.NextDouble(), 1);
                    do
                    {
                        car_array[car_array.Length - 1].current_load = rnd.Next(0, (int)Math.Round(car_array[car_array.Length - 1].max_load)) + Math.Round(rnd.NextDouble(), 1);
                    } while (load_cheak(car_array[car_array.Length - 1].current_passenger, car_array[car_array.Length - 1].max_load, car_array[car_array.Length - 1].current_load));
                    
                    break;
                case 2:
                    car_array[car_array.Length - 1].type_ts = "passenger";
                    car_array[car_array.Length - 1].max_passenger = rnd.Next(2, 10);
                    car_array[car_array.Length - 1].current_passenger = rnd.Next(1, car_array[car_array.Length - 1].max_passenger);
                    car_array[car_array.Length - 1].max_load = rnd.Next(500, 5000) + Math.Round(rnd.NextDouble(), 1);
                    do
                    {
                        car_array[car_array.Length - 1].current_load = rnd.Next(0, (int)Math.Round(car_array[car_array.Length - 1].max_load)) + Math.Round(rnd.NextDouble(), 1);
                    } while (load_cheak(car_array[car_array.Length - 1].current_passenger, car_array[car_array.Length - 1].max_load, car_array[car_array.Length - 1].current_load));

                    break;
                case 3:
                    car_array[car_array.Length - 1].type_ts = "cargo";
                    car_array[car_array.Length - 1].max_passenger = rnd.Next(1, 3);
                    car_array[car_array.Length - 1].current_passenger = rnd.Next(1, car_array[car_array.Length - 1].max_passenger);
                    car_array[car_array.Length - 1].max_load = rnd.Next(5000, 50000) + Math.Round(rnd.NextDouble(), 1);
                    do
                    {
                        car_array[car_array.Length - 1].current_load = rnd.Next(0, (int)Math.Round(car_array[car_array.Length - 1].max_load)) + Math.Round(rnd.NextDouble(), 1);
                    } while (load_cheak(car_array[car_array.Length - 1].current_passenger, car_array[car_array.Length - 1].max_load, car_array[car_array.Length - 1].current_load));

                    break;               
            }
        }
        public static bool load_cheak(int current_passenger,double max_load,double current_load)
        {
            int passenger_weight = current_passenger * 70;
            double load = max_load - passenger_weight;
            if (load <= current_load)
            {
                return true;
            }
            return false;
        }
        public static void path_car(car car)
        {
            double reserve = car.current_passenger * 6 ;
            
            switch (car.type_ts)
            {
                case "sport":
                    reserve += Math.Round(car.current_load / 80) * 4;
                    break;
                case "passenger":
                    reserve += Math.Round(car.current_load / 200) * 4;
                    break;
                case "cargo":
                    reserve += Math.Round(car.current_load / 2000) * 4;
                    break;
            }
           car.full_patch =Math.Round( (car.full_fuel/car.mid_fuel*100)- (car.full_fuel / car.mid_fuel * 100)/100*reserve, 1);
           car.current_patch= Math.Round((car.current_fuel / car.mid_fuel * 100) - (car.current_fuel / car.mid_fuel * 100) / 100 * reserve, 1);
            Console.WriteLine("Запас хода - " + reserve);
        }
        public static void time_car(car car)
        {
            double full_time;
            double current_time;
            full_time =Math.Round( car.full_patch / car.speed,1);
            current_time =Math.Round( car.current_patch / car.speed,1);
            Console.WriteLine("Время на путь с полныйм баком - " + full_time);
            Console.WriteLine("Время на путь с оставшимся топливом - " + current_time);

        }
    }
    public class check_add
    {


    }
}
