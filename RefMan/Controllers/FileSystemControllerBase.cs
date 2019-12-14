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
            NodeOrResponse nodeOrResponse = await EnsureNodeExistsAndOwnedByCurrentUser(repository, id);

            if (nodeOrResponse.HasNode)
            {
                return Ok(new NodeResult(nodeOrResponse.Node));
            }

            return nodeOrResponse.Response;
        }

        protected async Task<ActionResult<NodeResult>> CreateNode(
                IFileSystemRepository repository,
                EntryCreation entryCreation,
                string getHandlerName
        )
        {
            NodeOrResponse parentNodeOrResponse = await EnsureNodeExistsAndOwnedByCurrentUser(_folderRepository, entryCreation.ParentId);

            if (parentNodeOrResponse.HasNode)
            {
                Node parent = parentNodeOrResponse.Node;

                Node createdNode = await repository.CreateNode(parent.Id, parent.OwnerId, entryCreation.Name);

                var resourceParams = new { createdNode.Id };
                string resourceUrl = Url.Action(getHandlerName, resourceParams);

                return Created(resourceUrl, new NodeResult(createdNode));
            }

            return parentNodeOrResponse.Response;
        }

        protected async Task<IActionResult> DeleteNode(IFileSystemRepository repository, long id)
        {
            NodeOrResponse nodeOrResponse = await EnsureNodeExistsAndOwnedByCurrentUser(repository, id);

            if (nodeOrResponse.HasNode)
            {
                await repository.DeleteNode(nodeOrResponse.Node);
                return NoContent();
            }

            return nodeOrResponse.Response;
        }

        protected async Task<NodeOrResponse> EnsureNodeExistsAndOwnedByCurrentUser(IFileSystemRepository repository, long id)
        {
            Node node = repository.FindNodeOrDefault(id);

            if (node == null)
            {
                return new NodeOrResponse(NodeDoesNotExist(id));
            }

            AppUser currentUser = await FindCurrentUser();

            if (currentUser.Id != node.OwnerId)
            {
                return new NodeOrResponse(UserDoesNotOwn(node));
            }

            return new NodeOrResponse(node);
        }

        protected Task<AppUser> FindCurrentUser()
        {
            return _userManager.FindByNameAsync(User.ReadUsername());
        }

        private NotFoundObjectResult NodeDoesNotExist(long id)
        {
            return NotFound($"File system entry '{id}' does not exist.");
        }

        private ForbidResult UserDoesNotOwn(Node fileSystemEntry)
        {
            return Forbid($"Authenticated user is not the owner of file system entry '{fileSystemEntry.Id}'.");
        }
    }
}