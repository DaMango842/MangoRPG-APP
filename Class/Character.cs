using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRPG_APP.Class
{
    public class Character
    {
        public string name { get; set; }
        public int lv { get; set; }
        public int hp { get; set; }
        public int hpmax { get; set; }
        public int mana { get; set; }
        public int manamax { get; set; }
        public int atk { get; set; }
        public int def { get; set; }
        public int matk { get; set; }
        public int mdef { get; set; }
        public int money { get; set; }
        public int exp { get; set; }
        public int nextexp { get; set; }
    }
}
