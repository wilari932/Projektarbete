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
        public List<Product> CartProductsList = new List<Product>();
        public List<Product> RemoveCartProductsList = new List<Product>();
        public TableLayoutPanel PanelWithProducs { get; set; }
        public TableLayoutPanel PanelWithPersonData { get; set; }
        private double TotaltPrice { get; set; }

        public void ProducsInCart()
        {
            if (CartProductsList.Count >= 1)
            {
                for (int i = 0; i < CartProductsList.Count; i++)
                {
                    PanelWithProducs = new TableLayoutPanel
                    {
                        Height = 100,
                        Width = 275,
                        ColumnCount = 5,
                        //RowCount = 1,
                        CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                        BackColor = Color.White,
                        Dock = DockStyle.Top,
                        Cursor = Cursors.Hand,
                        Name = i.ToString()
                    };

                    PanelWithProducs.Click += PanelWithProducs_Click;
                    //PanelWithProducs.MouseEnter += PanelWithProducs_MouseEnter;
                    //PanelWithProducs.MouseLeave += PanelWithProducs_MouseLeave;
                    PanelWithProducs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
                    PanelWithProducs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));
                    PanelWithProducs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8));
                    PanelWithProducs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18));
                    PanelWithProducs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8));
                    PanelWithProducs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6));

                    PictureBox picture = new PictureBox
                    {
                        Dock = DockStyle.Fill,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Enabled = false,
                    };
                    try
                    {
                        picture.Image = Image.FromFile(@"Resources\" + CartProductsList[i].PictureName);
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
                    Label info = new Label
                    {
                        Text = CartProductsList[i].Name + "\n" + CartProductsList[i].Price,
                        Font = new Font("Arial", 11, FontStyle.Regular),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Fill,
                        Enabled = false,
                    };
                    Button buttonMore = new Button
                    {
                        Dock = DockStyle.Left,
                        Text = "+",
                        Font = new Font("Arial", 10, FontStyle.Regular),
                        FlatStyle = FlatStyle.System,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Anchor = (AnchorStyles.None | AnchorStyles.None),
                        ForeColor = Color.Black,
                        BackColor = Color.White
                    };
                    Button buttonLess = new Button
                    {
                        Dock = DockStyle.Right,
                        Text = "-",
                        Font = new Font("Arial", 10, FontStyle.Regular),
                        FlatStyle = FlatStyle.System,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Anchor = (AnchorStyles.None | AnchorStyles.None),
                        ForeColor = Color.Black,
                        BackColor = Color.White
                    };
                    TextBox quantity = new TextBox
                    {
                        //Dock = DockStyle.Fill,
                        TextAlign = HorizontalAlignment.Center,
                        Text = "1",
                        Anchor = (AnchorStyles.None | AnchorStyles.None),
                        Font = new Font("Arial", 11, FontStyle.Regular),
                        ForeColor = Color.Black,
                        BackColor = Color.White,
                        Enabled = false
                    };
                    PanelWithProducs.Controls.Add(picture);
                    PanelWithProducs.Controls.Add(info);
                    PanelWithProducs.Controls.Add(buttonLess);
                    PanelWithProducs.Controls.Add(quantity);
                    PanelWithProducs.Controls.Add(buttonMore);
                }
            }
        }
        //private void PanelWithProducs_MouseLeave(object sender, EventArgs e)
        //{
        //    TableLayoutPanel S = (TableLayoutPanel)sender;
        //    S.BackColor = Color.White;

        //}

        //private void PanelWithProducs_MouseEnter(object sender, EventArgs e)
        //{
        //    TableLayoutPanel S = (TableLayoutPanel)sender;

        //    S.BackColor = Color.AliceBlue;
        //    S.Cursor = Cursors.Hand;
        //}
        public void PanelWithProducs_Click(object sender, EventArgs e)
        {
            TableLayoutPanel S = (TableLayoutPanel)sender;
            if (S.BackColor == Color.AliceBlue)
            {
                S.BackColor = Color.White;
                RemoveCartProductsList.Remove(CartProductsList[int.Parse(S.Name)]);
            }
            else if (S.BackColor == Color.White)
            {
                S.BackColor = Color.AliceBlue;
                RemoveCartProductsList.Add(CartProductsList[int.Parse(S.Name)]);
            }
        }
        public double Purchase()
        {
            foreach (Product count in CartProductsList)
            {
                TotaltPrice += count.Price;
            }
            return TotaltPrice;
        }
        public void DeleteObjecs()
        {
            foreach (Product a in RemoveCartProductsList)
            {
                if (CartProductsList.Exists(x => x == a))
                {
                    CartProductsList.Remove(a);
                }
            }
            RemoveCartProductsList.Clear();
            PanelWithProducs.Controls.Clear();
            ProducsInCart();
        }
        public void PersonData()
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