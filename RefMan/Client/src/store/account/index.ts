import { mutationTypes, actionTypes } from "./Types";
import { CurrentUser } from "@/models/accounts/CurrentUser";
import { Login } from "@/models/accounts/Login";
import { Registration } from "@/models/accounts/Registration";
import { accountClient } from "@/services/api-clients/AccountClient";

export default {
  state: {
    isLoggedIn: false,
    username: "Anonymous"
  },
  mutations: {
    [mutationTypes.CURRENT_USER](state: any, user: CurrentUser) {
      state.isLoggedIn = user.isLoggedIn;
      state.username = user.username;
    }
  },
  actions: {
    async [actionTypes.CHECK_LOGIN](context: any) {
      const currentUser: CurrentUser = await accountClient.currentUser();
      context.commit(mutationTypes.CURRENT_USER, {
        isLoggedIn: currentUser.isLoggedIn,
        username: currentUser.isLoggedIn ? currentUser.username : "Anonymous"
      });
    },
    async [actionTypes.REGISTER](context: any, registration: Registration) {
      await accountClient.register(registration);
      context.commit(mutationTypes.CURRENT_USER, {
        isLoggedIn: true,
        username: registration.username
      });
    },
    async [actionTypes.LOG_IN](context: any, login: Login) {
      await accountClient.login(login);
      context.commit(mutationTypes.CURRENT_USER, {
        isLoggedIn: true,
        username: login.username
      });
    }
  }
};