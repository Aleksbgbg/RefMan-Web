import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import { actionTypes } from "@/store/account/Types";
import "@/assets/tailwind.css";
import "./GlobalComponents";

Vue.config.productionTip = false;

declare global {
  interface Array<T> {
    remove(item: T): Array<T>;
  }
}

Array.prototype.remove = function<T>(this: T[], item: T): T[] {
  this.splice(this.indexOf(item), 1);
  return this;
};

(async function() {
  await store.dispatch(actionTypes.CHECK_LOGIN);
})();

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");