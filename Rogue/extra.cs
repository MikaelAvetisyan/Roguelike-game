using System;
using System.Diagnostics.CodeAnalysis;
using System.Security;
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
    public static void Text(Character player)
    {
        int Enemy_1 = 100;
        int Enemy_2 = 100;
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
                int damage = player.Attack;
                while (true)
                {
                    Console.WriteLine("Which skeleton do you attack");
                    Console.WriteLine("Skeleton 1 or Skeleton 2");
                    string attack_answer = Console.ReadLine().Trim().ToLower();
                    if (attack_answer == "skeleton 1")
                    {
                        Enemy_1 -= damage;
                        Enemy_2 -= damage / 2;
                        Console.WriteLine("You attacked Skeleton 1");
                        Console.WriteLine($"You did {damage} Damage to Skeleton 1");
                        Console.WriteLine("While you swung your sword you hit the other skeleton too");
                        Console.ReadLine();
                        Console.WriteLine($"Skeleton 1 HP = {Enemy_1}");
                        Console.WriteLine($"Skeleton 2 HP = {Enemy_2}");
                        break;
                    }

                    else if (attack_answer == "skeleton 2")
                    {
                        Enemy_1 -= damage / 2;
                        Enemy_2 -= damage;
                        Console.WriteLine("You attacked Skeleton 2");
                        Console.WriteLine($"You did {damage} Damage to Skeleton ");
                        Console.WriteLine("While you swung your sword you hit the other skeleton too");
                        Console.ReadLine();
                        Console.WriteLine($"Skeleton 2 HP = {Enemy_2}");
                        Console.WriteLine($"Skeleton 1 HP = {Enemy_1}");
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Invalid Answer!");
                        Console.WriteLine("You got to write eather:");
                        Console.WriteLine("Skeleton 1 or Skeleton 2");
                    }
                    Console.ReadLine();
                }
                break;
            }
            else if (answer == "defend")
            {
                
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