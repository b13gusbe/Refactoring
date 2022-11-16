using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabbSolidBase.Interfaces;

namespace LabbSolidBase
{
    internal class QuickSort: ISortManager
    {

        public static void QuickSortArray(ref int[] inputArray, int left, int right)
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
                QuickSortArray(ref inputArray, left, leftHold - 1);

            if (right > rightHold + 1)
                QuickSortArray(ref inputArray, rightHold + 1, right);
        }

        public void ExecuteSort(ref int[] intArr)
        {
            QuickSortArray(ref intArr, 0, intArr.Length - 1);
        }
    }
}
