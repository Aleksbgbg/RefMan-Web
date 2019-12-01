namespace RefMan.Models.Database
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using RefMan.Models.FileSystem;
    using RefMan.Models.User;

    public class AppDbContext : IdentityDbContext<AppUser, AppRole, long>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Folder> Folders { get; protected set; }

        public virtual DbSet<File> Files { get; protected set; }
    }
}