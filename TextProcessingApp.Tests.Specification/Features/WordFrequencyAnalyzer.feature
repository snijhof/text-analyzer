Feature: WordFrequencyAnalyzer

Background: 
	Given the text is 'The sun shines over the lake'

Scenario: Calculate the frequency of a word in a text
	When the frequency of 'over' is calculated
	Then the frequency of 'over' should be 1

Scenario: Calculate the frequency of a word in a text which should ignore casing
	When the frequency of 'OVER' is calculated
	Then the frequency of 'OVER' should be 1

Scenario: Calculate the highest frequency in a text
	When the highest frequency in a text is calculated
	Then the highest frequency should be 2
	
Scenario: Calculate the n most frequent words in a text
	When the 2 most frequent words are calculated
	Then the most frequent words should be in the following order: 
		| Word | Frequency |
		| the  | 2         |
		| lake | 1         |

Scenario: When calculating the n most frequent words in a text and words have the same frequency the should be orderd in alphabetical order
	When the 5 most frequent words are calculated
	Then the most frequent words should be in the following order: 
		| Word   | Frequency |
		| the    | 2         |
		| lake   | 1         |
		| over   | 1         |
		| shines | 1         |
		| sun    | 1         |