using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
    public interface ILabelBl
    {
        public LabelEntity AddLabelName(string labelName, long noteId, long userId);
        public IEnumerable<LabelEntity> UpdateLabel(long userID, string oldLabelName, string labelName, long noteId);
        public bool RemoveLabel(long labelId, long userId);
        public IEnumerable<LabelEntity> GetAllLabels();

    }
}
