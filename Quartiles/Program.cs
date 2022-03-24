using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            int n = int.Parse(line);

            int[] arr = Array.ConvertAll<string, int>(Console.ReadLine().Split(' '), int.Parse);

            int q2 = Median(arr, 0, n - 1);

            int nhalf = n / 2;

            int q1 = Median(arr, 0, nhalf - 1);
            int q3 = Median(arr, nhalf + (n % 2), n - 1);

            Console.WriteLine($"{q1}\n{q2}\n{q3}");

        }

        static int Median(int[] arr, int ini, int fin)
        {
            int k = (ini + fin) / 2;
            int len = fin - ini + 1;
            SelectLomuto(arr, ini, fin, k);

            int median = arr[k];
            if (len % 2 == 0)
            {
                k++;
                SelectLomuto(arr, k - 1, fin, k);
                median = (median + arr[k]) / 2;
            }
            return median;
        }

        static void SelectLomuto(int[] arr, int left, int right, int k)
        {
            int kr;
            for (;;)
            {
                if (left == right) return;
                kr = PartitionLomuto(arr, left, right);
                if (kr == k) return;
                if (k < kr)
                {
                    right = kr - 1;
                }
                else
                {
                    left = kr + 1;
                }
            }
        }

        static int PartitionLomuto(int[] arr, int left, int right)
        {
            int storeIndex = left;

            int pivot = arr[right];
            int aux;
            for (int i = left; i < right; i++)
            {
                if (arr[i] < pivot)
                {
                    aux = arr[storeIndex];
                    arr[storeIndex] = arr[i];
                    arr[i] = aux;
                    storeIndex++;
                }
            }

            aux = arr[storeIndex];
            arr[storeIndex] = arr[right];
            arr[right] = aux;

            return storeIndex;
        }
    }
}
