using workshop.console;

Console.Write("What name should your opponent guess: ");
string name = Console.ReadLine();
Console.Clear();

Console.WriteLine("Welcome to Name Guess!");

NameGuessGame game = new NameGuessGame(name);
game.Start();
