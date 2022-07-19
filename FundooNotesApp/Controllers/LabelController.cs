using BussinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
    }
}
