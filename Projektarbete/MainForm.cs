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
        private TableLayoutPanel Root1 = new TableLayoutPanel();
        private TableLayoutPanel Root = new TableLayoutPanel();
        GetProducs DisplayProducs = new GetProducs();



        public MainForm()
        {
            InitialComponents();

        }
        private void InitialComponents()
        {

            FormStyles();


            Root1.RowCount = 2;
            Root1.Dock = DockStyle.Fill;
            Root1.RowStyles.Add(new RowStyle(SizeType.Percent, 14));
            Root1.RowStyles.Add(new RowStyle(SizeType.Percent, 86));
            TableLayoutPanel Panel = new TableLayoutPanel
            {

                Dock = DockStyle.Fill,
                //BackColor = Color.FromArgb(44, 45, 48),


                ColumnCount = 3,
                BackColor = Color.FromArgb(170, 166, 171),




            };

            TableLayoutPanel Panel3 = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(44, 45, 48),
                Margin = new Padding(0)
            };
            TableLayoutPanel Panel4 = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,

                BackColor = Color.FromArgb(170, 166, 171),
                Margin = new Padding(0)

            };

            Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
            Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
            Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33));
            PictureBox CompanyBanner = new PictureBox
            {
                Image = Image.FromFile(@"Resources\header.png"),
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage,                
                Margin = new Padding(0)
            };

            Panel.Controls.Add(Panel3);


            Panel.Controls.Add(CompanyBanner);
            Panel.Controls.Add(Panel4);


            Root1.Controls.Add(Panel);
            Root1.Controls.Add(Root);



            // root
            Root.Dock = DockStyle.Fill;
            Root.ColumnCount = 2;


            Root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36));
            Root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64));


            Root.Controls.Add(DisplayProducs.LeftMenuPanel);
            Root.Controls.Add(DisplayProducs.ShowProducs);

        }
        //MainForm Changes
        private void FormStyles()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.Controls.Add(Root1);
            this.Width = 1500;
            this.Height = 700;


        }


    }
}