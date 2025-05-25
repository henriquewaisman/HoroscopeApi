using HoroscopoPdc.Services;
using Microsoft.AspNetCore.Mvc;

namespace HoroscopoPdc.Controllers
{
    [ApiController]
    [Route("api/silverhoroscope")]
    public class SilverController : ControllerBase
    {

        private readonly HoroscopeService horoscopeService;

        public SilverController(HoroscopeService horoscopeService)
        {
            this.horoscopeService = horoscopeService;
        }

        /// <summary>
        /// Recupera previsão semanal
        /// </summary>
        /// <param name="sign"></param>
        /// <returns></returns>
        [HttpGet("{sign}")]
        public async Task<IActionResult> Get(string sign)
        {
            var response = await horoscopeService.GetSilverHoroscopeAsync(sign);
            return Ok(response);
        }
    }
}