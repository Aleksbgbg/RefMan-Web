namespace RefMan.Models.Repositories.FileSystem
{
    using System.Threading.Tasks;

    using RefMan.Models.User;

    public interface IRootFolderRepository
    {
        Task GenerateRootFolderForUser(AppUser user);
    }
}