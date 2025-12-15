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
    public static bool R2 = true;
    public static bool R3 = true;
    public static bool R4 = true;
    public static bool R5 = true;

    public static bool E1 = true;
    public static bool E2 = true;
    public static bool E3 = true;
    public static bool E4 = true;

    public static bool L1 = true;
    public static bool L2 = true;
    public static bool L3 = true;
    public static bool L4 = true;
    public static bool L5 = true;

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
    public int crit_chanse = 21;
    static bool NoHit = false;


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

    public void TakeDamage(int enemy_damage)
    {
        Health -= enemy_damage;
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
            if (!Global.C3)
            {   
                Action.GoldDropMultiplier += 0.1f;
                Global.C3 = true;
            }
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

    public static int Rare(Character player, int enemy_damage, int dodge, int reflectDamage, bool NoHit)
    {
        int rare_rnd = new Random().Next(1, 6);

        if (rare_rnd == 1)
        {
            Console.WriteLine("Vampiric Blade (Passive)");
            Console.WriteLine("Life steal");
            Console.WriteLine("----------");
            Console.WriteLine("Heal 10% of the damage you deal");
            if (!Global.R1)
                player.Heal((int)(player.Attack * 0.1));
        }

        else if (rare_rnd == 2)
        {
            Console.WriteLine("Spiked Armor (Passive)");
            Console.WriteLine("Reflect Damage");
            Console.WriteLine("----------");
            Console.WriteLine("Reflect 10% damage taken");
            if (!Global.R2)
            {
                reflectDamage = (int)(enemy_damage * 0.1f);
                return reflectDamage;
            }
        }

        else if (rare_rnd == 3)
        {
            Console.WriteLine("Rogue's Cloak (Passive)");
            Console.WriteLine("10% to avoid attack");
            Console.WriteLine("----------");
            Console.WriteLine("10% chance to completely avoid an attack");
            if (!Global.R3)
            {
                dodge = new Random().Next(1,11);
                if (dodge == 1)
                {
                    NoHit = true;
                } 
            }

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
        int epic_rnd = new Random().Next(1, 5);

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
    public static int round_enemy_mult = 1;
    public static int reflectDamage;
    public static int dodge;
    public static int Enemy_1 = 100;
    public static int Enemy_2 = 100;
    public static bool extra_def = false;
    public static int extra_def_round = 0;
    public static float GoldDropMultiplier = 1.0f; //items that increase % gold
    public static int ExtraGoldPerKill = 0; //extra gold per kill
    private const int BaseGoldPerKill = 10; //base gold per kill
    private const float GoldScalingPerRound = 0.5f; //additional gold per round
    private const float GoldScalingCap = 35f; //cap for scaling
    public static int Special_charge = 0;
    public static bool Specail_isCharged = false;
    public static int Enemy_damage = 10;


    public static void Text(Character player, bool Nohit)
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


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-| Special |-");
            Console.WriteLine($"Charge: {Special_charge}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("-| Run |-");
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

                    if (attack_answer == "skeleton 1" || attack_answer == "1")
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
                        damage = Special_charge;

                        Console.WriteLine($"You attacked Skeleton 1 for {damage} damage.");
                        Console.WriteLine($"Skeleton 1 HP = {Enemy_1}");
                        Console.WriteLine($"Skeleton 2 HP = {Enemy_2}");
                        break;
                    }
                    
                    else if (attack_answer == "skeleton 2" || attack_answer == "2")
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
                        damage = Special_charge;

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
                extra_def = true;
                break;
            }
            else if (answer == "special")
            {
                if (Special_charge < 100)
                Special_charge = 100;

                if (Special_charge == 100)
                    Specail_isCharged = true;

                else
                {
                    Console.WriteLine("You cant use your Special");
                    Console.WriteLine("Its not fully charged");
                    Console.WriteLine($"Special charge = {Special_charge}");
                    break;
                }

                if(Specail_isCharged = true)
                {
                    Console.WriteLine("Your Special is fully charged");
                    Console.WriteLine("Do you wish to do your Special");
                    Console.WriteLine("Yes or No");
                    string answer_special = Console.ReadLine().Trim().ToLower();

                    if (answer_special == "yes" || answer_special == "y")
                    {
                        //special
                    }

                    else if (answer_special == "no" || answer_special == "n")
                    {
                        Console.WriteLine("Then your Special charge will be saved");
                        break;
                    }
                }
            }

            else if (answer == "run")
            {
                Console.WriteLine("You ran out of the cave, you coward");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        Console.WriteLine("!! The skeletons strike back !!");
        Console.WriteLine($"The skeletons did -{Enemy_damage}");
        if (extra_def == false)
            player.TakeDamage((int)(Enemy_damage * round_enemy_mult * (player.Defense / 10 + 0.4)));

        else if (extra_def == true)
        {
            extra_def_round++;
            player.TakeDamage((int)(Enemy_damage * round_enemy_mult / 2 * (player.Defense / 10 + 0.4)));

            if (extra_def_round == 2)
            {
                extra_def_round = 0;
                extra_def = false;
            }
        }

        else if (Nohit = true)
        {
            Enemy_damage = 0;
        }
        Console.WriteLine($"Your HP = {player.Health}");

        if (Enemy_1 <= 0 || Enemy_2 <= 0)
        {
            float scalingGold = GoldScalingPerRound * (round - 1); 
            if (scalingGold > GoldScalingCap) 
                scalingGold = GoldScalingCap; 

            float goldPreModifier = BaseGoldPerKill + scalingGold + ExtraGoldPerKill; 

            int goldEarned = (int)Math.Floor(goldPreModifier * GoldDropMultiplier); 

            player.Gold += goldEarned;

            Console.WriteLine($"Enemies defeated! You earned {goldEarned} gold. Total gold: {player.Gold}");
        }

        if (Enemy_1 <= 0 && Enemy_2 <= 0)
        {
            Console.WriteLine("!!! Round cleared !!!");
            Console.WriteLine("Moving on to the next room");
            round++;
            Black.Market();
        }

        if (Enemy_damage < 10)
            Enemy_damage = 10;

        float scale = 1f + (round - 1) * 0.15f;
        if (scale > 4f) scale = 4f;

        Enemy_damage = (int)(Enemy_damage * scale);
    }
}

// Fix the Action method 
// Fix bugs that makes the code buggy
// sort / fix / UI changes
    