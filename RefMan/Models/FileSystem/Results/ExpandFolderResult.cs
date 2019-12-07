namespace RefMan.Models.FileSystem.Results
{
    using RefMan.Utilities;

    public class ExpandFolderResult
    {
        public ExpandFolderResult(Folder folder)
        {
            Folders = ResultUtil.FolderResultsFrom(folder);
            Files = ResultUtil.FileResultsFrom(folder);
        }

        public FolderResult[] Folders { get; }

        public FileResult[] Files { get; }
    }
}