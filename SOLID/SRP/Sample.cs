namespace SOLID.SRP
{
    namespace Invalid
    {
        // کلاس ناقض SRP
        public class User
        {
            public string Password { get; set; }
            public string Username { get; set; }

            public void Save()
            {
                
            }

            public bool Validate()
            {
                return default;
            }
        }
    }

    namespace Valid
    {
        // اصلاح شده بر اساس SRP
        public class User
        {
            public required string Password { get; set; }
            public required string Username { get; set; }
        }

        public class UserRepository
        {
            public void Save(User user)
            {
                
            }
        }

        public class UserValidator
        {
            public bool Validate(User user)
            {
                return default;
            }
        }
    }
}