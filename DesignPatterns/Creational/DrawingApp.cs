/* Task 10:
Create a drawing application where users can create different types of Brushes 
(PencilBrush, InkBrush, PaintBrush) based on the selected tool. */

using System.Runtime.InteropServices;

namespace Task10
{
    interface IBrush
    {
        void Paint();
    }

    class PencilBrush : IBrush
    {
        public void Paint()
        {
            Console.WriteLine($"Painted by {nameof(PencilBrush)}");
        }
    }

    class InkBrush : IBrush
    {
        public void Paint()
        {
            Console.WriteLine($"Painted by {nameof(InkBrush)}");
        }
    }

    class PaintBrush : IBrush
    {
        public void Paint()
        {
            Console.WriteLine($"Painted by {nameof(PaintBrush)}");
        }
    }

    static class BrushFactory
    {
        public static IBrush CreateBrush(string type)
        {
            string lowerType = type.ToLower();
            switch (lowerType)
            {
                case "ink":
                    return new InkBrush();
                case "paint":
                    return new PaintBrush();
                case "pencil":
                    return new PencilBrush();
                default:
                    throw new ArgumentException("Unknown type" + type);
            }
        }
    }
    

    static class Program
    {
        static void Main(string[] args)
        {
           var factory = BrushFactory.CreateBrush("ink");
           factory.Paint();
        }
    }
}