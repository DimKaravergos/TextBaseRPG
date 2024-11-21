using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textBaseRPG
{
    internal class Hoarder
    {
        private Dictionary<string, (string Description, int Price)> itemsForSale;

        public Hoarder()
        {
            // List of items Hoarder has
            itemsForSale = new Dictionary<string, (string Description, int Price)>
            {
                { "Health Potion", ("Restores 20 HP", 10) },
                { "Mana Elixir", ("Restores 2 spell slots", 15) },
                { "Magic Scroll", ("Grants a random new spell", 25) },
                { "Sword of Sparks", ("Deals extra 1-3 damage with lightning spells", 40) },
                { "Cloak of Shadows", ("Increases invisibility spell duration", 35) }
            };
        }

        public void DisplayItems()
        {
            Console.WriteLine("\n>Welcome to the Hoarder's shop! Here are the items available for purchase:");
            int i = 1;
            foreach (var item in itemsForSale)
            {
                Console.WriteLine($"{i}. {item.Key} - {item.Value.Description} (Price: {item.Value.Price} gold)");
                i++;
            }
            Console.WriteLine();
        }

        public void SellItem(Wizard wizard)
        {
            DisplayItems();
            Console.WriteLine($"You have {Wizard.gold} gold.");
            Console.WriteLine("Enter the number of the item you'd like to purchase (or 0 to exit):");

            string input = Console.ReadLine();
            bool isValid = int.TryParse(input, out int choice) && choice >= 1 && choice <= itemsForSale.Count;

            if (isValid)
            {
                string selectedItem = GetItemByNumber(choice);
                int price = itemsForSale[selectedItem].Price;

                // Check if the wizard has enough gold
                if (Wizard.gold >= price)
                {
                    Wizard.gold -= price;
                    Console.WriteLine($"You purchased {selectedItem} for {price} gold. You now have {Wizard.gold} gold.");
                    ApplyItemEffect(wizard, selectedItem);  // Apply the effect of the purchased item
                }
                else
                {
                    Console.WriteLine("\n>You don't have enough gold for that item!");
                }
            }
            else if (choice == 0)
            {
                Console.WriteLine(">Leaving the Hoarder's shop.");
            }
            else
            {
                Console.WriteLine("Invalid choice, please try again.");
            }
        }

        // Apply the effects of the item to the wizard
        private void ApplyItemEffect(Wizard wizard, string item)
        {
            switch (item)
            {
                case "Health Potion":
                    Wizard.hp += 20;
                    Console.WriteLine($"{wizard.name} drinks a Health Potion and restores 20 HP. Current HP: {Wizard.hp}.");
                    break;

                case "Mana Elixir":
                    wizard.SpellSlots += 2;
                    Console.WriteLine($"{wizard.name} drinks a Mana Elixir and restores 2 spell slots. Current spell slots: {wizard.SpellSlots}.");
                    break;

                case "Magic Scroll":
                    // You could add logic to add a random spell to the wizard's spellbook here
                    Console.WriteLine("You open the Magic Scroll and gain a random new spell!");
                    // wizard.Spells.Add("RandomSpell"); // Add random spell logic
                    break;

                case "Sword of Sparks":
                    Console.WriteLine("The Sword of Sparks is now in your inventory. It boosts your lightning spells' damage.");
                    // Add additional bonus effect for lightning spells if implemented
                    break;

                case "Cloak of Shadows":
                    Console.WriteLine("The Cloak of Shadows increases your invisibility spell duration.");
                    // Add invisibility spell boost effect if implemented
                    break;

                default:
                    Console.WriteLine("Unknown item.");
                    break;
            }
        }

        // Helper method to get item name by the user's choice
        private string GetItemByNumber(int choice)
        {
            int index = 1;
            foreach (var item in itemsForSale)
            {
                if (index == choice)
                {
                    return item.Key;
                }
                index++;
            }
            return null;
        }
    }
}