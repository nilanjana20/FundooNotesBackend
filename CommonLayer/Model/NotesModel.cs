using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class NotesModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public DateTime reminder { get; set; }
        public string color { get; set; }
        public string image { get; set; }
        public bool isArchived { get; set; }
        public bool isDeleted { get; set; }
        public bool isPinned { get; set; }
        public DateTime? createdAt { get; set; }  //nullable attribute
        public DateTime? editedAt { get; set; }
    }
    }
 
