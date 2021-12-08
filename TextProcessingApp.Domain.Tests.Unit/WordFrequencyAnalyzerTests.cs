using FluentAssertions;
using System;
using System.Linq;
using TextProcessingApp.Domain.Models;
using Xunit;

namespace TextProcessingApp.Domain.Tests.Unit
{
    public class WordFrequencyAnalyzerTests
    {
        private readonly WordFrequencyAnalyzer _sut;

        public WordFrequencyAnalyzerTests()
        {
            _sut = new WordFrequencyAnalyzer();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CalculateFrequencyForWord_TextContainsIsNullOrContainsNoCharacters_ThrowsArgumentException(string text)
        {
            // Arrange
            var word = "the";

            // Act
            Action action = () => _sut.CalculateFrequencyForWord(text, word);

            // Assert
            action.Should().Throw<ArgumentException>().WithMessage("text must contain text");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CalculateFrequencyForWord_WordContainsIsNullOrContainsNoCharacters_ThrowsArgumentException(string word)
        {
            // Arrange
            var text = "The sun shines over the lake";

            // Act
            Action action = () => _sut.CalculateFrequencyForWord(text, word);

            // Assert
            action.Should().Throw<ArgumentException>().WithMessage("word must contain text");
        }

        [Fact]
        public void CalculateFrequencyForWord_CalculatesFrequencyForTest_Returns2()
        {
            // Arrange
            var text = "The sun shines over the lake";
            var word = "the";

            // Act
            var result = _sut.CalculateFrequencyForWord(text, word);

            // Assert
            result.Should().Be(2);
        }

        [Fact]
        public void CalculateHighestFrequency_MostFrequentWordExists2Times_Returns2()
        {
            // Arrange
            var text = "The sun shines over the lake";

            // Act
            var result = _sut.CalculateHighestFrequency(text);

            // Assert
            result.Should().Be(2);
        }

        [Fact]
        public void CalculateMostFrequentNWords_Retrieve3MostFrequentWords_ReturnsWords()
        {
            // Arrange
            var n = 3;
            var text = "The sun shines over the lake";

            // Act
            var result = _sut.CalculateMostFrequentNWords(text, n);

            // Assert
            result.Count.Should().Be(n);
            result[0].Name.Should().Be("the");
            result[1].Name.Should().Be("lake");
            result[2].Name.Should().Be("over");
        }
    }
}