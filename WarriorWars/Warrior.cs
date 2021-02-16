﻿using System;
using System.Collections.Generic;
using System.Text;
using WarriorWars.Enum;
using WarriorWars.Equipment;

namespace WarriorWars
{
    class Warrior
    {
        private const int GOOD_GUY_STARTING_HEALTH = 90;
        private const int BAD_GUY_STARTING_HEALTH = 100;

        private readonly Faction FACTION;

        private int health;
        private string name;
        private bool isAlive;

        public bool IsAlive { 
            get
            {
                return isAlive;
            }
        }

        private Weapon weapon;
        private Armor armor;

        public Warrior(string name, Faction faction)
        {
            this.name = name;
            FACTION = faction;
            isAlive = true;

            switch (faction)
            {
                case Faction.GoodGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = GOOD_GUY_STARTING_HEALTH;
                    break;
                case Faction.BadGuy:
                    weapon = new Weapon(faction);
                    armor = new Armor(faction);
                    health = BAD_GUY_STARTING_HEALTH;
                    break;
                default:
                    break;

            }
        }

        public void Attack(Warrior enemy)
        {
            int damage = weapon.Damage / enemy.armor.ArmorPoints;
            enemy.health -= damage;
            if (enemy.health <= 0)
            {
                enemy.isAlive = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{enemy.name} is dead!");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{name} is victorious!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"{name} attacked {enemy.name}. {damage} damage was inflicted to {enemy.name}, remaining health of {enemy.name} is {enemy.health}.");
            }
        }

    }
}
