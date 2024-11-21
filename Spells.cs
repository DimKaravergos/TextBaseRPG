using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textBaseRPG
{
    internal static class Spells
    {
        private static Random random = new Random();

        private static Dictionary<string, string> spellInfo = new Dictionary<string, string>
        {
            { "Lightning Bolt", "Deals 1-6 damage to an enemy." },
            { "Magic Missile", "Deals 3-12 damage to an enemy." },
            { "Heal", "Heals your character for 1-10 HP." },
            { "Invisibility", "Makes your character invisible for 1 turn." },
            { "Shield", "Gives your character +5 temporary HP." }
        };

        public static void SpellsInfo()
        {
            foreach (var spell in spellInfo)
            {
                Console.WriteLine($"{spell.Key}: {spell.Value}");
            }
        }

        public static Dictionary<string, string> GetSpellInfo()
        {
            return spellInfo;
        }

        public static int LightningBolt()
        {
            Console.WriteLine("You cast Lightning Bolt! A surge of lightning strikes your enemy, dealing massive damage.");
            int effect = random.Next(1, 7);
            return effect;
        }

        public static int MagicMissile()
        {
            Console.WriteLine("You cast Magic Missile! Three arcane projectiles fly towards your enemy!");
            int effect = random.Next(1, 11);
            return effect;
        }

        public static int Heal()
        {
            Console.WriteLine("You cast Heal! Radiant light rejuvenate your wounds.");
            int effect = random.Next(1, 11);
            return effect;
        }

        public static bool Invisibility()
        {
            Console.WriteLine("You cast Invisibility! Your body becomes fully transparent and enemies cannot detect you for 1 round.");
            return true;
        }

        public static int Shield()
        {
            Console.WriteLine("You cast Shield! A magical barrier surrounds you, blocking incoming damage.");
            int effect = 5;
            return effect;
        }
    }
}