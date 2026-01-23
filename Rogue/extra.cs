using System;
using System.Data;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using RPGGame;

static class Global
{
    public static bool C1 = false, C2 = false, C3 = false, C4 = false, C5 = false, C6 = false, C7 = false;

    public static bool R1 = false, R2 = false, R3 = false, R4 = false;

    public static bool E1 = false, E2 = false, E3 = false;

    public static bool L1 = false, L2 = false, L3 = false, L4 = false, L5 = false;

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

public class Character
{
    public string Name;
    public int Health;
    public int MaxHealth;
    public int Attack;
    public int Defense;
    public int Gold;
    public int crit_chanse = 21;
    public static bool HasRevive = false;
    public static bool ReviveUsed = false;
    public static bool HasBloodPact = false;
    public static int AttackCounter = 0;
    public static bool HasEchoGloves = false;
    public bool HasSpikedArmor;


    public Character(string name, int health, int attack, int defense)
    {
        Name = name;
        Health = health;
        MaxHealth = health;
        Attack = attack;
        Defense = defense;
    }

    public void Heal(int amount)
    {   
        Health += amount;
        if (Health > MaxHealth)
            Health = MaxHealth;

    }

    public bool TakeDamage(int enemy_damage)
    {
        Health -= enemy_damage;
        if (Health < 0) Health = 0;

        if (Health <= 0)
        {
            if (HasRevive && !ReviveUsed)
            {
                ReviveUsed = true;
                Health = MaxHealth / 2;
                Console.WriteLine("Phoenix Heart activated");
                return false;
            }

            Console.WriteLine("You died");
            return true;
        }

        return false;
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
                player.crit_chanse = Math.Max(2, player.crit_chanse - 1);
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
                int roll = new Random().Next(1, 11);

                if (roll == 1)
                {
                    Action.DodgeNextHit = true;
                    Console.WriteLine("You feel light on your feet");
                }

                Global.R3 = true;
            }
        }

        else if (rare_rnd == 4)
        {
            Console.WriteLine("Bag of Fortune (Passive)");
            Console.WriteLine("15% for more gold");
            Console.WriteLine("----------");
            Console.WriteLine("15% chance enemies drop double gold");
            if (!Global.R4)
                Action.GoldDropMultiplier += 0.15f;
        }

        return 0;
    }

    public static void epic(Character character)
    {
        int epic_rnd = new Random().Next(1, 3);

        if (epic_rnd == 1)
        {
            Console.WriteLine("Phoenix Heart (Passive)");
            Console.WriteLine("Revive with half of your HP");
            Console.WriteLine("----------");
            Console.WriteLine("Revive once per run with 50% HP");
            if (!Global.E1)
                {
                    Character.HasRevive = true;
                    Global.E1 = true;
                }   
        }

        else if (epic_rnd == 2)
        {
            Console.WriteLine("Blood Pact (Passive)");
            Console.WriteLine("More damage, less HP");
            Console.WriteLine("----------");
            Console.WriteLine("+25% Damage, -15% Max HP");
            if (!Global.E2)
            {
                Character.HasBloodPact = true;

                character.Attack = (int)(character.Attack * 1.25f);
                character.MaxHealth = (int)(character.MaxHealth * 0.85f);

                if (character.Health > character.MaxHealth)
                    character.Health = character.MaxHealth;

                Global.E2 = true;
            }
        }
    }

    public static void legendry(Character player, Character character)
    {
        int legendry_rnd = new Random().Next(1, 5);

        if (legendry_rnd == 1)
        {
            Console.WriteLine("Dragon Fang Sword (Item)");
            Console.WriteLine("More damage, More gold");
            Console.WriteLine("----------");
            Console.WriteLine("+40% Damage, Enemies drop +20% more gold");
            if (!Global.L1)
            {
                player.Attack = (int)(player.Attack * 1.4f);
                Action.GoldDropMultiplier += 0.2f;
                Global.L1 = true;
            }
        }

        else if (legendry_rnd == 2)
        {
            Console.WriteLine("Crown Of The Damned (Passive)");
            Console.WriteLine("More gold per kill, less Max HP");
            Console.WriteLine("----------");
            Console.WriteLine("+2% gold per kill, but Max HP is reduced by 20%");
            if (!Global.L2)
            {
                Action.GoldDropMultiplier += 0.02f;
                player.MaxHealth = (int)(player.MaxHealth * 0.8f);

                if (player.Health > player.MaxHealth)
                    player.Health = player.MaxHealth;

                Global.L2 = true;
            }
        }

        else if (legendry_rnd == 3)
        {
            Console.WriteLine("Echo Gloves (Power-Up)");
            Console.WriteLine("Repeat Attack");
            Console.WriteLine("----------");
            Console.WriteLine("Every 3rd Attack repeats automatically");
            if (!Global.L3)
            {
                Character.HasEchoGloves = true;
                Global.L3 = true;
            }
        }

        else if (legendry_rnd == 4)
        {
            Console.WriteLine("Golden Furnace (Item)");
            Console.WriteLine("Sacrifice HP for Gold");
            Console.WriteLine("----------");
            Console.WriteLine("Sacrifice 50 HP for 100 Gold");
            if (!Global.L4)
            {
                Console.WriteLine("Golden Furnace activated: Sacrifice 50 HP for 100 Gold");
                if (player.Health > 50)
                {
                    player.TakeDamage(50);
                    player.Gold += 100;
                    Console.WriteLine($"Your HP: {player.Health}, Gold: {player.Gold}");
                }
                else
                {
                    Console.WriteLine("Not enough HP to use Golden Furnace");
                }
                Global.L4 = true;
            }
        }
    }
}

