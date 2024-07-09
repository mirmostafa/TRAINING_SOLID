namespace SOLID.LSP03
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
            // Side-effect
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
            public string? Name { get; set; }
            // کلاس پایه بدون متد Fly
        }

        // پرنده‌ای که میتواند پرواز کند
        public interface ICanFly
        {
            void Fly();
        }

        public class FlyingBird : Bird, ICanFly
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

        //------------------
        public class Test
        {
            // این متد را کامل کنید: void Flight() { }
            public static void Flight<TBird>(TBird bird)
                where TBird : Bird, ICanFly
            {
                Console.WriteLine($"{bird.Name} wants to fly:");
                bird.Fly();
            }
        }
    }
}
