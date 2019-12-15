namespace RefMan.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using RefMan.Attributes.Filters;
    using RefMan.Models.FileSystem;
    using RefMan.Models.FileSystem.Results;
    using RefMan.Models.Repositories.FileSystem;
    using RefMan.Models.User;

    [EnsureAuthenticated]
    [ApiController]
    [Route("api/[Controller]")]
    public class FolderController : FileSystemControllerBase
    {
        private readonly IFolderRepository _folderRepository;

        public FolderController(
                UserManager<AppUser> userManager,
                IFolderRepository folderRepository
        ) : base(userManager, folderRepository)
        {
            _folderRepository = folderRepository;
        }

        [HttpGet("[Action]")]
        public async Task<RootFolderResult> Root()
        {
            AppUser user = await FindCurrentUser();

            Folder root = _folderRepository.FindRootForUser(user);
            IncludeSubTree(root);

            return new RootFolderResult(root);
        }

        [HttpGet("expansion/{id}")]
        public async Task<ActionResult<ExpandFolderResult>> GetFolderExpansion(long id)
        {
            NodeOrResponse nodeOrResponse = await EnsureNodeExistsAndOwnedByCurrentUser(_folderRepository, id);

            if (nodeOrResponse.HasNode)
            {
                Folder folder = _folderRepository.FindFolderOrDefault(id);
                IncludeSubTree(folder);

                return Ok(new ExpandFolderResult(folder));
            }

            return nodeOrResponse.Response;
        }

        [HttpGet("{id}")]
        public Task<ActionResult<NodeResult>> GetFolder(long id)
        {
            return GetNode(_folderRepository, id);
        }

        [HttpPost]
        public Task<ActionResult<NodeResult>> PostFolder([FromBody] EntryCreation entryCreation)
        {
            return CreateNode(_folderRepository, entryCreation, nameof(GetFolder));
        }

        [HttpPut("{id}")]
        public Task<ActionResult<NodeResult>> PutFolder(long id, [FromBody] EntryEdit entryEdit)
        {
            return UpdateNode(_folderRepository, id, entryEdit);
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteFolder(long id)
        {
            return DeleteNode(_folderRepository, id);
        }

        private void IncludeSubTree(Folder root)
        {
            foreach (Folder folder in root.Folders)
            {
                Folder queriedFolder = _folderRepository.FindFolderOrDefault(folder.Id);
                folder.Folders = queriedFolder.Folders;
                folder.Files = queriedFolder.Files;
            }
        }
    }
}