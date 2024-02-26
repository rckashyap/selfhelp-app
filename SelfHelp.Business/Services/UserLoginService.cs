using SelfHelp.Business.Abstraction;
using SelfHelp.Business.Entities;
using SelfHelp.PostgreSql;
using SelfHelp.PostgreSql.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHelp.Business.Services
{
    public sealed class UserLoginService : IUserLoginService
    {
        private readonly AppDbContext context;

        public UserLoginService(AppDbContext context)
        {
            this.context = context;
        }

        public bool IsEmailAlreadyRegistered(string email)
        {
            return this.context.Users.Any(x => x.Email.Equals(email));
        }

        public int AddUser(UserEntity user)
        {
            var userToAdd = new User
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                IsActive = true,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
            };

            this.context.Add(userToAdd);
            this.context.SaveChanges();

            return this.context.Users.Single(a => a.Email.Equals(user.Email)).Id;
        }
    }
}
