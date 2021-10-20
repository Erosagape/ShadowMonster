using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowMonsters.Items
{
    public interface IItem
    {
        string Name { get; }
        int Price { get; }
        bool Usable { get; }
        void Apply(Monster monster);
    }
    public class Item
    {
        public string Name;
        public int Count;
    }
}
