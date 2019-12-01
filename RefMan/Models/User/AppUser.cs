namespace RefMan.Models.User
{
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNetCore.Identity;

    using RefMan.Models.FileSystem;

    public class AppUser : IdentityUser<long>
    {
        [ForeignKey(nameof(RootFolder))]
        public long RootFolderId { get; set; }

        public Folder RootFolder { get; set; }
    }
}