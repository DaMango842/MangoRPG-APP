using MangoRPG_APP.Assets;
using MangoRPG_APP.Class;
using MangoRPG_APP.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangoRPG_APP
{
    //得让背包里的物品传输到玩家背包里面
    //然后让物品添加到玩家背包里面
    //再然后把消耗品的使用,武器防具的装备做出来


    public partial class Backpacks : Form
    {
        //定义武器集合
        IList<Weapon> weaponList;
        //定义防具集合
        IList<Armor> armorList;
        //定义消耗品集合
        IList<Consumable> consumableList;
        //声明Lite DB 帮助类
        LiteDBHelper liteDBHelper;
        public Backpacks()
        {
            InitializeComponent();
            //从数据源加载武器信息
            weaponList = new Datasources().loadWeapon();
            //从数据源加载防具信息
            armorList = new Datasources().loadArmor();
            //从数据源加载消耗品信息
            consumableList = new Datasources().loadConsumable();
            //初始化Lite DB帮助类
            liteDBHelper = new LiteDBHelper();

            List<Inventory> invList = new List<Inventory>();

            //从LiteDB的inventory集合中加载背包数据
            var inventoryList = liteDBHelper.FindAll<Inventory>("inventory");
            //加载武器信息
            //foreach (var item in inventoryList)
            //{
            //    invList.Add(new Inventory {  Name = item.Name, Description = item.Description, Count = item.Count });
            //}

            ////加载防具信息
            //foreach (var item in armorList)
            //{
            //    invList.Add(new Inventory { ID = item.Id, Name = item.Name, Description = item.Description, Count = item.Count });
            //}

            //这里要弄背包的获取到道具的列表
            groupBox1.Text = "背包(" + Convert.ToString(inventoryList.Count) + "/" + "30" + ")";


            InitPackList(inventoryList.ToList());
        }


        public void InitPackList(List<Inventory> invList)
        {
            this.listView1.BeginUpdate();  //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度 

            for (int i = 0; i < invList.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = invList[i].Name;
                lvi.SubItems.Add(invList[i].Description);
                lvi.SubItems.Add(Convert.ToString(invList[i].Count));

                this.listView1.Items.Add(lvi);
            }

            this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。 
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //武器和防具和消耗品不是一个类型
            //必须要判断是否是啥道具类型的,才会生效
            if (listView1.SelectedItems.Count == 0) return;
            else
            {
                var currWItem = weaponList.Where(x => x.Name == listView1.SelectedItems[0].Text).FirstOrDefault();
                if (currWItem is not null)
                {
                    itemName.Text = currWItem.Name;
                    label1.Text = currWItem.Description;
                    label13.Text = currWItem.Lv.ToString();
                    label14.Text = "0";
                    label15.Text = "0";
                    label16.Text = "0";
                    label7.Text = "0";
                    label23.Text = currWItem.itemType.ToString();
                    label17.Text = currWItem.atk.ToString();
                    label20.Text = "0";
                    label18.Text = currWItem.matk.ToString();
                    label21.Text = "0";

                }
                var currAItem = armorList.Where(x => x.Name == listView1.SelectedItems[0].Text).FirstOrDefault();
                if (currAItem is not null)
                {
                    itemName.Text = currAItem.Name;
                    label1.Text = currAItem.Description;
                    label23.Text = currAItem.itemType.ToString();
                    label13.Text = currAItem.Lv.ToString();
                    label14.Text = "0";
                    label15.Text = "0";
                    label16.Text = currAItem.hpmax.ToString();
                    label7.Text = currAItem.manamax.ToString();
                    label17.Text = "0";
                    label20.Text = currAItem.def.ToString();
                    label18.Text = "0";
                    label21.Text = currAItem.mdef.ToString();
                }

                var currCItem = consumableList.Where(x => x.Name == listView1.SelectedItems[0].Text).FirstOrDefault();
                if (currCItem is not null)
                {
                    itemName.Text = currCItem.Name;
                    label1.Text = currCItem.Description;
                    label23.Text = currCItem.itemType.ToString();
                    label13.Text = currCItem.Lv.ToString();
                    label14.Text = currCItem.hp.ToString();
                    label15.Text = currCItem.mana.ToString();
                    label16.Text = "0";
                    label7.Text = "0";
                    label17.Text = "0";
                    label20.Text = "0";
                    label18.Text = "0";
                    label21.Text = "0";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            else
            {
                //label12.Text = listView1.SelectedItems[0].
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //从LiteDB的inventory集合中加载背包数据
            var inventoryList = liteDBHelper.FindAll<Inventory>("inventory");

            //初始化一个背包物品，以后你可以随便写道具装备武器等
            Inventory inventory = new Inventory()
            {
                Name = "树枝",
                Count = 1,
                Description = "捅粑粑的小树枝"
            };
            //检索当前LiteDB中是否存在上边初始化的道具
            var currentInventory = inventoryList.Where(x => x.Name == inventory.Name).FirstOrDefault();
            //如果为null，则视为新道具
            if (currentInventory is null)
            {
                //直接储存到LiteDB
                liteDBHelper.Save(inventory, "inventory");
                //更新List
                inventoryList.Add(inventory);
                //初始化ListView
                this.listView1.Items.Clear();
                //重新渲染ListView
                InitPackList(inventoryList.ToList());
            }
            else
            {
                //如果不为null，则视更新当前已有道具，数量+1
                currentInventory.Count += 1;
                //更新LiteDB的inventory集合。
                liteDBHelper.Update(currentInventory, "inventory");
                //从LiteDB的inventory集合中加载背包数据，因为刚刚更新过，所以再次读取
                var curentVentoryList = liteDBHelper.FindAll<Inventory>("inventory");
                //初始化ListView
                this.listView1.Items.Clear();
                //重新渲染ListView
                InitPackList(curentVentoryList.ToList());
            }


        }
    }
}
