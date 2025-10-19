using System;
using System.Threading;

//add slots for equipment
//add more items

Console.WriteLine("Helloing fellow rookie");
Console.WriteLine("There is a cave entrence apon you, you shall slain every enemy in there");
Console.WriteLine();
Console.WriteLine("Press enter to continue");
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
Console.Clear();

bool choose = true;
while (choose == true)
{
    Console.WriteLine("Well before you go in to that hell hole");
    Console.WriteLine("Choose your class:");
    Console.WriteLine();

    Console.WriteLine("Do you want to be the:");
    Console.WriteLine();
    Console.WriteLine("-- Vanguard --");
    Console.WriteLine(" Weapon: Longsword (common)");
    Console.WriteLine(" Armor: Heavy (rare)"); //armor level 4
    Console.WriteLine(" Special Ability: Shield Wall (rare)");
    Console.WriteLine("    -- Reduce incoming damage by 50% for 2 turns");
    Console.ReadLine();
    Console.WriteLine();
    Console.WriteLine("-- Ranger --");
    Console.WriteLine(" Weapon: Bow (Common)");
    Console.WriteLine(" Armor: Light (Common)"); //armor level 2
    Console.WriteLine(" Special Ability: Rapid Shot (rare)");
    Console.WriteLine("    -- Shoots 3 arrows at ones");
    Console.ReadLine();
    Console.WriteLine();
    Console.WriteLine("-- Assassin --");
    Console.WriteLine(" Weapon: Dubble Daggers (rare)");
    Console.WriteLine(" Armor: Medium (rare)"); //armor level 3
    Console.WriteLine(" Special Ability Silent Kill (epic)");
    Console.WriteLine("    -- Instantly kills a target with low health");
    Console.WriteLine("    -- If the enemy survives, deals bonus critical damage");
    Console.ReadLine();
    Console.WriteLine();
    Console.WriteLine("-- Warlock --");
    Console.WriteLine(" Weapon: Dark Tome");
    Console.WriteLine(" Armor: + light (common)"); //armor level 1
    Console.WriteLine(" Special Ability: Curse Mark");
    Console.WriteLine("    -- Marks an enemy. The enemy takes extra damage from all sources for 3 turns");
    Console.ReadLine();
    Console.WriteLine();
    Console.WriteLine("-- Samurai --");
    Console.WriteLine(" Weapon: Katana (epic)");
    Console.WriteLine(" Armor: Medium (rare)"); // armor level 3
    Console.WriteLine(" Special Ability: Laido Slash");
    Console.WriteLine("    -- Deals Heavy damage and guarantees a counterattack next turn");
    Console.ReadLine();
    Console.WriteLine();
    Console.WriteLine("-- Gunslinger --");
    Console.WriteLine(" Weapon: Revolver (rare)");
    Console.WriteLine(" Armor: Light"); // armor level 2
    Console.WriteLine(" Special Ability: Quick Draw");
    Console.WriteLine("    -- Instantly shoots all enemies once");
    Console.ReadLine();
    Console.WriteLine();
    Console.WriteLine("-- Blood knight --");
    Console.WriteLine(" Weapon: Blood Katana (epic)");
    Console.WriteLine(" Armor: Heavy (rare)");
    Console.WriteLine(" Special Ability: Life Steal (epic)");
    Console.WriteLine("    -- Deals strong damage and heals 30% of the damage dealt");
    Console.ReadLine();
    Console.WriteLine();
    Console.WriteLine("-- Juggernaut --");
    Console.WriteLine(" Weapon: Dual Axes (rare)");
    Console.WriteLine(" Armor: + Heavy (epic)");
    Console.WriteLine(" Special Ability: Iron body");
    Console.WriteLine("    -- Immune from negativ effects for 2 turns");
    Console.WriteLine();

    Console.ReadLine();

    Console.WriteLine("So what do you choose?");
    string Class = Console.ReadLine().Trim().ToLower();

    if (Class == "vanguard")
    {
        Console.Clear();
        Console.WriteLine("You choose Vanguard");
        bool Vanguard = true;
        break;
    }

    else if (Class == "ranger")
    {
        Console.Clear();
        Console.WriteLine("You choose Ranger");
        bool Ranger = true;
        break;

    }

    else if (Class == "assassin")
    {
        Console.Clear();
        Console.WriteLine("You choose Assassin");
        bool Assassin = true;
        break;

    }

    else if (Class == "warlock")
    {
        Console.Clear();
        Console.WriteLine("You choose Warlock");
        bool Warlock = true;
        break;

    }

    else if (Class == "samurai")
    {
        Console.Clear();
        Console.WriteLine("You choose Samurai");
        bool Samurai = true;
        break;

    }

    else if (Class == "gunslinger")
    {
        Console.Clear();
        Console.WriteLine("You choose Gunslinger");
        bool Gunslinger = true;
        break;

    }

    else if (Class == "blood knight")
    {
        Console.Clear();
        Console.WriteLine("You choose Blood Knight");
        bool blood_knight = true;
        break;

    }

    else if (Class == "juggernaut")
    {
        Console.Clear();
        Console.WriteLine("You choose Juggernaut");
        bool juggernaut = true;
        break;

    }

    else
    {
        Console.Clear();
        Console.WriteLine("There is no such class");
        Console.WriteLine("- Try again -");
        Console.ReadLine();
    }
}
Console.ReadLine();

