namespace RefMan.Controllers.Crud
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICrudCompatible<T>
    {
        bool ResourceExists();

        bool UserHasAccess();

        Task<CreationResult<T>> Create();

        IEnumerable<T> ReadAll();

        T ReadSingle();

        Task<T> Update();

        Task Delete();
    }
}