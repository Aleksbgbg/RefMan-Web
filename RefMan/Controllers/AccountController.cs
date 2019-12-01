namespace RefMan.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using RefMan.Attributes.Filters;
    using RefMan.Extensions;
    using RefMan.Models;
    using RefMan.Models.Repositories;
    using RefMan.Models.User;
    using RefMan.Utilities;

    using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class AccountController : ControllerBaseWrapper
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;

        private readonly IFileSystemRepository _fileSystemRepository;

        public AccountController(UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager,
                                 IFileSystemRepository fileSystemRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _fileSystemRepository = fileSystemRepository;
        }

        [HttpGet]
        public CurrentUser CurrentUser()
        {
            bool isLoggedIn = User.IsLoggedIn();

            return new CurrentUser
            {
                IsLoggedIn = isLoggedIn,
                Username = isLoggedIn ? User.ReadUsername() : null
            };
        }

        [EnsureAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(Registration registration)
        {
            if (ModelState.IsValid)
            {
                AppUser newUser = new AppUser
                {
                    Id = IdGenerator.GenerateId(),
                    UserName = registration.Username
                };

                await _fileSystemRepository.GenerateRootFolderForUser(newUser);

                IdentityResult createResult = await _userManager.CreateAsync(newUser, registration.Password);

                if (createResult.Succeeded)
                {
                    await _signInManager.SignInAsync(newUser, isPersistent: true);
                    return NoContent();
                }

                ModelState.AddIdentityErrors(createResult);
            }

            return ValidationFailed();
        }

        [EnsureAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByNameAsync(login.Username);

                if (user == null)
                {
                    ModelState.AddModelError("Username", "Username is not registered.");
                }
                else
                {
                    SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, login.Password, isPersistent: true, lockoutOnFailure: false);

                    if (signInResult.Succeeded)
                    {
                        return NoContent();
                    }

                    ModelState.AddModelError("Password", "Incorrect password.");
                }
            }

            return ValidationFailed();
        }

        [EnsureAuthenticated]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return NoContent();
        }
    }
}