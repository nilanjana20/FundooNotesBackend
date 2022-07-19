using CommonLayer.Model;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Service
{
    public class LabelRL : ILabelRl
    {
        private readonly FundooContext fundooContext;
        public LabelRL(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }

        public LabelEntity AddLabelName(string labelName, long noteId, long userId)
        {
            try
            {
                LabelEntity labelEntity = new LabelEntity
                {
                    LabelName = labelName,
                    Id = userId,
                    NoteId = noteId
                };
                this.fundooContext.Label.Add(labelEntity);
                int result = this.fundooContext.SaveChanges();
                if (result > 0)
                {
                    return labelEntity;  
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
