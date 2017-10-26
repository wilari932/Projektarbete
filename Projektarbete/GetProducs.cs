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
        public List<Product> CartProductsList = new List<Product>();
        public GetProducs()
        {
            try
            {
                List<string> ReadLines = File.ReadAllLines(path).ToList();
                foreach (string lines in ReadLines)
                {
                    string[] entries = lines.Split(',');
                    Product s = new Product();
                    s.Id = int.Parse(entries[0]);
                    s.Name = entries[1];
                    s.PictureName = entries[2];
                    s.Price = Double.Parse(entries[3]);
                    Products.Add(s);
                }
            }
            catch
            {
                MessageBox.Show("Text Filen Finns inte!");
            }
        }
        public void CartProducts(int ID)
        {
            CartProductsList.Add(Products[ID]);
        }
    }
}