using HoroscopoPdc.Services;
using Microsoft.AspNetCore.Mvc;

namespace HoroscopoPdc.Controllers
{
    [ApiController]
    [Route("api/bronzehoroscope")]
    public class BronzeController : ControllerBase
    {

        private readonly HoroscopeService horoscopeService;

        public BronzeController(HoroscopeService horoscopeService)
        {
            this.horoscopeService = horoscopeService;
        }

        /// <summary>
        /// Recupera previsão mensal
        /// </summary>
        /// <param name="sign"></param>
        /// <returns></returns>
        [HttpGet("{sign}")]
        public async Task<IActionResult> Get(string sign)
        {
            var response = await horoscopeService.GetBronzeHoroscopeAsync(sign);
            return Ok(response);
        }
    }
}