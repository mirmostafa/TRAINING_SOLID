using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prerequisites
{
	namespace Invalid
	{
        // کد ناقض DRY
        public class UserManager
        {
            public void CreateUser(string username, string password)
            {
                // اعتبارسنجی کاربر
                if (username == null || password == null)
                {
                    throw new ArgumentException("Username and password cannot be null");
                }
                // ایجاد کاربر
            }

            public void UpdateUser(string username, string password)
            {
                // اعتبارسنجی کاربر
                if (username == null || password == null)
                {
                    throw new ArgumentException("Username and password cannot be null");
                }
                // به‌روزرسانی کاربر
            }
        }
    }

	namespace Valid
	{
        // کد اصلاح شده بر اساس DRY
        public class UserManager
        {
            private void ValidateUser(string username, string password)
            {
                if (username == null || password == null)
                {
                    throw new ArgumentException("Username and password cannot be null");
                }
            }

            public void CreateUser(string username, string password)
            {
                ValidateUser(username, password);
                // ایجاد کاربر
            }

            public void UpdateUser(string username, string password)
            {
                ValidateUser(username, password);
                // به‌روزرسانی کاربر
            }
        }
    }
}