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
        private double Price { get; set; }
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
        public Cart()
        {
            InicialComponents();


        }
   
        private void InicialComponents()
        {
            CartLayoutPanel = new TableLayoutPanel
            {
             Dock = DockStyle.Fill,
              AutoScroll = true
            };

            CheckOutButton = new Button
            {
                Text = "Next",
                
                Dock = DockStyle.Fill,
              FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 20, FontStyle.Italic),
                TextAlign = ContentAlignment.MiddleCenter,



            };
            CheckOutButton.Click += CheckOutButton_Click;
            ShowPriceLabel = new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 20, FontStyle.Regular),
                TextAlign = ContentAlignment.TopLeft,
                ForeColor = Color.Green,
                Text =  "Total Price: 0"
            };



        }

        private void CheckOutButton_Click(object sender, EventArgs e)
        {
            if(Price == 0)
            {
                MessageBox.Show("Your cart is empty");
            }
        }

        private void CreateCartTable( int i)
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
                    Text = ItemsInTheCart[i].Name + "\n" + ItemsInTheCart[i].Price,
                    Font = new Font("Arial", 11, FontStyle.Regular),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Enabled = false,
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
                    Image = Image.FromFile(@"Resources\removeClose.png"),
                    BackColor = Color.White,

                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Anchor = (AnchorStyles.None | AnchorStyles.None),
                    Width = 50,
                    Height = 50,

                    
                };


                {

                    ButtonRemove.Tag = i;
                }
                ButtonRemove.Click += ButtonRemove_Click;
            ButtonRemove.MouseEnter += ButtonRemove_MouseEnter;
            ButtonRemove.MouseLeave += ButtonRemove_MouseLeave;
            
            }

        private void ButtonLess_Click(object sender, EventArgs e)
        {
            Button s = (Button)sender;
            TextBox t = (TextBox)s.Tag;

            if (t.Text != "1")
            {
                int f =  Convert.ToInt32(t.Text) - 1;

                t.Text = f.ToString();
                int i = Convert.ToInt32(t.Tag);
                ItemsInTheCart[i].Quantity = Convert.ToInt32(t.Text);
                PriceCount();
            }



        }

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

        private void ButtonRemove_MouseLeave(object sender, EventArgs e)
        {
            PictureBox a = (PictureBox)sender;
                   a.Image = Image.FromFile(@"Resources\removeClose.png");
                   a.Width = 50;
                   a.Height = 50;
        }

        private void ButtonRemove_MouseEnter(object sender, EventArgs e)
        {
            PictureBox a = (PictureBox)sender;
            a.Image = Image.FromFile(@"Resources\removeOpen.png");
            a.Width = 55;
            a.Height = 55;
        }

        public void AddToCart( bool IsRefresh)
        {
            RefreshCart(IsRefresh);
            if (IsRefresh == false)
            {
                 AddControlsToCartLayoutPanle(PanelWithProducs);
            }
            
        }
        private void AddControlsToCartLayoutPanle( Control control)
        {
            CartLayoutPanel.Controls.Add(control);
        }

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
                    AddControlsToCartLayoutPanle(PanelWithProducs);
                }
           
            }
               


            }
        public void PriceCount()
        {
           Price = 0;
            foreach (Product a in ItemsInTheCart)
            {

                Price += a.Price * a.Quantity;

            }
            ShowPriceLabel.Text = "Total Price: " + Price.ToString();
        }


      


        private void GetErrorFromPicturebox(int i)
        {
            try
            {
                Picture.Image = Image.FromFile(@"Resources\" + ItemsInTheCart[i].PictureName);
            }
            catch
            {
                try
                {
                    Picture.Image = Image.FromFile(@"Resources\Error\1.png");
                }
                catch
                {
                    Picture.BackColor = Color.Black;
                }

            }



        }

        public bool CartIsNotEmpty()
        {
           if( ItemsInTheCart.Count<Product>() >= 1)
            {
                return true;
            }
            else
            {
                return false;

            }
           
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            PictureBox a = (PictureBox)sender;

            //  CartLayoutPanel.Controls.RemoveAt(Convert.ToInt32(a.Tag));
            CartLayoutPanel.Controls.Clear();
            ItemsInTheCart[Convert.ToInt32(a.Tag)].Quantity = 1;
            ItemsInTheCart.Remove(ItemsInTheCart[Convert.ToInt32(a.Tag)]);
            
            AddToCart(true);
            PriceCount();

        }



    }
}




