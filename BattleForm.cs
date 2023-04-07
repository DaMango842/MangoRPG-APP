using MangoRPG_APP.Assets;
using MangoRPG_APP.Class;
using MangoRPG_APP.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangoRPG_APP
{
    public partial class BattleForm : Form
    {
        //private Player player { get; set; }
        private Player player = new Player();
        private IList<Enemy> enemyList { get; set; }

        private Enemy currentEnemy { get; set; }

        //声明Lite DB 帮助类
        LiteDBHelper liteDBHelper;

        public BattleForm()
        {
            InitializeComponent();

            this.ControlBox = false;

            liteDBHelper = new LiteDBHelper();
            var list = liteDBHelper.FindAll<Player>("user_data").ToList().Where(x => x.Name == "Mango");
            if (list.Count() > 0)
            {
                player = list.FirstOrDefault();
            }
            //player = _player;

            //加载敌人数据源
            enemyList = new Datasources().LoadEnemies();
            //随机取一个敌人
            int r = new Random().Next(enemyList.Count);
            currentEnemy = enemyList[r];

            textUpdate();

            label40.Text = "玩家回合";

        }
        //攻击
        private void button1_Click(object sender, EventArgs e)
        {
            var pDamage = (player.Atk + player.Matk) - currentEnemy.Def;
            currentEnemy.Hp -= pDamage;
            if (currentEnemy.Hp < 0)
            {
                currentEnemy.Hp = 0;
            }
            label41.Text = player.Name + " 对 " + currentEnemy.Name + " 造成" + pDamage + "点伤害!\r\n";
            label41.Text += currentEnemy.Name + "的血量为" + currentEnemy.Hp + "!\r\n";

            textUpdate();

            label40.Text = "敌人回合";

            var eDamage = (currentEnemy.Atk + currentEnemy.Matk) - (player.Def + player.Mdef);
            player.Hp -= eDamage;
            if (player.Hp < 0)
            {
                player.Hp = 0;
            }
            else if (player.Hp > player.Hpmax)
            {
                player.Hp = player.Hpmax;
            }
            else { }
            label41.Text += currentEnemy.Name + " 对 " + player.Name + " 造成" + eDamage + "点伤害!\r\n";
            label41.Text += player.Name + "的血量为" + player.Hp + "!\r\n";

            textUpdate();

            label40.Text = "结束回合";

            if (player.Hp > player.Hpmax)
            {
                player.Hp = player.Hpmax;
            }
            if (currentEnemy.Hp > currentEnemy.Hpmax)
            {
                currentEnemy.Hp = currentEnemy.Hpmax;
            }
            if (player.Hp <= 0)
            {
                label41.Text += "战斗失败!";
                Application.Exit();
            }
            else if (currentEnemy.Hp <= 0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                label41.Text += "战斗胜利!";
                player.Money += currentEnemy.Money;
                player.Exp += currentEnemy.Exp;
                textUpdate();
                label41.Text += player.Name + "获得了 " + currentEnemy.Money + "金钱和 " + currentEnemy.Exp + "经验\r\n";
                if (player.Exp >= player.Nextexp)
                {
                    player.LevelUp();
                    label41.Text += "下个等级所需经验:" + (player.Nextexp - player.Exp) + "点经验\r\n";
                }
                else
                {
                    label41.Text += "下个等级所需经验:" + (player.Nextexp - player.Exp) + "点经验\r\n";
                }

                liteDBHelper.Update(player, "user_data");

                this.ControlBox = true;
            }
            else
            {
                label40.Text = "玩家回合";
            }
        }
        //技能
        private void button2_Click(object sender, EventArgs e)
        {

        }
        //物品
        private void button3_Click(object sender, EventArgs e)
        {

        }
        //逃跑
        private void button4_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            var runSuccessPoint = r.Next(0, 100);
            if (runSuccessPoint >= 65)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                label41.Text = "逃跑成功!";
                this.ControlBox = true;
            }
            else
            {
                label41.Text = "逃跑失败!";
            }
        }

        private void textUpdate()
        {
            label11.Text = player.Name;
            label12.Text = Convert.ToString(player.Lv);
            label13.Text = Convert.ToString(player.Hp) + " / " + Convert.ToString(player.Hpmax);
            label14.Text = Convert.ToString(player.Mana) + " / " + Convert.ToString(player.Manamax);
            label15.Text = Convert.ToString(player.Atk);
            label16.Text = Convert.ToString(player.Def);
            label17.Text = Convert.ToString(player.Matk);
            label18.Text = Convert.ToString(player.Mdef);
            label19.Text = Convert.ToString(player.Money);
            label20.Text = Convert.ToString(player.Exp) + " / " + Convert.ToString(player.Nextexp);


            label30.Text = currentEnemy.Name;
            label31.Text = Convert.ToString(currentEnemy.Lv);
            label32.Text = Convert.ToString(currentEnemy.Hp) + " / " + Convert.ToString(currentEnemy.Hpmax);
            label33.Text = Convert.ToString(currentEnemy.Atk);
            label34.Text = Convert.ToString(currentEnemy.Def);
            label35.Text = Convert.ToString(currentEnemy.Matk);
            label36.Text = Convert.ToString(currentEnemy.Mdef);
            label37.Text = Convert.ToString(currentEnemy.Money);
            label38.Text = Convert.ToString(currentEnemy.Exp);

        }

        private void BattleForm_Load(object sender, EventArgs e)
        {
            label11.Text = player.Name;
            label12.Text = Convert.ToString(player.Lv);
            label13.Text = Convert.ToString(player.Hp) + " / " + Convert.ToString(player.Hpmax);
            label14.Text = Convert.ToString(player.Mana) + " / " + Convert.ToString(player.Manamax);
            label15.Text = Convert.ToString(player.Atk);
            label16.Text = Convert.ToString(player.Def);
            label17.Text = Convert.ToString(player.Matk);
            label18.Text = Convert.ToString(player.Mdef);
            label19.Text = Convert.ToString(player.Money);
            label20.Text = Convert.ToString(player.Exp) + " / " + Convert.ToString(player.Nextexp);


            label30.Text = currentEnemy.Name;
            label31.Text = Convert.ToString(currentEnemy.Lv);
            label32.Text = Convert.ToString(currentEnemy.Hp) + " / " + Convert.ToString(currentEnemy.Hpmax);
            label33.Text = Convert.ToString(currentEnemy.Atk);
            label34.Text = Convert.ToString(currentEnemy.Def);
            label35.Text = Convert.ToString(currentEnemy.Matk);
            label36.Text = Convert.ToString(currentEnemy.Mdef);
            label37.Text = Convert.ToString(currentEnemy.Money);
            label38.Text = Convert.ToString(currentEnemy.Exp);
        }

        private void BattleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Game game = (Game)this.Owner;
            game.textUpdate();
        }
    }
}
