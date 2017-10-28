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
        private TableLayoutPanel Header { get; set; }
        private PictureBox Header2 { get; set; }
        private PictureBox Header3 { get; set; }
        private PictureBox Header4 { get; set; }
        private Button Close1 { get; set; }
        private TableLayoutPanel a { get; set; }


        GetProducs GetProducsFromList = new GetProducs();

        public MainForm()
        {
            a = new TableLayoutPanel
            {
                Width = 970,
            Height = 535,
            RowCount = 1,
            Dock = DockStyle.Fill
        };
            MessageBox.Show("d00");
           a.RowStyles.Add(new RowStyle(SizeType.Percent, 90));

            Width = 1000;
            Height = 575;

            Close1 = new Button
            {
                Width = 45,
                Height =30,
                Text = "X",
                Font = new Font("Arial", 11, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
               // Anchor = (AnchorStyles.None | AnchorStyles.Left),
                Dock = DockStyle.Fill,
               BackColor = Color.Orange
                
                
                
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
                Height = 50,

                Dock = DockStyle.Top,
                BackColor = Color.Black,
                ColumnCount = 2
                

            };
            Header.Controls.Add(Close1,2,0);
            Header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 95));
            Header2 = new PictureBox
            {
                Height = 5,
                Dock = DockStyle.Bottom,
                BackColor = Color.Black


            };
            Header3 = new PictureBox
            {
                Width = 5,
                Dock = DockStyle.Right,
                BackColor = Color.Black,
              Cursor = Cursors.SizeWE
                

            };
            Header4 = new PictureBox
            {
                Width = 5,
                Dock = DockStyle.Left,
                BackColor = Color.Black,
                Cursor = Cursors.SizeWE



            };
            LeftMenuPanel = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2 , };
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
                RowCount = 1,
                ColumnCount = 2,
                
                Dock = DockStyle.Fill
            };
           
            this.Controls.Add(Header);
            this.Controls.Add(Header2);
            this.Controls.Add(Header3);
            this.Controls.Add(Header4);
            this.Controls.Add(a);
            a.Controls.Add(RootPanel);
            RootPanel.Controls.Add(RightMenuPanel,1,0);
           


        }

        private void Close1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            Button BtnGetProductID = (Button)sender;

            RootPanel.Controls.Add(LeftMenuPanel,0,0);
            RootPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            RootPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
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

