import { mapState } from "vuex";

export default {
  computed: mapState({
    isLoggedIn: state => state.account.isLoggedIn
  }),
  beforeRouteEnter(to, from, next) {
    next((instance) => {
      if (instance.isLoggedIn) {
        next({
          path: from.path
        });
      }
    });
  }
};