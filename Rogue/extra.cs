using System;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Security;
using System.Security.Cryptography.X509Certificates;
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
    public int MaxHealth;
    public int Attack;
    public int Defense;
    public string Ability;

    public void Heal(int amount)
    {
        Health += amount;
        if (Health > MaxHealth)
            Health = MaxHealth;
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health < 0)
            Health = 0;
    }

    public Character(string name, int health, int attack, int defense, string ability) 
    {
        Name = name;
        Health = health;
        Attack = attack;
        Defense = defense;
        Ability = ability;
    }
}

class Items
{
    public static void commen(Character player)
    {
        int common_rnd = new Random().Next(1, 7);

        if (common_rnd == 1)
        {
            Console.WriteLine("Old Shield (Passive)");
            Console.WriteLine("+1 armor");
            Console.WriteLine("----------");
            Console.WriteLine("Adds extra armor to make you lose less hp");
            player.Defense += 1;
        }

        else if (common_rnd == 2)
        {
            Console.WriteLine("Minor potion (Item)");
            Console.WriteLine("+15 HP");
            Console.WriteLine("----------");
            Console.WriteLine("Restors 15 hp instanly");
            player.Heal(15);
        }

        else if (common_rnd == 3)
        {
            Console.WriteLine("Traveler's Coin Purse (Passive)");
            Console.WriteLine("+10% gold kill");
            Console.WriteLine("----------");
            Console.WriteLine("10% more gold dropped by enemies");
            // add drop rate
        }

        else if (common_rnd == 4)
        {
            Console.WriteLine("Wooden Amulet (Passive)");
            Console.WriteLine("+10 HP Perma");
            Console.WriteLine("----------");
            Console.WriteLine("Adds +10 HP to the Max Health amount");
            player.MaxHealth += 10;
        }

        else if (common_rnd == 5)
        {
            Console.WriteLine("Lucky Pebble (Passive)");
            Console.WriteLine("+5% crit chanse");
            Console.WriteLine("----------");
            Console.WriteLine("Add's an extra 5 procent chanse of you hitting a critical hit");
            // add crit stat
        }

        else if (common_rnd == 6)
        {
            Console.WriteLine("Simple Bandage (Item)");
            Console.WriteLine("Heal 10 HP");
            Console.WriteLine("----------");
            Console.WriteLine("You can restore 10 Health");
            player.Heal(10);
        }

        else if (common_rnd == 7)
        {
            Console.WriteLine("Sharpend Knife (Passive)");
            Console.WriteLine("+10 Damage");
            Console.WriteLine("----------");
            Console.WriteLine("Deal an extra +10 Base damage");
            player.Attack += 10;
        }
    }

    public static void rare(Character player)
    {
        int rare_rnd = new Random().Next(1, 5);

        if (rare_rnd == 1)
        {
            Console.WriteLine("Vampiric Blade (Item)");
            Console.WriteLine("5% Life steal");
            Console.WriteLine("----------");
            Console.WriteLine("Heal 5% of the damage you deal");
            // add
        }

        else if (rare_rnd == 2)
        {
            Console.WriteLine("Spiked Armor (Passive)");
            Console.WriteLine("Reflect 10% Damage");
            Console.WriteLine("----------");
            Console.WriteLine("Reflect 10% damage taken");
            // add
        }

        else if (rare_rnd == 3)
        {
            Console.WriteLine("Rogue's Cloak (Passive)");
            Console.WriteLine("10% to avoid attack");
            Console.WriteLine("----------");
            Console.WriteLine("10% chance to completely avoid an attack");
            // add
        }

        else if (rare_rnd == 4)
        {
            Console.WriteLine("Mana Pendant (Passive)");
            Console.WriteLine("Reduce Ability cooldown by 1");
            Console.WriteLine("----------");
            Console.WriteLine("-1 Round cooldown on abilities");
            // add
        }

        else if (rare_rnd == 5)
        {
            Console.WriteLine("Bag of Fortune (Passive)");
            Console.WriteLine("15% for dubble gold");
            Console.WriteLine("----------");
            Console.WriteLine("15% chance enemies drop double gold");
            // add
        }
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
        Console.WriteLine("Here you can buy goods");
        Console.WriteLine("like items that can aid you in battle");
        Console.WriteLine();
        Console.WriteLine("Or upgrades like:");
        Console.WriteLine("Weapon upgrades");
        Console.WriteLine("Health upgrades");
        Console.WriteLine("And so on");

        // Item method here
    }
}

class Action (Character player)
{
    public int Max_Health => player.Health;
    public static int round = 1;
    public static int Enemy_1 = 100;
    public static int Enemy_2 = 100;
    public static int Enemy_damage = 10;

    public static void Text(Character player)
    {

        while (true)
        {
            Console.WriteLine("---- Choose Your Action ----");
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
                    Console.WriteLine("Which skeleton do you attack?");
                    Console.WriteLine("Skeleton 1 or Skeleton 2");
                    string attack_answer = Console.ReadLine().Trim().ToLower();

                    if (attack_answer == "skeleton 1")
                    {
                        Enemy_1 -= damage;
                        Enemy_2 -= damage / 2;
                        Console.WriteLine("You attacked Skeleton 1");
                        Console.WriteLine($"You did {damage} damage to Skeleton 1");
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
                        Console.WriteLine($"You did {damage} damage to Skeleton 2");
                        Console.WriteLine("While you swung your sword you hit the other skeleton too");
                        Console.ReadLine();
                        Console.WriteLine($"Skeleton 2 HP = {Enemy_2}");
                        Console.WriteLine($"Skeleton 1 HP = {Enemy_1}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Answer!");
                        Console.WriteLine("You’ve got to write either:");
                        Console.WriteLine("Skeleton 1 or Skeleton 2");
                    }
                    Console.ReadLine();
                }
                break;
            }
            else if (answer == "defend")
            {
                Console.WriteLine("You activated your Defense stance");
                Console.WriteLine("Defense stance = Opponents deal half damage for 2 rounds");
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

        Console.WriteLine("!! The skeletons strike back !!");
        Console.WriteLine($"The skeletons did -{Enemy_damage}");
        player.Health -= Enemy_damage;
        Console.WriteLine($"Your HP = {player.Health}");
        Console.ReadLine();

        if (Enemy_1 <= 0 && Enemy_2 <= 0)
        {
            Console.WriteLine("!!! Round cleared !!!");
            Console.WriteLine("Moving on to the next room");
            Console.ReadLine();
            Console.WriteLine("To the ");
            Black.Market();
            round++;
        }
    }
}
