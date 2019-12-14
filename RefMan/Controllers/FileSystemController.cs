namespace RefMan.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using RefMan.Attributes.Filters;
    using RefMan.Extensions;
    using RefMan.Models.FileSystem;
    using RefMan.Models.FileSystem.Results;
    using RefMan.Models.Repositories.FileSystem;
    using RefMan.Models.User;

    [EnsureAuthenticated]
    [ApiController]
    [Route("api/[Controller]")]
    public class FileSystemController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IFolderRepository _folderRepository;

        private readonly IFileRepository _fileRepository;

        public FileSystemController(
                UserManager<AppUser> userManager,
                IFolderRepository folderRepository,
                IFileRepository fileRepository
        )
        {
            _userManager = userManager;
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
        }

        [HttpGet("[Action]")]
        public async Task<RootFolderResult> Root()
        {
            AppUser user = await FindCurrentUser();

            Folder root = _folderRepository.FindRootForUser(user);
            IncludeSubTree(root);

            return new RootFolderResult(root);
        }

        [HttpGet("folder-expansion/{id}")]
        public async Task<ActionResult<ExpandFolderResult>> GetFolderExpansion(long id)
        {
            Folder folder = _folderRepository.FindFolderOrDefault(id);

            if (folder == null)
            {
                return NodeDoesNotExist(id);
            }

            AppUser user = await FindCurrentUser();

            if (folder.OwnerId != user.Id)
            {
                return UserDoesNotOwn(folder);
            }

            IncludeSubTree(folder);

            return Ok(new ExpandFolderResult(folder));
        }

        [HttpGet("folder/{id}")]
        public Task<ActionResult<NodeResult>> GetFolder(long id)
        {
            return GetNode(_folderRepository, id);
        }

        [HttpGet("file/{id}")]
        public Task<ActionResult<NodeResult>> GetFile(long id)
        {
            return GetNode(_fileRepository, id);
        }

        [HttpPost("folder")]
        public Task<ActionResult<NodeResult>> PostFolder([FromBody] EntryCreation entryCreation)
        {
            return CreateNode(_folderRepository, entryCreation, nameof(GetFolder));
        }

        [HttpPost("file")]
        public Task<ActionResult<NodeResult>> PostFile([FromBody] EntryCreation entryCreation)
        {
            return CreateNode(_fileRepository, entryCreation, nameof(GetFile));
        }

        [HttpDelete("folder/{id}")]
        public Task<IActionResult> DeleteFolder(long id)
        {
            return DeleteNode(_folderRepository, id);
        }

        [HttpDelete("file/{id}")]
        public Task<IActionResult> DeleteFile(long id)
        {
            return DeleteNode(_fileRepository, id);
        }

        private async Task<ActionResult<NodeResult>> GetNode(IFileSystemRepository repository, long id)
        {
            Node node = repository.FindNodeOrDefault(id);

            if (node == null)
            {
                return NodeDoesNotExist(id);
            }

            AppUser user = await FindCurrentUser();

            if (node.OwnerId != user.Id)
            {
                return UserDoesNotOwn(node);
            }

            return Ok(new NodeResult(node));
        }

        private async Task<ActionResult<NodeResult>> CreateNode(
                IFileSystemRepository repository,
                EntryCreation entryCreation,
                string getHandlerName
        )
        {
            Node parent = _folderRepository.FindNodeOrDefault(entryCreation.ParentId);

            if (parent == null)
            {
                return NodeDoesNotExist(entryCreation.ParentId);
            }

            AppUser user = await FindCurrentUser();

            if (parent.OwnerId != user.Id)
            {
                return UserDoesNotOwn(parent);
            }

            Node createdNode = await repository.CreateNode(parent.Id, user.Id, entryCreation.Name);

            var resourceParams = new { createdNode.Id };
            string resourceUrl = Url.Action(getHandlerName, resourceParams);

            return Created(resourceUrl, new NodeResult(createdNode));
        }

        private async Task<IActionResult> DeleteNode(IFileSystemRepository repository, long id)
        {
            Node node = repository.FindNodeOrDefault(id);

            if (node == null)
            {
                return NodeDoesNotExist(id);
            }

            AppUser user = await FindCurrentUser();

            if (node.OwnerId != user.Id)
            {
                return UserDoesNotOwn(node);
            }

            await repository.DeleteNode(node);

            return NoContent();
        }

        private Task<AppUser> FindCurrentUser()
        {
            return _userManager.FindByNameAsync(User.ReadUsername());
        }

        private NotFoundObjectResult NodeDoesNotExist(long id)
        {
            return NotFound($"File system entry with ID '{id}' does not exist.");
        }

        private ForbidResult UserDoesNotOwn(Node fileSystemEntry)
        {
            return Forbid($"Authenticated user is not the owner of file system entry '{fileSystemEntry.Id}'.");
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