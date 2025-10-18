using System;
using System.Threading;

Console.WriteLine("Hello and welcome to a rogue like game");
Console.WriteLine("Press enter to load the game");
    Console.ReadLine();

Loadingscreen.Hello();
    Console.ReadLine();

Console.WriteLine("A brief explnation of how the game works");

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine(" 1. its a infinity loop game");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine(" 2. You gather XP, loot, and power-ups to survive the difficult waves");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(" 3. Use the coins you get by defeting a wave of enemys to buy yourslef some fresh and cool equipments");
Console.ResetColor();

Console.ReadLine();

