/*
 * Hyunbin Park
 * HW 1: Character Story 
 * https://docs.google.com/document/d/1FL56QqpNtMweNRlBtU3jUyMp3C6c7ABd8IhM5ifgfF4/edit?usp=sharing
 */

namespace HW_CharacterStory_Park
{
    internal class Program
    {
        static void Main(string[] args)
        {  
            // Character's Stats & Variables
            // Constant numeric values
            const int maxHealth = 100;
            const int baseAttack = 15;
            const double baseAttackSpeed = 1.1;

            // Variables for character
            string characterName = "Gogo";
            int currentHealth = maxHealth;
            int currentAttack = baseAttack;
            double currentAttackSpeed = baseAttackSpeed;
            int moneyInPocket = 500;
            string status = "Normal";

            // Variable for evil dragon
            int healthOfEvilDragon = 75;



            // Introduction
            Console.WriteLine("=== Introduction ===");
            Console.WriteLine(characterName + ", a legendary warrior, starts his journey to defeat evil dragon.");
            Console.WriteLine();

            // Character Stats
            Console.WriteLine("--- Stats of " + characterName + " ---");
            Console.WriteLine("Health: " + currentHealth + " / " + maxHealth);
            Console.WriteLine("Attack: " + currentAttack);
            Console.WriteLine("Attack Speed: " + currentAttackSpeed);
            Console.WriteLine("Money: " + moneyInPocket);
            Console.WriteLine("Status: " + status);
            Console.WriteLine();



            // The Adventure & Calculations
            // Encounter
            Console.WriteLine("=== The Journey Begins ===");
            Console.WriteLine(characterName + " encountered with evil dragon!");
            Console.WriteLine();

            // Gogo's first turn, performs an attack
            Console.WriteLine(characterName + " attacked evil dragon, dealing " + currentAttack + " damage!");
            healthOfEvilDragon -= currentAttack;
            Console.WriteLine("* Evil dragon's health reduced to " + healthOfEvilDragon + ".");
            Console.WriteLine();

            // Evil dragon's first turn, reduces Gogo's attack
            Console.WriteLine("Evil dragon casted evil eyes, reducing " + characterName + "'s attack by 3!");
            currentAttack -= 3;
            Console.WriteLine("* " + characterName + "'s attack reduced to " + currentAttack + ".");
            Console.WriteLine();

            // Gogo's second turn, performs an attack
            Console.WriteLine(characterName + " attacked evil dragon, dealing " + currentAttack + " damage!");
            healthOfEvilDragon -= currentAttack;
            Console.WriteLine("* Evil dragon's health reduced to " + healthOfEvilDragon + ".");
            Console.WriteLine();

            // Evil dragon's turn, casts an evil laser
            Console.WriteLine("Evil dragon casted evil laser, dealing the damage based on its current health!");
            currentHealth = currentHealth % healthOfEvilDragon;
            Console.WriteLine("* " + characterName + "'s health reduced to " + currentHealth + ".");
            // Gogo's health is low which changes his status to outrage
            Console.WriteLine("* " + characterName + "'s health is low.");
            Console.WriteLine(characterName + " became outrageous! ");
            status = "Outrage";
            currentAttack *= 2;
            currentAttackSpeed *= 2;
            Console.WriteLine("* " + characterName + "'s attack increased to " + currentAttack + ".");
            Console.WriteLine("* " + characterName + "'s attack speeed increased to " + currentAttackSpeed + ".");
            Console.WriteLine();

            // Gogo's third turn, performs an attack
            Console.WriteLine(characterName + " attacked evil dragon, dealing " + currentAttack + " damage!");
            healthOfEvilDragon -= currentAttack;
            Console.WriteLine("* Evil dragon's health reduced to " + healthOfEvilDragon + ".");
            Console.WriteLine();

            // Increased attack speed causes Gogo's fourth turn, performs an attack
            Console.WriteLine(characterName + " attacked evil dragon, dealing " + currentAttack + " damage!");
            healthOfEvilDragon -= currentAttack;
            Console.WriteLine("* Evil dragon's health reduced to " + healthOfEvilDragon + ".");
            Console.WriteLine();

            // Gogo defeats evil dragon and takes the spoils
            Console.WriteLine(characterName + " defeated evil dragon, eanred 1000000 golds!");
            moneyInPocket += 1000000;
            Console.WriteLine();



            // Conclusion
            Console.WriteLine("=== Conclusion ===");
            Console.WriteLine("Gogo successfully defeated evil dragon and restored the peace of the world.");
            Console.WriteLine();

            // Final character stats!
            Console.WriteLine("--- Final Stats of " + characterName + " ---");
            Console.WriteLine("Health: " + currentHealth + " / " + maxHealth);
            Console.WriteLine("Attack: " + currentAttack);
            Console.WriteLine("Attack Speed: " + currentAttackSpeed);
            Console.WriteLine("Money: " + moneyInPocket);
            Console.WriteLine("Status: " + status);
            Console.WriteLine();
        }
    }
}
