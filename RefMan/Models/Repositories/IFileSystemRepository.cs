namespace RefMan.Models.Repositories
{
    using System.Threading.Tasks;

    public interface IFileSystemRepository
    {
        Task GenerateRootFolderForUser(AppUser user);

        Folder FindRootForUser(AppUser user);
    }
}