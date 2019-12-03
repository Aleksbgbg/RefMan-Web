import { mapState } from "vuex";

export function createMixin(allowedToAccess, computeRedirect) {
  return {
    computed: mapState({
      isLoggedIn: (state) => state.account.isLoggedIn
    }),
    beforeRouteEnter(to, from, next) {
      next((instance) => {
        if (allowedToAccess(instance.isLoggedIn)) {
          next();
        } else {
          next(computeRedirect(to, from, next));
        }
      });
    }
  };
}