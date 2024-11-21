using textBaseRPG;
using System;
using System.Collections.Generic;

namespace RPGGame
{
    internal class Program
    {
        private static int spellSlots;

        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Welcome to the text base rpg! \n>Enter your wizard's name:");

            string name = Console.ReadLine();
            Wizard wizard01 = new Wizard(name);

            Console.WriteLine("\n>Add a new spell:");
            Wizard.AddSpell(wizard01);

            wizard01.DisplayInfo();
            wizard01.Spellbook();

            Random random = new Random();
            int enemyType = random.Next(1, 4);

            while (Wizard.hp >= 0)
            {
                Story.RandomEncounter(wizard01);
            }
        }
    }
}