import Vue from "vue";
import App from "./App.vue";
import router from "./router";

import "@/assets/tailwind.css";

import ButtonComponent from "@/components/shared/buttons/Button.vue";
import CardComponent from "@/components/shared/cards/Card.vue";
import DropdownButtonComponent from "@/components/shared/dropdowns/DropdownButton.vue";
import DropdownItemComponent from "@/components/shared/dropdowns/DropdownItem.vue";

Vue.component("c-button", ButtonComponent);
Vue.component("c-card", CardComponent);
Vue.component("c-dropdown-button", DropdownButtonComponent);
Vue.component("c-dropdown-item", DropdownItemComponent);

Vue.config.productionTip = false;

new Vue({
  router,
  render: h => h(App)
}).$mount("#app");