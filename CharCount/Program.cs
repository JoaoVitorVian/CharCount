using System;
using System.IO;

namespace CharCounter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Stream stream = File.Open("teste.txt", FileMode.Open);

            List<char> characters = new List<char>();

            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    characters.AddRange(line);
                }
            }

            Dictionary<char, int> charCounts = new Dictionary<char, int>();
            foreach (char c in characters)
            {
                if (!charCounts.ContainsKey(c))
                {
                    charCounts.Add(c, 1);
                }
                else
                {
                    charCounts[c]++;
                }
            }

            List<KeyValuePair<char, int>> sortedCharCounts = charCounts.OrderByDescending(x => x.Value).ToList();

            foreach (KeyValuePair<char, int> charCount in sortedCharCounts)
            {
                Console.WriteLine("{0}: {1}", charCount.Key, charCount.Value);
            }
        }
    }
}
