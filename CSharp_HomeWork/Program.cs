using System;

namespace CSharp_HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, HW1 !");

            Random rnd = new Random();

            int[] array1 = new int[1000000];
            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = i;
            }

            //  O(1) — Константна складність (Constant)
            int n = rnd.Next(0, array1.Length);
            Console.WriteLine($"O(1){new String('.', 6)} Value = {array1[n]}");

            //  О(N) — Лінійна складність (Linear)
            for (int i = 0; i <= n; i++)
            {
                if (n != 0 & i == n-1)
                Console.WriteLine($"O(N){new String('.', 6)} Value n-1 = {array1[i]}");
            }

            //  O(log N) — Логарифмічна складність (Logarithmic)
            Console.WriteLine($"O(log N).. Index = {n}; Iteration count = {FindIndex(array1, n)};");

            //  O(N2) — Квадратична складність (Quadratic)
            Console.WriteLine($"O(N2){new String('.', 5)} Iteration count = {Quadratic(5)};");

            //  O(2N) — Експоненціальна складність(Exponential)
            Console.WriteLine($"O(2N){new String('.', 5)} Fibonacci  = {Fibonacci(7)};");
        }

        public static int FindIndex(int[] arr, int index)
        {
            int i = 0;
            int min = 0;
            int max = arr.Length - 1;
            while (min <= max)
            {
                i++;
                int mid = min + (max - min) / 2;
                if (index < arr[mid])
                    max = mid;
                else if (index > arr[mid])
                    min = mid + 1;
                else return i;
            }
            return i;
        }

        public static long Quadratic(int n)
        {
            int count = 0;
            for(int i = 0; i < n; i++) 
            {
                for (int j = 0; j < n; j++)
                { 
                    count++;
                }
            }
            return count;
        }

        public static int Fibonacci(int n)
        {
            if (n <= 1)
                return n;
            return Fibonacci(n - 2) + Fibonacci(n - 1);
        }
    }
}
