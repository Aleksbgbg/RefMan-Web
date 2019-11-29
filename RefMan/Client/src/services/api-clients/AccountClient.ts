import { ApiClientBase } from "@/services/api-clients/ApiClientBase";
import { CurrentUser } from "@/models/accounts/CurrentUser";
import { Registration } from "@/models/accounts/Registration";
import { Login } from "@/models/accounts/Login";

class AccountClient extends ApiClientBase {
  public currentUser(): Promise<CurrentUser> {
    return this.get("account/current-user");
  }

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