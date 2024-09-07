/*
 * Hyunbin Park
 * PE - Data Types & Variables
 * https://docs.google.com/document/d/1U91F590ypwhbyZGczKPR0nOnukeN886Zx_xY-AxTJSE/edit
 */

namespace PE_DataTypesVariables_Park
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declares and initializes the character's name.
            string nameOfCharacter = "Bin Park";
            // Declares and initializes the total starting points 50. It's a constant value.
            const int startingPoints = 50;
            // Declares and initializes the strength stat which is 23% of the starting points.
            double statStrength = startingPoints * 0.23;
            // Declares and initializes the dexterity stat which is half of the strength stat.
            double statDexterity = statStrength / 2;
            // Declares and initializes the intelligence stat which is exactly 7.
            double statIntelligence = 7;
            // Declares and initializes the health stat which is the sum of the dexterity and intelligence stat minus 2.
            double statHealth = statDexterity + statIntelligence - 2;
            // Declares and initializes the charisma stat which is the leftover points.
            double statCharisma = startingPoints - statStrength - statDexterity - statIntelligence - statHealth;
            // Declares and initializes the total points.
            double totalPoints = statStrength + statDexterity + statIntelligence + statHealth + statCharisma;

            // Prints the character's name.
            Console.WriteLine("Name: " + nameOfCharacter);
            // Adds an extra spacing.
            Console.WriteLine();
            // Prints the character's stats.
            Console.WriteLine("Strength: " + statStrength);
            Console.WriteLine("Dexterity: " + statDexterity);
            Console.WriteLine("Intelligence: " + statIntelligence);
            Console.WriteLine("Health: " + statHealth);
            Console.WriteLine("Charisma: " + statCharisma);
            // Adds an extra spacing.
            Console.WriteLine();
            // Lastly, Prints the character's total stat points.
            Console.WriteLine("TOTAL: " + totalPoints);
        }
    }
}
