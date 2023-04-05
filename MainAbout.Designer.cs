namespace MangoRPG_APP
{
    partial class MainAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(557, 140);
            label1.TabIndex = 0;
            label1.Text = "你说的对,\r\n但是《MangoRPG》是由[黑夜下的糖果酱]所制作的在C#上编写的文字类RPG,\r\n故事发生在一个叫⌈艾卡罗特行星⌋的幻想世界,\r\n被神选中的天选之人将被给予⌈'勇者'⌋的称号。\r\n你将扮演本作的⌈主角⌋,在这个充满生机的世界中探索。\r\n击败较为强大的敌人,寻找并肩作战的同伴,在一些奇特的建筑中寻回自己以往的记忆\r\n---同时,并逐渐发掘名为⌈故事⌋的真相";
            // 
            // button1
            // 
            button1.Location = new Point(12, 217);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "返回";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MainAbout
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 259);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "MainAbout";
            Text = "这不是关于界面,相信我.jpg";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
    }
}