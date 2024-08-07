﻿using System;
using System.Drawing;
using System.Windows.Forms;


namespace SeaBattle
{
    public partial class Form1 : Form
    {
        const float BORDER = 0.05f;
        const int SPLITTER_WIDTH = 2;
        const int HSIZE = 10;
        const int VSIZE = 10;

        
        Game game;


        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            game = new Game(field2, field1);

            rtStat.Text = game.Msg;

            game.TextChanged += Game_TextChanged;

            field2.FieldClick += Field2_FieldClick;

            field1.ShipsInstalled += Field1_ShipsInstalled;
            field1.ShipsChecked += Field1_ShipsChecked;
            //field2.ShipsDestroyed += Field2_ShipsDestroyed;

            SetSettings();

            this.OnResize(e);
        }

        private void Field1_ShipsChecked()
        {
            
        }

        private void Game_TextChanged()
        {
            rtStat.Text = game.Msg;
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                Container.SplitterDistance = (Container.Width - SPLITTER_WIDTH) / 2;

                int panelWidth = Math.Min(Container.Panel1.Width, Container.Panel2.Width);

                field1.Width = field2.Width = (int)((1.0f - 2.0f * BORDER) * panelWidth);

                field1.Location = new Point((int)(BORDER * panelWidth), (int)(BORDER * Container.Panel1.Height) + lblCaption1.Height);
                field2.Location = new Point((int)(Container.Panel2.Width * (1.0f - BORDER)) - field2.Width, field1.Location.Y);

                field1.Invalidate();
                field2.Invalidate();

                lblCaption1.Height = lblCaption2.Height = field1.Width / field1.HorizontalSize;
                lblCaption1.Font = lblCaption2.Font = new Font(lblCaption1.Font.Name, (float)(field1.Width / 27.5));
            }
        }


        private void Field1_ShipsInstalled()
        {
            game.AddText("Ваши корабли установлены!");

            field2.Mode = SeaFight.Mode.Battle;

            game.Start();

            game.YourStep = game.First();

            field2.Mode = game.YourStep ? SeaFight.Mode.Battle : SeaFight.Mode.View;

            field1.SetLights(game.YourStep ? SeaFight.Step.Wait : SeaFight.Step.Run);
            field2.SetLights(game.YourStep ? SeaFight.Step.Run : SeaFight.Step.Wait);

            if (!game.YourStep)
                game.DoStepNPC();
        }


        private void menuVsPC_Click(object sender, EventArgs e)
        {
            game.Clear();

            SetSettings();

            game.GenerateNPC();

            game.NewGame();
        }


        private void menuNetwork_Click(object sender, EventArgs e)
        {
            //game.NewGame();
        }


        void SetSettings()
        {
            field1.HorizontalSize = HSIZE;
            field1.VerticalSize = VSIZE;
            field2.HorizontalSize = HSIZE;
            field2.VerticalSize = VSIZE;

            //field1.Ships = new int[] { 10, 10 };
            //field2.Ships = new int[] { 10, 10 };
        }


        private void Field2_FieldClick(object sender, EventArgs e)
        {
            game.DoStepHuman();
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made_by_SerVer" + Environment.NewLine + Environment.NewLine + "mail@verevkinsa.ru", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