namespace RPGGame
{
    public class ShopItem
    {
        public string Name;
        public string Description;
        public int Price;
        public string Rarity;
        public Action<Character> Effect;
        public Func<bool> AlreadyOwned;
    }

    public static class ItemLibrary
    {
        public static List<ShopItem> GetFullInventory()
        {
            return new List<ShopItem>
            {
                new ShopItem { Name = "Old Shield", Rarity = "Common", Price = 25, Description = "+1 armor", AlreadyOwned = () => Global.C1, Effect = (p) => { p.Defense += 1; Global.C1 = true; }},
                new ShopItem { Name = "Minor Potion", Rarity = "Common", Price = 20, Description = "Restores 15 HP", AlreadyOwned = () => false, Effect = (p) => p.Heal(15)},
                new ShopItem { Name = "Coin Purse", Rarity = "Common", Price = 30, Description = "+10% gold per kill", AlreadyOwned = () => Global.C3, Effect = (p) => { Action.GoldDropMultiplier += 0.1f; Global.C3 = true; }},
                new ShopItem { Name = "Wooden Amulet", Rarity = "Common", Price = 25, Description = "+10 Max HP", AlreadyOwned = () => Global.C4, Effect = (p) => { p.MaxHealth += 10; Global.C4 = true; }},
                new ShopItem { Name = "Lucky Pebble", Rarity = "Common", Price = 35, Description = "+10% crit chance", AlreadyOwned = () => Global.C5, Effect = (p) => { p.crit_chanse -= 1; Global.C5 = true; }},
                new ShopItem { Name = "Simple Bandage", Rarity = "Common", Price = 15, Description = "Heal 10 HP", AlreadyOwned = () => false, Effect = (p) => p.Heal(10)},
                new ShopItem { Name = "Sharpened Knife", Rarity = "Common", Price = 40, Description = "+10 Damage", AlreadyOwned = () => Global.C7, Effect = (p) => { p.Attack += 10; Global.C7 = true; }},

                new ShopItem { Name = "Vampiric Blade", Rarity = "Rare", Price = 75, Description = "Heal 10% of damage dealt", AlreadyOwned = () => Global.R1, Effect = (p) => Global.R1 = true },
                new ShopItem { Name = "Spiked Armor", Rarity = "Rare", Price = 75, Description = "Reflect 10% damage taken", AlreadyOwned = () => Global.R2, Effect = (p) => {p.HasSpikedArmor = true; Global.R2 = true; }},
                new ShopItem { Name = "Rogue's Cloak", Rarity = "Rare", Price = 80, Description = "10% chance to avoid attacks", AlreadyOwned = () => Global.R3, Effect = (p) => Global.R3 = true },
                new ShopItem { Name = "Bag of Fortune", Rarity = "Rare", Price = 70, Description = "+15% gold finding", AlreadyOwned = () => Global.R4, Effect = (p) => { Action.GoldDropMultiplier += 0.15f; Global.R4 = true; }},

                new ShopItem { Name = "Phoenix Heart", Rarity = "Epic", Price = 150, Description = "Revive once with 50% HP", AlreadyOwned = () => Global.E1, Effect = (p) => { Character.HasRevive = true; Global.E1 = true; }},
                new ShopItem { Name = "Blood Pact", Rarity = "Epic", Price = 120, Description = "+25% Damage, -15% Max HP", AlreadyOwned = () => Global.E2, Effect = (p) => { p.Attack = (int)(p.Attack * 1.25f); p.MaxHealth = (int)(p.MaxHealth * 0.85f); Global.E2 = true; }},

                new ShopItem { Name = "Dragon Fang Sword", Rarity = "Legendary", Price = 300, Description = "+40% Dmg, +20% Gold", AlreadyOwned = () => Global.L1, Effect = (p) => { p.Attack = (int)(p.Attack * 1.4f); Action.GoldDropMultiplier += 0.2f; Global.L1 = true; }},
                new ShopItem { Name = "Crown of Damned", Rarity = "Legendary", Price = 250, Description = "+2% Gold kill, -20% Max HP", AlreadyOwned = () => Global.L2, Effect = (p) => { Action.GoldDropMultiplier += 0.02f; p.MaxHealth = (int)(p.MaxHealth * 0.8f); Global.L2 = true; }},
                new ShopItem { Name = "Echo Gloves", Rarity = "Legendary", Price = 350, Description = "Every 3rd attack repeats", AlreadyOwned = () => Global.L3, Effect = (p) => { Character.HasEchoGloves = true; Global.L3 = true; }},
                new ShopItem { Name = "Golden Furnace", Rarity = "Legendary", Price = 100, Description = "Sacrifice 50 HP for 100 Gold", AlreadyOwned = () => false, Effect = (p) => { if(p.Health > 50) { p.TakeDamage(50); p.Gold += 100; }}},
            };
        }
    }
}
namespace RPGGame
{
class Black
{
    public static void Market(Character player)
    {
        {
            Random rnd = new Random();
            // get all items from librery
            List<ShopItem> allItems = ItemLibrary.GetFullInventory();
            
            // filter out items already owned (except consumables)
            List<ShopItem> availableItems = allItems.Where(i => i.AlreadyOwned() == false).ToList();

            //Pick 4 random items to showcase
            List<ShopItem> showcase = availableItems.OrderBy(x => rnd.Next()).Take(4).ToList();

            bool shopping = true;
            while (shopping)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--- THE BLACK MARKET ---");
                Console.ResetColor();
                Console.WriteLine($"Your Gold: {player.Gold} | Your HP: {player.Health}/{player.MaxHealth}\n");
                Console.WriteLine(new string('-', 30));

                for (int i = 0; i < showcase.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {showcase[i].Name} [{showcase[i].Rarity}]");
                    Console.WriteLine($"   Cost: {showcase[i].Price} Gold");
                    Console.WriteLine($"   Effect: {showcase[i].Description}");
                    Console.WriteLine(new string('-', 30));
                }
                Console.WriteLine("0. Leave Market");

                Console.Write("\nWhat would you like to buy? ");
                string input = Console.ReadLine();

                if (input == "0") shopping = false;
                else if (int.TryParse(input, out int choice) && choice >= 1 && choice <= showcase.Count)
                {
                    ShopItem selected = showcase[choice - 1];

                    if (player.Gold >= selected.Price)
                    {
                        player.Gold -= selected.Price;
                        selected.Effect(player); // Trigger the code from the Library
                        Console.WriteLine($"\nYou bought {selected.Name}!");
                        showcase.RemoveAt(choice - 1); // Remove from shelf after buying
                    }
                    else
                    {
                        Console.WriteLine("\nYou don't have enough gold for that!");
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                Action.Text(player);
            }
        }
    }
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
    public static int Enemy_damage = 10;
    public static bool DodgeNextHit = false;

    public static bool Defending;
    private static int DefendRounds;


     public static void Text(Character player)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("=== Combat ===");
        Console.ResetColor();
        Console.WriteLine($"HP: {player.Health}/{player.MaxHealth} | Round: {round}\n");
        Console.WriteLine("Attack | Defend | Run");
        string input = Console.ReadLine().Trim().ToLower();

        if (input == "attack")
        {
            Character.AttackCounter++;
            Attack(player);
        }
        else if (input == "defend")
        {
            Defending = true;
            DefendRounds = 2;
            Console.WriteLine("Defense stance activated");
            EnemyTurn(player);
        }
        else if (input == "run")
        {
            Console.WriteLine("You fled the cave");
            return;
        }
        else
        {
            Console.WriteLine("Invalid input");
            return;
        }

        if (Enemy_1 <= 0 && Enemy_2 <= 0)
        {
            CheckRoundEnd(player);
            return;
        }
    }

