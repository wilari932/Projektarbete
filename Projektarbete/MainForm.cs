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
        private TableLayoutPanel Root = new TableLayoutPanel();
        private TableLayoutPanel RootContainer = new TableLayoutPanel();
        private TableLayoutPanel Banner;
        private int timer = 1;
        private TableLayoutPanel Bannercontent1;
        private TableLayoutPanel Bannerconten2;
        private PictureBox BannerPicture;
        private Label CompanyText;
     GetProducs DisplayProducs = new GetProducs();



        public MainForm()
        {
            FormStyles();
            InitialComponents();

        }
        private void InitialComponents()
        {
            BannerMaker(@"Resources/YourBanner/header.png");

            // root
            RootContainer.Dock = DockStyle.Fill;
            RootContainer.ColumnCount = 2;
            RootContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36));
            RootContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64));
            RootContainer.Controls.Add(DisplayProducs.LeftMenuPanel);
            RootContainer.Controls.Add(DisplayProducs.ShowProducs);

            //root
            Root.Controls.Add(Banner);
            Root.Controls.Add(RootContainer);
            Root.RowCount = 2;
            Root.Dock = DockStyle.Fill;
            Root.RowStyles.Add(new RowStyle(SizeType.Percent, 14));
            Root.RowStyles.Add(new RowStyle(SizeType.Percent, 86));

        }
        private  void BannerMaker(string PicturePath) {
            // Banner 
            Banner = new TableLayoutPanel
            {

                Dock = DockStyle.Fill,

                ColumnCount = 3,
                BackColor = Color.FromArgb(38, 38, 32),


            };
            Banner.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
            Banner.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
            Banner.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
           



            Bannercontent1 = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(38, 38, 32),
                Margin = new Padding(0)
            };
            CompanyText = new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 20, FontStyle.Italic),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "Welcome To Nordic Data Store",
                ForeColor = Color.White
                

            };
            Bannerconten2 = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,

                BackColor = Color.FromArgb(38, 38, 32),
                Margin = new Padding(0)

            };

           
                 BannerPicture = new PictureBox
                {
                   
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Margin = new Padding(0)
                };
            try
            {
                BannerPicture.Image = Image.FromFile(PicturePath);
            }
            catch
            {
               BannerPicture.BackColor = Color.Blue;
            }
          

            Timer Tick = new Timer
            {
                Interval = 1500
            };
            Tick.Tick += Tick_Tick;
            Tick.Start();
        }

        private void Tick_Tick(object sender, EventArgs e)
        {
            switch (timer)
            {
                case 1: 
                  
                    Banner.Controls.Add(BannerPicture);
                    Banner.Controls.Add(Bannercontent1);
                    Bannercontent1.Controls.Add(CompanyText);
                    Banner.Controls.Add(Bannerconten2);
                    timer = 2;
                    break;
                case 2:
                
            
                    Banner.Controls.Add(Bannerconten2);
                    Banner.Controls.Add(Bannercontent1);
                    Bannercontent1.Controls.Add(CompanyText);
                    Banner.Controls.Add(BannerPicture);
                   
                  
                    
                    timer = 1;
                    break;
               

            }
            
           
        }

        //MainForm Changes
        private void FormStyles()
        {
          

            //This Form
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.Controls.Add(Root);
            this.Width = 1500;
            this.Height = 700;
            this.FormClosing += MainForm_FormClosing;

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           if(DisplayProducs.SetCart.CartIsNotEmpty())
            {
                DialogResult dialogResult = MessageBox.Show("There is some stuff in your cart!", "Are you sure, you want to leave?", MessageBoxButtons.YesNo);
                e.Cancel = (dialogResult == DialogResult.No);
            }
        }
    }
}