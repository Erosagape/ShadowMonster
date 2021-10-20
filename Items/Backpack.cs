using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShadowMonsters.Items
{
    public class Backpack
    {
        private readonly List<Item> items = new List<Item>();
        public List<Item> Items { get => items; }
        public Backpack() { }
        public void AddItem(IItem item,int count)
        {
            if(items.Any(x => x.Name == item.Name))
            {
                for(int i = 0; i < items.Count; i++)
                {
                    if (items[i].Name == item.Name)
                    {
                        items[i].Count = items[i].Count + count;
                    }
                }
            } else
            {
                Item i = new Item() {
                    Name = item.Name,
                    Count = count
                };
                items.Add(i);
            }
        }
        public void AddItem(string item,int count)
        {
            if (items.Any(x => x.Name == item))
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].Name == item)
                    {
                        items[i].Count = items[i].Count + count;
                    }
                }
            }
            else
            {
                Item i = new Item()
                {
                    Name = item,
                    Count = count
                };
                items.Add(i);
            }
        }
        public IItem GetItem(string item)
        {
            if (!items.Any(x => x.Name == item))
            {
                return null;
            }
            for(int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == item)
                {
                    items[i].Count--;
                    if (items[i].Count < 1)
                    {
                        items.RemoveAt(i);
                    }
                    break;
                }
            }
            switch (item)
            {
                case "Potion":
                    return new Potion();
                case "Antidote":
                    return new Antidote();
                default:
                    return null;
            }
        }
        public IItem PeekItem(string item)
        {
            if (!items.Any(x => x.Name == item))
                return null;
            switch (item)
            {
                case "Potion":
                    return new Potion();
                case "Antidote":
                    return new Antidote();
                default:
                    return null;
            }
        }
    }
}
