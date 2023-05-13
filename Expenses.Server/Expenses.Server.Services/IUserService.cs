using Expenses.Server.DTO;
using Expenses.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Server.Services
{
    public interface IUserService : IBaseService<User>
    {
        (bool, string, User?) Login(UserDTO userDTO);
        User Register(UserDTO userDTO);
    }
}
