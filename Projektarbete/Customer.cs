using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Projektarbete
{
    class Customer : Form
    {
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
        private Label TotalPrice;
        private Button CompletePurchase;

        public Customer()
        {
            InitialComponents();
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
            //CustomerLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,));

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
                //Margin = new Padding.(25),
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

                Text = Environment.NewLine + "@" + Environment.NewLine,
                Font = new Font("Arial", 11, FontStyle.Regular),
                TextAlign = HorizontalAlignment.Center,
                Margin = new Padding(110, 2, 20, 5),
                ForeColor = Color.DimGray,
                BackColor = Color.White
            };
            EmailBox.TextChanged += EmailBox_TextChanged;

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
                Margin = new Padding(161, 0, 100, 0),
                ForeColor = Color.DimGray,
                BackColor = Color.White
            };
            CleringNumberBox.TextChanged += CleringNumberBox_TextChanged;

            TotalPrice = new Label
            {
                Dock = DockStyle.Fill,
                //vas a borrar el Text 
                Text = "Total Price : $356",
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
            CustomerLayoutPanel.Controls.Add(DiscountLabel);
            CustomerLayoutPanel.Controls.Add(DiscountBox);
            CustomerLayoutPanel.Controls.Add(CreditCardNumber);
            CustomerLayoutPanel.Controls.Add(CMaster);
            CustomerLayoutPanel.Controls.Add(CVisa);
            CustomerLayoutPanel.Controls.Add(CreditCardNumberBox);
            CustomerLayoutPanel.Controls.Add(CleringNumber);
            CustomerLayoutPanel.Controls.Add(CleringNumberBox);
            CustomerLayoutPanel.Controls.Add(TotalPrice);
            CustomerLayoutPanel.Controls.Add(CompletePurchase);

        }

        private void PhoneBox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(PhoneBox.Text, "[a-z]"))
            {
                PhoneBox.Text = PhoneBox.Text.Remove(PhoneBox.Text.Length - 1);
            }
        }

        private void EmailBox_TextChanged(object sender, EventArgs e)
        {
            List<string> num = new List<string> { "@" };
            foreach (string s in num)
            {
                if (EmailBox.Text.Contains(s))
                {

                }
                else
                {
                    EmailBox.Text = "@";
                    break;
                }
            }
        }

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

            if (System.Text.RegularExpressions.Regex.IsMatch(CreditCardNumberBox.Text, "[a-z]"))
            {
                CreditCardNumberBox.Text = CreditCardNumberBox.Text.Remove(CreditCardNumberBox.Text.Length - 1);
                CreditCardNumberBox.Select(CreditCardNumberBox.Text.Length, 0);
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