using TextProcessingApp.Domain.Models;

namespace TextProcessingApp.Tests.Specification.Contexts
{
    public class WordFrequencyAnalyzerScenarioContext
    {
        public string Text { get; set; }
        public (string Word, int Frequency) Result { get; set; }
        public int HighestFrequency { get; set; }
        public IList<IWordFrequency> MostFrequentWords { get; set; }
    }
}
