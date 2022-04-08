namespace Hw2.Exercise1
{
    /// <summary>
    /// Brackets application core.
    /// </summary>
    public sealed class BracketsApplication
    {
        /// <summary>
        /// Brackets application return codes.
        /// </summary>
        public enum ReturnCode
        {
            ValidSequence = 0,
            InvalidArgs = -1,
            InvalidSequence = -2
        }

        /// <summary>
        /// Runs brackets application.
        /// </summary>
        /// <param name="args">Command line arguments</param>
        /// <returns>
        /// Returns <see cref="ReturnCode.ValidSequence"/> in case of valid brackets sequence from  <paramref name="args"/>.
        /// Returns <see cref="ReturnCode.InvalidArgs"/> in case of null <paramref name="args"/>.
        /// Returns <see cref="ReturnCode.InvalidSequence"/> in case of invalid brackets sequence from <paramref name="args"/>.
        /// </returns>
        public ReturnCode Run(string[] args)
        {
            if (args == null)
                return ReturnCode.InvalidArgs;

            var validator = new BracketsValidator();
            var sequence = string.Concat(args);
            var isSequenceValid = validator.IsSequenceValid(sequence);

            Console.WriteLine(isSequenceValid);

            return isSequenceValid
                ? ReturnCode.ValidSequence
                : ReturnCode.InvalidSequence;
        }
    }
}
