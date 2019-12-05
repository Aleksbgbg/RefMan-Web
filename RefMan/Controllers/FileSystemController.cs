namespace RefMan.Controllers
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

            return new RootFolderResult(_fileSystemRepository.FindRootForUser(user));
        }

        [HttpGet("folder/{id}")]
        public IActionResult GetFolder(long id)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost("folder")]
        public async Task<IActionResult> PostFolder([FromBody] EntryCreation entryCreation)
        {
            Folder parent = _fileSystemRepository.FindFolderOrDefault(entryCreation.ParentId);

            if (parent == null)
            {
                return NotFound($"Parent folder with ID '{entryCreation.ParentId}' does not exist.");
            }

            AppUser user = await FindCurrentUser();

            if (parent.OwnerId != user.Id)
            {
                return Forbid("Request initiator must own parent folder to create sub-entries.");
            }

            Folder createdFolder = await _fileSystemRepository.CreateFolder(parent.Id, user.Id, entryCreation.Name);

            var resourceParams = new { createdFolder.Id };
            string resourceUrl = Url.Action(nameof(GetFolder), resourceParams);

            return Created(resourceUrl, new NodeResult(createdFolder));
        }

        private Task<AppUser> FindCurrentUser()
        {
            return _userManager.FindByNameAsync(User.ReadUsername());
        }
    }
}