    static void Attack(Character player)
    {
        Console.Clear();
        Console.WriteLine("Choose target: Skeleton 1 or 2");
        string target = Console.ReadLine();

        int damage = player.Attack;
        int critMax = Math.Max(2, player.crit_chanse);
        if (new Random().Next(1, critMax) == 1)
        {
            Console.WriteLine("! Critical Hit !");
            damage *= 3;
        }

        if (target == "1")
        {
            Enemy_1 -= damage;
            Enemy_2 -= damage / 2;
        }
        
        else
        {
            Enemy_2 -= damage;
            Enemy_1 -= damage / 2;
        }

        if (Character.HasEchoGloves && Character.AttackCounter % 3 == 0)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Echo attack triggered!");
            Console.ResetColor();
            if (target == "1") Enemy_1 -= player.Attack;
            else Enemy_2 -= player.Attack;
        }

        Console.WriteLine($"Skeleton 1 HP: {Enemy_1}");
        Console.WriteLine($"Skeleton 2 HP: {Enemy_2}");
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();

        EnemyTurn(player);
    }

    static void EnemyTurn(Character player)
    {
        if (Enemy_1 <= 0 && Enemy_2 <= 0) return;

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("=== Enemy Turn ===");
        Console.ResetColor();

        if (DodgeNextHit)
        {
            Console.WriteLine("You dodged the attack!");
            DodgeNextHit = false;
            return;
        }

        float reduction = 1f - player.Defense * 0.05f;
        if (reduction < 0.2f) reduction = 0.2f;

        int dmg = (int)(Enemy_damage * reduction);
        if (Defending) dmg /= 2;

        bool dead = player.TakeDamage(dmg);
        Console.WriteLine($"You took {dmg} damage");
        Console.WriteLine($"Your health is {player.Health}");

        if (Defending)
        {
            DefendRounds--;
            if (DefendRounds == 0) Defending = false;
        }

        if (dead)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game Over!");
            Console.ResetColor();
            Console.ReadKey();
            return;
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
        CheckRoundEnd(player); 
        return;
    }

    static void CheckRoundEnd(Character player)
    {
        if (Enemy_1 <= 0 && Enemy_2 <= 0)
        {
        float scaling = GoldScalingPerRound * (round - 1);
        if (scaling > GoldScalingCap) scaling = GoldScalingCap;

        int gold = (int)((BaseGoldPerKill + scaling) * GoldDropMultiplier);
        player.Gold += gold;

        Console.WriteLine($"Round cleared. Gold +{gold}");

        round++;
        Enemy_1 = 100 + round * 10;
        Enemy_2 = 100 + round * 10;

        float scale = 1f + (round - 1) * 0.15f;
        if (scale > 4f) scale = 4f;
        Enemy_damage = (int)(10 * scale);
        RPGGame.Black.Market(player);
        }
        else
        {
            Text(player);
        }
    }

}
// sort / fix / UI changes

// if extra time
//      Make more items
//      Abilitys
//      Add more actions