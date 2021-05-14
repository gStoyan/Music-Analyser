using MusicAnalyser.Models;
using System;
using System.Collections.Generic;
namespace MusicAnalyser.Infrastructure.BlockExtensions.Implementations
{
    public class BlockCreator : IBlockCreator
    {
        public List<Block> CreateBlocks(List<Note> notes)
        {
            int yStart = 30;
            int yEnd = 60;
            string color = "White";
            List<Block> blocks = new List<Block>();
            List<int> toneValues = new List<int>();
            List<int> pauses = new List<int>();
            List<int> timeValues = new List<int>();
            List<string> names = new List<string>();
            foreach (var note in notes)
            {
                names.Add(note.Name);
                toneValues.Add(note.Tone);
                timeValues.Add(note.Time);
                pauses.Add(note.Pause);
            }

            for (int i = 0; i < toneValues.Count ; i++)
            {
                if (i == 0)
                {
                    continue;
                }
                int currentTone = toneValues[i];
                int currentTime = timeValues[i];
                int pause = pauses[i];
                int prevTone = toneValues[i - 1];
                int prevTime = timeValues[i - 1];
                string name = names[i];
                color = GetColor(currentTone, currentTime, prevTone, prevTime);
                var y = GetYAxis(color, yStart,yEnd);
                blocks.Add(new Block
                {
                    Name = name,
                    Color = color,
                    YStart = y.Item1,
                    YEnd = y.Item2,
                    Time = currentTime,
                    Pause = pause
                });
                yStart = y.Item1;
                yEnd = y.Item2;
            }
            return blocks;
        }

        private Tuple<int, int> GetYAxis(string color,int yStart, int yEnd)
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
                    yStart =30;
                    yEnd =60;
                    break;
                default:
                    break;
            }
            return Tuple.Create(yStart, yEnd);
        }

        private string GetColor(int currentTone, int currentTime, int prevTone, int prevTime)
        {
            if (prevTime == currentTime || prevTime - currentTime ==1 ||currentTime - prevTime ==1 )
            {
                if (currentTone>prevTone)
                {
                    return Constants.LightGrey; 
                }

                if (currentTone< prevTone)
                {
                    return Constants.DarkGrey; 
                }
            }
            return Constants.White;            
        }
    }
}
