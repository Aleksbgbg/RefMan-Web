﻿namespace RefMan.Controllers
{
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
        public async Task<ActionResult<NodeResult>> PostFolder([FromBody] EntryCreation entryCreation)
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

            Folder createdFolder = await _fileSystemRepository.CreateFolder(parent.Id, user.Id, entryCreation.Name);

            var resourceParams = new { createdFolder.Id };
            string resourceUrl = Url.Action(nameof(GetFolderExpansion), resourceParams);

            return Created(resourceUrl, new NodeResult(createdFolder));
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