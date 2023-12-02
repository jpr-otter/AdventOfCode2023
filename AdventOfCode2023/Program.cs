using System;
using System.Text;

namespace AdventOfCode2023 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
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

    }

}   
    
