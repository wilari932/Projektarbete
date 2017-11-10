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
    class Customer : Form
    {
        private double price;
        public TableLayoutPanel CustomerLayoutPanel;
        private Label Title;
        private Label CName;
        private TextBox NameBox;
        private Label LastName;
        private TextBox LastNameBox;
        private Label Phone;
        private TextBox PhoneBox;
        private Label Email;
        private TextBox EmailBox;
        private Label City;
        private TextBox CityBox;
        private Label Address;
        private TextBox AddressBox;
        private Label DiscountLabel;
        private TextBox DiscountBox;
        private Label CreditCardNumber;
        private RadioButton CMaster;
        private RadioButton CVisa;
        private TextBox CreditCardNumberBox;
        private Label CleringNumber;
        private TextBox CleringNumberBox;
        private Label LabelTotalPrice;
        private Button CompletePurchase;
        private Checkout SetCheckout = new Checkout();
        private List<Product> ItemsTocheckouT = new List<Product>();
        public Cart cat = new Cart();

        public Customer(double pris, List<Product> Items, Cart C)
        {
            cat = C;
            GetPrice(pris, Items);
            InitialComponents();
            this.FormClosing += Customer_FormClosing;
        }

        private void Customer_FormClosing(object sender, FormClosingEventArgs e)
        {
            cat.CartLayoutPanel.Controls.Clear();
            cat.ItemsInTheCart.Clear();
            cat.PriceCount();
        }

        private void InitialComponents()
        {
            CustomerGUI();
            FormStyles();
        }
        private void CustomerGUI()
        {
            CustomerLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.WhiteSmoke,
                RowCount = 11
            };

            Title = new Label
            {
                Height = 50,
                Text = "Shipping Information",
                Font = new Font("Arial", 22, FontStyle.Regular),
                Dock = DockStyle.Fill,
                ForeColor = Color.DimGray,
                BackColor = Color.White,
                TextAlign = ContentAlignment.BottomCenter
            };

            CName = new Label
            {
                Dock = DockStyle.Fill,
                Text = "Name",
                Font = new Font("Arial", 12, FontStyle.Regular),
                Margin = new Padding(25, 20, 25, 2),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.BottomCenter
            };

            NameBox = new TextBox
            {
                Cursor = Cursors.Default,
                Width = 210,
                Height = 25,
                Font = new Font("Arial", 11, FontStyle.Regular),
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(110, 2, 20, 5),
                ForeColor = Color.DimGray,
                BackColor = Color.White

            };
            NameBox.TextChanged += NameBox_TextChanged;

            LastName = new Label
            {
                Dock = DockStyle.Fill,
                Text = "Last Name",
                Font = new Font("Arial", 12, FontStyle.Regular),
                Margin = new Padding(25, 10, 25, 2),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.BottomCenter
            };

            LastNameBox = new TextBox
            {
                Cursor = Cursors.Default,
                Width = 210,
                Height = 25,
                Font = new Font("Arial", 11, FontStyle.Regular),
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(110, 2, 20, 5),
                ForeColor = Color.DimGray,
                BackColor = Color.White
            };
            LastNameBox.TextChanged += LastNameBox_TextChanged;

            Phone = new Label
            {
                Dock = DockStyle.Fill,
                Text = "Telephone",
                Font = new Font("Arial", 12, FontStyle.Regular),
                Margin = new Padding(25, 10, 25, 2),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.BottomCenter
            };

            PhoneBox = new TextBox
            {
                Cursor = Cursors.Default,
                Width = 210,
                Height = 25,
                Font = new Font("Arial", 11, FontStyle.Regular),
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(110, 2, 20, 5),
                ForeColor = Color.DimGray,
                BackColor = Color.White
            };
            PhoneBox.TextChanged += PhoneBox_TextChanged;

            Email = new Label
            {
                Dock = DockStyle.Fill,
                Text = "E-mail",
                Font = new Font("Arial", 12, FontStyle.Regular),
                Margin = new Padding(25, 10, 25, 2),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.BottomCenter
            };

            EmailBox = new TextBox
            {
                Cursor = Cursors.Default,
                Width = 210,
                Height = 25,
                Font = new Font("Arial", 11, FontStyle.Regular),
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(110, 2, 20, 5),
                ForeColor = Color.DimGray,
                BackColor = Color.White
            };


            City = new Label
            {
                Dock = DockStyle.Fill,
                Text = "City",
                Font = new Font("Arial", 12, FontStyle.Regular),
                Margin = new Padding(25, 10, 25, 2),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.BottomCenter
            };

            CityBox = new TextBox
            {
                Cursor = Cursors.Default,
                Width = 210,
                Height = 25,
                Font = new Font("Arial", 11, FontStyle.Regular),
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(110, 2, 20, 5),
                ForeColor = Color.DimGray,
                BackColor = Color.White
            };

            Address = new Label
            {
                Dock = DockStyle.Fill,
                Text = "Street Address",
                Font = new Font("Arial", 12, FontStyle.Regular),
                Margin = new Padding(25, 10, 25, 2),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.BottomCenter
            };

            AddressBox = new TextBox
            {
                Cursor = Cursors.Default,
                Width = 210,
                Height = 25,
                Font = new Font("Arial", 11, FontStyle.Regular),
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(110, 2, 20, 5),
                ForeColor = Color.DimGray,
                BackColor = Color.White
            };

            DiscountLabel = new Label
            {
                Dock = DockStyle.Fill,
                Text = "Have you a discount code?",
                Font = new Font("Arial", 12, FontStyle.Regular),
                Margin = new Padding(25, 10, 25, 2),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.BottomCenter
            };

            DiscountBox = new TextBox
            {
                Cursor = Cursors.Default,
                Width = 210,
                Height = 25,
                Font = new Font("Arial", 11, FontStyle.Regular),
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(110, 2, 20, 5),
                ForeColor = Color.DimGray,
                BackColor = Color.White
            };
            DiscountBox.TextChanged += DiscountBox_TextChanged;

            CreditCardNumber = new Label
            {
                Dock = DockStyle.Fill,
                Text = "Credit Card Number",
                Font = new Font("Arial", 12, FontStyle.Regular),
                Margin = new Padding(25, 10, 25, 2),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.BottomCenter
            };

            CMaster = new RadioButton
            {
                Name = "MasterCard",
                Text = "MasterCard",
                Font = new Font("Arial", 9, FontStyle.Underline),
                Margin = new Padding(163, 1, 100, 0),
                ForeColor = Color.DimGray,
                CheckAlign = ContentAlignment.MiddleRight,
            };

            CVisa = new RadioButton
            {
                Name = "Visa",
                Text = "Visa",
                Font = new Font("Arial", 9, FontStyle.Underline),
                Margin = new Padding(163, 0, 100, 2),
                ForeColor = Color.DimGray,
                CheckAlign = ContentAlignment.MiddleRight,
            };

            CreditCardNumberBox = new TextBox
            {
                Cursor = Cursors.Default,
                Width = 210,
                Height = 25,
                MaxLength = 19,
                Font = new Font("Arial", 11, FontStyle.Regular),
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(110, 2, 20, 0),
                ForeColor = Color.DimGray,
                BackColor = Color.White
            };
            CreditCardNumberBox.KeyDown += CreditCardNumberBox_KeyDown;
            CreditCardNumberBox.TextChanged += CreditCardNumberBox_TextChanged;


            CleringNumber = new Label
            {
                Dock = DockStyle.Fill,
                Text = "Clering Number",
                Font = new Font("Arial", 12, FontStyle.Regular),
                Margin = new Padding(25, 2, 25, 0),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.BottomCenter
            };

            CleringNumberBox = new TextBox
            {
                Cursor = Cursors.Default,
                Width = 110,
                Height = 25,
                MaxLength = 3,
                Font = new Font("Arial", 11, FontStyle.Regular),
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(161, 0, 100, 5),
                ForeColor = Color.DimGray,
                BackColor = Color.White
            };
            CleringNumberBox.TextChanged += CleringNumberBox_TextChanged;

            LabelTotalPrice = new Label
            {
                Dock = DockStyle.Fill,
                //vas a borrar el Text 
                Text = "Total Price: $" + price.ToString(),
                Font = new Font("Arial", 14, FontStyle.Regular),
                Margin = new Padding(115, 5, 115, 3),
                ForeColor = Color.DimGray,
                TextAlign = ContentAlignment.MiddleCenter
            };

            CompletePurchase = new Button
            {
                Dock = DockStyle.Fill,
                FlatStyle = FlatStyle.Flat,
                Text = "Complete Purchase",
                Font = new Font("Arial", 16, FontStyle.Regular),
                Margin = new Padding(100, 10, 100, 25),
                ForeColor = Color.White,
                BackColor = Color.SandyBrown,
            };

            CompletePurchase.Click += CompletePurchase_Click;
            CustomerLayoutPanel.Controls.Add(Title);
            CustomerLayoutPanel.Controls.Add(CName);
            CustomerLayoutPanel.Controls.Add(NameBox);
            CustomerLayoutPanel.Controls.Add(LastName);
            CustomerLayoutPanel.Controls.Add(LastNameBox);
            CustomerLayoutPanel.Controls.Add(Phone);
            CustomerLayoutPanel.Controls.Add(PhoneBox);
            CustomerLayoutPanel.Controls.Add(Email);
            CustomerLayoutPanel.Controls.Add(EmailBox);
            CustomerLayoutPanel.Controls.Add(City);
            CustomerLayoutPanel.Controls.Add(CityBox);
            CustomerLayoutPanel.Controls.Add(Address);
            CustomerLayoutPanel.Controls.Add(AddressBox);
            if (!SetCheckout.SendError)
            {
                CustomerLayoutPanel.Controls.Add(DiscountLabel);
                CustomerLayoutPanel.Controls.Add(DiscountBox);
            }
            CustomerLayoutPanel.Controls.Add(CreditCardNumber);
            CustomerLayoutPanel.Controls.Add(CMaster);
            CustomerLayoutPanel.Controls.Add(CVisa);
            CustomerLayoutPanel.Controls.Add(CreditCardNumberBox);
            CustomerLayoutPanel.Controls.Add(CleringNumber);
            CustomerLayoutPanel.Controls.Add(CleringNumberBox);
            CustomerLayoutPanel.Controls.Add(LabelTotalPrice);
            CustomerLayoutPanel.Controls.Add(CompletePurchase);

        }
        private bool TexBoxesCheck()
        {

            if (NameBox.TextLength == 0 || !System.Text.RegularExpressions.Regex.IsMatch(NameBox.Text, "[A-z]") || System.Text.RegularExpressions.Regex.IsMatch(NameBox.Text, "[0-9]")) { NameBox.BackColor = Color.Red; return false; }
            else if (!EmailBox.Text.Contains("@") || EmailBox.TextLength == 0) { EmailBox.BackColor = Color.Red; return false; }
            else if (LastNameBox.TextLength == 0) { LastNameBox.BackColor = Color.Red; return false; }
            else if (CreditCardNumberBox.TextLength == 0 || CreditCardNumberBox.TextLength < 13) { CreditCardNumberBox.BackColor = Color.Red; return false; }
            else if (CleringNumberBox.TextLength == 0 || CleringNumberBox.TextLength < 3) { CleringNumberBox.BackColor = Color.Red; return false; }
            else if (PhoneBox.TextLength == 0) { PhoneBox.BackColor = Color.Red; return false; }
            else if (AddressBox.TextLength == 0) { AddressBox.BackColor = Color.Red; return false; }
            else
            {
                return true;
            }
        }

        private void DiscountBox_TextChanged(object sender, EventArgs e)
        {

            if (DiscountBox.TextLength > 0)
            {

                price = SetCheckout.Discount(DiscountBox.Text, price);
                LabelTotalPrice.Text = price.ToString();
                if (SetCheckout.Send)
                {
                    DiscountBox.BackColor = Color.Aquamarine;
                    MessageBox.Show("You have discount is set!");
                    DiscountBox.Enabled = false;
                }

                else
                {
                    DiscountBox.BackColor = Color.LightCoral;
                }
            }
            else
            {
                DiscountBox.BackColor = Color.White;
            }
        }

        public void GetPrice(double getPrice, List<Product> Items)
        {

            foreach (Product a in Items)
            {
                ItemsTocheckouT.Add(a);
            }
            price = getPrice;
        }

        private string Order()
        {
            try
            {
                Random radomPathNumber = new Random();
                int[] a = new int[] { };
                string[] b = new string[7] { "", "", "", "", "", "", "", };
                string c = null;

                for (int i = 0; i < 7; i++)
                {
                    b[i] = radomPathNumber.Next(0, 10).ToString();
                    c += b[i];
                }
                string path = @"Resources/Order/" + c + ".txt";

                if (File.Exists(path))
                {
                    c += "0";
                    path = @"Resources/Order/" + c + ".txt";
                    var Myfile = File.CreateText(path);
                    Myfile.Close();
                }
                else
                {
                    var Myfile = File.CreateText(path);
                    Myfile.Close();
                }

                DateTime s = DateTime.Now;

                string content = "Your order Was Created " + s.ToString() + System.Environment.NewLine +
                  "Your order number is : " + c + System.Environment.NewLine
                  + "Dear " + NameBox.Text + " " + LastNameBox.Text + ". Thanks for your order! "
                 + System.Environment.NewLine +
                 "**********************" + System.Environment.NewLine + "# Shipping Information #" + System.Environment.NewLine +
                 "# telephone number: " + PhoneBox.Text + " #" + System.Environment.NewLine +
                 "#" + "Adreess: " + AddressBox.Text + " #" + System.Environment.NewLine +
                 "# City: " + CityBox.Text + "#" + System.Environment.NewLine +
                 "You have ordered following items:" + System.Environment.NewLine;

                foreach (Product p in ItemsTocheckouT)
                {
                    content += System.Environment.NewLine + "**************************************************************************" + System.Environment.NewLine;
                    content += p.Name + " You have ordered " + p.Quantity.ToString() + " pieces of these. " + "The price per unit is $" + p.Price.ToString() + " Dollars " + System.Environment.NewLine;
                }
                content += " The toltal Price Was $" + price.ToString() + " Dollars";

                File.WriteAllText(path, content);
                return c + ".txt";
            }
            catch
            {
                MessageBox.Show("We are so sorry The order could not be completed");
            }
            return null;
        }

        private void CompletePurchase_Click(object sender, EventArgs e)
        {
            bool check = TexBoxesCheck();
            if (check)
            {
                SendMail sendMail = new SendMail();

                sendMail.CustomerMail = EmailBox.Text;
                sendMail.SendMailNow(Order());
                cat.CartLayoutPanel.Controls.Clear();
                cat.ItemsInTheCart.Clear();
                cat.PriceCount();

                this.Close();
            }
        }

        private void PhoneBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(PhoneBox.Text, "[a-z]"))
            {
                PhoneBox.Text = PhoneBox.Text.Remove(PhoneBox.Text.Length - 1);
            }
        }

        //private void EmailBox_TextChanged(object sender, EventArgs e)
        //{
        //    List<string> num = new List<string> { "@" };
        //    foreach (string s in num)
        //    {
        //        if (EmailBox.Text.Contains(s))
        //        {

        //        }
        //        else
        //        {
        //            EmailBox.Text = "@";
        //            break;
        //        }
        //    }
        //}

        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            List<string> num = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            foreach (string s in num)
            {
                if (NameBox.Text.Contains(s))
                {
                    NameBox.Clear();
                    break;
                }
            }
        }

        private void LastNameBox_TextChanged(object sender, EventArgs e)
        {
            List<string> num = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            foreach (string s in num)
            {
                if (LastNameBox.Text.Contains(s))
                {
                    LastNameBox.Clear();
                    break;
                }
            }
        }

        private void CreditCardNumberBox_TextChanged(object sender, EventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(CreditCardNumberBox.Text, "[A-z]"))
            {
                CreditCardNumberBox.Text = CreditCardNumberBox.Text.Remove(CreditCardNumberBox.Text.Length - 1);
                CreditCardNumberBox.Select(CreditCardNumberBox.Text.Length, 0);
            }
            else
            {
                if (CreditCardNumberBox.Text.StartsWith("4"))
                {
                    CVisa.Checked = true;
                }
                else if (CreditCardNumberBox.Text.StartsWith("5"))
                {
                    CMaster.Checked = true;
                }
            }
        }

        private string YourText(string text)
        {
            switch (text.Length)
            {
                case 4:
                    text = text + " ";
                    break;
                case 9:
                    text = text + " ";
                    break;
                case 14:
                    text = text + " ";
                    break;
            }
            return text;
        }

        private void CreditCardNumberBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Back)
            {
                CreditCardNumberBox.Text = YourText(CreditCardNumberBox.Text);

                CreditCardNumberBox.Select(CreditCardNumberBox.Text.Length, 0);
            }
        }

        private void CleringNumberBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(CleringNumberBox.Text, "[^0-9]"))
            {
                CleringNumberBox.Text = CleringNumberBox.Text.Remove(CleringNumberBox.Text.Length - 1);
            }
        }

        //MainForm Changes
        private void FormStyles()
        {
            this.Controls.Add(CustomerLayoutPanel);
            Text = "Nordic Data Store";
            Size = new Size(450, 830);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = false;
            MaximizeBox = false;
        }
    }
}