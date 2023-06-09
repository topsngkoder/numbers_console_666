namespace Client
{
    public class Game
    {

        private int _target = 10;
        private bool _endGame = true;
        private LevelsManager _levelsManager;

        public Game(List<Solution> allLevels)
        {
             _levelsManager = new LevelsManager(allLevels);
        }

        public bool isPlaying()
        {
            return _endGame;
        }

        public void Play()
        {
            var currentSolution = _levelsManager.GetCurrentSolution();
            var formatedTask = GenerateTask(currentSolution);

            Console.Clear();

            Console.WriteLine($"Получите 10 из чисел: {formatedTask}");
            Console.WriteLine($"Ответ вводите в формате a+b+c+d. Для выхода введите 10");

            var answerInput = Console.ReadLine();
            
            if (answerInput == "")
            {
                Console.WriteLine("Введите ответ!");
                Play();
            }
            if (answerInput == "10")
            {
                _endGame = false;
                return;
            }

            var answer = CalculationResult(answerInput);

            var isAnswerCorrect = answer == _target;

            if (isAnswerCorrect)
            {
                Console.WriteLine("Поздравляем, все верно! Для продолжения игры нажмите Enter");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Ответ неправильный! Чтобы попытаться еще раз нажмите Enter");
                Console.ReadLine();
                Play();
            }
        }

        private int? CalculationResult(string inputString)
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
            return result;
        }

        private string GenerateTask(Solution level)
        {
            return level.GetLevel();
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