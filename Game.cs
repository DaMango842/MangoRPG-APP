using MangoRPG_APP.Class;
using MangoRPG_APP.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangoRPG_APP
{
    public partial class Game : Form
    {
        private Player player { get; set; }
        //声明Lite DB 帮助类
        LiteDBHelper liteDBHelper;
        public Game(Player _player)
        {
            InitializeComponent();
            player = _player;
            liteDBHelper = new LiteDBHelper();

            textUpdate();

            Text = "欢迎回来," + player.Name + " - 游戏菜单";

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.ExitThread();
        }

        private void b站主页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://space.bilibili.com/31836115";
            Process.Start("explorer.exe", url);
        }

        private void githubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/DaMango842";
            Process.Start("explorer.exe", url);
        }

        private void 保存存档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LiteDBHelper liteDBHelper = new LiteDBHelper();
            liteDBHelper.Save(player, "user_data");
        }

        private void 读取存档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LiteDBHelper liteDBHelper = new LiteDBHelper();
            var list = liteDBHelper.FindAll<Player>("user_data").ToList().Where(x => x.Name == player.Name);
        }
        //背包
        private void button4_Click(object sender, EventArgs e)
        {
            Backpacks backpacks = new Backpacks();
            backpacks.ShowDialog();
            //Application.ExitThread();
        }
        //战斗
        private void button1_Click(object sender, EventArgs e)
        {
            BattleForm bform = new BattleForm();
            bform.Owner = this;
            //this.Hide();
            bform.ShowDialog();
            //Application.ExitThread();
        }

        public void textUpdate()
        {
            var list = liteDBHelper.FindAll<Player>("user_data").ToList().Where(x => x.Name == "Mango");
            if (list.Count() > 0)
            {
                player = list.FirstOrDefault();
            }
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
        }
        //商店
        private void button3_Click(object sender, EventArgs e)
        {
            Shop shop = new Shop();
            shop.Owner = this;
            // this.Hide();
            shop.ShowDialog();
            //Application.ExitThread();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            player.Money -= 20;
            player.Hp = player.Hpmax;
            MessageBox.Show("已消耗20金币恢复所有生命");
            liteDBHelper.Update(player, "user_data");
        }

        private void 关于ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Owner = this;
            aboutForm.ShowDialog();
        }
    }
}
