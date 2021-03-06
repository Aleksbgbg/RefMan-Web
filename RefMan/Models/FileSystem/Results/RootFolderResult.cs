﻿namespace RefMan.Models.FileSystem.Results
{
    using RefMan.Utilities;

    public class RootFolderResult : NodeResult
    {
        public RootFolderResult(Folder folder) : base(folder)
        {
            Folders = ResultUtil.FolderResultsFrom(folder);
            Files = ResultUtil.FileResultsFrom(folder);
        }

        public FolderResult[] Folders { get; }

        public FileResult[] Files { get; }
    }
}