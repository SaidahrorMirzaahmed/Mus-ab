using Mus_ab.Models;
using Mus_ab.Models.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mus_ab.Interfaces;

public interface IUserService
{
    ValueTask<UserView> CreateAsync(UserCreation userCreation);
    ValueTask<UserView> UpdateAsync(int id,UserCreation userCreation);
    ValueTask<bool> DeleteAsync(int id);
    ValueTask<List<User>> GetAllUsersAsync();
    ValueTask<UserView> GetByIdAsync(int id);
}
