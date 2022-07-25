using CommonLayer.Model;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepoLayer.Service
{
    public class CollabRL : ICollabRl
    {
        private readonly FundooContext fundooContext;
        public CollabRL(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }
        public CollabEntity AddCollab(CollabModel collabModel)
        {
            try
            {
                CollabEntity collab = new CollabEntity();
                var user = this.fundooContext.UserEntity.Where(e => e.Email == collabModel.CollabEmail).FirstOrDefault();
                var notes = this.fundooContext.NotesTable.Where(e => e.NoteId == collabModel.NotesId && e.Id == collabModel.Id).FirstOrDefault();
                if (notes != null && user != null)
                {
                    collab.NotesId = collabModel.NotesId;
                    collab.CollabEmail = collabModel.CollabEmail;
                    collab.Id = collabModel.Id;
                    this.fundooContext.Collab.Add(collab);
                    var result = this.fundooContext.SaveChanges();
                    return collab;
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

        public CollabEntity RemoveCollab(long userId, long collabId)
        {
            try
            {
                var data = this.fundooContext.Collab.FirstOrDefault(d => d.Id == userId && d.CollabId == collabId);
                if (data != null)
                {
                    this.fundooContext.Collab.Remove(data);
                    this.fundooContext.SaveChanges();
                    return data;
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
