using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRPG_APP.Class
{
    public enum ItemType
    {
        武器,
        防具,
        消耗品
    }

    public class Item
    {
        public Guid Id { get; } = new Guid();
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType itemType { get; set; }
        public int Lv { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int SellPrice { get; set; }
    }

    public class Weapon:Item
    {
        public int atk { get; set; }
        public int matk { get; set; }
    }

    public class Armor : Item
    {
        public int hpmax { get; set; }
        public int manamax { get; set; }
        public int def { get; set; }
        public int mdef { get; set; }
    }

    public class Consumable : Item
    {
        public int hp { get; set; }
        public int mana { get; set; }
    }



}
