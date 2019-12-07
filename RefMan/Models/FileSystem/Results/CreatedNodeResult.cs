namespace RefMan.Models.FileSystem.Results
{
    public class CreatedNodeResult
    {
        public CreatedNodeResult(FileSystemEntryBase node)
        {
            Id = node.Id;
        }

        public long Id { get; }
    }
}