using System;
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
        public FlowLayoutPanel RightMenuPanel { get; set; }
        private TableLayoutPanel LeftMenuPanel { get; set; }
        private Button LeftMenuPanelBtnDelete { get; set; }
        private Button BtnPurchase { get; set; }
        private TableLayoutPanel LeftMenuPanelUp { get; set; }
        private TableLayoutPanel LeftMenuPanelDown { get; set; }
        public TableLayoutPanel VisualCartPanel { get; set; }
        public List<Product> CartProductsList2 = new List<Product>();



        GetProducs GetProducsFromList = new GetProducs();

        public MainForm()
        {
            Width = 1000;
            Height = 575;

            LeftMenuPanel = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2 };
            VisualCartPanel = new TableLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true };
            LeftMenuPanelUp = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 1, BackColor = Color.White, BorderStyle = BorderStyle.Fixed3D };

            LeftMenuPanelUp.Controls.Add(VisualCartPanel);
            LeftMenuPanelUp.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            LeftMenuPanelDown = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, BackColor = Color.White, BorderStyle = BorderStyle.Fixed3D };
            LeftMenuPanelBtnDelete = new Button { Text = "Delete", Dock = DockStyle.Fill, FlatStyle = FlatStyle.System, BackColor = Color.WhiteSmoke, Font = new Font("Arial", 10, FontStyle.Regular) };
            BtnPurchase = new Button { Text = "COMPLETE PURCHASE", Dock = DockStyle.Fill, FlatStyle = FlatStyle.System, BackColor = Color.WhiteSmoke, Font = new Font("Arial", 11, FontStyle.Regular) };

            LeftMenuPanelDown.Controls.Add(LeftMenuPanelBtnDelete);
            LeftMenuPanelDown.Controls.Add(BtnPurchase);
            LeftMenuPanel.Controls.Add(LeftMenuPanelUp);
            LeftMenuPanel.Controls.Add(LeftMenuPanelDown);
            LeftMenuPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 90));
            LeftMenuPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));

            // RightMenuPanel Objekt
            RightMenuPanel = new FlowLayoutPanel { BackColor = Color.White, Dock = DockStyle.Fill, AutoScroll = true, BorderStyle = BorderStyle.Fixed3D };

            foreach (Product a in GetProducsFromList.Products)
            {
                PictureBox boc = new PictureBox
                {
                    BackColor = Color.White,
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Image.FromFile(@"Resources\" + a.PictureName)
                };

                Label labelName = new Label
                {
                    Text = a.Name,
                    Font = new Font("Arial", 11, FontStyle.Regular),
                    TextAlign = ContentAlignment.TopLeft,
                    Anchor = (AnchorStyles.None | AnchorStyles.Left),
                    Dock = DockStyle.Fill
                };

                Label labelPrice = new Label
                {
                    Text = "$" + a.Price.ToString(),
                    Font = new Font("Arial", 11, FontStyle.Regular),
                    TextAlign = ContentAlignment.TopLeft,
                    Anchor = (AnchorStyles.None | AnchorStyles.Left),
                    Dock = DockStyle.Fill
                };
                Button buttonInfo = new Button
                {
                    Dock = DockStyle.Left,
                    Text = "+info",
                    Font = new Font("Arial", 9, FontStyle.Regular),
                    FlatStyle = FlatStyle.System,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Anchor = (AnchorStyles.None | AnchorStyles.Right),
                    ForeColor = Color.Black,
                    BackColor = Color.Transparent
                };

                Button buttonAddToCart = new Button
                {
                    Name = a.Id.ToString(),
                    Dock = DockStyle.Fill,
                    Text = "Add to cart",
                    Font = new Font("Arial", 11, FontStyle.Bold),
                    FlatStyle = FlatStyle.Standard,
                    ForeColor = Color.White,
                    BackColor = Color.SandyBrown

                };

                buttonAddToCart.Click += Buttons_Click;

                TableLayoutPanel productRangePanel = new TableLayoutPanel
                {
                    RowCount = 4,
                    Width = 175,
                    Height = 250,
                    //CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial        
                };
                productRangePanel.Controls.Add(boc);
                productRangePanel.Controls.Add(labelName);
                productRangePanel.Controls.Add(labelPrice);
                productRangePanel.Controls.Add(buttonInfo);
                productRangePanel.Controls.Add(buttonAddToCart);
                productRangePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 55));
                productRangePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
                productRangePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
                productRangePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
                productRangePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 15));

                RightMenuPanel.Controls.Add(productRangePanel);
            }

            RootPanel = new TableLayoutPanel
            {
                ColumnCount = 2,
                Dock = DockStyle.Fill
            };

            this.Controls.Add(RootPanel);
            RootPanel.Controls.Add(LeftMenuPanel);
            RootPanel.Controls.Add(RightMenuPanel);
            RootPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            RootPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
        }



        private void Buttons_Click(object sender, EventArgs e)
        {
            Button BtnGetProductID = (Button)sender;

            //  BtnGetProductID.Enabled = false;
            Cart SelectedProducs = new Cart();


            if (CartProductsList2.Exists(x => x.Id == int.Parse(BtnGetProductID.Name)))
            {

                MessageBox.Show("Finns Redan i Cart");

            }
            else
            {
                SelectedProducs.ProducsInCart(GetProducsFromList, int.Parse(BtnGetProductID.Name));
                VisualCartPanel.Controls.Add(SelectedProducs.PanelWithProducs);
                CartProductsList2.Add(GetProducsFromList.Products[int.Parse(BtnGetProductID.Name)]);

            }








        }
    }

}

