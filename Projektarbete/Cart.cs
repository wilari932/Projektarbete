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
                    Width = 200


                };
                PictureBox picture = new PictureBox
                {
                    BackColor = Color.WhiteSmoke,
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage,

                    Image = Image.FromFile(@"Resources\" + ProducFinder.PictureName)

                };
                u.Controls.Add(picture);

                
              


            }
        }

    }
}
