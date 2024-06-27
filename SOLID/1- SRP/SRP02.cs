using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SRP
{
	namespace Invalid
	{
        // مثال کد بدون رعایت SRP
        public class UserManager
        {
            public void CreateUser(string username, string password)
            {
                // ذخیره اطلاعات کاربر در پایگاه داده
                // ارسال ایمیل خوش‌آمدگویی
            }
        }
    }

    namespace Valid
    {
        // مثال کد با رعایت SRP
        public class UserRepository
        {
            public void SaveUser(User user)
            {
                // ذخیره اطلاعات کاربر در پایگاه داده
            }
        }

        public class EmailService
        {
            public void SendWelcomeEmail(User user)
            {
                // ارسال ایمیل خوش‌آمدگویی
            }
        }

        public class UserManager
        {
            private UserRepository userRepository = new UserRepository();
            private EmailService emailService = new EmailService();

            public void CreateUser(string username, string password)
            {
                User user = new User(username, password);
                userRepository.SaveUser(user);
                emailService.SendWelcomeEmail(user);
            }
        }
    }

    public class User(string userName, string password);

}
