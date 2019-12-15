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

        public abstract Node FindNodeOrDefault(long id);

        public abstract Task<Node> CreateNode(long parentId, long ownerId, string name);

        public async Task UpdateNode(Node node)
        {
            _appDbContext.Entry(node).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteNode(Node node)
        {
            _appDbContext.Entry(node).State = EntityState.Deleted;
            await _appDbContext.SaveChangesAsync();
        }
    }
}