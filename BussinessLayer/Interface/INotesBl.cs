using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
    public interface INotesBl
    {
        public NoteEntity CreateNote(NotesModel notesModel, long userId);
        public NoteEntity UpdateNote(NotesModel notesModel, long noteId, long userId);
        public bool DeleteNote(long noteId, long userId);
        public List<NoteEntity> GetNotesByUserId(long userId);

    }
}
