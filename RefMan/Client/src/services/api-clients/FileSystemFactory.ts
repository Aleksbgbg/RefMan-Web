import { File } from "@/models/file-tree/File";
import { FileImpl } from "@/models/file-tree/FileImpl";
import { RootFolderResult } from "@/models/file-system/RootFolderResult";
import { NodeResult } from "@/models/file-system/NodeResult";
import { FolderResult } from "@/models/file-system/FolderResult";
import { Folder } from "@/models/file-tree/Folder";
import { FolderImpl } from "@/models/file-tree/FolderImpl";
import { ExpandFolderResult } from "@/models/file-system/ExpandFolderResult";
import { ExpandFolder } from "@/models/file-system/ExpandFolder";

class FileSystemFactory {
  public folderFromRootFolderResult(rootFolderResult: RootFolderResult): Folder {
    const folder = FolderImpl.fromIdNameExpandable(rootFolderResult.idString, rootFolderResult.name, true);
    folder.addFolders(rootFolderResult.folders.map(this.folderFromFolderResult));
    folder.addFiles(rootFolderResult.files.map(this.fileFromNodeResult));
    return folder;
  }

  public expandFolderFromExpandFolderResult(expandFolderResult: ExpandFolderResult): ExpandFolder {
    return {
      folders: expandFolderResult.folders.map(this.folderFromFolderResult),
      files: expandFolderResult.files.map(this.fileFromNodeResult)
    };
  }

  public folderFromFolderResult(folderResult: FolderResult): Folder {
    return FolderImpl.fromIdNameExpandable(folderResult.idString, folderResult.name, folderResult.isExpandable);
  }

  public folderFromNodeResult(nodeResult: NodeResult): Folder {
    return FolderImpl.fromIdNameExpandable(nodeResult.idString, nodeResult.name, false);
  }

  public fileFromNodeResult(nodeResult: NodeResult): File {
    return new FileImpl(nodeResult.idString, nodeResult.name);
  }
}

export const fileSystemFactory = new FileSystemFactory();