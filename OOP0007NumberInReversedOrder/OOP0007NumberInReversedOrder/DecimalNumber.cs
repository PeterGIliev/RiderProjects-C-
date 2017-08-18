using System.Linq;

namespace OOP0007NumberInReversedOrder
{
    public class DecimalNumber
    {
        private double number;

        public DecimalNumber(double number)
        {
            this.number = number;
        }

        public double Number => this.number;

        public void ReverseNumber(string inputString)
        {
            this.number = double.Parse(string.Join("", inputString.Reverse()));
        }
    }
}