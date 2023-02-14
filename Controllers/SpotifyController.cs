using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netcore_spotify_api.Services;

namespace netcore_spotify_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotifyController : ControllerBase
    {
        private readonly IHttpService _httpService;

        public SpotifyController(IHttpService httpService)
        {
            _httpService = httpService;
        }

        [HttpGet] 
        public async  Task<IActionResult> Get()
        {
           await _httpService.ExecuteAsync();
         return Ok();
        }
    }
}
