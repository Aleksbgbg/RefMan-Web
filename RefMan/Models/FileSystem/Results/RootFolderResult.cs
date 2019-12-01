namespace RefMan.Models.FileSystem.Results
{
    using System.Linq;

    public class RootFolderResult : NodeResult
    {
        public RootFolderResult(Folder folder) : base(folder)
        {
            Folders = folder.Folders.Select(ToNodeResult).ToArray();
            Files = folder.Files.Select(ToNodeResult).ToArray();
        }

        public NodeResult[] Folders { get; }

        public NodeResult[] Files { get; }

        private static NodeResult ToNodeResult(FileSystemEntryBase node)
        {
            return new NodeResult(node);
        }
    }
}