using BussinessLayer.Interface;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Service
{
    public class LabelBL:ILabelBl
    {
        public readonly ILabelRl labelRL;
        public LabelBL(ILabelRl labelRL)
        {
            this.labelRL = labelRL;
        }
        public LabelEntity AddLabelName(string labelName, long noteId, long userId)
        {
            try
            {
                return this.labelRL.AddLabelName(labelName, noteId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
