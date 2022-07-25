using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface ILabelRl
    {
        public LabelEntity AddLabelName(string labelName, long noteId, long userId);
        public IEnumerable<LabelEntity> UpdateLabel(long userID, string oldLabelName, string labelName, long noteId);
        public bool RemoveLabel(long labelId, long userId);
        public IEnumerable<LabelEntity> GetAllLabels();

    }
}
