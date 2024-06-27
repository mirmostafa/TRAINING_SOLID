using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLD.SRP;
// کلاس ناقض SRP
public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public void Save()
    {
        // ذخیره در پایگاه داده
    }
    public bool Validate()
    {
        // اعتبارسنجی کاربر
    }
}

// اصلاح شده بر اساس SRP
public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class UserRepository
{
    public void Save(User user)
    {
        // ذخیره در پایگاه داده
    }
}

public class UserValidator
{
    public bool Validate(User user)
    {
        // اعتبارسنجی کاربر
    }
}
