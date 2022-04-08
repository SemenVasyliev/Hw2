using System.Diagnostics;
using Hw2.Exercise4.Sorting;

namespace Hw2.Exercise4
{
    /// <summary>
    /// Sort application core.
    /// </summary>
    public sealed class SortApplication
    {
        /// <summary>
        /// Sort application return codes.
        /// </summary>
        public enum ReturnCode
        {
            Success = 0,
            InvalidArgs = -1,
            UnknownSort = -2
        }

        /// <summary>
        /// Runs sort application.
        /// </summary>
        /// <param name="args">Command line arguments</param>
        /// <returns>
        /// Returns <see cref="ReturnCode.Success"/> in case of valid currency exchange.
        /// Returns <see cref="ReturnCode.InvalidArgs"/> in case of invalid <paramref name="args"/>.
        /// Returns <see cref="ReturnCode.UnknownSort"/> in case of unknown sort algorithm from <paramref name="args"/>.
        /// </returns>
        public ReturnCode Run(string[] args)
        {
            if (!SortRequest.TryParse(args, out var request))
                return ReturnCode.InvalidArgs;

            var factory = new SortFactory();
            var sort = factory.ResolveSort(request.SortAlgorith);

            if (sort is null)
                return ReturnCode.UnknownSort;

            var stopWatch = Stopwatch.StartNew();
            var array = request.Array;
            sort.Sort(array);
            stopWatch.Stop();

            var output = string.Concat(array.Select(item => $"{item};"));
            Console.WriteLine(output);
            Console.WriteLine("At '{0}'", stopWatch.Elapsed);

            return ReturnCode.Success;
        }
    }
}
