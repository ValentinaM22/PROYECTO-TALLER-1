using System;

namespace TALLER_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Time[] times = new Time[]
                {
                    new Time(0, 0, 0, 0),
                    new Time(2, 0, 0, 0),
                    new Time(9, 34, 0, 0),
                    new Time(7, 45, 56, 0),
                    new Time(11, 3, 45, 678)
                };

                Time[] additions = new Time[]
                {
                    new Time(9, 34, 0, 0),
                    new Time(11, 34, 0, 0),
                    new Time(7, 8, 0, 0),
                    new Time(5, 19, 56, 0),
                    new Time(8, 37, 45, 678)
                };

                for (int i = 0; i < times.Length; i++)
                {
                    Console.WriteLine($"Time: {times[i]}");

                    long milliseconds = times[i].ToMilliseconds();
                    long seconds = times[i].ToSeconds();
                    long minutes = times[i].ToMinutes();

                    Console.WriteLine($"Milliseconds : {milliseconds:N0}");
                    Console.WriteLine($"Seconds      : {seconds:N0}");
                    Console.WriteLine($"Minutes      : {minutes:N0}");

                    Time addedTime = times[i].Add(additions[i]);
                    Console.WriteLine($"Add          : {addedTime}");
                    Console.WriteLine($"Is Other day: {times[i].IsOtherDay(additions[i])}");
                    Console.WriteLine();
                }

                // Prueba de validación de horas incorrectas
                try
                {
                    Time invalidTime = new Time(45, 0, 0);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Press any key to close this window . . .");
            Console.ReadKey();
        }
    }
}