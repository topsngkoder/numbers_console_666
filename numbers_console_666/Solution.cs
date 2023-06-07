using Newtonsoft.Json;

namespace Client
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Solution : IComparable<Solution>
    {
        [JsonProperty("numbers")] private int[] numbers;
        [JsonProperty("operators")] private char[] operators;
        [JsonProperty("target")] private int target;

        public Solution(int[] numbers, char[] operators, int target)
        {
            this.numbers = numbers;
            this.operators = operators;
            this.target = target;
        }

        public override string ToString()
        {
            var numbersString = String.Join(",", numbers);
            var operatorsString = String.Join(",", operators);
            return numbersString + operatorsString;
        }

        public string GetLevel()
        {
            return String.Join(",", numbers);
        }

        public int CompareTo(Solution other)
        {
            var sortedThis = this.numbers.OrderBy(n => n).ToArray();
            var sortedOther = other.numbers.OrderBy(n => n).ToArray();

            for (int i = 0; i < sortedThis.Length; i++)
            {
                if (sortedThis[i] > sortedOther[i])
                {
                    return 1;
                }
                if (sortedThis[i] < sortedOther[i])
                {
                    return -1;
                }
            }
            return 0;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            return this.GetHashCode() == obj.GetHashCode();
        }
        public override int GetHashCode()
        {
            var sortedSolutionNumbersList = numbers.OrderBy(n => n).ToArray();
            var hCode = int.Parse(string.Join("", sortedSolutionNumbersList));
            return hCode.GetHashCode();
        }
    }
}