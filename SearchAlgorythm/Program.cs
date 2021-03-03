using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchAlgorythm
{
    internal static class Program
    {
        private static List<SomeObject> PossibleResults = new()
        {
            new("Один два три, \"четыре\"? Пять!"),
            new("Четырнадцать... два, шесть семь? Один!"),
            new("Двести двенадцать - двадцать, четыре...")
        };

        private static List<string> GetWords(string original)
        {
            return original
                .Trim()
                .ToLower()
                .Split(' ', ',', '.', '-', '!', '?', '"', '\'')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();
        }

        private static Matching<T> Match<T>(T item, Func<T, string> itemString, string query)
        {
            var originalWords = GetWords(itemString(item));
            var queryWords = GetWords(query);
            var matches = 0;
            queryWords.ForEach(queryWord =>
            {
                foreach (var originalWord in originalWords)
                {
                    if (originalWord.Contains(queryWord))
                    {
                        matches++;
                        break;
                    }
                }
            });

            return new Matching<T>(item, matches);
        }

        private static void Main()
        {
            while (true)
            {
                Console.Write("> ");
                var query = Console.ReadLine();
                var matches = PossibleResults
                    .Select(x => Match(x, x => x.Name, query))
                    .Where(x => (x.Matches >= GetWords(query).Count - 2) && x.Matches > 0)
                    .OrderByDescending(x => x.Matches)
                    .ToList();
                matches.ForEach(Console.WriteLine);
            }
        }
    }
}