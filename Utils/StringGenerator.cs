
namespace TinyUrl.Utils
{
  public static class StringGenerator
  {
    private static readonly int Langth = 8;
    private static Random random = new Random();
    public static string RandomString()
    {
      const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
      return new string(Enumerable.Repeat(chars, Langth)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
  }
}