using System;
using System.Globalization;
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
            //secondStar(); //F*CKMYLIFE
            DayTwoFirstStar();
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
        //public static void DayTwoFirstStar()
        //{
        //    string[] gameLines = System.IO.File.ReadAllLines(@"C:\Users\jrotter\Desktop\advent2.txt");
        //    int sumOfGameIDs = 0;

        //    foreach (string  gameLine in gameLines)
        //    {
        //        string[] gameID = gameLine.Split(':');
        //        string[] colorParts = gameID[1].Split(new char[] { ',', ';' });

        //        Dictionary<string, int> colorCounts = new Dictionary<string, int>();

        //        foreach (var part in colorParts)
        //        {
        //            string[] colorCount = part.Trim().Split(' ');
        //            if (colorCount.Length == 2)
        //            {
        //                int count;
        //                if (int.TryParse(colorCount[0], out count))
        //                {
        //                    string color = colorCount[1];
        //                    if (colorCounts.ContainsKey(color))
        //                    {
        //                        colorCounts[color] += count;
        //                    }
        //                    else
        //                    {
        //                        colorCounts.Add(color, count);
        //                    }
        //                }
        //            }

        //            foreach (var color in colorCounts)
        //            {
        //                Console.WriteLine($"{color.Key}: {color.Value}");

        //            }
        //            //foreach (var ID in gameID)
        //            //{
        //            //    if (colorCounts.ContainsKey("red") && colorCounts["red"] <= 12 &&
        //            //        colorCounts.ContainsKey("green") && colorCounts["green"] <= 13 &&
        //            //        colorCounts.ContainsKey("blue") && colorCounts["blue"] <= 14)
        //            //    {
        //            //        sumOfGameIDs += int.Parse(ID.Split(' ')[1]);
        //            //    }
        //            //}

        //        }
        //        Console.WriteLine(gameID[0]);           

        //    }
        //    Console.WriteLine("Sum of Game IDs: " + sumOfGameIDs);


        //}          
        public static void DayTwoFirstStar()
        {
            List<AdventGame> games = new List<AdventGame>();
            string[] gameLines = System.IO.File.ReadAllLines(@"C:\Users\jrotter\Desktop\advent2.txt");
            int sumOfGameIDs = 0;

            foreach (string gameLine in gameLines)
            {
                string[] gameID = gameLine.Split(':');
                AdventGame game = new AdventGame(int.Parse(gameID[0].Split(' ')[1])); // Ekelhaft
                string[] colors = gameID[1].Split(new char[] { ',', ';' });

                foreach (string color in colors)
                {
                    string[] colorValueAndKey = color.Trim().Split(' ');
                    int colorValue = int.Parse(colorValueAndKey[0]);
                    string colorKey = colorValueAndKey[1];

                    AdventGameFrame frame = new AdventGameFrame(colorValue, colorKey);

                    game.frames.Add(frame);
                }

                games.Add(game);
            }


            foreach (AdventGame game in games)
            {
                game.SortFrames();
                if (game.IsValid(game.sortedFrames[0].Value, game.sortedFrames[1].Value, game.sortedFrames[2].Value) == true) 
                {
                    sumOfGameIDs = game.GameId;
                }
                Console.WriteLine(game.ToString() + "\n\n");
            }
            Console.WriteLine($"sumOfGameIDs "\n\n"); 
        }
    }
}   
    
