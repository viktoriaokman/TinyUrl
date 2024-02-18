using TinyUrl.Models;

namespace TinyUrl.Repositories
{
  public class UrlRepository : IUrlRepository
  {
    private IList<UrlEntry> _urlDB;
    private readonly IConfiguration _config;
    public UrlRepository(IConfiguration configuration)
    {
      _config = configuration;
      _urlDB = new List<UrlEntry>();
    }

    public string? GetOriginalUrl(string tinyUrl)
    {
      return _urlDB.FirstOrDefault(urlEntry => urlEntry.TinyUrl == tinyUrl)?.OriginalUrl;
    }
    public void SaveUrlEntity(UrlEntry urlEntry)
    {
      _urlDB.Add(urlEntry);
    }
    public string GetTinyUrl(string originalUrl)
    {
      return (_urlDB.First(urlEntry => urlEntry.OriginalUrl == originalUrl)).TinyUrl;
    }
  }
}