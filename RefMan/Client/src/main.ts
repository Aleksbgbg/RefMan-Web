import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import { actionTypes } from "@/store/account/Types";
import "@/assets/tailwind.css";
import "./GlobalComponents";

Vue.config.productionTip = false;

(async function() {
  await store.dispatch(actionTypes.CHECK_LOGIN);
})();

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");