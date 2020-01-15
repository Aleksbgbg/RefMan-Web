namespace RefMan.Services.Referencing
{
    using System.Threading.Tasks;

    using RefMan.Models.Referencing;

    public interface IReferencingService
    {
        Task<ReferenceProducedResult> ProduceReferenceForUrl(string url);
    }
}