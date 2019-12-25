namespace RefMan.Models.Repositories.FileSystem
{
    using System.Linq;
    using System.Threading.Tasks;

    using RefMan.Models.Database;
    using RefMan.Models.FileSystem;
    using RefMan.Models.Referencing;
    using RefMan.Utilities;

    public class FileRepository : FileSystemRepositoryBase, IFileRepository
    {
        private readonly AppDbContext _appDbContext;

        public FileRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public override Node FindNodeOrDefault(long id)
        {
            return _appDbContext.Files.SingleOrDefault(file => file.Id == id);
        }

        public override async Task<Node> CreateNode(long parentId, long ownerId, string name)
        {
            Document document = new Document
            {
                Id = IdGenerator.GenerateId()
            };

            File file = new File
            {
                Id = IdGenerator.GenerateId(),
                Name = name,
                ParentId = parentId,
                OwnerId = ownerId,
                DocumentId = document.Id
            };

            _appDbContext.Files.Add(file);
            _appDbContext.Documents.Add(document);

            await _appDbContext.SaveChangesAsync();

            return file;
        }
    }
}