
namespace OOP0007LastDigitName
{
    public class Num
    {
        private string number;

        public Num(string number)
        {
            this.number = number;
        }

        public string Number => this.number;

        public void TurnDigitToWord(int digit)
        {
            var lastDigit = digit % 10;
            
            switch (lastDigit)
            {
                    case 0:
                        this.number = "zero";
                        break;
                    case 1:
                        this.number = "one";
                        break;
                    case 2:
                        this.number = "two";
                        break;
                    case 3:
                        this.number = "three";
                        break;
                    case 4:
                        this.number = "four";
                        break;
                    case 5:
                        this.number = "five";
                        break;
                    case 6:
                        this.number = "six";
                        break;
                    case 7:
                        this.number = "seven";
                        break;
                    case 8:
                        this.number = "eight";
                        break;
                    case 9:
                        this.number = "nine";
                        break;
                    
            }
        }
        
    }
}