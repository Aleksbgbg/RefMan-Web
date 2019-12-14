import axios from "axios";

export abstract class ApiClientBase {
  private readonly _controllerName: string;

  protected constructor(controllerName: string) {
    this._controllerName = controllerName;
  }

  protected async get<T>(url: string): Promise<T> {
    return (await axios.get(this.formatUrl(url))).data;
  }

  protected async post<TData, TResponse>(url: string, data?: TData): Promise<TResponse> {
    return (await axios.post(this.formatUrl(url), data)).data;
  }

  protected async put<TData, TResponse>(url: string, data: TData): Promise<TResponse> {
    return (await axios.put(this.formatUrl(url), data)).data;
  }

  protected async delete(url: string): Promise<void> {
    await axios.delete(this.formatUrl(url));
  }

  private formatUrl(url: string): string {
    if (url === "") {
      return `/api/${this._controllerName}`;
    }

    return `/api/${this._controllerName}/${url}`;
  }
}