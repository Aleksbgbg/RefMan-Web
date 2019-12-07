import { ApiClientBase } from "./ApiClientBase";
import { CurrentUser } from "@/models/accounts/CurrentUser";
import { Registration } from "@/models/accounts/Registration";
import { Login } from "@/models/accounts/Login";

class AccountClient extends ApiClientBase {
  constructor() {
    super("account");
  }

  public currentUser(): Promise<CurrentUser> {
    return this.get("current-user");
  }

  public register(registration: Registration): Promise<void> {
    return this.post("register", registration);
  }

  public login(login: Login): Promise<void> {
    return this.post("login", login);
  }

  public logout(): Promise<void> {
    return this.post("logout");
  }
}

export const accountClient = new AccountClient();