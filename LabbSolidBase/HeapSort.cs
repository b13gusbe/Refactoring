using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabbSolidBase.Interfaces;

namespace LabbSolidBase
{
    internal class HeapSort: ISortManager
    {
        private static void HeapSortArray(ref int[] inputArray)
        {
            int heapSize = inputArray.Length;

            for (int p = (heapSize - 1) / 2; p >= 0; --p)
                Heapify(ref inputArray, heapSize, p);

            for (int i = inputArray.Length - 1; i > 0; --i)
            {
                (inputArray[i], inputArray[0]) = (inputArray[0], inputArray[i]);

                --heapSize;
                Heapify(ref inputArray, heapSize, 0);
            }
        }

        private static void Heapify(ref int[] data, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if (left < heapSize && data[left] > data[index])
                largest = left;
            else
                largest = index;

            if (right < heapSize && data[right] > data[largest])
                largest = right;

            if (largest != index)
            {
                (data[index], data[largest]) = (data[largest], data[index]);
                Heapify(ref data, heapSize, largest);
            }
        }

        public void ExecuteSort(ref int[] intArr)
        {
            HeapSortArray(ref intArr);
        }
    }
}
