using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabbSolidBase.Interfaces;

namespace LabbSolidBase
{
    internal class BubbleSort: ISortManager
    {
        private static void BubbleSortArray(ref int[] inputArray)
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

        public void ExecuteSort(ref int[] intArr)
        {
            BubbleSortArray(ref intArr);
        }
    }
}
