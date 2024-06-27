namespace SOLID.LSP
{
	namespace Invalid
	{
        // مثال کد بدون رعایت LSP
        public class Bird
        {
            public virtual void Fly()
            {
                // پرواز کردن
            }
        }

        public class Ostrich : Bird
        {
            public override void Fly()
            {
                throw new NotSupportedException("Ostriches can't fly!");
            }
        }
    }

	namespace Valid
	{
        // مثال کد با رعایت LSP
        public abstract class Bird
        {
            // کلاس پایه بدون متد Fly
        }

        public class FlyingBird : Bird
        {
            public void Fly()
            {
                // پرواز کردن
            }
        }

        public class Ostrich : Bird
        {
            // بدون متد Fly
        }
    }
}
