using TinyUrl.Models;

namespace TinyUrl.Repositories
{
  public interface IStatisticRepository
  {
    IList<StatisticEntry> GetStatistics();
    void UpdateUrlStatistic(string id);
    int? GetUrlStatistic(string id);
    void AddStatistic(string id);
  }
}