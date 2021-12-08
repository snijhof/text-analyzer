using TextProcessingApp.Domain.Models;

namespace TextProcessingApp.Domain.Extensions
{
    public static class WordFrequencyCollectionExtensions
    {
        public static int GetHighestFrequency(this ICollection<IWordFrequency> wordFrequencies)
        {
            if (wordFrequencies == null || wordFrequencies.Any() is false)
            {
                return 0;
            }

            return wordFrequencies.OrderByDescending(foundWord => foundWord.Frequency)
                .First()
                .Frequency;
        }
    }
}
