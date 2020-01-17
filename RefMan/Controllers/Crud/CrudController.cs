namespace RefMan.Controllers.Crud
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    public class CrudController<T> : ControllerBase, ICrudController<T>
    {
        private readonly ICrudCompatible<T> _crudCompatible;

        public CrudController(ICrudCompatible<T> crudCompatible)
        {
            _crudCompatible = crudCompatible;
        }

        public ActionResult<IEnumerable<T>> GetAll()
        {
            if (!_crudCompatible.ResourceExists())
            {
                return NotFound();
            }

            if (!_crudCompatible.UserHasAccess())
            {
                return Forbid();
            }

            return Ok(_crudCompatible.ReadAll());
        }

        public ActionResult<T> GetSingle()
        {
            if (!_crudCompatible.ResourceExists())
            {
                return NotFound();
            }

            if (!_crudCompatible.UserHasAccess())
            {
                return Forbid();
            }

            return Ok(_crudCompatible.ReadSingle());
        }

        public async Task<ActionResult<T>> Post()
        {
            if (!_crudCompatible.ResourceExists())
            {
                return NotFound();
            }

            if (!_crudCompatible.UserHasAccess())
            {
                return Forbid();
            }

            CreationResult<T> creationResult = await _crudCompatible.Create();
            return Created(creationResult.Url, creationResult.Value);
        }

        public async Task<ActionResult<T>> Put()
        {
            if (!_crudCompatible.ResourceExists())
            {
                return NotFound();
            }

            if (!_crudCompatible.UserHasAccess())
            {
                return Forbid();
            }

            return Ok(await _crudCompatible.Update());
        }

        public async Task<IActionResult> Delete()
        {
            if (!_crudCompatible.ResourceExists())
            {
                return NotFound();
            }

            if (!_crudCompatible.UserHasAccess())
            {
                return Forbid();
            }

            await _crudCompatible.Delete();
            return NoContent();
        }
    }
}