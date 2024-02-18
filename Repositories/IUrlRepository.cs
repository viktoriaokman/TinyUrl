using TinyUrl.Models;

namespace TinyUrl.Repositories
{
  public interface IUrlRepository
  {
    string? GetOriginalUrl(string tinyUrl);
    void SaveUrlEntity(UrlEntry urlEntry);
    string GetTinyUrl(string originalUrl);
  }
}