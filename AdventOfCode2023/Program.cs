using System;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2023 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        enum Numbers { zero = 0, one = 1, two = 2, three = 3, four = 4, five = 5, six = 6, seven = 7, eight = 8, nine = 9 }

        static void Main(string[] args)
        {

            //firstStar(); 
            secondStar();
        }
        public static void firstStar()
        {
            Console.WriteLine("Enter your text (type 'END' to stop):");
            StringBuilder sb = new StringBuilder();
            int totalSum = 0;

            while (true)
            {
                string line = Console.ReadLine();
                if (line.ToUpper() == "END")
                {
                    break;
                }

                char firstNumber = '\0', lastNumber = '\0';
                foreach (char c in line)
                {
                    if (char.IsDigit(c))
                    {
                        if (firstNumber == '\0')
                        {
                            firstNumber = c;
                        }
                        lastNumber = c;
                    }
                }

                if (firstNumber != '\0')
                {
                    string str = firstNumber.ToString() + lastNumber.ToString();
                    if (int.TryParse(str, out int number))
                    {
                        totalSum += number;
                    }
                }

                sb.AppendLine(line);
            }

            sb.AppendLine("Total sum of all numbers: " + totalSum);
            Console.WriteLine("You entered:\n" + sb.ToString());
        }
        public static void secondStar()
        {
            //FUUUCK
            Regex numberRegex = new Regex(@"\b(one|two|three|four|five|six|seven|eight|nine)\b");
            Dictionary<string, int> numberDictionary = new Dictionary<string, int>()
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 }
            };

            Console.WriteLine("Enter your text (type 'END' to stop):");
            StringBuilder sb = new StringBuilder();
            int totalSum = 0;

            while (true)
            {
                string line = Console.ReadLine();
                if (line.ToUpper() == "END")
                {
                    break;
                }

                MatchCollection matches = numberRegex.Matches(line);
                string firstNumber = null, lastNumber = null;

                foreach (Match match in matches)
                {
                    if (firstNumber == null)
                    {
                        firstNumber = match.Value;
                    }
                    lastNumber = match.Value;
                }

                if (firstNumber != null)
                {
                    string str = firstNumber + (lastNumber ?? firstNumber);
                    if (int.TryParse(str, out int concatenatedNumber))
                    {
                        totalSum += concatenatedNumber;
                        Console.WriteLine($"{line} - {firstNumber} + {lastNumber ?? firstNumber} - {concatenatedNumber}");
                    }
                }

                sb.AppendLine(line);
            }

            sb.AppendLine("Total sum of all numbers: " + totalSum);
            Console.WriteLine("You entered:\n" + sb.ToString());
        }

    }

}   
    
