import { ReadonlyCollection } from "@/models/tree/ReadonlyCollection";

type SortFunc<T> = (a: T, b: T) => number;

export class OrderedCollection<T> implements ReadonlyCollection<T> {
  private readonly _values: T[] = [];

  private readonly _sortFunc: SortFunc<T>;

  constructor(sortFunc: SortFunc<T>) {
    this._sortFunc = sortFunc;
  }

  public [Symbol.iterator](): Iterator<T> {
    return this._values[Symbol.iterator]();
  }

  public get length(): number {
    return this._values.length;
  }

  public at(index: number): T {
    return this._values[index];
  }

  public add(item: T): void {
    this.insertAt(this.findIndexOf(item), item);
  }

  public remove(item: T): void {
    const index = this.findIndexOf(item);

    if (this._values[index] === item) {
      this.removeAt(index);
    } else {
      throw new Error("Element does not exist in collection.");
    }
  }

  private findIndexOf(item: T): number {
    return this.findIndexOfInRange(item, 0, this._values.length);
  }

  private findIndexOfInRange(item: T, start: number, end: number): number {
    const length = end - start;
    const middleIndex = start + Math.floor(length / 2);

    if (length === 0) {
      return middleIndex;
    }

    const middleItem = this._values[middleIndex];
    const comparison = this._sortFunc(item, middleItem);

    if (comparison > 0) {
      return this.findIndexOfInRange(item, middleIndex + 1, end);
    } else if (comparison < 0) {
      return this.findIndexOfInRange(item, start, middleIndex);
    } else {
      return middleIndex;
    }
  }

  private insertAt(index: number, item: T): void {
    this._values.splice(index, 0, item);
  }

  private removeAt(index: number): void {
    this._values.splice(index, 1);
  }
}