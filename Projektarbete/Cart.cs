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
        public TableLayoutPanel CartLayoutPanel;
        private TableLayoutPanel PanelWithProducs;
        private Label LabelName;
        private PictureBox Picture;
        private Button ButtonMore;
        private Button ButtonLess;
        private TextBox Quantity;
        private PictureBox ButtonRemove;
        public List<Product> ItemsInTheCart = new List<Product>();
        public Cart()
        {
            CartLayoutPanel = new TableLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true };
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
                ButtonMore = new Button
                {
                    Dock = DockStyle.Left,
                    Text = "+",
                    Font = new Font("Arial", 10, FontStyle.Regular),
                    FlatStyle = FlatStyle.System,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Anchor = (AnchorStyles.None | AnchorStyles.None),
                    ForeColor = Color.Black,
                    BackColor = Color.White
                };
                ButtonLess = new Button
                {
                    Dock = DockStyle.Right,
                    Text = "-",
                    Font = new Font("Arial", 10, FontStyle.Regular),
                    FlatStyle = FlatStyle.System,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Anchor = (AnchorStyles.None | AnchorStyles.None),
                    ForeColor = Color.Black,
                    BackColor = Color.White
                };
                Quantity = new TextBox
                {

                    TextAlign = HorizontalAlignment.Center,
                    Text = "1",
                    Anchor = (AnchorStyles.None | AnchorStyles.None),
                    Font = new Font("Arial", 11, FontStyle.Regular),
                    ForeColor = Color.Black,
                    BackColor = Color.White,
                    Enabled = false
                };

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

        public void AddToCart()
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
               

            }
            AddControlsToCartLayoutPanle(PanelWithProducs);



        }
        private void AddControlsToCartLayoutPanle( Control control)
        {
            CartLayoutPanel.Controls.Add(control);
        }

        private void RefreshCart()
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

                AddControlsToCartLayoutPanle(PanelWithProducs);

            }
               


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


        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            PictureBox a = (PictureBox)sender;
           
            CartLayoutPanel.Controls.RemoveAt(Convert.ToInt32(a.Tag));
            CartLayoutPanel.Controls.Clear();
            ItemsInTheCart.Remove(ItemsInTheCart[Convert.ToInt32(a.Tag)]);
            RefreshCart();
           

        }



    }
}




