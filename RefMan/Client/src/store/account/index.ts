import { mutationTypes, actionTypes } from "./Types";
import { CurrentUser } from "@/models/accounts/CurrentUser";
import { Login } from "@/models/accounts/Login";
import { Registration } from "@/models/accounts/Registration";
import { accountClient } from "@/services/api-clients/AccountClient";

function loggedInState(username: string): CurrentUser {
  return {
    isLoggedIn: true,
    username
  };
}

function loggedOutState(): CurrentUser {
  return {
    isLoggedIn: false,
    username: "Anonymous"
  };
}

export default {
  state: {
    ...loggedOutState()
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

      let state;

      if (currentUser.isLoggedIn) {
        state = loggedInState(currentUser.username);
      } else {
        state = loggedOutState();
      }

      context.commit(mutationTypes.CURRENT_USER, state);
    },
    async [actionTypes.REGISTER](context: any, registration: Registration) {
      await accountClient.register(registration);
      context.commit(mutationTypes.CURRENT_USER, loggedInState(registration.username));
    },
    async [actionTypes.LOG_IN](context: any, login: Login) {
      await accountClient.login(login);
      context.commit(mutationTypes.CURRENT_USER, loggedInState(login.username));
    },
    async [actionTypes.LOG_OUT](context: any) {
      await accountClient.logout();
      context.commit(mutationTypes.CURRENT_USER, loggedOutState());
    }
  }
};