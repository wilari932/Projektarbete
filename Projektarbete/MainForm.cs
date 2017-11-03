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

        GetProducs DisplayProducs = new GetProducs();

       

        public MainForm()
        {
            InitialComponents();

        }
        private void InitialComponents()
        {
            
            FormStyles();
           

            Root.Dock = DockStyle.Fill;
            Root.ColumnCount = 2;
            Root.BackColor = Color.DarkGray;
            
            Root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36));
            Root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64));

          
            Root.Controls.Add( DisplayProducs.LeftMenuPanel);
            Root.Controls.Add( DisplayProducs.ShowProducs);

        }
        //MainForm Changes
        private void FormStyles()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.Controls.Add(Root);
            this.Width = 1500;
            this.Height = 700;
         
        
        }
       
     
    }
}