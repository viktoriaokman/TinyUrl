using TinyUrl.Models;

namespace TinyUrl.Repositories
{
  public class StatisticRepository : IStatisticRepository
  {
    private IList<StatisticEntry> _statisticsDB;
    public StatisticRepository()
    {
      _statisticsDB = new List<StatisticEntry>();
    }
     public IList<StatisticEntry> GetStatistics()
     {
       return _statisticsDB;
     }
    public void UpdateUrlStatistic(string id)
    {
      var statistic = _statisticsDB.FirstOrDefault(x => (x.Id == id));

      if (statistic == null)
      {
        return;
      }

      statistic.UseCounter++;
    }
    public int? GetUrlStatistic(string id)
    {
      return _statisticsDB.FirstOrDefault(x => (x.Id == id))?.UseCounter;
    }
    public void AddStatistic(string Id)
    {
      _statisticsDB.Add(new StatisticEntry(Id));
    }
  }
}