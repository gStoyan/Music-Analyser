

using System;

namespace MusicAnalyser.Infrastructure.BlockExtensions.Implementations
{
    public class BlockHelper : IBlockHelper
    {
        public string GetColor(int currentTone, int currentTime, int prevTone, int prevTime)
        {
            if (prevTime == currentTime || prevTime - currentTime == 1 || currentTime - prevTime == 1)
            {
                if (currentTone > prevTone)
                {
                    return Constants.LightGrey;
                }

                if (currentTone < prevTone)
                {
                    return Constants.DarkGrey;
                }
            }
            return Constants.White;
        }

        public Tuple<int, int> GetYAxis(string color, int yStart, int yEnd)
        {
            switch (color)
            {
                case Constants.LightGrey: //Dark Grey
                    yStart += 5;
                    yEnd += 5;
                    if (yStart == 30)
                    {
                        yStart += 5;
                        yEnd += 5;
                    }
                    break;
                case Constants.DarkGrey: //Light Grey
                    yStart -= 5;
                    yEnd -= 5;
                    if (yStart == 30)
                    {
                        yStart -= 5;
                        yEnd -= 5;
                    }
                    break;
                case Constants.White:
                    yStart = 30;
                    yEnd = 60;
                    break;
                default:
                    break;
            }
            return Tuple.Create(yStart, yEnd);
        }
    }
}
