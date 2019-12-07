namespace RefMan.Models.FileSystem.Results
{
    using System.Linq;

    public class RootFolderResult : NodeResult
    {
        public RootFolderResult(Folder folder) : base(folder)
        {
            Folders = folder.Folders.Select(folder => new FolderResult(folder)).ToArray();
            Files = folder.Files.Select(file => new FileResult(file)).ToArray();
        }

        public FolderResult[] Folders { get; }

        public FileResult[] Files { get; }
    }
}