using System.Collections.Generic;
using System.Diagnostics;

namespace _01.Chronometer
{
    public class Chronometer : IChronometer
    {
        private static readonly Stopwatch sw=new Stopwatch();

        public Chronometer()
        {
            Laps = new List<string>();
        }

        public string GetTime => sw.Elapsed.ToString().Substring(3, sw.Elapsed.ToString().Length - 6);

        public List<string> Laps { get; set; }

        public string Lap()
        {
            string lap = sw.Elapsed.ToString().Substring(3, sw.Elapsed.ToString().Length - 6);

            Laps.Add(lap);

            return lap;
        }

        public void Reset()
        {
            sw.Reset();
            Laps.Clear();
        }

        public void Start()
        {
            sw.Start();
        }

        public void Stop()
        {
            sw.Stop();
        }
    }
}
