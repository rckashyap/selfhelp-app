using SelfHelp.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Business.Abstraction
{
    public interface IUserLoginService
    {
        public bool IsEmailAlreadyRegistered(string email);

        public int AddUser(UserEntity user);
    }
}
