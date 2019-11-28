import axios from "axios";

export abstract class ApiClientBase {
  protected async get<T>(url: string): Promise<T> {
    return (await axios.get<T>(this.formatUrl(url))).data;
  }

  protected async post<T>(url: string, data?: T): Promise<void> {
    await axios.post(this.formatUrl(url), data);
  }

  protected async put<TData, TResponse>(url: string, data: TData): Promise<TResponse> {
    return (await axios.put<TResponse>(this.formatUrl(url), data)).data;
  }

  protected async delete(url: string): Promise<void> {
    await axios.delete(this.formatUrl(url));
  }

  private formatUrl(url: string): string {
    return `/api/${url}`;
  }
}