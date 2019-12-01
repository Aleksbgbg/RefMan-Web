namespace RefMan.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using RefMan.Attributes.Filters;
    using RefMan.Extensions;
    using RefMan.Models;
    using RefMan.Models.Repositories;

    [EnsureAuthenticated]
    [ApiController]
    [Route("api/[Controller]/[Action]")]
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

        [HttpGet]
        public async Task<Folder> Root()
        {
            AppUser user = await _userManager.FindByNameAsync(User.ReadUsername());

            return _fileSystemRepository.FindRootForUser(user);
        }
    }
}