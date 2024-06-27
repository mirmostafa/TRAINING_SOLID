namespace SOLID.ISP
{
	namespace Invalid
	{
        // کلاس ناقض ISP
        public interface IWorker
        {
            void Work();
            void Eat();
        }

        public class Worker : IWorker
        {
            public void Work()
            {
                // کار
            }
            public void Eat()
            {
                // غذا خوردن
            }
        }

        public class Robot : IWorker
        {
            public void Work()
            {
                // کار
            }
            public void Eat()
            {
                throw new NotImplementedException();
            }
        }
    }

	namespace Valid
	{
        // اصلاح شده بر اساس ISP
        public interface IWorkable
        {
            void Work();
        }

        public interface IFeedable
        {
            void Eat();
        }

        public class Worker : IWorkable, IFeedable
        {
            public void Work()
            {
                // کار
            }
            public void Eat()
            {
                // غذا خوردن
            }
        }

        public class Robot : IWorkable
        {
            public void Work()
            {
                // کار
            }
        }
    }
}
