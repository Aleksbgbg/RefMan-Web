namespace RefMan.Models.Repositories.FileSystem
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using RefMan.Models.Database;
    using RefMan.Models.FileSystem;
    using RefMan.Models.User;
    using RefMan.Utilities;

    public class FolderRepository : FileSystemRepositoryBase, IFolderRepository, IRootFolderRepository
    {
        private readonly AppDbContext _appDbContext;

        public FolderRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        private IQueryable<Folder> FoldersExpanded =>
                _appDbContext.Folders
                             .Include(folder => folder.Folders)
                             .Include(folder => folder.Files);


        public async Task GenerateRootFolderForUser(AppUser user)
        {
            long rootFolderId = IdGenerator.GenerateId();
            long ownerId = user.Id;

            _appDbContext.Folders.Add(new Folder
            {
                Id = rootFolderId,
                Name = string.Empty,
                IsRoot = true,
                OwnerId = ownerId
            });
            _appDbContext.Folders.Add(new Folder
            {
                Id = IdGenerator.GenerateId(),
                Name = "Example Folder",
                ParentId = rootFolderId,
                OwnerId = ownerId
            });

            await _appDbContext.SaveChangesAsync();
        }

        public Folder FindRootForUser(AppUser user)
        {
            return FoldersExpanded.Single(folder => folder.OwnerId == user.Id && folder.IsRoot);
        }

        public Folder FindFolderOrDefault(long id)
        {
            return FoldersExpanded.SingleOrDefault(folder => folder.Id == id);
        }

        public override Node FindNodeOrDefault(long id)
        {
            return FindFolderOrDefault(id);
        }

        public override async Task<Node> CreateNode(long parentId, long ownerId, string name)
        {
            Folder folder = new Folder
            {
                Id = IdGenerator.GenerateId(),
                Name = name,
                ParentId = parentId,
                OwnerId = ownerId
            };

            _appDbContext.Folders.Add(folder);
            await _appDbContext.SaveChangesAsync();

            return folder;
        }
    }
}