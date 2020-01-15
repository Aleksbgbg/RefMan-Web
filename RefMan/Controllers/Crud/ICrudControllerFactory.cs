namespace RefMan.Controllers.Crud
{
    public interface ICrudControllerFactory
    {
        ICrudController<T> CreateCrudController<T>(ICrudCompatible<T> crudCompatible);
    }
}