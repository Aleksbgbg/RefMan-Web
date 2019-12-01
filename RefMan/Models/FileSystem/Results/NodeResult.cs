namespace RefMan.Models.FileSystem.Results
{
    public class NodeResult
    {
        public NodeResult(FileSystemEntryBase node)
        {
            Id = node.Id;
            Name = node.Name;
        }

        public long Id { get; }

        public string Name { get; }
    }
}