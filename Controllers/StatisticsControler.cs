using System.Net;
using Microsoft.AspNetCore.Mvc;
using TinyUrl.Models;
using TinyUrl.Repositories;
using TinyUrl.Utils;

namespace TinyUrl.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class StatisticController : ControllerBase
  {
    private readonly IStatisticRepository _statisticRepository;
    private readonly IConfiguration _config;

    public StatisticController(IConfiguration configuration, IStatisticRepository statisticRepository)
    {
      _config = configuration;
      _statisticRepository = statisticRepository;
    }

      [HttpPost("Add")]
      public IActionResult AddStatistic(string id)
      {
        _statisticRepository.AddStatistic(id);
        return Ok();
      }

      [HttpPost("Update")]
      public IActionResult UpdateStatistic(string id)
      {
        _statisticRepository.UpdateUrlStatistic(id);
        return Ok();
      }

      [HttpGet]
      public IActionResult FullStatistics()
      {
        var statistics = _statisticRepository.GetStatistics();

        if(statistics == null || statistics.Count() == 0) 
        { 
          return NotFound();
        }

        return Ok(statistics);
      }

  }
}

