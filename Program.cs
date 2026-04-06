using playingcards.Models;
using playingcards.Services;

Game game = new();

string[] segs = Console.ReadLine()!.Split(' ');
game.AddCard(PlayingCard.Parse(segs[0], segs[1]));
Console.WriteLine(game.CardString(0));

segs = Console.ReadLine()!.Split(' ');
game.AddCard(PlayingCard.Parse(segs[0], segs[1]));
Console.WriteLine(game.CardString(1));
Console.WriteLine(game.CardBeats(0, 1) ? "true" : "false");