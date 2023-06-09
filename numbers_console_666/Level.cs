using Newtonsoft.Json;
using System;

namespace Client
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Level : IComparable<Level>
    {
        Random num = new Random();
        [JsonProperty("numbers")] private int[] numbers;
        [JsonProperty("operators")] private char[] operators;
        //[JsonProperty("target")] private int target;

        public Level(int[] numbers, char[] operators, int target)
        {
            this.numbers = numbers;
            this.operators = operators;
            //this.target = target;
        }

        public override string ToString()
        {
            var numbersString = String.Join(",", numbers);
            var operatorsString = String.Join(",", operators);
            return numbersString + operatorsString;
        }

        public string GetShuffledLevel()
        {
            var shuffleList = new List<int>();

            foreach (var number in numbers)
            {
                int random = num.Next(2);
                shuffleList.Add(number);
                if (random > 0)
                {
                    shuffleList.Reverse();
                }
            }
            return (String.Join("", shuffleList));
        }

        public int CompareTo(Level other)
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
            if (obj == null)
            {
                return false;
            }
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