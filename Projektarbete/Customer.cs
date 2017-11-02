using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Projektarbete
{
    class Customer
    {
        public TableLayoutPanel PanelWithPersonData;
        public Customer()
        {
            PanelWithPersonData = new TableLayoutPanel
            {
                Height = 400,
                Width = 400
            };
            TableLayoutPanel J = new TableLayoutPanel
            {
                RowCount = 7,
                Dock = DockStyle.Fill
            };
            Label PlainTextName = new Label
            {
                Text = "Name",
                Font = new Font("Arial", 11, FontStyle.Regular),
            };
            TextBox nameBox = new TextBox
            {
                Height = 30,
                Width = 250,
                BorderStyle = BorderStyle.Fixed3D,
            };
            Label PlainTexSecondtName = new Label
            {
                Text = "Second Name",
                Font = new Font("Arial", 11, FontStyle.Regular),
            };
            TextBox SecondNameBox = new TextBox
            {
                Height = 30,
                Width = 50,
            };
            Label PlainTextEmail = new Label
            {
                Text = "Email",
                Font = new Font("Arial", 11, FontStyle.Regular),
            };
            TextBox EmailBox = new TextBox
            {
                Height = 30,
                Width = 50,
            };
            MessageBox.Show("This product is already in your cart");
            TextBox CleringNumberBox = new TextBox
            {
                Height = 30,
                Width = 50,
            };
            TextBox CredicCardNumberBox = new TextBox
            {
                Height = 30,
                Width = 50,
            };
            PictureBox SelectpictureCart = new PictureBox
            {
                Width = 20,
                Height = 20,
            };
            PictureBox SelectpictureCart2 = new PictureBox
            {
                Width = 20,
                Height = 20,
            };
            TableLayoutPanel CardTable = new TableLayoutPanel
            {

                RowCount = 3,
                ColumnCount = 2,
                Dock = DockStyle.Fill
            };
            CardTable.Controls.Add(CleringNumberBox);
            CardTable.Controls.Add(CredicCardNumberBox);
            CardTable.Controls.Add(SelectpictureCart);
            CardTable.Controls.Add(SelectpictureCart);
            CardTable.Controls.Add(CleringNumberBox);
            J.Controls.Add(PlainTextName);
            J.Controls.Add(nameBox);
            J.Controls.Add(PlainTexSecondtName);
            J.Controls.Add(SecondNameBox);
            J.Controls.Add(PlainTextEmail);
            J.Controls.Add(EmailBox);
            J.Controls.Add(CardTable);
            J.Controls.Add(CardTable);
            PanelWithPersonData.Controls.Add(J);
        }
    }
}