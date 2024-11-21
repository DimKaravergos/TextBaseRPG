using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textBaseRPG
{
    internal class Battles
    {
        public static void Battle(Wizard wizard, dynamic enemy)
        {
            // Battle loop
            bool enemyMissesNextAttack = false;
            while (enemy.HP > 0)
            {
                Console.WriteLine("\n>What would you like to do?");
                Console.WriteLine("1. Cast Spell");
                Console.WriteLine("2. Meditate to regain spell slots");

                string action = Console.ReadLine();
                if (action == "1")
                {
                    if (wizard.SpellSlots > 0)
                    {
                        bool enemyMisses = true;
                        string chosenSpell = WizardActions.ChooseSpell(wizard);
                        int spellEffect = WizardActions.CastSpell(wizard, chosenSpell);

                        switch (chosenSpell)
                        {
                            case "Lightning Bolt":
                                enemy.TakeDamage(spellEffect);

                                // Check if the enemy is dead
                                if (enemy.HP <= 0)
                                {
                                    Console.WriteLine("You are victorious!");
                                    return;
                                }
                                break;

                            case "Magic Missile":
                                enemy.TakeDamage(spellEffect);
                                if (enemy.HP <= 0)
                                {
                                    Console.WriteLine("You are victorious!");
                                    return;
                                }
                                break;

                            case "Heal":
                                break;

                            case "Invisibility":
                                if (enemyMisses)
                                {
                                    enemyMissesNextAttack = true;
                                    Console.WriteLine("\nYou are invisible. Enemy will miss next attack.");
                                }
                                break;

                            case "Shield":
                                break;

                            default:
                                Console.WriteLine("Unknown spell.");
                                break;
                        }

                        if (enemyMissesNextAttack)
                        {
                            Console.WriteLine("The enemy misses their attack due to invisibility!");
                            enemyMissesNextAttack = false;  // Reset for the next turn
                        }
                        else
                        {
                            // Enemy attacks back
                            int enemyDamage = enemy.Attack();
                            wizard.TakeDamage(enemyDamage);
                        }
                    }
                    else
                    {
                        Console.WriteLine("You ran out of spell slots!");
                    }
                }
                else if (action == "2")
                {
                    WizardActions.Meditate(wizard);
                    int enemyDamage = enemy.Attack();
                    wizard.TakeDamage(enemyDamage);
                }
                else
                {
                    Console.WriteLine("Invalid choice, try again.");
                }
            }
        }
    }
}