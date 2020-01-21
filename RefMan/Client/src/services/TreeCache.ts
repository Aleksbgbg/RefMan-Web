class TreeCache {
  public toggle(id: string): void {
    if (this.isToggled(id)) {
      localStorage.removeItem(id);
    } else {
      localStorage.setItem(id, "");
    }
  }

  public isToggled(id: string): boolean {
    return localStorage.getItem(id) !== null;
  }
}

export const treeCache = new TreeCache();