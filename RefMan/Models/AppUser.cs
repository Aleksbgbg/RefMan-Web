namespace RefMan.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNetCore.Identity;

    public class AppUser : IdentityUser<long>
    {
        [ForeignKey(nameof(RootFolder))]
        public long RootFolderId { get; set; }

        public Folder RootFolder { get; set; }
    }
}