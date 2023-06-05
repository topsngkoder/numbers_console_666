using System;
using System.Collections.Generic;

namespace Client
{
    public class LevelGenerator
    {
        private List<Solution> validSolutions = new List<Solution>();

        public List<Solution> Generate()
        {
            int[] availebleNumerals = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int numbersCount = 4;
            int target = 10;

            int[] combination = new int[numbersCount];

            GenerateCombinations(availebleNumerals, combination, numbersCount, 0, target);

            return validSolutions;
        }

        private void GenerateCombinations(int[] availebleNumerals, int[] combination, int numbersCount, int index, int target)
        {
            if (index == numbersCount)
            {
                var result = FindValidSolutions(combination, target);

                validSolutions.AddRange(result);
                return;
            }

            for (int i = 0; i < availebleNumerals.Length; i++)
            {
                combination[index] = availebleNumerals[i];

                GenerateCombinations(availebleNumerals, combination, numbersCount, index + 1, target);
            }
        }

        private List<Solution> FindValidSolutions(int[] nums, int target)
        {
            var result = new List<Solution>();

            foreach (char op1 in "+-*/")
            {
                foreach (char op2 in "+-*/")
                {
                    foreach (char op3 in "+-*/")
                    {
                        double calculationResult = Calculate(nums[0], nums[1], nums[2], nums[3], op1, op2, op3);

                        if (calculationResult == target)
                        {
                            char[] op = { op1, op2, op3 };

                            var solution = new Solution(nums.ToArray(), op, target);

                            result.Add(solution);
                        }
                    }
                }
            }
            return result;
        }

        static double Calculate(int a, int b, int c, int d, char op1, char op2, char op3)
        {
            double res = ApplyOp(ApplyOp(ApplyOp(a, b, op1), c, op2), d, op3);
            return res;
        }

        static double ApplyOp(double a, double b, char op)
        {
            switch (op)
            {
                case '+': return a + b;
                case '-': return a - b;
                case '*': return a * b;
                case '/': return a / b;
                default: throw new ArgumentException($"Invalid operator '{op}'");
            }
        }
    }

}