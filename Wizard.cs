using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textBaseRPG
{
    internal class Wizard
    {
        public static int hp = 20;
        public string name;
        public List<string> spells;
        public int spellSlots;
        private static float exp = 0f;
        public static int maxHP = hp;
        public static int gold = 50;

        public Wizard(string name, List<string> _spells = null)
        {
            this.name = name;
            this.spells = _spells ?? new List<string>();
            this.spellSlots = 2;
        }

        public int SpellSlots
        {
            get { return spellSlots; }
            set { spellSlots = value; }
        }

        public void GainExperience(float amount)
        {
            exp += amount;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"\n>This is your character's stats \nName: {name}\nHP:{hp} \nSpellslots: {spellSlots}");
        }

        public void Spellbook()
        {
            Console.WriteLine($"\n>Your spells: {string.Join(", ", spells)}");
        }

        public static void AddSpell(Wizard wizard)
        {
            var availableSpells = Spells.GetSpellInfo();

            Console.WriteLine("Here are the available spells you can choose from:");
            Spells.SpellsInfo();
            while (wizard.spells.Count < 3)
            {
                Console.WriteLine("\n>Choose a spell by entering the corresponding number:");
                int i = 1;
                foreach (var spell in availableSpells)
                {
                    Console.WriteLine($"{i}. {spell.Key}");
                    i++;
                }

                string input = Console.ReadLine();
                bool isValid = int.TryParse(input, out int choice) && choice >= 1 && choice <= availableSpells.Count;

                if (isValid)
                {
                    string selectedSpell = GetSpellByNumber(choice, availableSpells);

                    // Ensure the spell isn't already learned
                    if (!wizard.spells.Contains(selectedSpell))
                    {
                        wizard.spells.Add(selectedSpell);
                        Console.WriteLine($"\n>{selectedSpell} has been added to your spellbook!");
                    }
                    else
                    {
                        Console.WriteLine(">You already know this spell. Choose another one.");
                    }
                }
                else
                {
                    Console.WriteLine(">Invalid choice. Please enter a number between 1 and 5.");
                }
            }
        }

        //    string[] spellOptions = {
        //        "Lightning Bolt",
        //        "Magic Missile",
        //        "Heal",
        //        "Invisibility",
        //        "Shield" };
        //    bool spellLearned = false;

        //    while (!spellLearned)
        //    {
        //        Console.WriteLine(">Choose a new spell to learn:");

        //        for (int i = 0; i < spellOptions.Length; i++)
        //        {
        //            // Display the spell only if it hasn't been learned yet
        //            if (!wizard.spells.Contains(spellOptions[i]))
        //            {
        //                Console.WriteLine($"{i + 1}. {spellOptions[i]}");
        //            }
        //        }

        //        int choice;
        //        while (true)
        //        {
        //            Console.WriteLine("Enter the number of the spell you want to learn (1-5):");
        //            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 5)
        //            {
        //                break;
        //            }
        //            else Console.WriteLine("Invalid choice, please try again.");
        //        }

        //        string selectedSpell = spellOptions[choice - 1];

        //        // Check if the spell has already been learned
        //        if (wizard.spells.Contains(selectedSpell))
        //        {
        //            Console.WriteLine($"{wizard.name} already knows {selectedSpell}. Please choose a different spell.");
        //        }
        //        else
        //        {
        //            wizard.spells.Add(selectedSpell);
        //            Console.WriteLine($"{wizard.name} has learned a new spell: {selectedSpell}!");
        //            spellLearned = true;
        //        }
        //    }
        //}

        // Method to get the spell name by the user's choice
        private static string GetSpellByNumber(int choice, Dictionary<string, string> spellInfo)
        {
            int index = 1;
            foreach (var spell in spellInfo)
            {
                if (index == choice)
                {
                    return spell.Key;
                }
                index++;
            }
            return null;
        }

        public void TakeDamage(int damage)
        {
            hp -= damage;
            Console.WriteLine($"{name} takes {damage} damage! You have {hp} hp.");

            if (hp <= 0)
            {
                Console.WriteLine("You have been defeated!");
                Environment.Exit(0);
            }
        }

        public void Shield(int shieldAmount)
        {
            maxHP += shieldAmount;
            hp += shieldAmount;
            Console.WriteLine($"{name} shields for {shieldAmount} temporary HP! Current HP: {hp}/{maxHP}");
        }

        public void Heal(int healAmount)
        {
            hp += healAmount;

            if (hp > maxHP)
                hp = maxHP;

            Console.WriteLine($"{name} heals for {healAmount} HP! Current HP: {hp}/{maxHP}");
        }
    }
}

// gia na testarei to input : int.TryParse(Console.ReadLine(), out int choice);LMAO