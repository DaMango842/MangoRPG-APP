using MangoRPG_APP.Assets;
using MangoRPG_APP.Class;
using MangoRPG_APP.Utils;
using System.Data;

namespace MangoRPG_APP
{

    public partial class Shop : Form
    {
        private IList<Weapon> weaponList = new List<Weapon>();
        private IList<Armor> armorList = new List<Armor>();
        private IList<Consumable> consumableList = new List<Consumable>();

        private Player player = new Player();

        private IList<ShopItems> shopItems = new List<ShopItems>();


        //声明Lite DB 帮助类
        LiteDBHelper liteDBHelper;
        public Shop()
        {
            InitializeComponent();
            liteDBHelper = new LiteDBHelper();
            var list = liteDBHelper.FindAll<Player>("user_data").ToList().Where(x => x.Name == "Mango");
            if (list.Count() > 0)
            {
                player = list.FirstOrDefault();
            }

            //初始化Lite DB帮助类

            #region 道具数据源加载
            weaponList = new Datasources().loadWeapon();

            foreach (var item in weaponList)
            {
                var shopItem = new ShopItems();
                shopItem.Name = item.Name;
                shopItem.Desc = item.Description;
                shopItem.Price = item.Price;
                shopItems.Add(shopItem);
            }
            consumableList = new Datasources().loadConsumable();

            foreach (var item in consumableList)
            {
                var shopItem = new ShopItems();
                shopItem.Name = item.Name;
                shopItem.Desc = item.Description;
                shopItem.Price = item.Price;
                shopItems.Add(shopItem);
            }
            armorList = new Datasources().loadArmor();

            foreach (var item in armorList)
            {
                var shopItem = new ShopItems();
                shopItem.Name = item.Name;
                shopItem.Desc = item.Description;
                shopItem.Price = item.Price;
                shopItems.Add(shopItem);
            }
            #endregion



            InitShopList(shopItems.ToList());
        }

        private void InitShopList(List<ShopItems> invList)
        {
            this.listView1.BeginUpdate();  //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度 

            for (int i = 0; i < invList.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = invList[i].Name;
                lvi.SubItems.Add(invList[i].Desc);
                lvi.SubItems.Add(Convert.ToString(invList[i].Price));

                this.listView1.Items.Add(lvi);
            }

            this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。 
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var isSelected = listView1.SelectedItems;
            if (isSelected.Count > 0)
            {
                var currSItem = shopItems.Where(x => x.Name == listView1.SelectedItems[0].Text).FirstOrDefault();
                if (currSItem is not null)
                {
                    //从LiteDB的inventory集合中加载背包数据
                    var inventoryList = liteDBHelper.FindAll<Inventory>("inventory");

                    //初始化一个背包物品，以后你可以随便写道具装备武器等
                    Inventory inventory = new Inventory()
                    {
                        Name = currSItem.Name,
                        Count = 1,
                        Description = currSItem.Desc
                    };
                    //检索当前LiteDB中是否存在上边初始化的道具
                    var currentInventory = inventoryList.Where(x => x.Name == inventory.Name).FirstOrDefault();
                    //如果为null，则视为新道具
                    if (currentInventory is null)
                    {
                        //直接储存到LiteDB
                        liteDBHelper.Save(inventory, "inventory");
                    }
                    else
                    {
                        //如果不为null，则视更新当前已有道具，数量+1
                        if (Convert.ToInt32(numericUpDown1.Text) > 0)
                        {
                            currentInventory.Count += Convert.ToInt32(numericUpDown1.Text);

                            //更新LiteDB的inventory集合。
                            liteDBHelper.Update(currentInventory, "inventory");

                            MessageBox.Show("获得了新道具：" + currSItem.Name);
                        }
                        else
                        {
                            MessageBox.Show("请选择数量！");
                        }
                    }

                    //金币减少，并更新liteDB user data

                    player.Money -= currSItem.Price;
                    if (player.Money < 0)
                    {
                        MessageBox.Show("Sorry，你的钱不够");
                    }
                    else
                    {
                        liteDBHelper.Update(player, "user_data");
                    }
                    //MessageBox.Show("获得了新道具：" + currSItem.Name);
                }
                else
                {
                    MessageBox.Show("请选择你要购买的商品哦！");
                }
            }
            else
            {
                MessageBox.Show("请选择你要购买的商品哦！");
            }
        }
        // 这里要写出售道具
        // 检查背包里是否含有该物品
        // 如果没有则无法出售
        // 如果存在该物品,出售该物品*数量
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Shop_FormClosing(object sender, FormClosingEventArgs e)
        {
            Game game = (Game)this.Owner;
            game.textUpdate();
        }
        //这里的话是购买和出售物品数量
        //我不懂这个东西
        //所以这里就注释了
        //大致是将购买或出售的数量相对应就行了
        //可能不用这个类也可以实现的吧?

    }
}
