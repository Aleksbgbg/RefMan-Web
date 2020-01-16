namespace RefMan.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using RefMan.Attributes.Filters;
    using RefMan.Models.FileSystem;
    using RefMan.Models.FileSystem.Results;
    using RefMan.Models.Referencing;
    using RefMan.Models.Repositories.FileSystem;
    using RefMan.Models.User;

    [EnsureAuthenticated]
    [ApiController]
    [Route("api/[Controller]")]
    public class FileController : FileSystemControllerBase
    {
        private readonly IFileRepository _fileRepository;

        public FileController(
                UserManager<AppUser> userManager,
                IFolderRepository folderRepository,
                IFileRepository fileRepository
        ) : base(userManager, folderRepository)
        {
            _fileRepository = fileRepository;
        }

        [HttpGet("{id}/document")]
        public async Task<ActionResult<DocumentResult>> GetFileDocument(long id)
        {
            NodeOrResponse nodeOrResponse = await EnsureNodeExistsAndOwnedByCurrentUser(_fileRepository, id);

            if (nodeOrResponse.HasNode)
            {
                return new DocumentResult(_fileRepository.GetDocumentForFileId(id));
            }

            return nodeOrResponse.Response;
        }

        [HttpGet("{id}")]
        public Task<ActionResult<NodeResult>> GetFile(long id)
        {
            return GetNode(_fileRepository, id);
        }

        [HttpPost]
        public Task<ActionResult<NodeResult>> PostFile([FromBody] EntryCreation entryCreation)
        {
            return CreateNode(_fileRepository, entryCreation, nameof(GetFile));
        }

        [HttpPut("{id}")]
        public Task<ActionResult<NodeResult>> PutFolder(long id, [FromBody] EntryEdit entryEdit)
        {
            return UpdateNode(_fileRepository, id, entryEdit);
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteFile(long id)
        {
            return DeleteNode(_fileRepository, id);
        }
    }
}