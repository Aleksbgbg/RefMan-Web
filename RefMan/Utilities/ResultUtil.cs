namespace RefMan.Utilities
{
    using System.Linq;

    using RefMan.Models.FileSystem;
    using RefMan.Models.FileSystem.Results;

    public static class ResultUtil
    {
        public static FolderResult[] FolderResultsFrom(Folder folder)
        {
            return folder.Folders.Select(folder => new FolderResult(folder)).ToArray();
        }

        public static FileResult[] FileResultsFrom(Folder folder)
        {
            return folder.Files.Select(file => new FileResult(file)).ToArray();
        }
    }
}