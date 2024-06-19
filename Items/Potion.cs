using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowMonsters.Items
{
    class Potion : IItem
    {
        public string Name { get { return "Potion"; } }
        public int Price { get { return 200; } }
        public bool Usable => true;
        public void Apply(ShadowMonster monster)
        {
            monster.Heal(50);
        }
    }
}
