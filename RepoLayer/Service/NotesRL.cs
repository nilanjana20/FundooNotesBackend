using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepoLayer.Service
{
    public class NotesRL:INotesRl
    {
       private readonly FundooContext fundooContext;

        private readonly IConfiguration config;

        public NotesRL(FundooContext fundooContext, IConfiguration config)
        {
            this.fundooContext = fundooContext;
            this.config = config;
        }

        public NoteEntity CreateNote(NotesModel notesModel, long userId)
        {
            try
            {
                var user=fundooContext.UserEntity.Where(x => x.UserId == userId).FirstOrDefault();

                if (user==null)
                {
                    throw new UnauthorizedAccessException();
                }

                NoteEntity notesEntity = new NoteEntity()
                {
                    title = notesModel.title,
                    description = notesModel.description,
                    reminder = notesModel.reminder,
                    color = notesModel.color,
                    image = notesModel.image,
                    isArchived = notesModel.isArchived,
                    isDeleted = notesModel.isDeleted,
                    isPinned = notesModel.isPinned,
                    createdAt = notesModel.createdAt,
                    editedAt = notesModel.editedAt,
                    user = user,
                    Id = userId
                };

                this.fundooContext.NotesTable.Add(notesEntity);
                int result =  this.fundooContext.SaveChanges();

                if (result > 0)
                {
                    return notesEntity;
                }
                else
                {
                    throw new Exception("Notes not added");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public NoteEntity UpdateNote(NotesModel notesModel, long noteId, long userId)
        {
            try
            {
                // Fetch All the details with the given noteId.
                var note = this.fundooContext.NotesTable.Where(u => u.NoteId == noteId && u.Id == userId).FirstOrDefault();
                if (note != null)
                {
                    note.title = notesModel.title;
                    note.description = notesModel.description;

                    note.image = notesModel.image;
                    note.editedAt = notesModel.editedAt;

                    // Update database for given NoteId.
                    this.fundooContext.NotesTable.Update(note);

                    // Save Changes Made in the database
                    this.fundooContext.SaveChanges();
                    return note;
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

        public bool DeleteNote(long noteId, long userId)
        {
            try
            {
                var notes = this.fundooContext.NotesTable.Where(n => n.NoteId == noteId && n.Id == userId).FirstOrDefault();
                if (notes != null)
                {
                    // Remove Note details from database
                    this.fundooContext.NotesTable.Remove(notes);
                    this.fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<NoteEntity> GetNotesByUserId(long userId)
        {
            try
            {
                var notesResult = this.fundooContext.NotesTable.Where(n => n.Id == userId).ToList();
                if (notesResult != null)
                {
                    return notesResult;
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
