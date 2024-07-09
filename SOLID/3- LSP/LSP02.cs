namespace SOLID.LSP02
{
    namespace Invalid
    {
        // کلاس ناقض LSP
        public class Rectangle
        {
            public virtual int Width { get; set; }
            public virtual int Height { get; set; }
        }

        public class Square : Rectangle
        {
            public override int Width
            {
                set { base.Width = value; }
            }
            public override int Height
            {
                set { base.Height = value; }
            }
        }

        // به نظر شما، چرا ناقص است؟
        // کلاس، برعکس ارث‌بری شده است.
    }

    namespace Valid
    {
        public class Square
        {
            public virtual int Width { get; set; }
        }

        public class Rectangle: Square
        {
            public override int Width { get => base.Width; set => base.Width = value; }
            public int Height { get; set; }
        }        
    }

    namespace Valid_Upgraded
    {
        // اصلاح شده بر اساس LSP
        public interface IShape
        {
            int Area();
        }

        public class Rectangle : IShape
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public int Area() => Width * Height;
        }

        public class Square : IShape
        {
            public int Side { get; set; }
            public int Area() => Side * Side;
        }
    }
}
