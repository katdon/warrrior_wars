using System;
using System.Threading;

namespace WarriorWars
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            
            Warrior goodGuy = new Warrior("Bob", Enum.Faction.GoodGuy);
            Warrior badGuy = new Warrior("Joe", Enum.Faction.BadGuy);

            while (goodGuy.IsAlive && badGuy.IsAlive)
            {
                if (rnd.Next(0,10) < 5)
                {
                    goodGuy.Attack(badGuy);

                }
                else
                {
                    badGuy.Attack(goodGuy);
                }
                Thread.Sleep(200);
            }
        }
    }
}
