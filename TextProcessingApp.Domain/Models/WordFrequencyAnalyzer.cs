using System.Text.RegularExpressions;
using TextProcessingApp.Domain.Extensions;

namespace TextProcessingApp.Domain.Models
{
    public class WordFrequencyAnalyzer : IWordFrequencyAnalyzer
    {
        public int CalculateFrequencyForWord(string text, string word)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException($"{nameof(text)} must contain text");
            }

            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentException($"{nameof(word)} must contain text");
            }

            return Regex.Matches(text, word, RegexOptions.IgnoreCase)
                .Count;
        }

        public int CalculateHighestFrequency(string text)
        {
            var words = GetWords(text);

            var wordFrequencies = GetWordFrequencies(words);

            return wordFrequencies.GetHighestFrequency();
        }

        public IList<IWordFrequency> CalculateMostFrequentNWords(string text, int n)
        {
            var words = GetWords(text);

            var wordFrequencies = GetWordFrequencies(words);

            return wordFrequencies.OrderBy(foundWord => foundWord.Name)
                .OrderByDescending(foundWord => foundWord.Frequency)
                .Take(n)
                .ToList();
        }

        private static IEnumerable<string> GetWords(string text)
        {
            return Regex.Matches(text, @"[a-z]+", RegexOptions.IgnoreCase)
                .Select(match => match.Value);
        }

        private static List<IWordFrequency> GetWordFrequencies(IEnumerable<string> words)
        {
            var foundWords = new List<IWordFrequency>();

            foreach (var word in words)
            {
                if (foundWords.Any(foundWord => foundWord.Name.Equals(word, StringComparison.OrdinalIgnoreCase)))
                {
                    WordFrequency foundWord = (WordFrequency)foundWords.Single(foundWord => foundWord.Name.Equals(word, StringComparison.OrdinalIgnoreCase));
                    foundWord.IncrementFrequency();
                }
                else
                {
                    foundWords.Add(new WordFrequency(word.ToLower()));
                }
            }

            return foundWords;
        }
    }
}
