using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ShadowMonsters.Items
{
    public interface IItem
    {
        string Name { get; }
        int Price { get; }
        bool Usable { get; }
        void Apply(ShadowMonster monster);
    }
    public class Item
    {
        public string Name;
        public int Count;
        public void Save(BinaryWriter writer)
        {
            writer.Write(Name);
            writer.Write(Count);
        }

    }
}
