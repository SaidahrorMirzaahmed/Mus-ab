using Mus_ab.Helpers;
using Mus_ab.Helpers.Users;
using Mus_ab.Interfaces;
using Mus_ab.Models.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mus_ab.Services;

public class UserService : IUserService
{
    private List<User> users = new List<User>();
    UserReader reader=new UserReader();
    UserWriter writer=new UserWriter();

    public async ValueTask<UserView> CreateAsync(UserCreation userCreation)
    {
        users = reader.Main();
        var user = Mapper.MapTo<User>(userCreation);
        user.Id = users.Count == 0 ? 1 : users.Last().Id + 1;
        users.Add(user);
        writer.Main(users);
        return Mapper.MapTo<UserView>(user);
    }

    public async ValueTask<bool> DeleteAsync(int id)
    {
        users = reader.Main();
        var exist=users.FirstOrDefault(x => x.Id == id);
        if (exist is null)
        {
            throw new Exception("User is not found");
        }
        users.Add(exist);
        writer.Main(users);
        return true;
    }

    public async ValueTask<List<User>> GetAllUsersAsync()
    {
        users = reader.Main();
        return users;
    }

    public async ValueTask<UserView> GetByIdAsync(int id)
    {
        users = reader.Main();
        var exist = users.FirstOrDefault(x => x.Id == id);
        if (exist is null)
        {
            throw new Exception("User is not found");
        }
        return Mapper.MapTo<UserView>(exist);
    }

    public async ValueTask<UserView> UpdateAsync(int id, UserCreation userCreation)
    {
        users = reader.Main();
        var exist = users.FirstOrDefault(x => x.Id == id);
        if (exist is null)
        {
            throw new Exception("User is not found");
        }
        exist.FirstName = userCreation.FirstName;
        exist.LastName = userCreation.LastName;
        exist.Phone = userCreation.Phone;
        exist.Email = userCreation.Email;
        exist.Password = userCreation.Password;
        exist.Id = id;
        return Mapper.MapTo<UserView>(exist);
    }
}
