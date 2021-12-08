namespace TextProcessingApp.Domain.Models
{
    public class WordFrequency : IWordFrequency
    {
        private readonly string _name;
        private int _frequency;

        public WordFrequency(string name, int frequency = 1)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"{nameof(name)} cannot be null or whitespace.");
            }

            if (frequency < 1)
            {
                throw new ArgumentException($"{nameof(frequency)} can't be lower then 1");
            }

            _name = name;
            _frequency = frequency;
        }

        public string Name => _name;

        public int Frequency => _frequency;

        public void IncrementFrequency()
        {
            _frequency++;
        }
    }
}
