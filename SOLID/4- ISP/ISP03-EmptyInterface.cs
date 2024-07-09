namespace SOLID.ISP03;

internal interface IAdmin;

internal interface IUser;

class Admin : IAdmin
{

}

class SuperAdmin : IAdmin
{

}

class User
{

}

class Stakeholder
{

}

class Test
{
    void SetAdminPermission(IAdmin admin)
    {

    }

    void Test01()
    {
        var user1 = new Admin();
        var user2 = new User();
        SetAdminPermission(user1);
        // Wrong
        //SetAdminPermission(user2);
    }
}