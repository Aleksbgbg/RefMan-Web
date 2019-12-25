declare global {
  interface Array<T> {
    remove(item: T): Array<T>;
  }
}

export function extendArray() {
  Array.prototype.remove = function<T>(this: T[], item: T): T[] {
    this.splice(this.indexOf(item), 1);
    return this;
  };
}