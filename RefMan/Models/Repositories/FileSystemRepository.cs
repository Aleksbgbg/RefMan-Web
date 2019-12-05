namespace RefMan.Models.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using RefMan.Models.Database;
    using RefMan.Models.FileSystem;
    using RefMan.Models.User;
    using RefMan.Utilities;

    public class FileSystemRepository : IFileSystemRepository
    {
        private readonly AppDbContext _appDbContext;

        public FileSystemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task GenerateRootFolderForUser(AppUser user)
        {
            long rootFolderId = IdGenerator.GenerateId();
            long ownerId = user.Id;

            _appDbContext.Folders.Add(new Folder
            {
                Id = rootFolderId,
                OwnerId = ownerId
            });
            _appDbContext.Folders.Add(new Folder
            {
                Id = IdGenerator.GenerateId(),
                Name = "Example Folder",
                ParentId = rootFolderId,
                OwnerId = ownerId
            });

            user.RootFolderId = rootFolderId;

            await _appDbContext.SaveChangesAsync();
        }

        public Folder FindRootForUser(AppUser user)
        {
            return _appDbContext.Folders
                                .Include(folder => folder.Folders)
                                .Include(folder => folder.Files)
                                .First(folder => folder.Id == user.RootFolderId);
        }
    }
}