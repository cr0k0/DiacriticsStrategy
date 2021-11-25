using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiacriticsStrategyPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IDiacriticsService _diacritics;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDiacriticsService diacritics)
        {
            _logger = logger;
            _diacritics = diacritics;
        }

        [HttpGet]
        [Route("German")]
        public IActionResult Get()
        { 
            var germanText = "Die in diesem Bericht aufgeführten Ergebnisse für das Jahr 2020 zeigen, dass der Ausbau erneuerbarer Energien wesentlich zur Erreichung der Klimaschutzziele in Deutschland beiträgt. Insgesamt werden in allen Verbrauchssektoren fossile Energieträger zunehmend durch erneuerbare Energien ersetzt und damit dauerhaft ⁠Treibhausgas⁠- und Luftschadstoffemissionen vermieden. Die Ergebnisse zeigen darüber hinaus, dass eine differenzierte Betrachtung verschiedener Technologien und Sektoren sinnvoll und notwendig ist, wenn es z.B. darum geht, gezielte Maßnahmen zum ⁠Klimaschutz⁠ und der Luftreinhaltung abzuleiten, da sich die spezifischen Vermeidungsfaktoren für die untersuchten Treibhausgase und Luftschadstoffe teilweise erheblich unterscheiden. Im Ergebnis weist die Netto - Emissionsbilanz der erneuerbaren Energien unter Berücksichtigung der Vorketten eine Vermeidung von Treibhausgasemissionen in Höhe von rund 230 Mio.t ⁠CO2⁠ - Äquivalente(CO2 - Äq.) im Jahr 2020 aus.Auf den Stromsektor entfielen 179 Mio.t CO2-Äq., davon sind 157 Mio.t der Strommenge mit EEG - Vergütungsanspruch zuzuordnen.Im Wärmesektor wurden 41 Mio.t und durch biogene Kraftstoffe 11 Mio.t CO2-Äq.vermieden.";

            var result = _diacritics.Process(germanText, Language.DE);
            return Content(result.ToString());
        }

        [HttpGet]
        [Route("Spanish")]
        public IActionResult GetSpanish()
        {
            var spanishText = "Mark está de viaje de negocios en Barcelona. Hoy tuvo un día libre y salió a visitar la ciudad. Primero, caminó por La Rambla, la calle más famosa de Barcelona, llena de gente, tiendas y restaurantes.Se dirigió al Barrio Gótico, uno de los sitios más antiguos y bellos de la ciudad.En la Plaza Sant Jaume observó dos de los edificios más importantes: El Palacio de la Generalitat de Catalunya y el Ayuntamiento.";

            return Content(_diacritics.Process(spanishText, Language.ES).ToString());
        }
    }
}
