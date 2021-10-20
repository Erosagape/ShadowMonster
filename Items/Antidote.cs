using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowMonsters.Items
{
    public class Antidote : IItem
    {
        public string Name => "Antidote";

        public int Price => 1000;

        public bool Usable => true;

        public void Apply(Monster monster)
        {
            monster.IsPoisoned = false;
        }
    }
}
