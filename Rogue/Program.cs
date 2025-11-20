using System;
using System.Threading;

Console.WriteLine("There is a cave entrance upon you, you shall slay every enemy in there");
Console.WriteLine("Mission > Slay every enemy");
Console.WriteLine();
Console.WriteLine("Press enter to continue");
Console.ReadLine();

Loadingscreen.Hello();
Console.ReadLine();
Console.Clear();

Character selectedCharacter = null;
bool choose = true;

while (choose == true)
{
    Console.WriteLine("Well before you go into that hell hole");
    Console.WriteLine("Choose your class:");
    Console.WriteLine();

    Console.WriteLine("Do you want to be the:");
    Console.WriteLine();

    Console.WriteLine("-- Vanguard --");
    Console.WriteLine(" Weapon: Longsword (common)");
    Console.WriteLine(" Armor: Heavy (rare)"); // armor level 4
    Console.WriteLine(" Special Ability: Shield Wall (rare)");
    Console.WriteLine("    -- Reduce incoming damage by 50% for 2 turns");
    Console.WriteLine();

    Console.WriteLine("-- Ranger --");
    Console.WriteLine(" Weapon: Bow (Common)");
    Console.WriteLine(" Armor: Light (Common)"); // armor level 2
    Console.WriteLine(" Special Ability: Rapid Shot (rare)");
    Console.WriteLine("    -- Shoots 3 arrows at once");
    Console.WriteLine();

    Console.WriteLine("-- Assassin --");
    Console.WriteLine(" Weapon: Double Daggers (rare)");
    Console.WriteLine(" Armor: Medium (rare)"); // armor level 3
    Console.WriteLine(" Special Ability: Silent Kill (epic)");
    Console.WriteLine("    -- Instantly kills a target with low health");
    Console.WriteLine("    -- If the enemy survives, deals bonus critical damage");
    Console.WriteLine();

    Console.WriteLine("-- Warlock --");
    Console.WriteLine(" Weapon: Dark Tome");
    Console.WriteLine(" Armor: Light (common)"); // armor level 1
    Console.WriteLine(" Special Ability: Curse Mark");
    Console.WriteLine("    -- Marks an enemy. The enemy takes extra damage from all sources for 3 turns");
    Console.WriteLine();

    Console.WriteLine("-- Samurai --");
    Console.WriteLine(" Weapon: Katana (epic)");
    Console.WriteLine(" Armor: Medium (rare)"); // armor level 3
    Console.WriteLine(" Special Ability: Iaido Slash");
    Console.WriteLine("    -- Deals heavy damage and guarantees a counterattack next turn");
    Console.WriteLine();

    Console.WriteLine("-- Gunslinger --");
    Console.WriteLine(" Weapon: Revolver (rare)");
    Console.WriteLine(" Armor: Light"); // armor level 2
    Console.WriteLine(" Special Ability: Quick Draw");
    Console.WriteLine("    -- Instantly shoots all enemies once");
    Console.WriteLine();

    Console.WriteLine("-- Blood Knight --");
    Console.WriteLine(" Weapon: Blood Katana (epic)");
    Console.WriteLine(" Armor: Heavy (rare)"); // armor level 4
    Console.WriteLine(" Special Ability: Life Steal (epic)");
    Console.WriteLine("    -- Deals strong damage and heals 30% of the damage dealt");
    Console.WriteLine();

    Console.WriteLine("-- Juggernaut --");
    Console.WriteLine(" Weapon: Dual Axes (rare)");
    Console.WriteLine(" Armor: Heavy (epic)");
    Console.WriteLine(" Special Ability: Iron Body");
    Console.WriteLine("    -- Immune from negative effects for 2 turns");
    Console.WriteLine();

    Character vanguard = new Character("Vanguard", 120, 40, 4, "Shield Wall");
    Character ranger = new Character("Ranger", 90, 55, 2, "Rapid Shot");
    Character assassin = new Character("Assassin", 85, 65, 3, "Silent Kill");
    Character warlock = new Character("Warlock", 80, 70, 1, "Curse Mark");
    Character samurai = new Character("Samurai", 95, 60, 3, "Iaido Slash");
    Character gunslinger = new Character("Gunslinger", 90, 50, 2, "Quick Draw");
    Character bloodKnight = new Character("Blood Knight", 110, 55, 4, "Life Steal");
    Character juggernaut = new Character("Juggernaut", 130, 45, 5, "Iron Body");

    Console.WriteLine("So what do you choose?");
    string chosenClass = Console.ReadLine().Trim().ToLower();

    if (chosenClass == "vanguard") selectedCharacter = vanguard;
    else if (chosenClass == "ranger") selectedCharacter = ranger;
    else if (chosenClass == "assassin") selectedCharacter = assassin;
    else if (chosenClass == "warlock") selectedCharacter = warlock;
    else if (chosenClass == "samurai") selectedCharacter = samurai;
    else if (chosenClass == "gunslinger") selectedCharacter = gunslinger;
    else if (chosenClass == "blood knight") selectedCharacter = bloodKnight;
    else if (chosenClass == "juggernaut") selectedCharacter = juggernaut;
    else
    {
        Console.Clear();
        Console.WriteLine("There is no such class.");
        Console.WriteLine("- Try again -");
        Console.ReadLine();
        continue;
    }

    choose = false;
}

Console.Clear();
Console.WriteLine($"You chose {selectedCharacter.Name}");
Console.WriteLine($"Health: {selectedCharacter.Health}");
Console.WriteLine($"Attack: {selectedCharacter.Attack}");
Console.WriteLine($"Defense: {selectedCharacter.Defense}");
Console.WriteLine($"Ability: {selectedCharacter.Ability}");

Console.WriteLine();
Console.WriteLine("You went into the cave");
Console.WriteLine("You stumble upon 2 enemy skeletons, you take your stance");
Console.WriteLine();

Action.Text(selectedCharacter);
