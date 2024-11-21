using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textBaseRPG
{
    internal class Goblin
    {
        public int HP { get; private set; }
        private Random random;

        public Goblin()
        {
            HP = 10;
            random = new Random();
        }

        public int Attack()
        {
            int damage = random.Next(1, 7);
            Console.WriteLine($"\n>Goblin attacks and deals {damage} damage!");
            return damage;
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;
            Console.WriteLine($"\n>Goblin takes {damage} damage. Goblin HP: {HP}");

            if (HP <= 0)
            {
                Console.WriteLine("\n>The Goblin has been defeated!");
            }
        }
    }

    internal class Banshee
    {
        public int HP { get; private set; }
        private Random random;

        public Banshee()
        {
            HP = 10;
            random = new Random();
        }

        public int Attack()
        {
            int damage = random.Next(3, 9);
            Console.WriteLine($"\n>Banshee wails and deals {damage} damage!");
            return damage;
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;
            Console.WriteLine($"\n>Banshee takes {damage} damage. Banshee HP: {HP}");

            if (HP <= 0)
            {
                Console.WriteLine("\n>The Banshee has been defeated!");
            }
        }
    }

    internal class Kobold
    {
        public int HP { get; private set; }
        private Random random;

        public Kobold()
        {
            HP = 10;
            random = new Random();
        }

        public int Attack()
        {
            int damage = random.Next(2, 6);
            Console.WriteLine($"\n>Kobold slashes and deals {damage} damage!");
            return damage;
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;
            Console.WriteLine($"\n>Kobold takes {damage} damage. Kobold HP: {HP}");

            if (HP <= 0)
            {
                Console.WriteLine("\n>The Kobold has been defeated!");
            }
        }
    }
}