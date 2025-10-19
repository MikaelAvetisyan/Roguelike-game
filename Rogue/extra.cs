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