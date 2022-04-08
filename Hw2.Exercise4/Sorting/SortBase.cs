namespace Hw2.Exercise4.Sorting
{
    /// <summary>
    /// Base sort algorithm.
    /// </summary>
    public abstract class SortBase
    {
        /// <summary>
        /// Sort given array.
        /// </summary>
        /// <param name="array">Array to sort.</param>
        /// <exception cref="ArgumentNullException">
        /// Throws when <paramref name="array"/> is null.
        /// </exception>
        public abstract void Sort(int[] array);
    }
}
