using Diacritics;
using Diacritics.AccentMappings;

namespace DiacriticsStrategyPattern.Languages
{
    public class GermanDiacritics: ILanguageDiacritics
    {
        public Language Language => Language.DE;

        public string Process(string input)
        {
            var mapper = new DiacriticsMapper(new GermanAccentsMapping());

            var options = new DiacriticsOptions { Decompose = true };
            return mapper.RemoveDiacritics(input, options);
        }
    }
}
