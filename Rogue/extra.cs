using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

class Loadingscreen
{
    public static void Hello()
    {
        string[] spinner = { "/", "-", "\\", "|" };
        for (int i = 0; i < 40; i++)
        {
            Console.Write($"\rLoading {spinner[i % spinner.Length]}");
            Thread.Sleep(100);
        }
        Console.WriteLine("\rLoading complete!");
    }
}

class Character
{
    public string Name;
    public int Health;
    public int Attack;
    public int Defense;
    public string Ability;

    public Character(string name, int health, int attack, int defense, string ability)
    {
        Name = name;
        Health = health;
        Attack = attack;
        Defense = defense;
        Ability = ability;
    }
}

class Action
{
    public static void Text()
    {
        while (true)
        {
            Console.WriteLine("---- Choose Your action ----");
            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-| Attack |-");
            Console.ResetColor();


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-| Defend |-");
            Console.ResetColor();


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-| Item |-");
            Console.ResetColor();


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-| Special |-");
            Console.ResetColor();


            Console.WriteLine();
            string answer = Console.ReadLine().Trim().ToLower();


            if (answer == "attack")
            {
                // Add attack logic here
                break;
            }
            else if (answer == "defend")
            {
                // Add defend logic here
                break;
            }
            else if (answer == "item")
            {
                // Add item logic here
                break;
            }
            else if (answer == "special")
            {
                // Add special logic here
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Try again.");
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}