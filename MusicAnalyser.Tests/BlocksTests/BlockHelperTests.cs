
using FluentAssertions;
using MusicAnalyser.Infrastructure;
using MusicAnalyser.Infrastructure.BlockExtensions;
using MusicAnalyser.Infrastructure.BlockExtensions.Implementations;
using Xunit;

namespace MusicAnalyser.Tests.BlocksTests
{
    public class BlockHelperTests
    {
        private IBlockHelper blockHelper;

        public BlockHelperTests()
        {
            this.blockHelper = new BlockHelper();
        }

        [Fact]
        public void GetColor_ReturnsLightGrey()
        {
            //Arrage
            int currentTone = 50;
            int currentTime = 200;
            int prevTone = 40;
            int prevTime = 200;

            //Act
            var color = this.blockHelper.GetColor(currentTone, currentTime, prevTone, prevTime);
            //Assert
            color.Should().Be(Constants.LightGrey);
        }
        [Fact]
        public void GetColor_ReturnsDarkGrey()
        {
            //Arrage
            int currentTone = 40;
            int currentTime = 200;
            int prevTone = 50;
            int prevTime = 200;
            //Act
            var color = this.blockHelper.GetColor(currentTone, currentTime, prevTone, prevTime);
            //Assert
            color.Should().Be(Constants.DarkGrey);
        }
        [Fact]
        public void GetColor_ReturnsWhite()
        {
            //Arrage
            int currentTone = 40;
            int currentTime = 210;
            int prevTone = 50;
            int prevTime = 200;
            //Act
            var color = this.blockHelper.GetColor(currentTone, currentTime, prevTone, prevTime);
            //Assert
            color.Should().Be(Constants.White);
        }
        [Fact]
        public void GetY_ReturnsValue()
        {
            //Arrange
            string color = Constants.LightGrey;
            int yStart = 20;
            int yEnd = 40;
            //Act
            var y = this.blockHelper.GetYAxis(color, yStart, yEnd);
            //Assert
            y.Should().NotBeNull();
        }
    }
}
