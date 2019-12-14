namespace RefMan.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using RefMan.Attributes.Filters;
    using RefMan.Extensions;
    using RefMan.Models.FileSystem;
    using RefMan.Models.FileSystem.Results;
    using RefMan.Models.Repositories;
    using RefMan.Models.User;

    [EnsureAuthenticated]
    [ApiController]
    [Route("api/[Controller]")]
    public class FileSystemController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IFileSystemRepository _fileSystemRepository;

        public FileSystemController(UserManager<AppUser> userManager,
                                    IFileSystemRepository fileSystemRepository)
        {
            _userManager = userManager;
            _fileSystemRepository = fileSystemRepository;
        }

        [HttpGet("[Action]")]
        public async Task<RootFolderResult> Root()
        {
            AppUser user = await FindCurrentUser();

            Folder root = _fileSystemRepository.FindRootForUser(user);
            IncludeSubTree(root);

            return new RootFolderResult(root);
        }

        [HttpGet("folder/{id}")]
        public ActionResult<NodeResult> GetFolder(long id)
        {
            return GetNode(_fileSystemRepository.FindFolderOrDefault, id);
        }

        [HttpGet("file/{id}")]
        public ActionResult<NodeResult> GetFile(long id)
        {
            return GetNode(_fileSystemRepository.FindFileOrDefault, id);
        }

        [HttpGet("folder-expansion/{id}")]
        public async Task<ActionResult<ExpandFolderResult>> GetFolderExpansion(long id)
        {
            Folder folder = _fileSystemRepository.FindFolderOrDefault(id);

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

        [HttpPost("folder")]
        public Task<ActionResult<NodeResult>> PostFolder([FromBody] EntryCreation entryCreation)
        {
            return CreateNode(entryCreation, _fileSystemRepository.CreateFolder, nameof(GetFolder));
        }

        [HttpPost("file")]
        public Task<ActionResult<NodeResult>> PostFile([FromBody] EntryCreation entryCreation)
        {
            return CreateNode(entryCreation, _fileSystemRepository.CreateFile, nameof(GetFile));
        }

        private ActionResult<NodeResult> GetNode<T>(Func<long, T> findNodeOrDefault, long id)
                where T : FileSystemEntryBase
        {
            T node = findNodeOrDefault(id);

            if (node == null)
            {
                return NodeDoesNotExist(id);
            }

            return Ok(new NodeResult(node));
        }

        private async Task<ActionResult<NodeResult>> CreateNode<T>(
                EntryCreation entryCreation,
                Func<long, long, string, Task<T>> createNode,
                string getHandlerName
        ) where T : FileSystemEntryBase
        {
            Folder parent = _fileSystemRepository.FindFolderOrDefault(entryCreation.ParentId);

            if (parent == null)
            {
                return NodeDoesNotExist(entryCreation.ParentId);
            }

            AppUser user = await FindCurrentUser();

            if (parent.OwnerId != user.Id)
            {
                return UserDoesNotOwn(parent);
            }

            T createdNode = await createNode(parent.Id, user.Id, entryCreation.Name);

            var resourceParams = new { createdNode.Id };
            string resourceUrl = Url.Action(getHandlerName, resourceParams);

            return Created(resourceUrl, new NodeResult(createdNode));
        }

        private Task<AppUser> FindCurrentUser()
        {
            return _userManager.FindByNameAsync(User.ReadUsername());
        }

        private NotFoundObjectResult NodeDoesNotExist(long id)
        {
            return NotFound($"File system entry with ID '{id}' does not exist.");
        }

        private ForbidResult UserDoesNotOwn(FileSystemEntryBase fileSystemEntry)
        {
            return Forbid($"Authenticated user is not the owner of file system entry '{fileSystemEntry.Id}'.");
        }

        private void IncludeSubTree(Folder root)
        {
            foreach (Folder folder in root.Folders)
            {
                Folder queriedFolder = _fileSystemRepository.FindFolderOrDefault(folder.Id);
                folder.Folders = queriedFolder.Folders;
                folder.Files = queriedFolder.Files;
            }
        }
    }
}