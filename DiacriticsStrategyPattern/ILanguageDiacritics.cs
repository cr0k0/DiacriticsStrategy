using System;
using Diacritics.AccentMappings;

namespace DiacriticsStrategyPattern
{
    public interface ILanguageDiacritics
    {
        Language Language { get; }

        string Process(string name);
    }
}
