using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace textBaseRPG
{
    internal class WizardActions
    {
        public static string ChooseSpell(Wizard wizard)
        {
            Console.WriteLine("Choose a spell to cast:");
            for (int i = 0; i < wizard.spells.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {wizard.spells[i]}");
            }

            int choice = int.Parse(Console.ReadLine());
            return wizard.spells[choice - 1];
        }

        public static int CastSpell(Wizard wizard, string spell)
        {
            int effect = 0;
            bool enemyMisses = false;
            switch (spell)
            {
                case "Lightning Bolt":
                    effect = Spells.LightningBolt();
                    break;

                case "Magic Missile":
                    effect = Spells.MagicMissile();
                    break;

                case "Heal":
                    effect = Spells.Heal();
                    wizard.Heal(effect);
                    break;

                case "Invisibility":
                    enemyMisses = Spells.Invisibility();
                    break;

                case "Shield":
                    effect = Spells.Shield();
                    wizard.Shield(effect);
                    break;

                default:
                    Console.WriteLine($"Spell is not recognized.");
                    break;
            }
            wizard.SpellSlots--;
            Console.WriteLine($"Remaining spell slots: {wizard.spellSlots}");
            //wizard.GainExperience(0.2f);
            return effect;
        }

        public static void Meditate(Wizard wizard)
        {
            Console.WriteLine($"\n>{wizard.name} meditates to regain 2 spells slots!");
            wizard.spellSlots += 2;
            Console.WriteLine($"you now have {wizard.spellSlots} spellslots");
        }
    }
}