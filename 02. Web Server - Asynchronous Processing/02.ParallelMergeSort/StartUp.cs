using System;
using System.Linq;

namespace _02.ParallelMergeSort
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            MergeSort<int>.Sort(input);

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
