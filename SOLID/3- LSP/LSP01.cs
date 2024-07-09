
namespace SOLID.LSP01
{
	namespace Valid
	{
        public abstract class Shape
        {
            public abstract double Area();
        }

        public class Rectangle : Shape
        {
            public double Width { get; set; }
            public double Height { get; set; }

            public Rectangle(double width, double height)
            {
                Width = width;
                Height = height;
            }

            public override double Area()
            {
                return Width * Height;
            }
        }

        public class Square : Rectangle
        {
            public Square(double side) : base(side, side)
            {
            }
        }

        //----------------------------------
        // یک روش ساده برای بررسی اینکه آیا اصل LSP رعایت شده است یا نه، استفاده از متدهایی است که با کلاس پایه کار می‌کنند.
        //----------------------------------
        class Test
        {
            public static void PrintArea(Shape shape)
            {
                Console.WriteLine("Area: " + shape.Area());
            }

            public static void Test1()
            {
                Rectangle rect = new Rectangle(5, 10);
                PrintArea(rect);

                Square sqr = new Square(5);
                PrintArea(sqr);
            }
        }

    }

    namespace Invalid
	{
        //----------------------------------
        // فرض کنید می‌خواهیم در کلاس Rectangle یک متد جدید به نام SetDimensions اضافه کنیم که ابعاد مستطیل را تنظیم می‌کند.
        //----------------------------------

        public class Rectangle : Valid.Shape
        {
            public double Width { get; set; }
            public double Height { get; set; }

            public Rectangle(double width, double height)
            {
                Width = width;
                Height = height;
            }

            public virtual void SetDimensions(double width, double height)
            {
                Width = width;
                Height = height;
            }

            public override double Area()
            {
                return Width * Height;
            }
        }

        public class Square : Rectangle
        {
            public Square(double side) : base(side, side)
            {
            }

            // تغییر Signature
            public new void SetDimensions(double side)
            {
                base.SetDimensions(side, side);
            }
        }
    }
}
