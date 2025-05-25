using HoroscopoPdc.Services;
using Microsoft.AspNetCore.Mvc;

namespace HoroscopoPdc.Controllers
{
    [ApiController]
    [Route("api/goldhoroscope")]
    public class GoldController : ControllerBase
    {

        private readonly HoroscopeService horoscopeService;

        public GoldController(HoroscopeService horoscopeService)
        {
            this.horoscopeService = horoscopeService;
        }

        /// <summary>
        /// Recupera previsão diária
        /// </summary>
        /// <param name="sign"></param>
        /// <returns></returns>
        [HttpGet("{sign}")]
        public async Task<IActionResult> Get(string sign)
        {
            var response = await horoscopeService.GetGoldHoroscopeAsync(sign);
            return Ok(response);
        }
    }
}