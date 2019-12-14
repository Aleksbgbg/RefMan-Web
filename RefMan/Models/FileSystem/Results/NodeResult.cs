namespace RefMan.Models.FileSystem.Results
{
    public class NodeResult
    {
        public NodeResult(Node node)
        {
            Id = node.Id;
            Name = node.Name;
        }

        public long Id { get; }

        public string IdString => Id.ToString();

        public string Name { get; }
    }
}