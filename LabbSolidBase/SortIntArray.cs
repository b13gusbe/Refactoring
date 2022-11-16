using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Media.Media3D;

namespace LabbSolidBase;

public static class SortIntArray
{
    public static void BubbleSort(ref int[] inputArray)
    {
        for (var j = 0; j <= inputArray.Length - 2; j++)
        {
            for (var i = 0; i <= inputArray.Length - 2; i++)
            {
                if (inputArray[i] <= inputArray[i + 1])
                    continue;

                (inputArray[i + 1], inputArray[i]) = (inputArray[i], inputArray[i + 1]);
            }
        }
    }

    public static void QuickSort(ref int[] inputArray, int left, int right)
    {
        var pivot = inputArray[(left + right) / 2];
        var leftHold = left;
        var rightHold = right;

        while (leftHold < rightHold)
        {
            while ((inputArray[leftHold] < pivot) && (leftHold <= rightHold)) leftHold++;
            while ((inputArray[rightHold] > pivot) && (rightHold >= leftHold)) rightHold--;

            if (leftHold >= rightHold) continue;

            (inputArray[leftHold], inputArray[rightHold]) = (inputArray[rightHold], inputArray[leftHold]);
            if (inputArray[leftHold] == pivot && inputArray[rightHold] == pivot)
                leftHold++;
        }

        if (left < leftHold - 1)
            QuickSort(ref inputArray, left, leftHold - 1);

        if (right > rightHold + 1)
            QuickSort(ref inputArray, rightHold + 1, right);
    }

    public static void HeapSort(ref int[] inputArray)
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
}
