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
                    BackColor = Color.WhiteSmoke,
                    Dock = DockStyle.Top,
                };
                
                PictureBox picture = new PictureBox
                {
                    //BackColor = Color.WhiteSmoke,
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Image.FromFile(@"Resources\" + ProducFinder.PictureName)

                };
                

                Label info = new Label
                {
                    Text = ProducFinder.Name + " " + ProducFinder.Price,
                    Font = new Font("Arial", 12, FontStyle.Regular),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    
                };

                PanelWithProducs.Controls.Add(picture);
                PanelWithProducs.Controls.Add(info);





            }
        }
        //ahhhhhhhhhhhhhhh
    }
}