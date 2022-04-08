using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw2.Exercise4.Sorting
{
    internal class QuickSort : SortBase
    {
        public override void Sort(int[] array)
        {
            int middle = array[array.Length / 2];
            int temp;
            int i = 0;
            int j = array.Length - 1;
            while (i <= j)
            {
                while (array[i] < middle && i <= j) ++i;
                while (array[j] > middle && j >= i) --j;
                if (i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    ++i; --j;
                }
                if (j > i) Sort(array);
                if (i < j) Sort(array);
            }
        }
    }
}
