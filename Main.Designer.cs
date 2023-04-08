namespace MangoRPG_APP
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            startButton = new Button();
            loadButton = new Button();
            aboutButton = new Button();
            exitButton = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(255, 0, 240);
            label1.Location = new Point(350, 67);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(301, 65);
            label1.TabIndex = 0;
            label1.Text = "MangoRPG";
            // 
            // startButton
            // 
            startButton.Location = new Point(134, 352);
            startButton.Margin = new Padding(4);
            startButton.Name = "startButton";
            startButton.Size = new Size(174, 53);
            startButton.TabIndex = 1;
            startButton.Text = "开始游戏";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // loadButton
            // 
            loadButton.Location = new Point(315, 352);
            loadButton.Margin = new Padding(4);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(174, 53);
            loadButton.TabIndex = 2;
            loadButton.Text = "读取存档";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // aboutButton
            // 
            aboutButton.Location = new Point(496, 352);
            aboutButton.Margin = new Padding(4);
            aboutButton.Name = "aboutButton";
            aboutButton.Size = new Size(174, 53);
            aboutButton.TabIndex = 3;
            aboutButton.Text = "关于游戏";
            aboutButton.UseVisualStyleBackColor = true;
            aboutButton.Click += aboutButton_Click;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(678, 352);
            exitButton.Margin = new Padding(4);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(174, 53);
            exitButton.TabIndex = 4;
            exitButton.Text = "退出游戏";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 511);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(164, 20);
            label2.TabIndex = 5;
            label2.Text = "MangoRPG first build";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 529);
            Controls.Add(label2);
            Controls.Add(exitButton);
            Controls.Add(aboutButton);
            Controls.Add(loadButton);
            Controls.Add(startButton);
            Controls.Add(label1);
            ForeColor = Color.FromArgb(0, 0, 0, 0);
            Margin = new Padding(4);
            Name = "Main";
            Text = "MangoRPG";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button startButton;
        private Button loadButton;
        private Button aboutButton;
        private Button exitButton;
        private Label label2;
    }
}