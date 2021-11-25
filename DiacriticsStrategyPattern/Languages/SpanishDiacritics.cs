using System;
using Diacritics;
using Diacritics.AccentMappings;

namespace DiacriticsStrategyPattern.Languages
{
    public class SpanishDiacritics : ILanguageDiacritics
    {
        public Language Language => Language.ES;

        public string Process(string input)
        {
            var mapper = new DiacriticsMapper(new SpanishAccentsMapping());

            return mapper.RemoveDiacritics(input);
        }
    }
}
