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
      //  public List<Product> CartProductsList2 = new List<Product>();
        private TableLayoutPanel Header { get; set; }
        private Button Close1 { get; set; }
        private Button Minimize1 { get; set; }
        private TableLayoutPanel a { get; set; }


        GetProducs GetProducsFromList = new GetProducs();
        Cart SavedItemsToBuy = new Cart();

        public MainForm()
        {
            a = new TableLayoutPanel
            {
                RowCount = 2,
                Dock = DockStyle.Fill,
                BackColor = Color.Black,
                //CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble        
            };

            a.RowStyles.Add(new RowStyle(SizeType.Percent, 5));
            a.RowStyles.Add(new RowStyle(SizeType.Percent, 95));

            Width = 1000;
            Height = 575;

            Minimize1 = new Button
            {
                Height = 30,
                Width = 35,
                Text = "-",
                Font = new Font("Arial", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = (AnchorStyles.None | AnchorStyles.Right),
                Dock = DockStyle.Fill,
                BackColor = Color.SandyBrown,
                FlatStyle = FlatStyle.Flat,
            };
            Minimize1.Click += Minimize1_Click;

            Close1 = new Button
            {
                Height = 30,
                Width = 35,
                Text = "X",
                Font = new Font("Arial", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = (AnchorStyles.None | AnchorStyles.Right),
                Dock = DockStyle.Fill,
                BackColor = Color.SandyBrown,
                FlatStyle = FlatStyle.Flat,
            };
            Close1.Click += Close1_Click;

            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ControlBox = false;
            this.WindowState = FormWindowState.Normal;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            Header = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3
            };
            Header.Controls.Add(Close1, 2, 0);
            Header.Controls.Add(Minimize1, 1, 0);
            Header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            LeftMenuPanel = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2, };
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
                RowCount = 1,
                ColumnCount = 2,
                Dock = DockStyle.Fill
            };
            this.Controls.Add(a);
            a.Controls.Add(Header, 0, 0);
            a.Controls.Add(RootPanel, 0, 1);
            RootPanel.Controls.Add(RightMenuPanel, 1, 0);
        }
        private void Minimize1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Close1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Buttons_Click(object sender, EventArgs e)
        {
            Button BtnGetProductID = (Button)sender;

            RootPanel.Controls.Add(LeftMenuPanel, 0, 0);
            RootPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36));
            RootPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64));
            ///  BtnGetProductID.Enabled = false;
          

            if (SavedItemsToBuy.CartProductsList.Exists(x => x.Id == int.Parse(BtnGetProductID.Name)))
            {
                MessageBox.Show("This product is already in your cart");
            }
            else
            {
                SavedItemsToBuy.ProducsInCart(GetProducsFromList, int.Parse(BtnGetProductID.Name));
                VisualCartPanel.Controls.Add(SavedItemsToBuy.PanelWithProducs);
                SavedItemsToBuy.CartProductsList.Add(GetProducsFromList.Products[int.Parse(BtnGetProductID.Name)]);
            }
        }
    }
}