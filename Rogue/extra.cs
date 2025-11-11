using System;
using System.Data;
using System.Threading;

static class Global
{
    public static bool C1 = true;
    public static bool C2 = true;
    public static bool C3 = true;
    public static bool C4 = true;
    public static bool C5 = true;
    public static bool C6 = true;
    public static bool C7 = true;

    public static bool R1 = true;
}

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
    public int Gold;
    public int crit_chanse = 11;

    public Character(string name, int health, int attack, int defense, string ability)
    {
        Name = name;
        Health = health;
        MaxHealth = health;
        Attack = attack;
        Defense = defense;
        Ability = ability;
    }

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
        {
            Health = 0;
        }

        if (Health == 0)
        {
            Environment.Exit(0);
        }               

    }
}
class Items
{
    public static void Commen(Character player)
    {
        int common_rnd = new Random().Next(1, 8);

        if (common_rnd == 1)
        {
            Console.WriteLine("Old Shield (Passive)");
            Console.WriteLine("+1 armor");
            Console.WriteLine("----------");
            Console.WriteLine("Adds extra armor to make you lose less hp");
            if (!Global.C1)
            {
                player.Defense += 1;
                Global.C1 = true;
            }
        }
        else if (common_rnd == 2)
        {
            Console.WriteLine("Minor potion (Item)");
            Console.WriteLine("+15 HP");
            Console.WriteLine("----------");
            Console.WriteLine("Restores 15 hp instantly");
            if (!Global.C2)
            {
                player.Heal(15);
                Global.C2 = true;
            }
        }
        else if (common_rnd == 3)
        {
            Console.WriteLine("Traveler's Coin Purse (Passive)");
            Console.WriteLine("+10% gold per kill");
            Console.WriteLine("----------");
            Console.WriteLine("10% more gold dropped by enemies");
            Global.C3 = true;
        }
        else if (common_rnd == 4)
        {
            Console.WriteLine("Wooden Amulet (Passive)");
            Console.WriteLine("+10 HP Permanent");
            Console.WriteLine("----------");
            Console.WriteLine("Adds +10 HP to Max Health");
            if (!Global.C4)
            {
                player.MaxHealth += 10;
                Global.C4 = true;
            }
        }
        else if (common_rnd == 5)
        {
            Console.WriteLine("Lucky Pebble (Passive)");
            Console.WriteLine("+10% crit chance");
            Console.WriteLine("----------");
            Console.WriteLine("Adds an extra 10% chance of hitting a critical hit");
            if (!Global.C5)
            {
                player.crit_chanse -= 1;
                Global.C5 = true;
            }
        }
        else if (common_rnd == 6)
        {
            Console.WriteLine("Simple Bandage (Item)");
            Console.WriteLine("Heal 10 HP");
            Console.WriteLine("----------");
            Console.WriteLine("You can restore 10 Health");
            if (!Global.C6)
            {
                player.Heal(10);
                Global.C6 = true;
            }
        }
        else if (common_rnd == 7)
        {
            Console.WriteLine("Sharpened Knife (Passive)");
            Console.WriteLine("+10 Damage");
            Console.WriteLine("----------");
            Console.WriteLine("Deal an extra +10 base damage");
            if (!Global.C7)
            {
                player.Attack += 10;
                Global.C7 = true;
            }
        }
    }

    public static void rare(Character player)
    {
        int rare_rnd = new Random().Next(1, 6);

        if (rare_rnd == 1)
        {
            Console.WriteLine("Vampiric Blade (Item)");
            Console.WriteLine("Life steal");
            Console.WriteLine("----------");
            Console.WriteLine("Heal 5% of the damage you deal");
            // add
        }

        else if (rare_rnd == 2)
        {
            Console.WriteLine("Spiked Armor (Passive)");
            Console.WriteLine("Reflect Damage");
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
            Console.WriteLine("Reduce Ability cooldown");
            Console.WriteLine("----------");
            Console.WriteLine("-1 Round cooldown on abilities");
            // add
        }

        else if (rare_rnd == 5)
        {
            Console.WriteLine("Bag of Fortune (Passive)");
            Console.WriteLine("15% for more gold");
            Console.WriteLine("----------");
            Console.WriteLine("15% chance enemies drop double gold");
            // add
        }
    }

    public static void epic()
    {
        int epic_rnd = new Random().Next(1 ,5);

        if (epic_rnd == 1)
        {
            Console.WriteLine("Thunder Blade (Item)");
            Console.WriteLine("+10% AOE-damage");
            Console.WriteLine("----------");
            Console.WriteLine("Attack's deal +10% splash damage to all nearby enemies");
            //add
        }

        else if (epic_rnd == 2)
        {
            Console.WriteLine("Phoenix Heart (Passive)");
            Console.WriteLine("Revive with half of your HP");
            Console.WriteLine("----------");
            Console.WriteLine("Revive once per run with 50% HP");
            //add
        }

        else if (epic_rnd == 3)
        {
            Console.WriteLine("Alchemist's Coin (Passive)");
            Console.WriteLine("Gain gold, take more damage");
            Console.WriteLine("----------");
            Console.WriteLine("Gain +5 gold every 10 rounds, but take +10% more damage");
            //add
        }

        else if (epic_rnd == 4)
        {
            Console.WriteLine("Blood Pact (Passive)");
            Console.WriteLine("More damage, less HP");
            Console.WriteLine("----------");
            Console.WriteLine("+25% Damage, -15% Max HP");
            //add
        }
    }

