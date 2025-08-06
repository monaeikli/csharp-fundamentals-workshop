using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop.console
{
    public class NameGuessGame
    {
        private string _name;
        private int _count = 0;
        private Dictionary<int, char> guesses = new Dictionary<int, char>();

        public NameGuessGame(string name)
        {
            _name = name;
        }
        public void Start()
        {
            while (true)
            {
                _count++;

                if (guesses.Count > 0)
                {
                    if (guesses.Count == _name.Length)
                    {
                        Console.WriteLine("Well done... you guessed the name!");
                        break;
                    }

                    foreach (KeyValuePair<int, char> kvp in guesses)
                    {
                        Console.WriteLine($"Key:{kvp.Key} Value: {kvp.Value}");
                    }

                }

                Console.WriteLine("Enter a single letter, or qqq to quit!");
                string input = Console.ReadLine();

                if (input == "qqq") break;

                if (input.Length == 1)
                {
                    Console.WriteLine($"Valid input: {input}");
                }
                else
                {
                    continue;
                }
                //ignored by continue
                if (_name.Contains(input, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Letter is in the name!");
                    guesses.Add(_count, char.Parse(input));
                }
            }
        }
    }
}
