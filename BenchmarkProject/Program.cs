using BenchmarkDotNet.Running;
using System;
using System.Linq;

namespace BenchmarkProject
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //double[] array = new double[] { 5, 4, 3, 2, 1, 0 };
            //Random random = new Random();
            //double[] array = new double[1000];

            //for (int i = 0; i < array.Length; i++)
            //{
            //    array[i] = random.Next(-50, 51);
            //}

            //var result = array.OrderBy(item => item);
            //foreach (var item in result)
            //{
            //    Console.Write($"{item}\t");
            //}

            BenchmarkRunner.Run<TestMethodsProject>();
            Console.ReadLine();
        }

        public static double[] BubleSort(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (array[j] < array[i])
                    {
                        var temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                    }
                }
            }
            return array;
        }

        public static double[] SortInsertNoSwap(double[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i - 1;
                while ((array[j + 1] < array[j]) && j > 0)
                {
                    var temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                    j--;
                }
            }
            return array;
        }
    }
}