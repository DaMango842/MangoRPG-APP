using MangoRPG_APP.Class;
using System.Numerics;
using System.Security.Cryptography;

namespace MangoRPG_APP
{
    public partial class EnterName : Form
    {

        public EnterName()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //private Player player;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string nameInput = textBox1.Text;
                // e
                Player player = new Player()
                {
                    Name = nameInput,
                    Lv = 1,
                    Hp = 100,
                    Hpmax = 100,
                    Mana = 0,
                    Manamax = 0,
                    Atk = 5,
                    Def = 2,
                    Matk = 0,
                    Mdef = 0,
                    Money = 2000000,
                    Exp = 0,
                    Nextexp = 10
                };

                Game form2 = new Game(player);
                this.Hide();
                form2.ShowDialog();
                Application.ExitThread();
            }
            else
            {
                MessageBox.Show("请输入名字!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main form1 = new Main();
            this.Hide();
            form1.ShowDialog();
            Application.ExitThread();
        }
    }
}
