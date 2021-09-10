using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkProject
{
    [MemoryDiagnoser]
    [RankColumn]
    public class TestMethodsProject
    {
        private static double[] array = new double[500_000];

        public TestMethodsProject()
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-50, 51);
            }
        }

        [Benchmark]
        public void ArraySortTest()
        {
            //Array.Sort(array);
        }

        [Benchmark]
        public void SortInsertWithSwapTest()
        {
            _ = SortInsertWithSwap(array);
        }

        [Benchmark]
        public void SortInsertNoSwapTest()
        {
            var test = SortInsertNoSwap(array);
        }

        [Benchmark]
        public void BubleSortTest()
        {
            _ = BubleSort(array);
        }

        /// <summary>
        /// Сортировка пузырьком
        /// </summary>
        /// <param name="array">Массив для сортировки</param>
        /// <returns>Отсортированный массив</returns>
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

        /// <summary>
        /// Сортировка вставками с методом Swap()
        /// </summary>
        /// <param name="array">Массив для сортировки</param>
        /// <returns>Отсортированный массив</returns>
        public static double[] SortInsertWithSwap(double[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i - 1;
                while ((array[j + 1] < array[j]) && j > 0)
                {
                    Swap(ref array[j], ref array[j + 1]);
                    j--;
                }
            }
            return array;
        }

        [Benchmark]
        public void LINQSortTest()
        {
            var s = array.OrderBy(item => item).ToArray();
        }

        /// <summary>
        /// Сортировка вставками без методом Swap()
        /// </summary>
        /// <param name="array">Массив для сортировки</param>
        /// <returns>Отсортированный массив</returns>
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

        /// <summary>
        /// Метод меняющий элементы местами
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        private static void Swap(ref double item1, ref double item2)
        {
            var temp = item1;
            item1 = item2;
            item2 = temp;
        }
    }
}