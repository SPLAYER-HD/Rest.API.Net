using System;
using System.Linq;

namespace Rest.API.Services
{
    public class DefaultReverseWordsService : IReverseWordsService
    {
        public String ReverseWords(String value)
        {
            string [] words =value.Split(" ");
            foreach(string word in words)
            {
                char [] array = word.ToArray();
                Array.Reverse(array);
                words[Array.IndexOf(words, word)] = string.Join("", array);
            }
            return string.Join(" ", words);
        }
    }
}
