using System.Collections;

namespace Hw2.Exercise1
{
    /// <summary>
    /// Brackets sequence validator.
    /// </summary>
    public class BracketsValidator
    {
        /// <summary>
        /// Validates chars sequence if all brackets are closed in right order.
        /// Supported brackets : '{', '}', '[', ']', '(', ')', '<', '>'.
        /// </summary>
        /// <param name="sequence">Char sequence.</param>
        /// <returns>
        /// Returns <c>true</c> if all brackets are closed in the right order (or no brackets at all). 
        /// Otherwise returns <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">Sequence is null.</exception>
        public bool IsSequenceValid(string sequence)
        {
            if (sequence is null)
                throw new ArgumentNullException(nameof(sequence));

            Stack<char> brackets = new Stack<char>();

            for (int i = 0; i < sequence.Length; i++)
            {
                switch (sequence[i])
                {
                    case '(':
                    case '{':
                    case '[':
                    case '<':
                        brackets.Push(sequence[i]);
                        break;
                    case ')':
                    case '}':
                    case ']':
                    case '>':
                        if (brackets.Count == 0)
                        {
                            return false;
                        }
                        else if (BracketMatch(brackets.Pop(), sequence[i]) == false)
                        {
                            return false;
                        }
                        break;
                }
            }
            if (brackets.Count != 0)
            {
                return false;
            }

            return true;
        }
        public static bool BracketMatch (char open, char close)
        {
            return (open == '(' && close == ')') || (open == '<' && close == '>') ||
            (open == '[' && close == ']') || (open == '{' && close == '}');
        }
    }
}
