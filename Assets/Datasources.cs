using MangoRPG_APP.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRPG_APP.Assets
{
    public class Datasources
    {
        public IList<Weapon> loadWeapon() {

            IList<Weapon> weaponList = new List<Weapon>();
            weaponList.Add(new Weapon()
            {
                Lv = 1,
                Name = "旧木剑",
                atk = 2,
                matk = 0,
                itemType = ItemType.武器,
                Description = "已经破旧的木剑,据说是某位勇者用完后不用的废弃物品",
                Count = 1,
                Price = 10,
                SellPrice = 5
            });

            weaponList.Add(new Weapon()
            {
                Lv = 1,
                Name = "木剑",
                atk = 5,
                matk = 0,
                itemType = ItemType.武器,
                Description = "这把剑很新,几乎看不出什么端倪",
                Count = 1,
                Price = 12,
                SellPrice = 6
            });

            weaponList.Add(new Weapon()
            {
                Lv = 1,
                Name = "桃木剑",
                atk = 8,
                matk = 2,
                itemType = ItemType.武器,
                Description = "放在以前是某位仙人使用的桃木剑,但现在已经无人问津了",
                Count = 1,
                Price = 20,
                SellPrice = 10
            });
            return weaponList;
        }

        public IList<Armor> loadArmor()
        {

            IList<Armor> armorList = new List<Armor>();
            armorList.Add(new Armor()
            {
                Lv = 1,
                Name = "皮衣",
                def = 1,
                mdef = 0,
                itemType = ItemType.防具,
                Description = "用动物皮制成,但现在基本很少了",
                Count = 1,
                Price = 10,
                SellPrice = 2
            });

            armorList.Add(new Armor()
            {
                Lv = 1,
                Name = "旧勇者衣",
                def = 3,
                mdef = 0,
                itemType = ItemType.防具,
                Description = "经过岁月洗礼,却安然无恙的衣服,究竟是什么来头?",
                Count = 1,
                Price = 14,
                SellPrice = 7
            });

            armorList.Add(new Armor()
            {
                Lv = 1,
                Name = "铜盔甲",
                def = 2,
                mdef = 2,
                itemType = ItemType.防具,
                Description = "看似没什么太大问题,除了...",
                Count = 1,
                Price = 20,
                SellPrice = 10
            });
            return armorList;
        }

        public IList<Consumable> loadConsumable()
        {

            IList<Consumable> consumableList = new List<Consumable>();
            consumableList.Add(new Consumable()
            {
                Lv = 1,
                Name = "草药",
                hp = 1,
                mana = 0,
                itemType = ItemType.消耗品,
                Description = "你好",
                Count = 1,
                Price = 100,
                SellPrice = 1
            });

            consumableList.Add(new Consumable()
            {
                Lv = 1,
                Name = "Yeee",
                hp = 1,
                mana = 0,
                itemType = ItemType.消耗品,
                Description = "你好",
                Count = 1,
                Price = 100,
                SellPrice = 1
            });

            consumableList.Add(new Consumable()
            {
                Lv = 1,
                Name = "Yeeeeee",
                hp = 1,
                mana = 0,
                itemType = ItemType.消耗品,
                Description = "你好",
                Count = 1,
                Price = 100,
                SellPrice = 1
            });
            return consumableList;
        }

        public IList<Enemy> LoadEnemies()
        {
            IList<Enemy> enemiesList = new List<Enemy>();
            enemiesList.Add(new Enemy()
            {
                Name = "史莱姆",
                Lv = 1,
                Hp = 20,
                Hpmax = 20,
                Atk = 1,
                Def = 1,
                Matk = 0,
                Mdef = 0,
                Money = 3,
                Exp = 2
            });
            enemiesList.Add(new Enemy()
            {
                Name = "骷髅",
                Lv = 1,
                Hp = 100,
                Hpmax = 100,
                Atk = 4,
                Def = 2,
                Matk = 0,
                Mdef = 0,
                Money = 3,
                Exp = 3
            });
            enemiesList.Add(new Enemy()
            {
                Name = "小蝙蝠",
                Lv = 1,
                Hp = 100,
                Hpmax = 100,
                Atk = 6,
                Def = 3,
                Matk = 0,
                Mdef = 0,
                Money = 4,
                Exp = 3
            });

            return enemiesList;
        }


    }
}
