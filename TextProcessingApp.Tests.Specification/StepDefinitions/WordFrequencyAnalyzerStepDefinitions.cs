using TechTalk.SpecFlow.Assist;
using TextProcessingApp.Domain.Models;
using TextProcessingApp.Tests.Specification.Contexts;
using TextProcessingApp.Tests.Specification.Models;

namespace TextProcessingApp.Tests.Specification.StepDefinitions
{
    [Binding]
    public sealed class WordFrequencyAnalyzerStepDefinitions
    {
        private readonly WordFrequencyAnalyzerScenarioContext _context;
        private readonly WordFrequencyAnalyzer _sut;

        public WordFrequencyAnalyzerStepDefinitions(WordFrequencyAnalyzerScenarioContext wordFrequencyAnalyzerScenarioContext)
        {
            _context = wordFrequencyAnalyzerScenarioContext;
            _sut = new WordFrequencyAnalyzer();
        }

        [Given("the text is '(.*)'")]
        public void GivenTheTextIs(string text)
        {
            _context.Text = text;
        }

        [When("the frequency of '(.*)' is calculated")]
        public void WhenTheFrequencyOfIsCalculated(string word)
        {
            var frequency = _sut.CalculateFrequencyForWord(_context.Text, word);
            
            _context.Result = (Word: word, Frequency: frequency);
        }

        [When("the (.*) most frequent words are calculated")]
        public void WhenTheMostFrequentWordsAreCalculated(int numberOfMostFrequentNumbers)
        {
            _context.MostFrequentWords = _sut.CalculateMostFrequentNWords(_context.Text, numberOfMostFrequentNumbers);
        }

        [When("the highest frequency in a text is calculated")]
        public void WhenTheHighestFrequencyInATextIsCalculated()
        {
            _context.HighestFrequency = _sut.CalculateHighestFrequency(_context.Text);
        }

        [Then("the frequency of '(.*)' should be (.*)")]
        public void ThenTheResultShouldBe(string word, int frequency)
        {
            _context.Result.Word.Should().Be(word);
            _context.Result.Frequency.Should().Be(frequency);
        }

        [Then("the highest frequency should be (.*)")]
        public void ThenTheHighestFrequencyShouldBe(int frequency)
        {
            _context.HighestFrequency.Should().Be(frequency);
        }

        [Then(@"the most frequent words should be in the following order:")]
        public void ThenTheMostFrequentWordsShouldBeInTheFollowingOrder(Table mostFrequentWordsTable)
        {
            var mostFrequentWords = mostFrequentWordsTable.CreateSet<WordFrequencyTableEntry>()
                .Select(word => new WordFrequency(word.Word, word.Frequency) as IWordFrequency);

            var intersectedList = _context.MostFrequentWords.Intersect(mostFrequentWords);
            intersectedList.Count().Should().Be(0);
        }
    }
}