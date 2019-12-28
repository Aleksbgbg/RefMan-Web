import accountModule from "@/store/account";

const state = accountModule.state;

export function createMixin(allowedToAccess, computeRedirect) {
  return {
    beforeRouteEnter(to, from, next) {
      if (allowedToAccess(state.isLoggedIn)) {
        next();
      } else {
        next(computeRedirect(to, from, next));
      }
    }
  };
}