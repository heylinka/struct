using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace praktika1
{
    class Program
    {

        //Сортировка с выборкой
        public static void Selection(int[] numbers)
        {

            for (int i = 0; i < numbers.Length - 1; i++)
            {

                int min = i;

                for (int j = i + 1; j < numbers.Length; j++)
                    if (numbers[j] < numbers[min]) min = j;

                int dummy = numbers[i];
                numbers[i] = numbers[min];
                numbers[min] = dummy;
            }

        }



        //Сортировка с подсчетом
        public static void CountingSort(int[] numbers)
        {

            int[] c = new int[10000];

            for (int k = 0; k < c.Length; k++)
                c[numbers[k]] = c[numbers[k]] + 1;

            int i = 0;
            for (int j = 0; j < c.Length; j++)
                while (c[j] != 0)
                {
                    numbers[i] = j;
                    c[j]--;
                    i++;
                }

        }


        static void Main(string[] args)
        {

            int[] numbers1 = new int[10000];
            int[] numbers2 = new int[10000];
            Random rnd = new Random();
            Stopwatch watch = new Stopwatch();

            for (int i = 0; i < numbers1.Length; i++)
            {
                numbers1[i] = rnd.Next(10000);
                numbers2[i] = numbers1[i];
            }

            Console.WriteLine("Сортировка с выборкой");
            watch.Start();
            Selection(numbers1);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            watch.Restart();

            Console.WriteLine("Сортировка с подсчетом");
            watch.Start();
            CountingSort(numbers2);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

            /*for (int i = 0; i < numbers.Length; i++)
                Console.WriteLine(numbers[i]);*/

            Console.ReadKey();

        }
    }
}
