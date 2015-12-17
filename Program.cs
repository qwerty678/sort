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
            int left, right;

            String[] fileNames = { "Small.csv", "Big.csv" };
            int[] counts = { COUNT1, COUNT2, COUNT3, COUNT4 };

            foreach(String fileName in fileNames)
            {
                foreach (int count in counts)
                {
                    File.AppendAllText(fileName, count.ToString() + ';');
                    array = generateArray(COUNT1, MIN_TO_MAX, SMALL_E);
                    stWatch.Start();
                    Program.sortByChoose(array, COUNT1);
                    stWatch.Stop();
                    File.AppendAllText(fileName, "choose:" + stWatch.ElapsedMilliseconds.ToString() + ';');
                    stWatch.Reset();
                    stWatch.Start();
                    Program.sortByInsert(array, COUNT1);
                    stWatch.Stop();
                    File.AppendAllText(fileName, "insert:" + stWatch.ElapsedMilliseconds.ToString() + ';');
                    stWatch.Reset();
                    stWatch.Start();
                    Program.boobleSort(array, COUNT1);
                    stWatch.Stop();
                    File.AppendAllText(fileName, "booble:" + stWatch.ElapsedMilliseconds.ToString() + ';');
                    stWatch.Reset();
                    left = array[0]; right = array[COUNT1 - 1];
                    stWatch.Start();
                    Program.mergeSort(array, left, right);
                    stWatch.Stop();
                    File.AppendAllText(fileName, "merge:" + stWatch.ElapsedMilliseconds.ToString() + ';');
                    stWatch.Reset();
                    stWatch.Start();
                    Program.quickSort(array, 0, COUNT1 - 1);
                    stWatch.Stop();
                    File.AppendAllText(fileName, "quick:" + stWatch.ElapsedMilliseconds.ToString() + ';');
                    stWatch.Reset();

                    File.AppendAllText(fileName, Environment.NewLine);
                }
            }
        }

        public static int[] sortByChoose(int[] array, int count)
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

        public static int[] sortByInsert(int[] array, int count)
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

        public static int[] boobleSort(int[] array, int count)
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

        public static void merge(int[] numbers, int left, int mid, int right)
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

        public static void mergeSort(int[] numbers, int left, int right)
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

        public static int[] quickSort(int[] array, int leftIndex, int rightIndex)
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
