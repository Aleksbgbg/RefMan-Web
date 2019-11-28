import { ApiClientBase } from "@/services/api-clients/ApiClientBase";
import { Registration } from "@/models/accounts/Registration";
import { Login } from "@/models/accounts/Login";

class AccountClient extends ApiClientBase {
  public register(registration: Registration): Promise<void> {
    return this.post("account/register", registration);
  }

  public login(login: Login): Promise<void> {
    return this.post("account/login", login);
  }

  public logout(): Promise<void> {
    return this.post("account/logout");
  }
}

export const accountClient = new AccountClient();