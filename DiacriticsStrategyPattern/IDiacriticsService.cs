using System;
namespace DiacriticsStrategyPattern
{
    public interface IDiacriticsService
    {
        string Process(string input, Language language);
    }
}
