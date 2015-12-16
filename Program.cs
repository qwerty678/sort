using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Sort
{
    class Program
    {
        // Count
        const int COUNT1 = 50000;
        const int COUNT2 = 100000;
        const int COUNT3 = 500000;
        const int COUNT4 = 1000000;

        // element sort
        const int MIN_TO_MAX = 1;
        const int MAX_TO_MIN = 2;
        const int RANDOM     = 3;

        // values entropy
        const int BIG_E = 1;
        const int SMALL_E   = 2;

        static void Main(string[] args)
        {
            int[] array;
            Stopwatch stWatch = new Stopwatch();
            StringBuilder csv = new StringBuilder();


            stWatch.Start();
            array = generateArray(COUNT1, MIN_TO_MAX, SMALL_E);
            stWatch.Stop();
            File.AppendAllText ("Small.csv", stWatch.ElapsedMilliseconds.ToString()+';');
            stWatch.Reset();

            stWatch.Start();
            array = generateArray(COUNT1, MIN_TO_MAX, BIG_E);
            stWatch.Stop();
            File.AppendAllText ("Big.csv", stWatch.ElapsedMilliseconds.ToString()+';');
            stWatch.Reset();

            stWatch.Start();
            array = generateArray(COUNT1, MAX_TO_MIN, SMALL_E);
            stWatch.Stop();
            File.AppendAllText ("Small.csv", stWatch.ElapsedMilliseconds.ToString() + ';');
            stWatch.Reset();

            stWatch.Start();
            array = generateArray(COUNT1, MAX_TO_MIN, BIG_E);
            stWatch.Stop();
            File.AppendAllText ("Big.csv", stWatch.ElapsedMilliseconds.ToString() + ';');
            stWatch.Reset();

            stWatch.Start();
            array = generateArray(COUNT1, RANDOM, SMALL_E);
            stWatch.Stop();
            File.AppendAllText ("Small.csv", stWatch.ElapsedMilliseconds.ToString() + ';');
            stWatch.Reset();

            stWatch.Start();
            array = generateArray(COUNT1, RANDOM, BIG_E);
            stWatch.Stop();
            File.AppendAllText ("Big.csv", stWatch.ElapsedMilliseconds.ToString() + ';');
            stWatch.Reset();

            stWatch.Start();
            array = generateArray(COUNT2, MIN_TO_MAX, SMALL_E);
            stWatch.Stop();
            File.AppendAllText ("Small.csv", stWatch.ElapsedMilliseconds.ToString() + ';');
            stWatch.Reset();

            stWatch.Start();
            array = generateArray(COUNT2, MIN_TO_MAX, BIG_E);
            stWatch.Stop();
            File.AppendAllText ("Big.csv", stWatch.ElapsedMilliseconds.ToString() + ';');
            stWatch.Reset();

            stWatch.Start();
            array = generateArray(COUNT2, MAX_TO_MIN, SMALL_E);
            stWatch.Stop();
            File.AppendAllText ("Small.csv", stWatch.ElapsedMilliseconds.ToString() + ';');
            stWatch.Reset();

            stWatch.Start();
            array = generateArray(COUNT2, MAX_TO_MIN, BIG_E);
            stWatch.Stop();
            File.AppendAllText ("Big.csv", stWatch.ElapsedMilliseconds.ToString() + ';');
            stWatch.Reset();

            stWatch.Start();
            array = generateArray(COUNT2, RANDOM, SMALL_E);
            stWatch.Stop();
            File.AppendAllText ("Small.csv", stWatch.ElapsedMilliseconds.ToString() + ';');
            stWatch.Reset();

            stWatch.Start();
            array = generateArray(COUNT2, RANDOM, BIG_E);
            stWatch.Stop();
            File.AppendAllText ("Big.csv", stWatch.ElapsedMilliseconds.ToString() + ';');
            stWatch.Reset();

            stWatch.Start();
            array = generateArray(COUNT3, MIN_TO_MAX, SMALL_E);
            stWatch.Stop();
            File.AppendAllText ("Small.csv", stWatch.ElapsedMilliseconds.ToString() + ';');
            stWatch.Reset();

            stWatch.Start();
            array = generateArray(COUNT3, MIN_TO_MAX, BIG_E);
            stWatch.Stop();
            File.AppendAllText ("Big.csv", stWatch.ElapsedMilliseconds.ToString() + ';');
            stWatch.Reset();

            stWatch.Start();
            array = generateArray(COUNT3, MAX_TO_MIN, SMALL_E);
            stWatch.Stop();
            File.AppendAllText ("Small.csv", stWatch.ElapsedMilliseconds.ToString() + ';');
            stWatch.Reset();

            stWatch.Start();
            array = generateArray(COUNT3, MAX_TO_MIN, BIG_E);
            stWatch.Stop();
            File.AppendAllText ("Big.csv", stWatch.ElapsedMilliseconds.ToString() + ';');
            stWatch.Reset();

            stWatch.Start();
            array = generateArray(COUNT3, RANDOM, SMALL_E);
            stWatch.Stop();
            File.AppendAllText ("Small.csv", stWatch.ElapsedMilliseconds.ToString() + ';');
            stWatch.Reset();

            stWatch.Start();
            array = generateArray(COUNT3, RANDOM, BIG_E);
            stWatch.Stop();
            File.AppendAllText ("Big.csv", stWatch.ElapsedMilliseconds.ToString() + ';');
            stWatch.Reset();

            stWatch.Start();
            array = generateArray(COUNT4, MIN_TO_MAX, SMALL_E);
            stWatch.Stop();
            File.AppendAllText ("Small.csv", stWatch.ElapsedMilliseconds.ToString() + ';');
            stWatch.Reset();

            stWatch.Start();
            array = generateArray(COUNT4, MIN_TO_MAX, BIG_E);
            stWatch.Stop();
            File.AppendAllText ("Big.csv", stWatch.ElapsedMilliseconds.ToString() + ';');
            stWatch.Reset();

            stWatch.Start();
            array = generateArray(COUNT4, MAX_TO_MIN, SMALL_E);
            stWatch.Stop();
            File.AppendAllText ("Small.csv", stWatch.ElapsedMilliseconds.ToString() + ';');
            stWatch.Reset();

            stWatch.Start();
            array = generateArray(COUNT4, MAX_TO_MIN, BIG_E);
            stWatch.Stop();
            File.AppendAllText ("Big.csv", stWatch.ElapsedMilliseconds.ToString() + ';');
            stWatch.Reset();

            stWatch.Start();
            array = generateArray(COUNT4, RANDOM, SMALL_E);
            stWatch.Stop();
            File.AppendAllText ("Small.csv", stWatch.ElapsedMilliseconds.ToString() + ';');
            stWatch.Reset();

            stWatch.Start();
            array = generateArray(COUNT4, RANDOM, BIG_E);
            stWatch.Stop();
            File.AppendAllText ("Big.csv", stWatch.ElapsedMilliseconds.ToString() + ';');
            stWatch.Reset();

        }

        int[] sortByChoose(int[] array, int count)
        {
            int i, j, k, temp;

            for (i = 1; i < count; i++)
            {
                k = i;
                for (j = i + 1; j < count; j++)
                    if (array[j] < array[k]) k = j;

                temp = array[k];
                array[k] = array[i];
                array[i] = temp;
            }

            return array;
        }

        int[] sortByInsert(int[] array, int count)
        {
            int i, j, x;

            for (i = 2; i < count; i++)
            {
                x = array[i]; array[0] = x; j = i;

                while (x < array[j-1]) {
                    array[j] = array[j - 1]; j--;
                }
                array[j] = x;
            }

            return array;
        }

        int[] boobleSort(int[] array, int count)
        {
            int i, j, temp;

            for (i=2; i<count; i++)
            {
                for(j=count; j <= i; j--)
                {
                    if (array[j-1] > array[j])
                    {
                        temp = array[j - 1]; array[j - 1] = array[j]; array[j] = temp;
                    }
                }
            }

            return array;
        }

        static public void merge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[25];
            int i, left_end, num_elements, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[tmp_pos++] = numbers[left++];
                else
                    temp[tmp_pos++] = numbers[mid++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = numbers[left++];

            while (mid <= right)
                temp[tmp_pos++] = numbers[mid++];

            for (i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }

        static public void mergeSort(int[] numbers, int left, int right)
        {
            int mid;

            if (right > left)
            {
                mid = (right + left) / 2;
                mergeSort(numbers, left, mid);
                mergeSort(numbers, (mid + 1), right);

                merge(numbers, left, (mid + 1), right);
            }
        }

        int[] quickSort(int[] array, int leftIndex, int rightIndex)
        {
            int i, j, x, w;

            i = leftIndex; j = rightIndex;
            x = array[leftIndex];


            do
            {
                while (array[i] < x) i = i + 1;
                while (array[j] > x) j = j - 1;

                if( i <= j )
                {
                    w = array[i];
                    array[i] = array[j];
                    array[j] = w;
                    i = i + 1;
                    j = j - 1;
                }
            } while (i > j);

            if (leftIndex < j) array = quickSort(array, leftIndex, j);
            if (i < rightIndex) array = quickSort(array, i, rightIndex);

            return array;
        }

        private static int[] generateArray(int count, int presortType, int entropy) 
        {
            int randMax;

            switch(entropy)
            {
                case BIG_E:
                    randMax = 100 * count;
                    break;
                case SMALL_E:
                    randMax = 10;
                    break;
                default:
                    randMax = 0;
                    break;
            }

            switch (presortType)
            {
                case MAX_TO_MIN:
                    return maxToMin(count, randMax);
                case MIN_TO_MAX:
                    return minToMax(count, randMax);
                default:
                    return random(count, randMax);
            }
        }

        private static int[] minToMax(int count, int randMax)
        {
            int[] array = new int[count];
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
                array[i] = rnd.Next(i, randMax + i);

            return array;
        }

        private static int[] random(int count, int randMax)
        {
            int[] array = new int[count];
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
                array[i] = rnd.Next(1, randMax);

            return array;
        }

        private static int[] maxToMin(int count, int randMax)
        {
            int[] array = new int[count];
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
                array[i] = randMax - rnd.Next(i, randMax + i) + 1;

            return array;
        }
    }
}
