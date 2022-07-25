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

        public IEnumerable<LabelEntity> UpdateLabel(long userID, string oldLabelName, string labelName, long noteId)
        {
            try
            {
                return this.labelRL.UpdateLabel(userID, oldLabelName, labelName, noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RemoveLabel(long labelId, long userId)
        {
            try
            {
                return this.labelRL.RemoveLabel(labelId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<LabelEntity> GetAllLabels()
        {
            try
            {
                return this.labelRL.GetAllLabels();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
