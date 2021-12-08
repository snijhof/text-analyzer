namespace TextProcessingApp.Api.Models
{
    public class CalculateMostFrequentNWordsInput
    {
        public string Text { get; set; }
        public int NumberOfMostFrequentWords { get; set; }
    }
}