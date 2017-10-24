﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Projektarbete
{
    class MainForm : Form
    {
        private TableLayoutPanel RootPanel { get; set; }
        public FlowLayoutPanel CenterPanel { get; set; }
        //Left Menu Objects
        private TableLayoutPanel LeftMenuPanel { get; set; }
        private Button LeftMenuPanelBtnDelete { get; set; }
        private Button LeftMenuPanelBtnPurchase { get; set; }
        private TableLayoutPanel LeftMenuPanelUp { get; set; }
        private TableLayoutPanel LeftMenuPanelDown { get; set; }
       public TableLayoutPanel NewCart { get; set; }
        private int NewCartRows { get; set; }
        GetProducs G = new GetProducs();
        public MainForm()
        {
            Width = 1100;
            Height = 675;
            //Left Menu Objects
            LeftMenuPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                BackColor = Color.Gray
            };
            NewCart = new TableLayoutPanel
            {
                RowCount = NewCartRows,
                AutoScroll = true,
                Dock = DockStyle.Fill
            };
            LeftMenuPanelUp = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 1,
                BackColor = Color.Gray,
                AutoScroll = true
                
            };

            LeftMenuPanelUp.Controls.Add(NewCart);
            LeftMenuPanelUp.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            LeftMenuPanelDown = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                BackColor = Color.Gray
            };
            LeftMenuPanelBtnDelete = new Button
            {
                Text = "Remove",
                Dock = DockStyle.Fill
            };

          
            LeftMenuPanelBtnPurchase = new Button
            {
                Text = "COMPLETE PURCHASE",
                Dock = DockStyle.Fill
            };

            LeftMenuPanelDown.Controls.Add(LeftMenuPanelBtnDelete);
            LeftMenuPanelDown.Controls.Add(LeftMenuPanelBtnPurchase);
            LeftMenuPanel.Controls.Add(LeftMenuPanelUp);
            LeftMenuPanel.Controls.Add(LeftMenuPanelDown);
            LeftMenuPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 90));
            LeftMenuPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            //CenterMenu Objects
            CenterPanel = new FlowLayoutPanel
            {
                BackColor = Color.WhiteSmoke,
                Dock = DockStyle.Fill,
                AutoScroll = true,
            };

          
            foreach (Product a in G.Products)
            {
                
                PictureBox boc = new PictureBox
                {
                    BackColor = Color.WhiteSmoke,
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Image.FromFile(@"Resources\" + a.PictureName)
                };

                Label labelName = new Label
                {
                    Text = a.Name,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Dock = DockStyle.Fill
                };

                Label labelPrice = new Label
                {
                    Text = "$" + a.Price.ToString(),
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Dock = DockStyle.Fill
                };

                Button buttons = new Button
                {
                    Name = a.Id.ToString(),
                    Dock = DockStyle.Fill,
                    Text = "Buy now",
                    BackColor = Color.Azure
                };
                buttons.Click += Buttons_Click;
                




                    TableLayoutPanel f = new TableLayoutPanel
                    {
                        RowCount = 4,
                        Width = 200,
                        Height = 200
                    };
                    f.Controls.Add(boc);
                    f.Controls.Add(labelName);
                    f.Controls.Add(labelPrice);
                    f.Controls.Add(buttons);
                    f.RowStyles.Add(new RowStyle(SizeType.Percent, 60));
                    f.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
                    f.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
                    f.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
                    CenterPanel.Controls.Add(f);

                }

            RootPanel = new TableLayoutPanel
            {
                ColumnCount = 2,
                Dock = DockStyle.Fill
            };
            this.Controls.Add(RootPanel);
            RootPanel.Controls.Add(LeftMenuPanel);
            RootPanel.Controls.Add(CenterPanel);
            RootPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            RootPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
        }

        private void Buttons_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            MessageBox.Show(btn.Name);
            G.CartProducts(int.Parse(btn.Name));
            foreach (Product b in G.CartProductsList)
            {
                NewCartRows++;
                TableLayoutPanel u = new TableLayoutPanel {

                    Height = 100,
                    Width =200


                };
                PictureBox picture = new PictureBox
                {
                    BackColor = Color.WhiteSmoke,
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                   
                    Image = Image.FromFile(@"Resources\" + b.PictureName)
                    
                };
                u.Controls.Add(picture);
                NewCart.Controls.Add(u);
            }

        }
    }
}