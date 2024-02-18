using Microsoft.AspNetCore.Mvc;
using TinyUrl.Repositories;

namespace TinyUrl.Controllers
{
  [ApiController]
  [Route("t")]
  public class TinyUrlController : ControllerBase
  {
    private readonly IUrlRepository _urlRepository;
    private readonly IStatisticRepository _statisticRepository;

    public TinyUrlController(IUrlRepository urlRepository, IStatisticRepository statisticRepository)
    {
      _urlRepository = urlRepository;
      _statisticRepository = statisticRepository;
    }
      [HttpGet("{tinyUrl}")]
      public IActionResult GetUrl(string tinyUrl)
      {
        var url = _urlRepository.GetOriginalUrl(tinyUrl);

        System.Console.WriteLine($"tinyUrl {tinyUrl} url {url}");

        if(string.IsNullOrEmpty(url)) {
          
          return NotFound();
        }
        _statisticRepository.UpdateUrlStatistic(tinyUrl);
        return Redirect(url);
      }

  }
}

