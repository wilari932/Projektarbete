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
        private string path = @"Resources\products.txt";
        public List<Product> Products = new List<Product>();

        public GetProducs()
        {

            try
            {

                List<string> ReadLines = File.ReadAllLines(path).ToList();


                foreach (string lines in ReadLines)
                {

                    string[] entries = lines.Split(',');
                    Product s = new Product();
                    s.Name = entries[0];
                    s.PictureName = entries[1];
                    s.Price = Double.Parse(entries[2]);
                    Products.Add(s);

                }
            }
            catch
            {
                MessageBox.Show("Text Filen Finns inte !");
            }


            }
        }
      
    }

