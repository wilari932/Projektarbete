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
        GetProducs GetProducsFromList = new GetProducs();

        public MainForm()
        {
            
           
            Width = 1100;
            Height = 500;
            
           
            LeftMenuPanel = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2, BackColor = Color.Gray };
            VisualCartPanel = new TableLayoutPanel { Dock = DockStyle.Fill, AutoScroll=true };
            LeftMenuPanelUp = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 1, BackColor = Color.Gray,  };


            LeftMenuPanelUp.Controls.Add(VisualCartPanel);
            LeftMenuPanelUp.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            LeftMenuPanelDown = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, BackColor = Color.Gray };
            LeftMenuPanelBtnDelete = new Button { Text = "delete", Dock = DockStyle.Fill, FlatStyle = FlatStyle.Flat, BackColor = Color.MediumPurple, Font = new Font("Arial", 12, FontStyle.Bold) };
            BtnPurchase = new Button { Text = "COMPLETE PURCHASE", Dock = DockStyle.Fill, FlatStyle = FlatStyle.Flat ,BackColor = Color.MediumPurple , Font = new Font("Arial",  12, FontStyle.Bold) };
           

            LeftMenuPanelDown.Controls.Add(LeftMenuPanelBtnDelete);
            LeftMenuPanelDown.Controls.Add(BtnPurchase);
            LeftMenuPanel.Controls.Add(LeftMenuPanelUp);
            LeftMenuPanel.Controls.Add(LeftMenuPanelDown);
            LeftMenuPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 90));
            LeftMenuPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));

            // RightMenuPanel Objekt
            RightMenuPanel = new FlowLayoutPanel { BackColor = Color.WhiteSmoke, Dock = DockStyle.Fill, AutoScroll = true ,BorderStyle = BorderStyle.Fixed3D};

            foreach (Product a in GetProducsFromList.Products)
            {
                
                PictureBox boc = new PictureBox
                {
                    BackColor = Color.WhiteSmoke,
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Image.FromFile(@"Resources\" + a.PictureName)
                };

                Label labelName = new Label
                {
                    Text = a.Name,
                    Font = new Font("Arial", 12, FontStyle.Regular),
                    Dock = DockStyle.Fill
                };
                
                
                Label labelPrice = new Label
                {
                    Text = "$" + a.Price.ToString(),
                    Font = new Font("Arial", 12, FontStyle.Regular),
                    Dock = DockStyle.Fill
                };

                Button buttons = new Button
                {
                    Name = a.Id.ToString(),
                    Dock = DockStyle.Fill,
                    Text = "Buy now",
                    BackColor = Color.Azure
                };
                buttons.Click += Buttons_Click;
                


                    TableLayoutPanel productRangePanel = new TableLayoutPanel
                    {
                        RowCount = 4,
                        Width = 200,
                        Height = 200,
                        //CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial
                        
                    };
                    productRangePanel.Controls.Add(boc);
                    productRangePanel.Controls.Add(labelName);
                    productRangePanel.Controls.Add(labelPrice);
                    productRangePanel.Controls.Add(buttons);
                    productRangePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 60));
                    productRangePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
                    productRangePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
                    productRangePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
                   
                RightMenuPanel.Controls.Add(productRangePanel);

                }

            RootPanel = new TableLayoutPanel { ColumnCount = 2, Dock = DockStyle.Fill };
          
            this.Controls.Add(RootPanel);
            RootPanel.Controls.Add(LeftMenuPanel);
            RootPanel.Controls.Add(RightMenuPanel);
            RootPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            RootPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            Button BtnGetProductID = (Button)sender;
            GetProducsFromList.CartProducts(int.Parse(BtnGetProductID.Name));
            Cart SelectedProducs = new Cart();
            SelectedProducs.ProducsInCart(GetProducsFromList);
            VisualCartPanel.Controls.Add(SelectedProducs.PanelWithProducs);
        }
    }
}