using System;

namespace _01.Chronometer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IChronometer chronometer = new Chronometer();

            string command = string.Empty;

            while ((command = Console.ReadLine().ToLower()) != "exit")
            {
                if (command == "start")
                {
                    chronometer.Start();
                }
                else if (command == "stop")
                {
                    chronometer.Stop();
                }
                else if (command == "lap")
                {
                    Console.WriteLine(chronometer.Lap());
                }
                else if (command == "laps")
                {
                    if (chronometer.Laps.Count == 0)
                    {
                        Console.WriteLine("Laps: no laps");
                        continue;
                    }

                    for (int i = 0; i < chronometer.Laps.Count; i++)
                    {
                        Console.WriteLine($"{i}. {chronometer.Laps[i]}");
                    }
                }
                else if (command == "time")
                {
                    if (chronometer.GetTime.Length>3)
                    {
                        Console.WriteLine(chronometer.GetTime);
                    }
                    else
                    {
                        Console.WriteLine("The chronometer is not started!");
                    }
                }
                else if (command == "reset")
                {
                    chronometer.Reset();
                }
                else
                {
                    Console.WriteLine($"\"{command}\" is not a valid command!");
                }
            }
        }
    }
}
