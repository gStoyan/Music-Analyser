using FluentAssertions;
using MusicAnalyser.Infrastructure.TextsExtensions;
using MusicAnalyser.Infrastructure.TextsExtensions.Implementations;
using Xunit;

namespace MusicAnalyser.Tests.TextsTests
{
    public class TextParserTests
    {
        private ITextParser textParser;

        public TextParserTests()
        {
            this.textParser = new TextParser();
        }
        [Fact]
        public void TextParser_ReturnsLines()
        {
            //Arrange
            string content = "test \n" +
                             "test line 2";
            //Act
            var lines = this.textParser.ParseCsv(content);
            //Assert
            lines.Count.Should().Be(2);
        }
    }
}
