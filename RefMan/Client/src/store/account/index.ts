import { mutationTypes, actionTypes } from "./Types";
import { User } from "@/models/accounts/User";
import { Login } from "@/models/accounts/Login";
import { Registration } from "@/models/accounts/Registration";
import { accountClient } from "@/services/api-clients/AccountClient";

export default {
  state: {
    username: "Anonymous"
  },
  mutations: {
    [mutationTypes.CURRENT_USER](state: any, user: User) {
      state.username = user.username;
    }
  },
  actions: {
    async [actionTypes.REGISTER](context: any, registration: Registration) {
      await accountClient.register(registration);
      context.commit(mutationTypes.CURRENT_USER, {
        username: registration.username
      });
    },
    async [actionTypes.LOG_IN](context: any, login: Login) {
      await accountClient.login(login);
      context.commit(mutationTypes.CURRENT_USER, {
        username: login.username
      });
    }
  }
};