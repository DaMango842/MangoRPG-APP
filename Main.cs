using MangoRPG_APP.Class;
using MangoRPG_APP.Utils;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace MangoRPG_APP
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        //开始
        private void startButton_Click(object sender, EventArgs e)
        {

            EnterName enterName = new EnterName();
            this.Hide();
            enterName.ShowDialog();
            Application.ExitThread();
        }
        //读档
        private void loadButton_Click(object sender, EventArgs e)
        {
            //定位所在的文件
            string savefile = Environment.CurrentDirectory + "\\mangorpg.db";
            //判定是否存在该文件
            if (File.Exists(savefile))
            {
                LiteDBHelper liteDBHelper = new LiteDBHelper();
                var list = liteDBHelper.FindAll<Player>("user_data").ToList().Where(x => x.Name == "Mango");
                //提示读档成功
                MessageBox.Show("存档读取成功");
                Game game = new Game(list.First());
                this.Hide();
                game.ShowDialog();
                Application.ExitThread();
            }
            else //反之创建新游戏
            {
                MessageBox.Show("存档不存在!\r\n已为你跳转至新游戏");
                EnterName enterName = new EnterName();
                this.Hide();
                enterName.ShowDialog();
                Application.ExitThread();
            }
        }
        //关于
        private void aboutButton_Click(object sender, EventArgs e)
        {
            //假关于界面
            //MainAbout mainAbout = new MainAbout();
            //mainAbout.ShowDialog();
            //真关于界面
            AboutForm aboutForm = new AboutForm();
            aboutForm.Owner = this;
            aboutForm.ShowDialog();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.ExitThread();
        }
    }
}