<template lang="pug">
nav.nav-height.flex.flex-row.bg-dark-light.px-4.py-2
  router-link.text-white.text-xl.py-1.mx-auto.sm-mr-4(to="/")
    img.inline-block(
      src="/img/logo.png"
      alt="RefMan logo"
      width="25"
      height="25"
    )
    span RefMan
  .hidden.sm-flex.flex-grow
    c-navigation
      c-nav-item(:to="{ name: 'references' }") References
    c-dropdown-button.ml-auto(variant="purple")
      template(v-slot:button-content)
        img.inline-block.mr-1(
          src="/img/avatar.png"
          alt="user avatar"
          width="21"
          height="21"
        )
        span {{ username }}
      template(v-if="isLoggedIn")
        c-dropdown-item(@click="logout") Log Out
      template(v-else)
        c-dropdown-item(:to="{ name: 'login' }") Login
        c-dropdown-item(:to="{ name: 'register' }") Register
</template>

<script>
import NavigationComponent from "./partials/Navigation";
import NavItemComponent from "./partials/NavItem";
import DropdownButtonComponent from "@/components/shared/dropdowns/DropdownButton";
import DropdownItemComponent from "@/components/shared/dropdowns/DropdownItem";
import { mapState, mapActions } from "vuex";
import { actionTypes } from "@/store/account/Types";

export default {
  components: {
    "c-navigation": NavigationComponent,
    "c-nav-item": NavItemComponent,
    "c-dropdown-button": DropdownButtonComponent,
    "c-dropdown-item": DropdownItemComponent
  },
  computed: {
    ...mapState({
      isLoggedIn: (state) => state.account.isLoggedIn,
      username: (state) => state.account.username
    })
  },
  methods: {
    ...mapActions({
      logout: actionTypes.LOG_OUT
    })
  }
};
</script>

<style lang="stylus">
.nav-height
  height: 56px
</style>