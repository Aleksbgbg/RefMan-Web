namespace RefMan.Models.FileSystem.Results
{
    public abstract class NodeResult
    {
        protected NodeResult(FileSystemEntryBase node)
        {
            Id = node.Id;
            Name = node.Name;
        }

        public long Id { get; }

        public string IdString => Id.ToString();

        public string Name { get; }
    }
}