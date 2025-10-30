using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Intrinsics.X86;
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

class Black
{
    public static void Market()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Market");
        Console.ResetColor();
        Console.ReadLine();

        Console.WriteLine("Welcome to the ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Market");
        Console.ResetColor();
        Console.WriteLine("Here you can buy Goods ");
        Console.WriteLine("like items that can aid you in battle");
        Console.WriteLine("");
        Console.WriteLine("Or upgrades like");
        Console.WriteLine("Weapon upgrades");
        Console.WriteLine("Health upgrades");
        Console.WriteLine("And so on");

        // continue here
    }
}

class Action
{
    public static int round = 1;
    public static int Enemy_1 = 100;
    public static int Enemy_2 = 100;
    public static int Enemy_damage = 10;
    public static void Text(Character player)
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
                Console.WriteLine("You activated your Defense stance");
                Console.WriteLine("Defense stance = Your oponents deal half damage for 2 round");
                bool defense_stance = true;
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

        Console.WriteLine("!! The skeletons strikes back !!");
        Console.WriteLine($"The skeletons did -{Enemy_damage}");
        player.Health -= Enemy_damage;
        Console.WriteLine($"Your HP = {player.Health}");
        Console.ReadLine();

        if (Enemy_1 >= 0 && Enemy_2 >= 0)
        {
            Console.WriteLine("!!! Round cleared !!!");
            Console.WriteLine("Moving on to the next room");
            Console.ReadLine();
            Console.WriteLine("To the ");
            round++;

        }
    }
}

