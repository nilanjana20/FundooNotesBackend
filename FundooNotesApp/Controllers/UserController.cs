using BussinessLayer.Interface;
using BussinessLayer.Service;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Security.Claims;

namespace FundooNotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBl user;

        public UserController(IUserBl user)
        {
           this.user = user;
        }

        [HttpPost("Registration")]
        public IActionResult Registration(UserRegistration user1)
        {
            try
            {
                var result = user.Registration(user1);
                if (result != null)
                {
                    return this.Ok(new
                    {
                        success = true,
                        message = "Registration is Successfull",
                        response = result
                    });
                }
                else
                {
                    return this.BadRequest(new
                    {
                        success = false,
                        message = "Registration unsucessfull",
                        
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(UserLogin user1)
        {
            try
            {
                var result = user.Login(user1);
                if (result != null)
                {
                    return this.Ok(new
                    {
                        success = true,
                        message = "Login is Successfull",
                        response = result
                    });
                }
                else
                {
                    return this.BadRequest(new
                    {
                        success = false,
                        message = "Login unsucessfull",

                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("Forgot")]
        public IActionResult Forgot(string email)
        {
            try
            {
                var token = user.ForgotPassword(email);

                if (token == null)
                {
                    return this.Unauthorized(new
                    {
                        success = false,
                        message = "Mail not sent",
                        
                    });
                }
                else
                {
                    return this.Ok(new
                    {
                        success = true,
                        message = "Reset mail sucessfull"

                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpPost("Reset")]
        public IActionResult ResetPassword(string password, string confirmpassword)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value;
                var result = user.ResetPassword(email, password, confirmpassword);

                if (result != null)
                {
                    return this.Ok(new
                    {
                        success = true,
                        message = "Reset password sucessful",
                        Response = result
                    });
                }
                else
                {
                    return this.BadRequest(new
                    {
                        success = false,
                        message = "Unable to reset password",

                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
