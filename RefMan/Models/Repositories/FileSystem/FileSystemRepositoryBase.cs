namespace RefMan.Models.Repositories.FileSystem
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using RefMan.Models.Database;
    using RefMan.Models.FileSystem;

    public abstract class FileSystemRepositoryBase : IFileSystemRepository
    {
        private readonly AppDbContext _appDbContext;

        public FileSystemRepositoryBase(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public abstract FileSystemEntryBase FindNodeOrDefault(long id);

        public abstract Task<FileSystemEntryBase> CreateNode(long parentId, long ownerId, string name);

        public async Task DeleteNode(FileSystemEntryBase fileSystemEntryBase)
        {
            _appDbContext.Entry(fileSystemEntryBase).State = EntityState.Deleted;
            await _appDbContext.SaveChangesAsync();
        }
    }
}