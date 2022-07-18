using BussinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Linq;

namespace FundooNotesApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        INotesBl notebl;
        public NotesController(INotesBl notebl)
        {
            this.notebl = notebl;
        }

        [HttpPost("Create")]
        public IActionResult CreateNote(NotesModel notesModel)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity == null)
                {
                    throw new UnauthorizedAccessException();
                }
                    IEnumerable<Claim> claim = identity.Claims;

                    // Gets name from claims. Generally it's an email address.
                    var email = claim
                        .Where(x => x.Type == ClaimTypes.Email)
                        .FirstOrDefault();
                    var userId = Convert.ToInt64(identity.FindFirst("id").Value);

                var result = this.notebl.CreateNote(notesModel, userId);
                if (result != null)
                {
                    return this.Ok(new
                    { 
                        success = true, 
                        message = "Note Created Successfull", 
                        data = result });
                }
                else
                {
                    return this.BadRequest(new
                    {
                        success = false, 
                        message = "Notes Creation UnSuccessfull"
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("Update")]
        public IActionResult UpdateNote(NotesModel notesModel, long noteId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "id").Value);
                var notes = this.notebl.UpdateNote(notesModel, noteId, userId);

                if (notes != null)
                {
                    return this.Ok(new 
                    { 
                      Success = true,
                      message = "Note Updated successfully",
                      data = notes
                    });
                }
                else
                {
                    return this.BadRequest(new
                    { 
                        Success = false, 
                        message = "Failed to update note" 
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteNote(long noteId)
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "id").Value);
                var notes = this.notebl.DeleteNote(noteId, userId);
                if (!notes)
                {
                    return this.BadRequest(new
                    {
                        Success = false, 
                        message = "Failed to Delete note"
                    });
                }
                else
                {
                    return this.Ok(new 
                    { 
                        Success = true, 
                        message = "Note deleted" 
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetNote")]
        public IActionResult GetNotesByUserId()
        {
            try
            {
                long userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "id").Value);

                var notes = this.notebl.GetNotesByUserId(userId);
                if (notes != null)
                {
                    return this.Ok(new 
                    {
                        Success = true, 
                        message = "All Notes are displayed", 
                        data = notes 
                    });
                }
                else
                {
                    return this.BadRequest(new 
                    {
                        Success = false,
                        message = "Failed to display the notes" 
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
