using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projektarbete
{
    class Checkout
    {
        private bool SomethingisWrong;
        public bool SendError
        {
            get
            {
                return SomethingisWrong;
            }

        }

        private bool DiscuntCodeIsInvaluable;
        public bool Send
        {
            get
            {
                return DiscuntCodeIsInvaluable;
            }
        }

        public double Discount(string DiscontCode, double TotaltPrice)
        {
            try
            {
                string path = @"Resources/ProgramFIles/DiscontCodes.txt";
                List<string> ReadDiscontCode = new List<string>();
                ReadDiscontCode = File.ReadLines(path).ToList();
                foreach (string s in ReadDiscontCode)
                {
                    string[] separator = s.Split(',');
                    if (separator[0] == DiscontCode)
                    {

                        double Fix = Convert.ToDouble(separator[1].Trim(new Char[] { '%' })) / 100;
                        Fix = Fix * TotaltPrice;
                        TotaltPrice = TotaltPrice - Fix;
                        DiscuntCodeIsInvaluable = true;
                    }
                    else
                    {
                        DiscuntCodeIsInvaluable = false;
                    }
                }
            }
            catch
            {
                SomethingisWrong = true;
            }
            return TotaltPrice;
        }
    }
}