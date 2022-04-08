namespace Hw2.Exercise4
{
    /// <summary>
    /// Sort request.
    /// </summary>
    public class SortRequest
    {
        /// <summary>
        /// Requested sort algorithm.
        /// </summary>
        public string SortAlgorith { get; }

        /// <summary>
        /// Array to sort.
        /// </summary>
        public int[] Array { get; set; }

        /// <summary>
        /// Creates instance of <see cref="SortRequest"/>.
        /// </summary>
        /// <param name="sortAlgorithm">Sort algorithm name.</param>
        /// <param name="array">Array to sort.</param>
        /// <exception cref="ArgumentNullException">
        /// Throws when one of the given arguments is null.
        /// </exception>
        public SortRequest(string sortAlgorithm, int[] array)
        {
            if (sortAlgorithm == null || sortAlgorithm.Length == 0)
            {
                throw new ArgumentNullException(nameof(sortAlgorithm));
            }
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            SortAlgorith = sortAlgorithm;
            Array = array;
        }

        /// <summary>
        /// Tries to parse command line arguments as <see cref="SortRequest"/>.
        /// </summary>
        /// <param name="args">CLI arguments.</param>
        /// <param name="request">Parsed request.</param>
        /// <returns>
        /// Returns <c>true</c> in case of success, otherwise returns <c>false</c>.
        /// </returns>
        public static bool TryParse(string[] args, out SortRequest request)
        {
            if (args == null || args.Length == 0)
            {
                int[] emptArray = new int[0];
                request = new SortRequest("empty array", emptArray);
                return false;
            }
            bool result = true;
            int[] array = new int[args.Length - 1];
            int temp;
            for (int i = 1; i < args.Length; i++)
            {
                if (!int.TryParse(args[i], out temp))
                {
                    result = false;
                    break;
                }
                array[i - 1] = int.Parse(args[i]);
            }
            request = new SortRequest(args[0], array);
            return result;
        }
    }
}
