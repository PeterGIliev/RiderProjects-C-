namespace OOP0016ClassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        
        
        public double Length
        {
            private get { return this.length; }
            set
            {
                if (value <= 0)  
                {
                    throw new System.ArgumentException("Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }
        
        public double Width
        {
            private get { return this.width; }
            set
            {
                if (value <= 0)  
                {
                    throw new System.ArgumentException("Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }
        
        public double Height
        {
            private get { return this.height; }
            set
            {
                if (value <= 0)  
                {
                    throw new System.ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            return 2 * length * width + 2 * length * height + 2 * width * height;
        }

        public double LateralSurface()
        {
            return (length * height) * 2 + (width * height) * 2;
        }

        public double Volume()
        {
            return length * width * height;
        }
    }
}