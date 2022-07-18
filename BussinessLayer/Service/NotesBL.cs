using BussinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Service
{
    public class NotesBL:INotesBl
    {
        public readonly INotesRl notesRL;
        public NotesBL(INotesRl notesRL)
        {
            this.notesRL = notesRL;
        }
        public NoteEntity CreateNote(NotesModel notesModel, long userId)
        {
            try
            {
                return this.notesRL.CreateNote(notesModel, userId);
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
                return this.notesRL.UpdateNote(notesModel, noteId, userId);
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
                return this.notesRL.DeleteNote(noteId, userId);

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
                return this.notesRL.GetNotesByUserId(userId);

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
