using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepoLayer.Entity
{
    public class NoteEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long NoteId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime reminder { get; set; }
        public string color { get; set; }
        public string image { get; set; }
        public bool isArchived { get; set; }
        public bool isDeleted { get; set; }
        public bool isPinned{ get; set; }
        public DateTime? createdAt { get; set; }  //nullable attribute
        public DateTime? editedAt { get; set; }

        [ForeignKey("user")]
        public long Id { get; set; }
        public UserEntity user { get; set; }
    }
}
