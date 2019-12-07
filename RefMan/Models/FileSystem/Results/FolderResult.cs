namespace RefMan.Models.FileSystem.Results
{
    public class FolderResult : NodeResult
    {
        public FolderResult(Folder node) : base(node)
        {
            IsExpandable = node.Folders.Count > 0 || node.Files.Count > 0;
        }

        public bool IsExpandable { get; }
    }
}