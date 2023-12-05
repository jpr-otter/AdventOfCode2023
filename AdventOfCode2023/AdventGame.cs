using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    internal class AdventGame
    {
        public int GameId { get; private set; }
        public List<AdventGameFrame> frames = new List<AdventGameFrame>();
        public List<AdventGameFrame> sortedFrames = new List<AdventGameFrame>();

        public AdventGame(int gameId) { 
            
        }

        public override string ToString()
        {
            string output = $"Game: {GameId}\n";

            foreach(AdventGameFrame frame in frames)
            {
                output += frame.ToString() + "\n" ;
            }

            output += $"\nSortierte Frames von Game {GameId}: \n\n" ;

            foreach (AdventGameFrame frame in sortedFrames)
            {
                output += frame.ToString() + "\n";
            }

            return output ;
        }

        public void SortFrames()
        {
            int greenValue = 0;
            int redValue = 0;
            int blueValue = 0;

            foreach(AdventGameFrame frame in frames)
            {
                if(frame.Color == "green")
                {
                    greenValue += frame.Value;
                }
                else if (frame.Color == "red")
                {
                    redValue += frame.Value;
                }
                else
                {
                    blueValue += frame.Value;
                }
            }

            sortedFrames.Add(new AdventGameFrame(greenValue, "Green"));
            sortedFrames.Add(new AdventGameFrame(redValue, "Red"));
            sortedFrames.Add(new AdventGameFrame(blueValue, "Blue"));
        }

        public bool IsValid(int greenValue,int redValue, int blueValue)
        {
            if ( greenValue <= 10 && redValue <=10 && blueValue <= 10)
            {
                return true;
            }
                return false ;
        }
    }
}
