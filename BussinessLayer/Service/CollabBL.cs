using BussinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Service
{
    public class CollabBL : ICollabBl
    {
        private readonly ICollabRl collabRL;
        public CollabBL(ICollabRl collabRL)
        {
            this.collabRL = collabRL;
        }

        public CollabEntity AddCollab(CollabModel collabModel)
        {
            try
            {
                return this.collabRL.AddCollab(collabModel);
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
                return this.collabRL.RemoveCollab(userId, collabId);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
