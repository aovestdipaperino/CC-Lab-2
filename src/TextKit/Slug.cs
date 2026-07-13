namespace TextKit;

public static class Slug
{
  public static string Ify(string input)
  {
    return input.Trim().ToLowerInvariant().Replace(' ', '-'); 
  }
}