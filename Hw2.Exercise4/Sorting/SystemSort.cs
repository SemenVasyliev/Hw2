using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw2.Exercise4.Sorting
{
    internal class SystemSort : SortBase
    {
        public override void Sort(int[] array)
        {
            Array.Sort(array);
        }
    }
}
