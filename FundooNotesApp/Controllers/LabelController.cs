using BussinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FundooNotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        private readonly ILabelBl labelBL;
        public LabelController(ILabelBl labelBL)
        {
            this.labelBL = labelBL;
          
        }
        [Authorize]
        [HttpPost("Add")]
        public IActionResult AddLabel(string labelName, long noteId)
        {
            try
            {

                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "id").Value);
                var label = this.labelBL.AddLabelName(labelName, noteId, userId);
                if (label != null)
                {
                    return this.Ok(new
                    { 
                        success = true, 
                        message = "Label Added Successfully", 
                        data = label 
                    });
                }
                else
                {
                    return this.BadRequest(new
                    { 
                        success = true, 
                        message = "Label adding UnSuccessfull"
                    });

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("Update")]
        public IActionResult RenameLabel(long noteId, string lableName, string newLabelName)
        {
            try
            {
                long userID = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "id").Value);
                var result = labelBL.UpdateLabel(userID, lableName, newLabelName, noteId);
                if (result != null)
                {
                    return this.Ok(new 
                    { 
                        success = true, 
                        message = "Label renamed successfully", 
                        Response = result 
                    });
                }
                else
                {
                    return this.BadRequest(new
                    { 
                        success = false, 
                        message = "User access denied" 
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("Remove")]
        public IActionResult RemoveLabel(long labelId)
        {
            try
            {
                // Take id of  Logged In User
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "id").Value);
                if (this.labelBL.RemoveLabel(labelId, userId))
                {
                    return this.Ok(new 
                    { 
                        Success = true, 
                        message = " Label Removed  successfully " 
                    });
                }
                else
                {
                    return this.BadRequest(new
                    { 
                        Success = false,
                        message = "Label Remove Failed " 
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetAll")]
        public IEnumerable<LabelEntity> GetAllLabels()
        {
            try
            {
                var result = this.labelBL.GetAllLabels();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
