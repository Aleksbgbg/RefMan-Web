namespace RefMan.Models.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;

    using RefMan.Models.Database;
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

            _appDbContext.Folders.Add(new Folder
            {
                Id = rootFolderId
            });

            user.RootFolderId = rootFolderId;

            await _appDbContext.SaveChangesAsync();
        }

        public Folder FindRootForUser(AppUser user)
        {
            return _appDbContext.Folders.First(folder => folder.Id == user.RootFolderId);
        }
    }
}