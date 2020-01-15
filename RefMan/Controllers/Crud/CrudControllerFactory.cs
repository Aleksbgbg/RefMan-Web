namespace RefMan.Controllers.Crud
{
    public class CrudControllerFactory : ICrudControllerFactory
    {
        public ICrudController<T> CreateCrudController<T>(ICrudCompatible<T> crudCompatible)
        {
            return new CrudController<T>(crudCompatible);
        }
    }
}