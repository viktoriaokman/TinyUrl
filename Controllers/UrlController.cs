using System.Net;
using Microsoft.AspNetCore.Mvc;
using TinyUrl.Models;
using TinyUrl.Repositories;
using TinyUrl.Utils;

namespace TinyUrl.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UrlController : ControllerBase
  {
    private readonly IUrlRepository _urlRepository;
    private readonly IStatisticRepository _statisticRepository;
    private readonly IConfiguration _config;

    public UrlController(IConfiguration configuration, IUrlRepository urlRepository, IStatisticRepository statisticRepository)
    {
      _config = configuration;
      _urlRepository = urlRepository;
      _statisticRepository = statisticRepository;
    }

      [HttpPost]
      public string NewTinyUrl(string url)
      {
        var urlEntry = new UrlEntry {
          OriginalUrl = url,
          TinyUrl = StringGenerator.RandomString()
        };
        System.Console.WriteLine($"tinyUrl {urlEntry.TinyUrl} url {urlEntry.OriginalUrl}");

        _urlRepository.SaveUrlEntity(urlEntry);

        _statisticRepository.AddStatistic(urlEntry.TinyUrl);

        return $"{_config["UrlStr"]}{urlEntry.TinyUrl}";
      }

      [HttpGet("URL/{tinyUrl}")]
      public IActionResult GetUrl(string tinyUrl)
      {
        var url = _urlRepository.GetOriginalUrl(tinyUrl);

        System.Console.WriteLine($"tinyUrl {tinyUrl} url {url}");

        if(string.IsNullOrEmpty(url)) {
          return NotFound();
        }

        return Ok(url);
      }

  }
}

