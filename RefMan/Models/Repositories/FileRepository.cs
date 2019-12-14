﻿namespace RefMan.Models.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;

    using RefMan.Models.Database;
    using RefMan.Models.FileSystem;
    using RefMan.Utilities;

    public class FileRepository : FileSystemRepositoryBase, IFileRepository
    {
        private readonly AppDbContext _appDbContext;

        public FileRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public override FileSystemEntryBase FindNodeOrDefault(long id)
        {
            return _appDbContext.Files.SingleOrDefault(file => file.Id == id);
        }

        public override async Task<FileSystemEntryBase> CreateNode(long parentId, long ownerId, string name)
        {
            File file = new File
            {
                Id = IdGenerator.GenerateId(),
                Name = name,
                ParentId = parentId,
                OwnerId = ownerId
            };

            _appDbContext.Files.Add(file);
            await _appDbContext.SaveChangesAsync();

            return file;
        }
    }
}