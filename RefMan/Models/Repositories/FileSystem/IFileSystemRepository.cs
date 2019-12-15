namespace RefMan.Models.Repositories.FileSystem
{
    using System.Threading.Tasks;

    using RefMan.Models.FileSystem;

    public interface IFileSystemRepository
    {
        Node FindNodeOrDefault(long id);

        Task<Node> CreateNode(long parentId, long ownerId, string name);

        Task UpdateNode(Node node);

        Task DeleteNode(Node node);
    }
}