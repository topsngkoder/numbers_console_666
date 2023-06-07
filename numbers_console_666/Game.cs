namespace Client
{
    public class Game
    {
        List<Solution> allLevels = new List<Solution>();
        int currentLevel = 0;

        public Game(List<Solution> levels)
        {
            allLevels = levels;
        }

        internal void Start(int currentLevel)
        {
            var target = 10;

            var formatedTask = GenerateTask(allLevels[currentLevel]);

            Play(10, formatedTask);

            var test = Console.ReadLine();

            FindResult(test);
        }

        private void Play(int target, string taskNumbers)
        {
            Console.Clear();
            Console.WriteLine($"Получите 10 из чисел: {taskNumbers}");

            var answerInput = Console.ReadLine();
            var answer = ConvertInputAnswer(answerInput);
            var isSucces = answer == target;

            if (isSucces)
            {
                Console.WriteLine("Поздравляем, все верно! Для продолжения игры нажмите Enter");
                Console.ReadLine();
                currentLevel++;
                Start(currentLevel);
            }
            else
            {
                Console.WriteLine("Ответ неправильный! Чтобы попытаться еще раз нажмите Enter");
                Console.ReadLine();
                Play(target, taskNumbers);
            }
        }

        private int FindResult(string inputString)
        {
            var ListOfNumbers = new List<int>();
            var ListOfChar = new List<char>();
            var stringNumber = "";

            for (int i = 0; i < inputString.Length; i++)
            {
                if (int.TryParse(inputString[i].ToString(), out var d))
                {
                    stringNumber += inputString[i];
                    if ((i + 1) == inputString.Length)
                    {
                        ListOfNumbers.Add(int.Parse(stringNumber));
                    }
                }
                else
                {
                    ListOfNumbers.Add(int.Parse(stringNumber));
                    stringNumber = "";
                    ListOfChar.Add(inputString[i]);
                }
            }

            var result = ListOfNumbers[0];

            for (int i = 1; i < ListOfNumbers.Count; i++)
            {
                var operationResult = Operation(result, ListOfNumbers[i], ListOfChar[i - 1]);
                if (operationResult.Status == OperationResult.ResultStatus.DivideByZero)
                {
                    Console.WriteLine("Деление на 0 - ОШИБКА!");
                    return -1;
                }
                if (operationResult.Status == OperationResult.ResultStatus.NotFullNumberResult)
                {
                    Console.WriteLine("Не делится - ОШИБКА!");
                    return -2;
                }
                result = operationResult.Result;
            }

            Console.WriteLine(result.ToString());
            return result;
        }

        private string GenerateTask(Solution level)
        {
            return level.GetLevel();
        }

        private int ConvertInputAnswer(string answerInput)
        {
            return FindResult(answerInput);
        }

        int FindTheNumber(string a)
        {
            string res = "";
            foreach (var item in a)
            {
                if (int.TryParse(item.ToString(), out var d))
                {
                    res += item.ToString();
                }
                else return int.Parse(res);
            }
            return int.Parse(res);
        }

        OperationResult Operation(int a, int b, char oper)
        {
            switch (oper)
            {
                case '+':
                    return new OperationResult()
                    {
                        Result = a + b,
                        Status = OperationResult.ResultStatus.Success
                    };
                case '-':
                    return new OperationResult()
                    {
                        Result = a - b,
                        Status = OperationResult.ResultStatus.Success
                    };
                case '*':
                    return new OperationResult()
                    {
                        Result = a * b,
                        Status = OperationResult.ResultStatus.Success
                    };
                case '/':
                    {
                        if (b == 0)
                        {
                            return new OperationResult()
                            {
                                Status = OperationResult.ResultStatus.DivideByZero,
                            };
                        }
                        else if (a % b == 0)

                            return new OperationResult()
                            {
                                Result = a / b,
                                Status = OperationResult.ResultStatus.Success
                            };
                        else return new OperationResult()
                        {
                            Status = OperationResult.ResultStatus.NotFullNumberResult
                        };
                    }
                default: throw new Exception("Operator not found");
            }
        }
    }

    class OperationResult
    {
        public int Result;
        public ResultStatus Status;
        public enum ResultStatus { Success, DivideByZero, NotFullNumberResult }
    }
}