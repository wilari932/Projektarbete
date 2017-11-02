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
            Root.Dock = DockStyle.Fill;
            Root.ColumnCount = 2;
            
            Root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36));
            Root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64));

            this.Controls.Add(Root);
            Root.Controls.Add( DisplayProducs.LeftMenuPanel);
            Root.Controls.Add( DisplayProducs.ShowProducs);

        }
       
     
    }
}