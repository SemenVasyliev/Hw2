using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw2.Exercise4.Sorting
{
    internal class BubbleSort : SortBase
    {
        public override void Sort (int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }
}
