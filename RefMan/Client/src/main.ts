import Vue from "vue";
import { performSetup } from "@/setup";
import router from "@/router";
import store from "@/store";
import App from "@/App.vue";
import "@/assets/tailwind.css";

Vue.config.productionTip = false;

performSetup()
  .then();

new Vue({
  router,
  store,
  render: (h) => h(App)
}).$mount("#app");