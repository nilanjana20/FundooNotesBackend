using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IUserRl
    {
        public UserEntity Registration(UserRegistration user);
        public string Login(UserLogin userlogin);
        public string ForgotPassword(string email);
        public bool ResetPassword(string email, string password, string confirmpassword);

    }
}
