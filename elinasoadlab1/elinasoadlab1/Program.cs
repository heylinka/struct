using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;


namespace elinasoadlab1
{

    struct People {
        public int Id;
        public string Name;
        public string Meaning;
        public string Gender;
        public string Origin;
        public int PeopleCount;

    }



    class Program
    {

        //Сортировка пузырьком
        static void BubbleSort(List<People> people)
        {
            People temp;
            for (int i = 0; i < people.Count; i++)
            {
                for (int j = i + 1; j < people.Count; j++)
                {
                    if (people[i].PeopleCount > people[j].PeopleCount)
                    {
                        temp = people[i];
                        people[i] = people[j];
                        people[j] = temp;
                    }
                }
            }
        }


        //Гномья сортировка 
        static void gnomeSort(List<People> people)
        {
            int i = 1;
            while (i < people.Count)
            {
                if (i == 0 || people[i - 1].PeopleCount <= people[i].PeopleCount)
                    i++;
                else {
                    People temp = people[i];
                    people[i] = people[i - 1];
                    people[i - 1] = temp;
                    i--;
                }
            }
        }

        //Сортировка Шелла
        static void shellSort(List<People> people)
        {
            int step = people.Count / 2;
            while (step > 0)
            {
                int i, j;
                for (i = step; i < people.Count; i++)
                {
                    People value = people[i];
                    for (j = i - step; (j >= 0) && (people[j].PeopleCount > value.PeopleCount); j -= step)
                        people[j + step] = people[j];
                    people[j + step] = value;
                }
                step /= 2;
            }
        }


        //Пирамидальная сортировка 
        static int add2pyramid(List<People> people, int i, int N)
        {
            int imax;
            People buf;
            if ((2 * i + 2) < N)
            {
                if (people[2 * i + 1].PeopleCount < people[2 * i + 2].PeopleCount) imax = 2 * i + 2;
                else imax = 2 * i + 1;
            }
            else imax = 2 * i + 1;
            if (imax >= N) return i;
            if (people[i].PeopleCount < people[imax].PeopleCount)
            {
                buf = people[i];
                people[i] = people[imax];
                people[imax] = buf;
                if (imax < N / 2) i = imax;
            }
            return i;
        }

        static void Pyramid_Sort(List<People> people)
        {
            //step 1: building the pyramid
            for (int i = people.Count / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = add2pyramid(people, i, people.Count);
                if (prev_i != i) ++i;
            }

            //step 2: sorting
            People buf;
            for (int k = people.Count - 1; k > 0; --k)
            {
                buf = people[0];
                people[0] = people[k];
                people[k] = buf;
                int i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = add2pyramid(people, i, k);
                }
            }
        }






        //Считать файл
        static void ReadFile(List<People> list)
        {
            try
            {
                using (StreamReader reader = File.OpenText("D:\\elina\\elinasoadlab1\\foreign_names.csv"))
                {
                    string[] text = new string[6];
                    while (!reader.EndOfStream)
                    {
                        People ind = new People();
                        text = reader.ReadLine().Split(';');
                        ind.Id = Convert.ToInt32(text[0]);
                        ind.Name = Convert.ToString(text[1]);
                        ind.Meaning = Convert.ToString(text[2]);
                        ind.Gender = Convert.ToString(text[3]);
                        ind.Origin = Convert.ToString(text[4]);
                        ind.PeopleCount = Convert.ToInt32(text[5]);
                        list.Add(ind);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

        }


        static void Main(string[] args)
        {

            List<People> people = new List<People>();

            //Измерятор времени
            Stopwatch watch = new Stopwatch();


            ReadFile(people);
            Console.WriteLine("Сортировка пузырьком");
            watch.Start();
            BubbleSort(people);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            watch.Restart();
            people.Clear();


            ReadFile(people);
            Console.WriteLine("\nГномья сортировка");
            watch.Start();
            gnomeSort(people);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            watch.Restart();
            people.Clear();



            ReadFile(people);
            Console.WriteLine("\nСортировка Шелла");
            watch.Start();
            shellSort(people);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            watch.Restart();
            people.Clear();



            ReadFile(people);
            Console.WriteLine("\nПирамидальная сортировка");
            watch.Start();
            Pyramid_Sort(people);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            watch.Restart();


            Console.ReadKey();
        }
    }
}
