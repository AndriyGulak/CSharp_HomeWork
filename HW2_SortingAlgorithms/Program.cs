using System;
using System.Diagnostics;

namespace HW2_SortingAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, HW2 !");

            Random rnd = new Random();

            var array0 = new int[5000];
            var array1 = new int[5000];
            var array2 = new int[5000];
            var array3 = new int[5000];
            var array4 = new int[5000];
            var array5 = new int[5000];
            var array6 = new int[5000];
            var array7 = new int[5000];
            
            for (int i = 0; i < array0.Length; i++)
            {
                var x = 0;
                bool equal = true;
                if (i == 0)
                    x = rnd.Next(0, array0.Length * 10);
                else 
                {
                    equal = true;
                    while (equal)
                    {
                        equal = false;
                        x = rnd.Next(0, array0.Length * 10);
                        for (int j = 0; j < i; j++)
                        {
                            if (array0[i] == x)
                                equal = true;
                        }
                    }
                }
                array0[i] = x;
                array1[i] = x;
                array2[i] = x;
                array3[i] = x;
                array4[i] = x;
                array5[i] = x;
                array6[i] = x;
                array7[i] = x;
                
            }

            //for (int i = 0; i < array0.Length; i++)
            //{
            //    Console.WriteLine(i + " " + array0[i]);
            //}
            //Console.WriteLine(new String('-', 25));

            Console.WriteLine($"Array Length =  {array0.Length} \n");
            SortArray(array0, Array.Sort);
            SortArray(array1, BubbleSort);
            SortArray(array2, InsertionSort);
            SortArray(array3, SelectionSort);
            SortArray(array4, MergeSort);
            SortArray(array5, GnomeSort);
            SortArray(array6, CycleSort);
            SortArray(array7, TimSort);


            // 25000
            var array10 = new int[25000];
            var array11 = new int[25000];
            var array12 = new int[25000];
            var array13 = new int[25000];
            var array14 = new int[25000];
            var array15 = new int[25000];
            var array16 = new int[25000];
            var array17 = new int[25000];

            for (int i = 0; i < array0.Length; i++)
            {
                var x = 0;
                bool equal = true;
                if (i == 0)
                    x = rnd.Next(0, array10.Length * 10);
                else
                {
                    equal = true;
                    while (equal)
                    {
                        equal = false;
                        x = rnd.Next(0, array10.Length * 10);
                        for (int j = 0; j < i; j++)
                        {
                            if (array10[i] == x)
                                equal = true;
                        }
                    }
                }
                array10[i] = x;
                array11[i] = x;
                array12[i] = x;
                array13[i] = x;
                array14[i] = x;
                array15[i] = x;
                array16[i] = x;
                array17[i] = x;

            }
            Console.WriteLine($"\n Array Length =  {array10.Length} \n");
            SortArray(array10, Array.Sort);
            SortArray(array11, BubbleSort);
            SortArray(array12, InsertionSort);
            SortArray(array13, SelectionSort);
            SortArray(array14, MergeSort);
            SortArray(array15, GnomeSort);
            SortArray(array16, CycleSort);
            SortArray(array17, TimSort);

            // 50000
            var array20 = new int[50000];
            var array21 = new int[50000];
            var array22 = new int[50000];
            var array23 = new int[50000];
            var array24 = new int[50000];
            var array25 = new int[50000];
            var array26 = new int[50000];
            var array27 = new int[50000];

            for (int i = 0; i < array20.Length; i++)
            {
                var x = 0;
                bool equal = true;
                if (i == 0)
                    x = rnd.Next(0, array20.Length * 10);
                else
                {
                    equal = true;
                    while (equal)
                    {
                        equal = false;
                        x = rnd.Next(0, array20.Length * 10);
                        for (int j = 0; j < i; j++)
                        {
                            if (array20[i] == x)
                                equal = true;
                        }
                    }
                }
                array20[i] = x;
                array21[i] = x;
                array22[i] = x;
                array23[i] = x;
                array24[i] = x;
                array25[i] = x;
                array26[i] = x;
                array27[i] = x;

            }
            Console.WriteLine($"\n Array Length =  {array20.Length} \n");
            SortArray(array20, Array.Sort);
            SortArray(array21, BubbleSort);
            SortArray(array22, InsertionSort);
            SortArray(array23, SelectionSort);
            SortArray(array24, MergeSort);
            SortArray(array25, GnomeSort);
            SortArray(array26, CycleSort);
            SortArray(array27, TimSort);
        }

        public const int RUN = 32;

        //  O(log N)
        public static void TimSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; i += RUN)
                InsertionSort(array, i, Math.Min((i + RUN - 1), (n - 1)));

            for (int size = RUN; size < n; size = 2 * size)
            {
                for (int left = 0; left < n; left += 2 * size)
                {

                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1), (n - 1));

                    if (mid < right)
                        MergeSort(array, left, right);
                }
            }
        }
        // O(n^2)
        public static void InsertionSort(int[] arr, int left,  int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int temp = arr[i];
                int j = i - 1;
                while (j >= left && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = temp;
            }
        }
        // O(n^2)
        static void GnomeSort(int[] array)
        {
            int count = 0;
            int index = 0;
            int n = array.Length;

            while (index < n)
            {
                if (index == 0)
                    index++;
                if (array[index] >= array[index - 1])
                    index++;
                else
                {
                    int temp = 0;
                    temp = array[index];
                    array[index] = array[index - 1];
                    array[index - 1] = temp;
                    index--;
                    count++;
                }
            }
            return;
        }
        // O(n^2)
        static void CycleSort(int[] array)
        {
            int n = array.Length;
            int count = 0;

            for (int cycle_start = 0; cycle_start <= n - 2; cycle_start++)
            {
                int item = array[cycle_start];

                int pos = cycle_start;
                for (int i = cycle_start + 1; i < n; i++)
                    if (array[i] < item)
                        pos++;

                if (pos == cycle_start)
                    continue;

                while (item == array[pos])
                    pos += 1;

                if (pos != cycle_start)
                {
                    int temp = item;
                    item = array[pos];
                    array[pos] = temp;
                    count++;
                }

                while (pos != cycle_start)
                {
                    pos = cycle_start;

                    for (int i = cycle_start + 1; i < n; i++)
                        if (array[i] < item)
                            pos += 1;

                    while (item == array[pos])
                        pos += 1;

                    if (item != array[pos])
                    {
                        int temp = item;
                        item = array[pos];
                        array[pos] = temp;
                        count++;
                    }
                }
            }
        }

        //FROM LESON
        // O(n^2)
        static void BubbleSort(int[] array)
        {
            var count = 0;
            var length = array.Length;
            var temp = 0;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1 - i; j++)
                {
                    count++;
                    temp = array[j];
                    if (array[j] > array[j + 1])
                    {
                        // swap
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            //Console.WriteLine("Count: " + count);
        }

        // O(n^2)
        static void InsertionSort(int[] array)
        {
            var count = 0;
            var length = array.Length;
            for (int i = 1; i < length; i++)
            {
                var key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    count++;
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
            //Console.WriteLine("Count: " + count);
        }

        // O(n^2)
        static void SelectionSort(int[] array)
        {
            var count = 0;
            int temp;
            var length = array.Length;

            for (int i = 0; i < length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < length; j++)
                {
                    count++;
                    if (array[j] < array[minIndex])
                        minIndex = j;
                }

                temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
            }
            //Console.WriteLine("Count: " + count);
        }

        static void Merge(int[] array, int low, int middle, int high)
        {
            var count = 0;
            var left = low;
            var right = middle + 1;
            var tempArray = new int[high - low + 1];
            int index = 0;

            while ((left <= middle) && (right <= high))
            {
                count++;
                if (array[left] <= array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }
                index++;
            }
            for (var i = left; i <= middle; i++)
            {
                count++;
                tempArray[index] = array[i];
                index++;
            }
            for (var i = right; i <= high; i++)
            {
                count++;
                tempArray[index] = array[i];
                index++;
            }
            for (var i = 0; i < tempArray.Length; i++)
            {
                count++;
                array[low + i] = tempArray[i];
            }
            //Console.WriteLine("Count: " + count);
        }

        static void MergeSort(int[] array)
        {
            MergeSort(array, 0, array.Length - 1);
        }

        static int[] MergeSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                var middle = (low + high) / 2;
                MergeSort(array, low, middle);
                MergeSort(array, middle + 1, high);
                Merge(array, low, middle, high);
            }
            return array;
        }

        static void SortArray(int[] array, Action<int[]> sort)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            sort(array);
            stopwatch.Stop();
            Console.WriteLine($"{sort.Method}(array): " + stopwatch.ElapsedMilliseconds.ToString());
        }
    }
}
