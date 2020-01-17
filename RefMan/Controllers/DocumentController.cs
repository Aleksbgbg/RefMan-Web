namespace RefMan.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using RefMan.Attributes.Filters;
    using RefMan.Controllers.Crud;
    using RefMan.Extensions;
    using RefMan.Models.Referencing;
    using RefMan.Models.Repositories;
    using RefMan.Services.Referencing;

    [EnsureAuthenticated]
    [ApiController]
    [Route("api/[Controller]")]
    public class DocumentController : ControllerBaseWrapper, ICrudCompatible<Reference>
    {
        private readonly IDocumentRepository _documentRepository;

        private readonly IReferencingService _referencingService;

        private readonly ICrudController<Reference> _crudController;

        private long _documentId;

        private long? _referenceId;

        private ReferenceCreation _referenceCreation;

        private ReferenceEdit _referenceEdit;

        public DocumentController(IDocumentRepository documentRepository,
                                  IReferencingService referencingService,
                                  ICrudControllerFactory crudControllerFactory)
        {
            _documentRepository = documentRepository;
            _referencingService = referencingService;
            _crudController = crudControllerFactory.CreateCrudController(this);
        }

        [HttpGet("{documentId}/references")]
        public ActionResult<IEnumerable<Reference>> GetReferences(long documentId)
        {
            SetUpDocument(documentId);
            return _crudController.GetAll();
        }

        [HttpGet("{documentId}/reference/{referenceId}")]
        public ActionResult<Reference> GetReference(long documentId, long referenceId)
        {
            SetUpDocumentAndReference(documentId, referenceId);
            return _crudController.GetSingle();
        }

        [HttpPost("{documentId}/reference")]
        public async Task<ActionResult<Reference>> PostReference(long documentId, [FromBody] ReferenceCreation referenceCreation)
        {
            SetUpDocument(documentId);
            _referenceCreation = referenceCreation;
            return await _crudController.Post();
        }

        [HttpPut("{documentId}/reference/{referenceId}")]
        public async Task<ActionResult<Reference>> PutReference(long documentId, long referenceId, [FromBody] ReferenceEdit referenceEdit)
        {
            SetUpDocumentAndReference(documentId, referenceId);
            _referenceEdit = referenceEdit;
            return await _crudController.Put();
        }

        [HttpDelete("{documentId}/reference/{referenceId}")]
        public async Task<IActionResult> DeleteReference(long documentId, long referenceId)
        {
            SetUpDocumentAndReference(documentId, referenceId);
            return await _crudController.Delete();
        }

        bool ICrudCompatible<Reference>.ResourceExists()
        {
            if (CheckDocumentOnly())
            {
                return DocumentExists();
            }

            return DocumentExists() && ReferenceExists();
        }

        bool ICrudCompatible<Reference>.UserHasAccess()
        {
            return _documentRepository.UserOwnsDocument(_documentId, User.ReadId());
        }

        async Task<CreationResult<Reference>> ICrudCompatible<Reference>.Create()
        {
            ReferenceProducedResult referenceProducedResult =
                    await _referencingService.ProduceReferenceForUrl(_referenceCreation.Url);

            Reference reference = new Reference
            {
                AccessDate = referenceProducedResult.AccessDate,
                IconUrl = referenceProducedResult.IconUrl,
                DocumentId = _documentId,
                PublishYear = referenceProducedResult.PublishYear,
                Url = referenceProducedResult.Url,
                WebpageTitle = referenceProducedResult.WebpageTitle,
                WebsiteName = referenceProducedResult.WebsiteName
            };

            await _documentRepository.CreateReference(reference);

            return new CreationResult<Reference>(
                Url.Action(nameof(GetReference), values: new
                {
                    documentId = _documentId,
                    referenceId = reference.Id
                }),
                reference
            );
        }

        IEnumerable<Reference> ICrudCompatible<Reference>.ReadAll()
        {
            return _documentRepository.GetReferences(_documentId);
        }

        Reference ICrudCompatible<Reference>.ReadSingle()
        {
            return _documentRepository.GetReference(_documentId);
        }

        async Task<Reference> ICrudCompatible<Reference>.Update()
        {
            return await _documentRepository.UpdateReference(_referenceId.Value, _referenceEdit);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        async Task ICrudCompatible<Reference>.Delete()
        {
            await _documentRepository.DeleteReference(_referenceId.Value);
        }

        private void SetUpDocument(long documentId)
        {
            _documentId = documentId;
        }

        private void SetUpDocumentAndReference(long documentId, long referenceId)
        {
            _documentId = documentId;
            _referenceId = referenceId;
        }

        private bool CheckDocumentOnly()
        {
            return _referenceId == null;
        }

        private bool DocumentExists()
        {
            return _documentRepository.DocumentExists(_documentId);
        }

        private bool ReferenceExists()
        {
            return _referenceId != null && _documentRepository.ReferenceExistsInDocument(_referenceId.Value, _documentId);
        }
    }
}