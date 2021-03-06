﻿namespace RefMan.Models.FileSystem
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using RefMan.Models.User;

    public class Node : EntryName
    {
        [Key]
        public long Id { get; set; }

        public bool IsRoot { get; set; }

        [ForeignKey(nameof(Parent))]
        public long? ParentId { get; set; }

        public Folder Parent { get; set; }

        [ForeignKey(nameof(Owner))]
        public long OwnerId { get; set; }

        public AppUser Owner { get; set; }
    }
}