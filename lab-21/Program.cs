using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;

namespace lab_21
{
    class Program
    {
        static int a = 0;
        static int b = 0;
        static int[,] array;
        static object locker = new object();
        public static void fermer1()
        {
            lock (locker)
            {
                for (int i = 0; i < a; i++)
                {
                    for (int j = 0; j < b; j++)
                    {
                        if (array[i, j] == 0)
                            array[i, j] = 1;
                        else
                            continue;
                        Thread.Sleep(10);
                    }
                }
            }

        }
        public static void fermer2()
        {
            for (int i = b - 1; i >= 0; i--)
            {
                for (int j = a - 1; j >= 0; j--)
                {
                    if (array[j, i] == 0)
                        array[j, i] = 1;
                    else
                        continue;
                    Thread.Sleep(10);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Введите размеры поля a = ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("b = ");
            b = Convert.ToInt32(Console.ReadLine());
            array = new int[a, b];
            ThreadStart myThreadStart1 = new ThreadStart(fermer1);
            Thread myThread1 = new Thread(myThreadStart1);
            myThread1.Start();

            fermer2();

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }


            Console.ReadKey();
        }
    }
}
