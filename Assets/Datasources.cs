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
                Name = "树枝",
                atk = 1,
                matk = 1,
                itemType = ItemType.武器,
                Description = "于哲的小树枝",
                Count = 1,
                Price = 100,
                SellPrice = 1
            });

            weaponList.Add(new Weapon()
            {
                Lv = 1,
                Name = "粑粑",
                atk = 1,
                matk = 100,
                itemType = ItemType.武器,
                Description = "小黑拉的粑粑",
                Count = 1,
                Price = 100,
                SellPrice = 1
            });

            weaponList.Add(new Weapon()
            {
                Lv = 1,
                Name = "林克的小刀",
                atk = 2,
                matk = 1,
                itemType = ItemType.武器,
                Description = "好像生锈了",
                Count = 1,
                Price = 100,
                SellPrice = 1
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
                mdef = 1,
                itemType = ItemType.防具,
                Description = "你好",
                Count = 1,
                Price = 100,
                SellPrice = 1
            });

            armorList.Add(new Armor()
            {
                Lv = 1,
                Name = "Yeee",
                def = -1,
                mdef = -1,
                itemType = ItemType.防具,
                Description = "你好",
                Count = 1,
                Price = 100,
                SellPrice = 1
            });

            armorList.Add(new Armor()
            {
                Lv = 1,
                Name = "Yeeeeee",
                def = 2,
                mdef = 2,
                itemType = ItemType.防具,
                Description = "你好",
                Count = 1,
                Price = 100,
                SellPrice = 1
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
                Name = "测试敌人",
                Lv = 1,
                Hp = 100,
                Hpmax = 100,
                Atk = 2,
                Def = 0,
                Matk = 0,
                Mdef = 0,
                Money = 3,
                Exp = 2
            });
            enemiesList.Add(new Enemy()
            {
                Name = "测试敌人2",
                Lv = 1,
                Hp = 100,
                Hpmax = 100,
                Atk = 3,
                Def = 1,
                Matk = 0,
                Mdef = 0,
                Money = 3,
                Exp = 3
            });
            enemiesList.Add(new Enemy()
            {
                Name = "测试敌人3",
                Lv = 1,
                Hp = 100,
                Hpmax = 100,
                Atk = 3,
                Def = 0,
                Matk = 0,
                Mdef = 0,
                Money = 4,
                Exp = 3
            });

            return enemiesList;
        }


    }
}
