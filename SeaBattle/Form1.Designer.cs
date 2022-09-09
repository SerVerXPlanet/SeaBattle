
namespace SeaBattle
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Container = new System.Windows.Forms.SplitContainer();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuGame = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVsPC = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.rtStat = new System.Windows.Forms.RichTextBox();
            this.field1 = new SeaFight.Field();
            this.field2 = new SeaFight.Field();
            ((System.ComponentModel.ISupportInitialize)(this.Container)).BeginInit();
            this.Container.Panel1.SuspendLayout();
            this.Container.Panel2.SuspendLayout();
            this.Container.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // Container
            // 
            this.Container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Container.IsSplitterFixed = true;
            this.Container.Location = new System.Drawing.Point(115, 27);
            this.Container.Name = "Container";
            // 
            // Container.Panel1
            // 
            this.Container.Panel1.Controls.Add(this.field1);
            // 
            // Container.Panel2
            // 
            this.Container.Panel2.Controls.Add(this.field2);
            this.Container.Size = new System.Drawing.Size(676, 342);
            this.Container.SplitterDistance = 234;
            this.Container.TabIndex = 2;
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGame,
            this.menuAbout});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(791, 24);
            this.menuMain.TabIndex = 3;
            this.menuMain.Text = "menu";
            // 
            // menuGame
            // 
            this.menuGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuVsPC,
            this.menuNetwork});
            this.menuGame.Name = "menuGame";
            this.menuGame.Size = new System.Drawing.Size(46, 20);
            this.menuGame.Text = "Игра";
            // 
            // menuVsPC
            // 
            this.menuVsPC.Name = "menuVsPC";
            this.menuVsPC.Size = new System.Drawing.Size(199, 22);
            this.menuVsPC.Text = "Против компьютера";
            this.menuVsPC.Click += new System.EventHandler(this.menuVsPC_Click);
            // 
            // menuNetwork
            // 
            this.menuNetwork.Enabled = false;
            this.menuNetwork.Name = "menuNetwork";
            this.menuNetwork.Size = new System.Drawing.Size(199, 22);
            this.menuNetwork.Text = "По сети (в разработке)";
            this.menuNetwork.Click += new System.EventHandler(this.menuNetwork_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(94, 20);
            this.menuAbout.Text = "О программе";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // rtStat
            // 
            this.rtStat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtStat.Location = new System.Drawing.Point(0, 24);
            this.rtStat.Name = "rtStat";
            this.rtStat.Size = new System.Drawing.Size(109, 345);
            this.rtStat.TabIndex = 4;
            this.rtStat.Text = "";
            // 
            // field1
            // 
            this.field1.BackColor = System.Drawing.Color.White;
            this.field1.BorderColor = System.Drawing.Color.DarkBlue;
            this.field1.BufferColor = System.Drawing.Color.Gray;
            this.field1.CursorColor = System.Drawing.Color.Cyan;
            this.field1.FontColor = System.Drawing.Color.OrangeRed;
            this.field1.HitColor = System.Drawing.Color.Red;
            this.field1.HorizontalSize = 10;
            this.field1.InnerColor = System.Drawing.Color.Blue;
            this.field1.Location = new System.Drawing.Point(53, 77);
            this.field1.MissColor = System.Drawing.Color.SaddleBrown;
            this.field1.Mode = SeaFight.Mode.View;
            this.field1.Name = "field1";
            this.field1.NamesX = new string[] {
        "А",
        "Б",
        "В",
        "Г",
        "Д",
        "Е",
        "Ж",
        "З",
        "И",
        "К",
        "Л",
        "М",
        "Н",
        "О",
        "П",
        "Р",
        "С",
        "Т",
        "У",
        "Ф",
        "Х",
        "Ц",
        "Ч",
        "Ш",
        "Щ",
        "Ъ",
        "Ы",
        "Э",
        "Ю",
        "Я"};
            this.field1.NamesY = new string[] {
        " 1",
        " 2",
        " 3",
        " 4",
        " 5",
        " 6",
        " 7",
        " 8",
        " 9",
        "10",
        "11",
        "12",
        "13",
        "14",
        "15",
        "16",
        "17",
        "18",
        "19",
        "20",
        "21",
        "22",
        "23",
        "24",
        "25",
        "26",
        "27",
        "28",
        "29",
        "30"};
            this.field1.ShipColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.field1.Ships = new int[] {
        4,
        3,
        3,
        2,
        2,
        2,
        1,
        1,
        1,
        1};
            this.field1.Size = new System.Drawing.Size(275, 275);
            this.field1.TabIndex = 0;
            this.field1.VerticalSize = 10;
            // 
            // field2
            // 
            this.field2.BackColor = System.Drawing.Color.White;
            this.field2.BorderColor = System.Drawing.Color.DarkBlue;
            this.field2.BufferColor = System.Drawing.Color.Gray;
            this.field2.CursorColor = System.Drawing.Color.Cyan;
            this.field2.FontColor = System.Drawing.Color.OrangeRed;
            this.field2.HitColor = System.Drawing.Color.Red;
            this.field2.HorizontalSize = 10;
            this.field2.InnerColor = System.Drawing.Color.Blue;
            this.field2.Location = new System.Drawing.Point(142, 19);
            this.field2.MissColor = System.Drawing.Color.SaddleBrown;
            this.field2.Mode = SeaFight.Mode.View;
            this.field2.Name = "field2";
            this.field2.NamesX = new string[] {
        "А",
        "Б",
        "В",
        "Г",
        "Д",
        "Е",
        "Ж",
        "З",
        "И",
        "К",
        "Л",
        "М",
        "Н",
        "О",
        "П",
        "Р",
        "С",
        "Т",
        "У",
        "Ф",
        "Х",
        "Ц",
        "Ч",
        "Ш",
        "Щ",
        "Ъ",
        "Ы",
        "Э",
        "Ю",
        "Я"};
            this.field2.NamesY = new string[] {
        " 1",
        " 2",
        " 3",
        " 4",
        " 5",
        " 6",
        " 7",
        " 8",
        " 9",
        "10",
        "11",
        "12",
        "13",
        "14",
        "15",
        "16",
        "17",
        "18",
        "19",
        "20",
        "21",
        "22",
        "23",
        "24",
        "25",
        "26",
        "27",
        "28",
        "29",
        "30"};
            this.field2.ShipColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.field2.Ships = new int[] {
        4,
        3,
        3,
        2,
        2,
        2,
        1,
        1,
        1,
        1};
            this.field2.Size = new System.Drawing.Size(275, 275);
            this.field2.TabIndex = 0;
            this.field2.VerticalSize = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 369);
            this.Controls.Add(this.rtStat);
            this.Controls.Add(this.Container);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.Name = "Form1";
            this.Text = "Sea Battle";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.Container.Panel1.ResumeLayout(false);
            this.Container.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Container)).EndInit();
            this.Container.ResumeLayout(false);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer Container;
        private SeaFight.Field field1;
        private SeaFight.Field field2;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuGame;
        private System.Windows.Forms.ToolStripMenuItem menuVsPC;
        private System.Windows.Forms.ToolStripMenuItem menuNetwork;
        private System.Windows.Forms.RichTextBox rtStat;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
    }
}

