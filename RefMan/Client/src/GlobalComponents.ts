import Vue from "vue";

import ButtonComponent from "@/components/shared/buttons/Button.vue";
import CardComponent from "@/components/shared/cards/Card.vue";
import DropdownButtonComponent from "@/components/shared/dropdowns/DropdownButton.vue";
import DropdownItemComponent from "@/components/shared/dropdowns/DropdownItem.vue";

Vue.component("c-button", ButtonComponent);
Vue.component("c-card", CardComponent);
Vue.component("c-dropdown-button", DropdownButtonComponent);
Vue.component("c-dropdown-item", DropdownItemComponent);