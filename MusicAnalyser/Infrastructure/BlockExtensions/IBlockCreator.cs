
using MusicAnalyser.Models;
using System.Collections.Generic;

namespace MusicAnalyser.Infrastructure.BlockExtensions
{
    public interface IBlockCreator
    {
        List<Block> CreateBlocks(List<Note> notes);
    }
}
