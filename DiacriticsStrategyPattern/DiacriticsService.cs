using System;
using System.Collections.Generic;
using System.Linq;

namespace DiacriticsStrategyPattern
{
    public class DiacriticsService: IDiacriticsService
    {
        private readonly IEnumerable<ILanguageDiacritics> _languages;

        public DiacriticsService(IEnumerable<ILanguageDiacritics> languages)
        {
            _languages = languages;
        }

        public string Process(string input, Language language)
        { 
            var langProcessor = _languages.FirstOrDefault(x => x.Language == language)?.Process(input);

            return langProcessor;
        }
    }
}
