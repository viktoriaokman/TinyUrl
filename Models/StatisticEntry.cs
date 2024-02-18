namespace TinyUrl.Models
{
  public class StatisticEntry
  {
    public string Id { get; set; }
    public int UseCounter { get; set; }

    public StatisticEntry(string id)
    {
      this.Id = id;
      UseCounter = 0;
    }
  }
}