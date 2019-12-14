namespace RefMan.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using RefMan.Extensions;
    using RefMan.Models.FileSystem;
    using RefMan.Models.FileSystem.Results;
    using RefMan.Models.Repositories.FileSystem;
    using RefMan.Models.User;

    public class FileSystemControllerBase : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IFolderRepository _folderRepository;

        public FileSystemControllerBase(UserManager<AppUser> userManager, IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
            _userManager = userManager;
        }

        protected async Task<ActionResult<NodeResult>> GetNode(IFileSystemRepository repository, long id)
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

        protected async Task<ActionResult<NodeResult>> CreateNode(
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

        protected async Task<IActionResult> DeleteNode(IFileSystemRepository repository, long id)
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

        protected Task<AppUser> FindCurrentUser()
        {
            return _userManager.FindByNameAsync(User.ReadUsername());
        }

        protected NotFoundObjectResult NodeDoesNotExist(long id)
        {
            return NotFound($"File system entry with ID '{id}' does not exist.");
        }

        protected ForbidResult UserDoesNotOwn(Node fileSystemEntry)
        {
            return Forbid($"Authenticated user is not the owner of file system entry '{fileSystemEntry.Id}'.");
        }
    }
}