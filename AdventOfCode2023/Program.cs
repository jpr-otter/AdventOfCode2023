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
            secondStar(); //F*CKMYLIFE
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
            Dictionary<string, int> numberWords = new Dictionary<string, int>()
            {
                {"zero", 0}, {"one", 1}, {"two", 2}, {"three", 3}, {"four", 4},
                {"five", 5}, {"six", 6}, {"seven", 7}, {"eight", 8}, {"nine", 9}
            };

            Console.WriteLine("Enter your lines (type 'END' to stop):");
            string line;
            int totalSum = 0;
            while ((line = Console.ReadLine()) != "END")
            {
                string numberString = "";
                foreach (var numberWord in numberWords)
                {
                    while (line.Contains(numberWord.Key))
                    {
                        numberString += numberWord.Value.ToString();
                        int index = line.IndexOf(numberWord.Key);
                        line = line.Remove(index, numberWord.Key.Length);
                    }
                }

                if (int.TryParse(numberString, out int number))
                {
                    totalSum += number;
                }
            }

            Console.WriteLine("Total sum of all calibration values: " + totalSum);
        }
        public static void secondSecondStar()
        {
            Dictionary<string, int> numberWords = new Dictionary<string, int>()
            {
                {"zero", 0}, {"one", 1}, {"two", 2}, {"three", 3}, {"four", 4},
                {"five", 5}, {"six", 6}, {"seven", 7}, {"eight", 8}, {"nine", 9}
            };

            Console.WriteLine("Enter your lines (type 'END' to stop):");
            string line;
            int totalSum = 0;
            while ((line = Console.ReadLine()) != "END")
            {
                // Initialize an empty string to hold the numbers found in the line
                string numberString = ""; // <-- This is new

                foreach (var numberWord in numberWords)
                {
                    if (line.Contains(numberWord.Key))
                    {
                        // Add the numeric value of the number word to the number string
                        numberString += numberWord.Value.ToString(); // <-- This is changed

                        // Remove the number word from the line so it's not counted more than once
                        line = line.Replace(numberWord.Key, ""); // <-- This is new
                    }
                }

                // Try to parse the number string into an integer
                if (int.TryParse(numberString, out int number)) // <-- This is changed
                {
                    // Add the number to the total sum
                    totalSum += number; // <-- This is changed
                }
            }

            Console.WriteLine("Total sum of all calibration values: " + totalSum);
        }

    }

}   
    
