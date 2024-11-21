using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textBaseRPG
{
    internal class Story
    {
        public static void RandomEncounter(Wizard wizard)
        {
            Random rand = new Random();
            int encounter = rand.Next(1, 4);  // Generates a random number between 1 and 3.

            if (encounter == 1)
            {
                // 33% chance to encounter the Hoarder
                EncounterHoarder(wizard);
            }
            else
            {
                // 67% chance for a battle encounter
                RandomBattleEncounter(wizard);
            }
        }

        public static void EncounterHoarder(Wizard wizard)
        {
            Hoarder hoarder = new Hoarder();
            Console.WriteLine("\n>You encounter a mysterious figure known as 'The Hoarder'. He offers you various items for sale.");
            hoarder.SellItem(wizard);
        }

        public static void RandomBattleEncounter(Wizard wizard)
        {
            Random rand = new Random();
            int encounter = rand.Next(1, 4);  // Random number for encounters

            switch (encounter)
            {
                case 1:
                    Console.WriteLine("\n>You encounter a Goblin!");
                    Goblin goblin = new Goblin();
                    Battles.Battle(wizard, goblin);
                    break;

                case 2:
                    Console.WriteLine("\n>You face a Banshee!");
                    Banshee banshee = new Banshee();
                    Battles.Battle(wizard, banshee);
                    break;

                case 3:
                    Console.WriteLine("\n>A Kobold jumps out from the shadows!");
                    Kobold kobold = new Kobold();
                    Battles.Battle(wizard, kobold);
                    break;
            }
        }
    }
}