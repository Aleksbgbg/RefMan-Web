namespace RefMan.Controllers.Crud
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    public interface ICrudController<T>
    {
        ActionResult<IEnumerable<T>> GetAll();

        ActionResult<T> GetSingle();

        Task<ActionResult<T>> Post();

        Task<ActionResult<T>> Put();

        Task<IActionResult> Delete();
    }
}