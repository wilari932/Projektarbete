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

        public List<Product> CartProductsList = new List<Product>();
        public TableLayoutPanel PanelWithProducs { get; set; }
    
        public void ProducsInCart(GetProducs GetProducsFromList, int ID)
        {
            CartProductsList.Add(GetProducsFromList.Products[ID]);
            
              foreach (Product ProducFinder in CartProductsList)
            {
                PanelWithProducs = new TableLayoutPanel
                {
                    Height = 100,
                    Width = 275,
                    ColumnCount = 5,
                    //RowCount = 1,
                    //CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                    BackColor = Color.White,
                    Dock = DockStyle.Top,
                };
                PanelWithProducs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
                PanelWithProducs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
                PanelWithProducs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
                PanelWithProducs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
                PanelWithProducs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));

                PictureBox picture = new PictureBox
                {
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Image.FromFile(@"Resources\" + ProducFinder.PictureName)
                };
                Label info = new Label
                {
                    Text = ProducFinder.Name + "\n" + ProducFinder.Price,
                    Font = new Font("Arial", 11, FontStyle.Regular),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                };
                Button buttonMore = new Button
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
                Button buttonLess = new Button
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
                TextBox quantity = new TextBox
                {
                    //Dock = DockStyle.Fill,
                    TextAlign = HorizontalAlignment.Center,
                    Text = "1",
                    Anchor = (AnchorStyles.None | AnchorStyles.None),
                    Font = new Font("Arial", 11, FontStyle.Regular),
                    ForeColor = Color.Black,
                    BackColor = Color.White,
                    Enabled = false
                };


                PanelWithProducs.Controls.Add(picture);
                PanelWithProducs.Controls.Add(info);
                PanelWithProducs.Controls.Add(buttonLess);
                PanelWithProducs.Controls.Add(quantity);
                PanelWithProducs.Controls.Add(buttonMore);


            }


      

        }



    }


    }

