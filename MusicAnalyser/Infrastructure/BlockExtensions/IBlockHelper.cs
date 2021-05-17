using System;

namespace MusicAnalyser.Infrastructure.BlockExtensions
{
    public interface IBlockHelper
    {
        string GetColor(int currentTone, int currentTime, int prevTone, int prevTime);

        Tuple<int, int> GetYAxis(string color, int yStart, int yEnd);
    }
}
