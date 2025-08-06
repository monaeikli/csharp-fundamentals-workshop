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
                    if (_name.ToLower().Distinct().All(c => guesses.Values.Any(g => char.ToLower(g) == c)))
                    {
                        Console.WriteLine($"Well done... you guessed the name! The answer was: {_name}!");
                        break;
                    }

                    string display = "";
                    for (int i = 0; i < _name.Length; i++)
                    {
                        char c = _name[i];
                        if (guesses.Values.Any(g => char.ToLower(g) == char.ToLower(c)))
                        {
                            display += c;
                        }
                        else
                        {
                            display += "-";
                        }
                    }
                    Console.WriteLine(display);
                }
                Console.WriteLine();
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
                char guessedChar = char.ToLower(input[0]);

                if (guesses.Values.Any(c => char.ToLower(c) == guessedChar))
                {
                    Console.WriteLine("You already guessed that letter!");
                    continue;
                }

                if (_name.Contains(guessedChar, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Letter is in the name!");
                    guesses.Add(_count, input[0]);
                }
            }
        }
    }
}
