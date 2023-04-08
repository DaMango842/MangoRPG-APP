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
        //��ʼ
        private void startButton_Click(object sender, EventArgs e)
        {

            EnterName enterName = new EnterName();
            this.Hide();
            enterName.ShowDialog();
            Application.ExitThread();
        }
        //����
        private void loadButton_Click(object sender, EventArgs e)
        {
            //��λ���ڵ��ļ�
            string savefile = Environment.CurrentDirectory + "\\mangorpg.db";
            //�ж��Ƿ���ڸ��ļ�
            if (File.Exists(savefile))
            {
                LiteDBHelper liteDBHelper = new LiteDBHelper();
                var list = liteDBHelper.FindAll<Player>("user_data").ToList().Where(x => x.Name == "Mango");
                //��ʾ�����ɹ�
                MessageBox.Show("�浵��ȡ�ɹ�");
                Game game = new Game(list.First());
                this.Hide();
                game.ShowDialog();
                Application.ExitThread();
            }
            else //��֮��������Ϸ
            {
                MessageBox.Show("�浵������!\r\n��Ϊ����ת������Ϸ");
                EnterName enterName = new EnterName();
                this.Hide();
                enterName.ShowDialog();
                Application.ExitThread();
            }
        }
        //����
        private void aboutButton_Click(object sender, EventArgs e)
        {
            //�ٹ��ڽ���
            //MainAbout mainAbout = new MainAbout();
            //mainAbout.ShowDialog();
            //����ڽ���
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