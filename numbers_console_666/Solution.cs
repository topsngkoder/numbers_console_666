using Newtonsoft.Json;

namespace Client
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Solution
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
    }
}