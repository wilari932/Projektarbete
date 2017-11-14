using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Projektarbete
{
    class Cart
    {
        private static double Price { get; set; }

        public TableLayoutPanel CartLayoutPanel;
        private TableLayoutPanel PanelWithProducs;
        private Label LabelName;
        private PictureBox Picture;
        private Button ButtonMore;
        private Button ButtonLess;
        private TextBox Quantity;
        private PictureBox ButtonRemove;
        public Button CheckOutButton;
        public Label ShowPriceLabel;
        public List<Product> ItemsInTheCart = new List<Product>();

        // Vårt Konstruktör
        public Cart()
        {
            InitialComponents();
        }

        // Start metoder för GUI. Den kommer att köras först.
        private void InitialComponents()
        {
            CartLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None
            };

            CheckOutButton = new Button
            {
                Text = "Checkout",
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Standard,
                BackColor = Color.SandyBrown,
                ForeColor = Color.White,
                Font = new Font("Arial", 16, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
            };
            CheckOutButton.Click += CheckOutButton_Click;

            ShowPriceLabel = new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 15, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.DimGray,
                BackColor = Color.White,
                Text = "Total Price: $0"
            };
        }

        // Här visas när användaren vill göra CheckOut och inte finns nån produkt i kundvagnen.
        private void CheckOutButton_Click(object sender, EventArgs e)
        {
            if (Price == 0)
            {
                MessageBox.Show("Your cart is empty");
            }
            else
            {
                Customer a = new Customer(Price, ItemsInTheCart, this);
                a.ShowDialog();
            }
        }

        // Här skapar vi panelen som ska visa våra produkter.
        private void CreateCartTable(int i)
        {
            PanelWithProducs = new TableLayoutPanel
            {
                Height = 100,
                Width = 275,
                ColumnCount = 7,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                BackColor = Color.White,
                Dock = DockStyle.Top,
                Cursor = Cursors.Hand,
            };

            PanelWithProducs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            PanelWithProducs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            PanelWithProducs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9));
            PanelWithProducs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12));
            PanelWithProducs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9));
            PanelWithProducs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            PanelWithProducs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0));

            Picture = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Enabled = false,
            };

            LabelName = new Label
            {
                Text = ItemsInTheCart[i].Name + "\n" + "$" + ItemsInTheCart[i].Price,
                Font = new Font("Arial", 11, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                ForeColor = Color.DimGray,
            };

            Quantity = new TextBox
            {
                TextAlign = HorizontalAlignment.Center,
                Text = ItemsInTheCart[i].Quantity.ToString(),
                Anchor = (AnchorStyles.None | AnchorStyles.None),
                Font = new Font("Arial", 11, FontStyle.Regular),
                ForeColor = Color.Black,
                BackColor = Color.White,
                Enabled = false,
                Tag = i.ToString(),
            };

            ButtonMore = new Button
            {
                Dock = DockStyle.Left,
                Text = "+",
                Font = new Font("Arial", 10, FontStyle.Regular),
                FlatStyle = FlatStyle.System,
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = (AnchorStyles.None | AnchorStyles.None),
                ForeColor = Color.Black,
                BackColor = Color.White,
                Tag = Quantity
            };
            ButtonMore.Click += ButtonMore_Click;

            ButtonLess = new Button
            {
                Dock = DockStyle.Right,
                Text = "-",
                Font = new Font("Arial", 10, FontStyle.Regular),
                FlatStyle = FlatStyle.System,
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = (AnchorStyles.None | AnchorStyles.None),
                ForeColor = Color.Black,
                BackColor = Color.White,
                Tag = Quantity
            };
            ButtonLess.Click += ButtonLess_Click;

            ButtonRemove = new PictureBox
            {
                Image = Image.FromFile(@"Resources\ProgramFIles\removeClose.png"),
                BackColor = Color.White,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Anchor = (AnchorStyles.None | AnchorStyles.None),
                Width = 50,
                Height = 50,
                Tag = i
            };
            ButtonRemove.Click += ButtonRemove_Click;
            ButtonRemove.MouseEnter += ButtonRemove_MouseEnter;
            ButtonRemove.MouseLeave += ButtonRemove_MouseLeave;
        }

        //Skapar en GUI för produkter i kassan. 
        public void AddToCart(bool IsRefresh)
        {
            RefreshCart(IsRefresh);
            if (IsRefresh == false)
            {
                AddControlsToCartLayoutPanel(PanelWithProducs);
            }
        }


        private void AddControlsToCartLayoutPanel(Control control)
        {
            CartLayoutPanel.Controls.Add(control);
        }

        //Beräknar hur många produkter finns i listan och återskapar den i kassan.
        private void RefreshCart(bool IsRefresh)
        {
            for (int i = 0; i < ItemsInTheCart.Count; i++)
            {
                CreateCartTable(i);
                GetErrorFromPicturebox(i);
                PanelWithProducs.Controls.Add(Picture);
                PanelWithProducs.Controls.Add(LabelName);
                PanelWithProducs.Controls.Add(ButtonLess);
                PanelWithProducs.Controls.Add(Quantity);
                PanelWithProducs.Controls.Add(ButtonMore);
                PanelWithProducs.Controls.Add(ButtonRemove);
                if (IsRefresh)
                {
                    AddControlsToCartLayoutPanel(PanelWithProducs);
                }
            }
        }

        //Beräknar totalpris, enligt produkten och antal enheter.
        public void PriceCount()
        {
            Price = 0;
            foreach (Product a in ItemsInTheCart)
            {
                Price += a.Price * a.Quantity;
            }
            ShowPriceLabel.Text = "Total Price: $" + Price.ToString();
        }

        //Om det inte finns en bild till en och flera produkter då metoden sätter en default bild.
        private void GetErrorFromPicturebox(int i)
        {
            try
            {
                Picture.Image = Image.FromFile(@"Resources\ProductImages\" + ItemsInTheCart[i].PictureName);
            }
            catch
            {
                try
                {
                    Picture.Image = Image.FromFile(@"Resources\ProgramFIles\Error\1.png");
                }
                catch
                {
                    Picture.BackColor = Color.Black;
                }
            }
        }

        // En metod som hjälper oss att veta om kundvagnen är tömt eller inte.
        public bool CartIsNotEmpty()
        {
            if (ItemsInTheCart.Count<Product>() >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //En event som koppla med ButtonRemove som ta bort produkterna från kundvagnen, en och en.
        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            PictureBox a = (PictureBox)sender;

            CartLayoutPanel.Controls.Clear();
            ItemsInTheCart[Convert.ToInt32(a.Tag)].Quantity = 1;
            ItemsInTheCart.Remove(ItemsInTheCart[Convert.ToInt32(a.Tag)]);

            AddToCart(true);
            PriceCount();
        }

        //Minska antalet produkter i kundvagnen.
        private void ButtonLess_Click(object sender, EventArgs e)
        {
            Button s = (Button)sender;
            TextBox t = (TextBox)s.Tag;

            if (t.Text != "1")
            {
                int f = Convert.ToInt32(t.Text) - 1;

                t.Text = f.ToString();
                int i = Convert.ToInt32(t.Tag);
                ItemsInTheCart[i].Quantity = Convert.ToInt32(t.Text);
                PriceCount();
            }
        }

        //Öka antalet produkter i kundvagnen.
        private void ButtonMore_Click(object sender, EventArgs e)
        {

            Button s = (Button)sender;
            TextBox t = (TextBox)s.Tag;
            int f = 1 + Convert.ToInt32(t.Text);
            t.Text = f.ToString();
            int i = Convert.ToInt32(t.Tag);
            ItemsInTheCart[i].Quantity = Convert.ToInt32(t.Text);
            PriceCount();
        }

        //Den första delen av knapp animationen.
        private void ButtonRemove_MouseLeave(object sender, EventArgs e)
        {
            PictureBox a = (PictureBox)sender;
            a.Image = Image.FromFile(@"Resources\ProgramFIles\removeClose.png");
            a.Width = 50;
            a.Height = 50;
        }

        //Den andra delen av knapp animationen.
        private void ButtonRemove_MouseEnter(object sender, EventArgs e)
        {
            PictureBox a = (PictureBox)sender;
            a.Image = Image.FromFile(@"Resources\ProgramFIles\removeOpen.png");
            a.Width = 50;
            a.Height = 50;

        }
    }
}