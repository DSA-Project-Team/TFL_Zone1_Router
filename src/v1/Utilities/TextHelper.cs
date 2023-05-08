using System;

namespace tflzone1.Models
{
  class TextHelper
  {
    public static string CapitalizeFirstLetter(string content)
    {
      if (string.IsNullOrEmpty(content))
      {
        return content;
      }

      string[] words = content.Split(' ');

      for (int i = 0; i < words.Length; i++)
      {
        if (words[i].Length > 0)
        {
          char firstChar = Char.ToUpper(words[i][0]);
          words[i] = firstChar + words[i].Substring(1).ToLower();
        }
      }

      return string.Join(" ", words);
    }
  }
}