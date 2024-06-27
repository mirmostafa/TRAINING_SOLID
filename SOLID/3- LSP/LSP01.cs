namespace SOLID.LSP
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
                set { base.Width = base.Height = value; }
            }
            public override int Height
            {
                set { base.Width = base.Height = value; }
            }
        }
    }

    namespace Valid
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
