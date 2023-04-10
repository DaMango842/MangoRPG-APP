namespace MangoRPG_APP.Class
{
    public class Player
    {
        public Guid ID { get; set; } = new Guid();
        public string? Name { get; set; }
        public int? Lv { get; set; }
        public int? LvMax { get; set; } = 10; // 等级上限,固定设置
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
        //升级函数
        public void LevelUp()
        {
            //首先调用随机函数
            Random random = new Random();
            //扣除经验
            Exp -= Nextexp;
            //等级提升与属性提升
            Lv += 1;
            Hpmax += (random.Next(0, 30) - 5) + Lv;
            Manamax += (random.Next(0, 30) - 10) + Lv;
            Atk += random.Next(0, 12) - 2;
            Def += random.Next(0, 12) - 2;
            Matk += random.Next(0, 12) - 4;
            Mdef += random.Next(0, 12) - 4;
            //计算下个等级的经验
            Nextexp = Nextexp + random.Next(0, 10);
        }

    }
}
