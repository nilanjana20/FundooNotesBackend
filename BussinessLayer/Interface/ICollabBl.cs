using CommonLayer.Model;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
    public interface ICollabBl
    {
        public CollabEntity AddCollab(CollabModel collabModel);
        public CollabEntity RemoveCollab(long userId, long collabId);

    }
}
