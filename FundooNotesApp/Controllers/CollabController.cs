using BussinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FundooNotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollabController : ControllerBase
    {
        private readonly ICollabBl collabBL;
        public CollabController(ICollabBl collabBL)
        {
            this.collabBL = collabBL;
        }

        [HttpPost("Add")]
        public IActionResult AddCollab(string email, long noteId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "id").Value);
                CollabModel collaboratorModel = new CollabModel();
                collaboratorModel.Id = userId;
                collaboratorModel.NotesId = noteId;
                collaboratorModel.CollabEmail = email;
                var result = this.collabBL.AddCollab(collaboratorModel);
                if (result != null)
                {
                    return this.Ok(new 
                    { 
                        Success = true, 
                        message = " Collab Added successfully ",
                        data = result 
                    });
                }
                else
                {
                    return this.BadRequest(new 
                    { 
                        Success = false, 
                        message = "Collab Add Failed! Try Again" 
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("Remove")]
        public IActionResult RemoveCollab(long collabId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "id").Value);
                var result = this.collabBL.RemoveCollab(userId, collabId);
                if (result != null)
                {
                    return this.Ok(new 
                    { 
                        Success = true, 
                        message = " Collab Removed  successfully ", 
                        data = result 
                    });
                }
                else
                {
                    return this.BadRequest(new 
                    { 
                        Success = false, 
                        message = "Collab Remove Failed!Try Again" 
                    });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new 
                { 
                    Success = false, 
                    message = ex.Message 
                });
            }
        }

    }
}
