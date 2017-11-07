using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Projektarbete
{


    class GetProducs
    {

        private TableLayoutPanel LeftMenuPanelUp;
        public FlowLayoutPanel ShowProducs;
        private Button ButtonAddToCart;
        public TableLayoutPanel LeftMenuPanel;
        private  TableLayoutPanel LeftMenuPanelDown;
        private Cart SetCart = new Cart();
        public List<Product> ProducsFromList = new List<Product>();
       
        public GetProducs()
        {

            InitialComponents();
   

        }

        // Get the Data From Text File
        private void GetProducsFromList()
        {
            string path = @"Resources\products.txt";

        List<string> ReadLines = File.ReadAllLines(path).ToList();
            foreach (string lines in ReadLines)
            {
                string[] entries = lines.Split(',');
                Product product = new Product();
                product.Id = int.Parse(entries[0]);
                product.Name = entries[1];
                product.PictureName = entries[2];
                product.Price = Double.Parse(entries[3]);
                ProducsFromList.Add(product);
            }
        }


        //Display The Products In A GUI Form,  And We Save The Output In : FlowLayoutPanel ShowProducs;

        private void InitialComponents()
        {
            try
            {
                GetProducsFromList();
            }
            catch
            {

            }
            ShowTables();
            ShowProducsInGui();
            ShowLeftMenuPanelDownControls();

        }
        private void ShowLeftMenuPanelDownControls()
        {
            LeftMenuPanelDown.Controls.Add(SetCart.ShowPriceLabel);
            LeftMenuPanelDown.Controls.Add(SetCart.CheckOutButton);
           
        }
        private void ShowTables() {
            LeftMenuPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,



            };

            LeftMenuPanelUp = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 1,
                BackColor = Color.White,
                BorderStyle = BorderStyle.Fixed3D,


            };
            LeftMenuPanelUp.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            LeftMenuPanelDown = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = Color.White,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble
            };
            LeftMenuPanelDown.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            LeftMenuPanelDown.RowStyles.Add(new RowStyle(SizeType.Percent, 50));

            LeftMenuPanel.Controls.Add(LeftMenuPanelUp);
            LeftMenuPanel.Controls.Add(LeftMenuPanelDown);
            LeftMenuPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 85));
            LeftMenuPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 15));

            
        }
        private void ShowProducsInGui()
        {


            ShowProducs = new FlowLayoutPanel
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BorderStyle = BorderStyle.Fixed3D


            };


            foreach (Product a in ProducsFromList)
            {
                PictureBox picture = new PictureBox
                {
                    BackColor = Color.White,
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                };
                try
                {
                    picture.Image = Image.FromFile(@"Resources\" + a.PictureName);
                }
                catch
                {
                    try
                    {
                        picture.Image = Image.FromFile(@"Resources\Error\1.png");
                    }
                    catch
                    {
                        picture.BackColor = Color.Black;
                    }
                }


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

                ButtonAddToCart = new Button
                {
                    Tag = ProducsFromList.FindIndex(x => x == a),
                    Dock = DockStyle.Fill,
                    Text = "Add to cart",
                    Font = new Font("Arial", 11, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    ForeColor = Color.White,
                    BackColor = Color.SandyBrown,
                };
                ButtonAddToCart.Click += ButtonAddToCart_Click;



                TableLayoutPanel productRangePanel = new TableLayoutPanel
                {
                    RowCount = 3,
                    Width = 175,
                    Height = 250,
                };
                productRangePanel.Controls.Add(picture);
                productRangePanel.Controls.Add(labelName);
                productRangePanel.Controls.Add(labelPrice);
                productRangePanel.Controls.Add(ButtonAddToCart);
                productRangePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 55));
                productRangePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
                productRangePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
                productRangePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 15));
                ShowProducs.Controls.Add(productRangePanel);




            }
        }

        private void ButtonAddToCart_Click(object sender, EventArgs e)
        {
            Button a = (Button)sender;

            if (SetCart.ItemsInTheCart.Exists(x => x.Id == ProducsFromList[Convert.ToInt32(a.Tag)].Id))
            {
                MessageBox.Show("This product is already in your cart");
            }
            else
            {
               
                LeftMenuPanelUp.Controls.Add(SetCart.CartLayoutPanel);
                SetCart.ItemsInTheCart.Add(ProducsFromList[Convert.ToInt32(a.Tag)]);
                SetCart.AddToCart(false);
                 SetCart.PriceCount();
            }
          
        }





    }
}
