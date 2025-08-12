/* Task 7:
Implement a graphic editor where users can duplicate shapes (Circle, Square, Rectangle)
 without manually copying all properties every time. */

namespace Task7
{
    interface IPrototype
    {
        IPrototype Clone();
    }

    interface IShape
    {
        double CalculateArea();
        void Draw();
    }

    class Circle : IShape, IPrototype
    {
        public int Radius { get; set; }
        public Circle(int radius) => Radius = radius;
        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public IPrototype Clone()
        {
            return new Circle(Radius);
        }

        public void Draw()
        {
            throw new NotImplementedException(); // chgitem vonc circle tpem consolov)))
        }
    }

    class Square : IShape, IPrototype
    {
        private int _height;
        private int _width;
        public int Height
        {
            get { return _height; }
            set 
            {
                _height = value; 
                _width = value;
            }
        }
        
        public int Width
        {
            get { return _width; }
            set 
            {
                _height = value; 
                _width = value;
            }
        }
        
        

        public Square(int width, int height)
        {
            Width = width; Height = height;
        }
        public double CalculateArea()
        {
            return Height * Width;
        }

        public IPrototype Clone()
        {
            return new Square(Width, Height);
        }

        public void Draw()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }
    }

   
}
