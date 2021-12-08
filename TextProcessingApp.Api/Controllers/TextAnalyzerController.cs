using Microsoft.AspNetCore.Mvc;
using TextProcessingApp.Api.Models;
using TextProcessingApp.Domain.Models;

namespace TextProcessingApp.Api.Controllers
{
    [ApiController]
    [Route("text-analyzer")]
    public class TextAnalyzerController : ControllerBase
    {
        private readonly ILogger<TextAnalyzerController> _logger;
        private readonly IWordFrequencyAnalyzer _wordFrequencyAnalyzer;

        public TextAnalyzerController(ILogger<TextAnalyzerController> logger, IWordFrequencyAnalyzer wordFrequencyAnalyzer)
        {
            _logger = logger;
            _wordFrequencyAnalyzer = wordFrequencyAnalyzer;
        }

        [HttpPost("highest-frequency")]
        public ActionResult<int> CalculateHighestFrequency([FromBody] CalculateHighestFrequencyInput input)
        {
            return _wordFrequencyAnalyzer.CalculateHighestFrequency(input.Text);
        }

        [HttpPost("words/{word}/frequency")]
        public ActionResult<int> CalculateFrequencyForWord([FromRoute] string word, [FromBody] CalculateFrequencyForWordInput input)
        {
            return _wordFrequencyAnalyzer.CalculateFrequencyForWord(input.Text, word);
        }

        [HttpPost("most-frequent-n-words")]
        public IList<IWordFrequency> AnalyzeText([FromBody] CalculateMostFrequentNWordsInput input)
        {
            return _wordFrequencyAnalyzer.CalculateMostFrequentNWords(input.Text, input.NumberOfMostFrequentWords);
        }
    }
}