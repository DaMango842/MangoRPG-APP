using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRPG_APP.Class
{
    public class Player
    {

        public Guid ID { get; set; } = new Guid();
        public string? Name { get; set; }
        public int? Lv { get; set; }
        public int? Hp { get; set; }
        public int? Hpmax { get; set; }
        public int? Mana { get; set; }
        public int? Manamax { get; set; }
        public int? Atk { get; set; }
        public int? Def { get; set; }
        public int? Matk { get; set; }
        public int? Mdef { get; set; }
        public int? Money { get; set; }
        public int? Exp { get; set; }
        public int? Nextexp { get; set; }
        public Weapon? CurrWeapon { get; set; }
        public Armor? CurrArmor { get; set; }
        //背包
        public Inventory? Inventory { get; set; }


        public void LevelUp()
        {
            Random random = new Random();

            Exp -= Nextexp;
            Lv += 1;
            Hpmax += random.Next(0, 30);
            Manamax += random.Next(0, 30) - 10;
            Atk += random.Next(0, 10) - 1;
            Def += random.Next(0, 10) - 1;
            Matk += random.Next(0, 10) - 2;
            Mdef += random.Next(0, 10) - 2;
            
            Nextexp = Nextexp + random.Next(0, 10);
        }

    }
}
