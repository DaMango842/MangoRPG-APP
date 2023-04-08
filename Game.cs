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
using System.Security.Policy;
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
        //背包
        private void button4_Click(object sender, EventArgs e)
        {
            Backpacks backpacks = new Backpacks();
            backpacks.ShowDialog();
        }
        //战斗
        private void button1_Click(object sender, EventArgs e)
        {
            BattleForm bform = new BattleForm();
            bform.Owner = this;
            bform.ShowDialog();
        }
        //刷新用
        public void textUpdate()
        {
            var list = liteDBHelper.FindAll<Player>("user_data").ToList().Where(x => x.Name == player.Name);
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
        //临时回血功能,花费金币
        private void button5_Click(object sender, EventArgs e)
        {
            if (player.Money >= 20)
            {
                player.Money -= 20;
                player.Hp = player.Hpmax;
                MessageBox.Show("已消耗20金币恢复所有生命");
                liteDBHelper.Update(player, "user_data");
            }
            else
            {
                MessageBox.Show("你没有足够的金币!");
            }
            textUpdate();
        }
        // 退出按钮
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.ExitThread();
        }
        // 链接网页
        private void b站主页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://space.bilibili.com/31836115";
            Process.Start("explorer.exe", url);
        }
        // 链接网页
        private void githubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/DaMango842";
            Process.Start("explorer.exe", url);
        }
        //保存
        private void 保存存档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LiteDBHelper liteDBHelper = new LiteDBHelper();
            liteDBHelper.Save(player, "user_data");
        }
        //读取
        private void 读取存档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LiteDBHelper liteDBHelper = new LiteDBHelper();
            var list = liteDBHelper.FindAll<Player>("user_data").ToList().Where(x => x.Name == player.Name);
        }
        //关于界面
        private void 关于ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Owner = this;
            aboutForm.ShowDialog();
        }
        // 删除存档
        private void 删除存档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //定位文件位置
            string savefile = Environment.CurrentDirectory + "\\mangorpg.db";
            //删除存档工作
            if (File.Exists(savefile))
            {
                File.Delete(savefile);
                DialogResult dr = MessageBox.Show("存档已删除,请重启游戏!", "Mango RPG", MessageBoxButtons.OK);
                //退出游戏
                if (dr == DialogResult.OK)
                {
                    Application.Exit();
                }
                else
                {
                    Application.Exit();
                }
            }
            //未找到存档
            else
            {
                MessageBox.Show("存档不存在!");
            }
        }

        private void 打开存档文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string savefile = Environment.CurrentDirectory;
            Process.Start("explorer.exe", savefile);
        }
    }
}
