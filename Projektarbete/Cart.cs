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
      public  TableLayoutPanel PanelWithProducs { get; set; }
        public void ProducsInCart(GetProducs GetProducsFromList)
        {
            GetProducs G = GetProducsFromList;
            foreach (Product ProducFinder in G.CartProductsList)
            {
                // NewCartRows++;
                PanelWithProducs = new TableLayoutPanel
                {
                    Height = 100,
                    Width = 400,
                    ColumnCount = 2,
                    RowCount = 1,
                    CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble,
                    BackColor = Color.White,
                    Dock = DockStyle.Top,
                };
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
                    TextAlign = ContentAlignment.TopCenter,
                    Dock = DockStyle.Fill,
                };
                Button buttonMore = new Button
                {
                    //Name = a.Id.ToString(),
                    Dock = DockStyle.Right,
                    Text = "+",
                    Font = new Font("Arial", 14, FontStyle.Regular),
                    FlatStyle = FlatStyle.Standard,
                    ForeColor = Color.Black,
                    BackColor = Color.White
                };
                Button buttonMinus = new Button
                {
                    //Name = a.Id.ToString(),
                    Dock = DockStyle.Left,
                    Text = "-",
                    Font = new Font("Arial", 14, FontStyle.Regular),
                    FlatStyle = FlatStyle.Standard,
                    ForeColor = Color.Black,
                    BackColor = Color.White
                };
                PanelWithProducs.Controls.Add(picture);  
                PanelWithProducs.Controls.Add(buttonMore);
                PanelWithProducs.Controls.Add(info);
                PanelWithProducs.Controls.Add(buttonMinus);
            }
        }
    }
}