    public static void legendry()
    {
        int legendry_rnd = new Random().Next(1, 6);

        if (legendry_rnd == 1)
        {
            Console.WriteLine("Dragon Fang Sword (Item)");
            Console.WriteLine("More damage, More gold");
            Console.WriteLine("----------");
            Console.WriteLine("+40% Damage, Enemies drop +20% more gold");
            //add
        }

        else if (legendry_rnd == 2)
        {
            Console.WriteLine("Crown Of The Damned (Passive)");
            Console.WriteLine("More gold per kill, less Max HP");
            Console.WriteLine("----------");
            Console.WriteLine("+2% gold per kill, but Max HP is reduced by 20%");
            //add
        }

        else if (legendry_rnd == 3)
        {
            Console.WriteLine("Echo Gloves (Power-Up)");
            Console.WriteLine("Repeat Attack");
            Console.WriteLine("----------");
            Console.WriteLine("Every 3rd Attack repeats automatically");
            //add
        }

        else if (legendry_rnd == 4)
        {
            Console.WriteLine("Golden Furnace (Item)");
            Console.WriteLine("Sacrifice HP for Gold");
            Console.WriteLine("----------");
            Console.WriteLine("Sacrifice 50 HP for 100 Gold");
            //add
        }

        else if (legendry_rnd == 5)
        {
            Console.WriteLine("Soal Contract (Power-Up)");
            Console.WriteLine("Trade Gold for Damage");
            Console.WriteLine("----------");
            Console.WriteLine("Trade 50% of current gold for +50% damage for 2 rounds");
            //add
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

        Console.WriteLine("Welcome to the Market");
        Console.WriteLine("Here you can buy goods like items that can aid you in battle");
        Console.WriteLine();
        Console.WriteLine("Or upgrades like:");
        Console.WriteLine("Weapon upgrades");
        Console.WriteLine("Health upgrades");
        Console.WriteLine("And so on");
    }
}

class Action
{
    public static int round = 1;
    public static int Enemy_1 = 100;
    public static int Enemy_2 = 100;
    public static int Enemy_damage = 11;

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
                        int crit = new Random().Next(1, player.crit_chanse);
                        if (crit == 1)
                        {
                            Console.WriteLine("! Crit !");
                            Enemy_1 -= damage * 3;
                        }
                        else
                        {
                            Enemy_1 -= damage;
                        }
                        Enemy_2 -= damage / 2;
                        Console.WriteLine($"You attacked Skeleton 1 for {damage} damage.");
                        Console.WriteLine($"Skeleton 1 HP = {Enemy_1}");
                        Console.WriteLine($"Skeleton 2 HP = {Enemy_2}");
                        break;
                    }
                    else if (attack_answer == "skeleton 2")
                    {
                        int crit = new Random().Next(1, player.crit_chanse);
                        if (crit == 1)
                        {
                            Console.WriteLine("! Crit !");
                            Enemy_2 -= damage * 3;
                        }
                        else
                        {
                            Enemy_2 -= damage;
                        }
                        Enemy_1 -= damage / 2;
                        Console.WriteLine($"You attacked Skeleton 2 for {damage} damage.");
                        Console.WriteLine($"Skeleton 2 HP = {Enemy_2}");
                        Console.WriteLine($"Skeleton 1 HP = {Enemy_1}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Answer! Write 'Skeleton 1' or 'Skeleton 2'");
                    }
                }
                break;
            }
            else if (answer == "defend")
            {
                Console.WriteLine("You activated your Defense stance");
                Console.WriteLine("Opponents deal half damage for 2 rounds");
                bool Extra_def = true;
                break;
            }
            else if (answer == "item")
            {
                Items.Commen(player);
                break;
            }
            else if (answer == "special")
            {
                Console.WriteLine("Special ability not implemented yet");
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        Console.WriteLine("!! The skeletons strike back !!");
        Console.WriteLine($"The skeletons did -{Enemy_damage}");
        if ()
        player.TakeDamage(Enemy_damage);
        Console.WriteLine($"Your HP = {player.Health}");

        if (Enemy_1 <= 0 || Enemy_2 <= 0)
        {
            player.Gold += 10;
        }

        if (Enemy_1 <= 0 && Enemy_2 <= 0)
        {
            Console.WriteLine("!!! Round cleared !!!");
            Console.WriteLine("Moving on to the next room");
            Black.Market();
            round++;
        }
    }
}
