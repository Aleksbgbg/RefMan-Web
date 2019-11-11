export interface FileSystemEntryIdentity {
    name: string;

    children?: FileSystemEntryIdentity[];
}