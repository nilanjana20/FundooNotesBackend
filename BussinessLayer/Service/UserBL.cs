using BussinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Service
{
    public class UserBL:IUserBl
    {
        IUserRl userRl;

        public UserBL(IUserRl userRl)
        {
            this.userRl = userRl;
        }

        public UserEntity Registration(UserRegistration user)
        {
            try
            {
                return userRl.Registration(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Login(UserLogin userlogin)
        {
            try
            {
                return userRl.Login(userlogin);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string ForgotPassword(string email)
        {
            try
            {
              return userRl.ForgotPassword(email);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ResetPassword(string email, string password, string confirmpassword)
        {

            try
            {
                return this.userRl.ResetPassword(password, confirmpassword, email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
