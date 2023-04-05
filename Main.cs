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

        private void button1_Click(object sender, EventArgs e)
        {

            EnterName enterName = new EnterName();
            this.Hide();
            enterName.ShowDialog();
            Application.ExitThread();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LiteDBHelper liteDBHelper = new LiteDBHelper();
            var list = liteDBHelper.FindAll<Player>("user_data").ToList().Where(x => x.Name == "Mango");

            MessageBox.Show("¥Êµµ∂¡»°≥…π¶");
            Game game = new Game(list.First());
            this.Hide();
            game.ShowDialog();
            Application.ExitThread();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainAbout mainAbout = new MainAbout();
            mainAbout.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.ExitThread();
        }
    }
}