using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interface
{
    public interface ILabelBl
    {
        public LabelEntity AddLabelName(string labelName, long noteId, long userId);

    }
}
