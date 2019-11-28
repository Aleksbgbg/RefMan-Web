<template lang="pug">
nav.flex.flex-row.bg-dark-light.px-4.py-2
  router-link.text-white.text-xl.py-1.mr-4(to="/")
    img.inline-block(
      :src="require('@/assets/logo.png')"
      alt="logo"
      width="25"
      height="25"
    )
    span RefMan
  .flex.flex-grow
    navigation
      nav-item(:to="{ name: 'references' }") References
    c-dropdown-button.ml-auto(variant="purple")
      template(v-slot:button-content)
        img.inline-block.mr-1(
          src="https://api.adorable.io/avatars/285/username.png"
          alt=""
          width="21"
          height="21"
        )
        span Username
      c-dropdown-item(:to="{ name: 'login' }") Login
      c-dropdown-item(:to="{ name: 'register' }") Register
</template>

<script>
import NavigationComponent from "./partials/Navigation";
import NavItemComponent from "./partials/NavItem";
import DropdownButtonComponent from "@/components/shared/dropdowns/DropdownButton";
import DropdownItemComponent from "@/components/shared/dropdowns/DropdownItem";

export default {
  components: {
    "navigation": NavigationComponent,
    "nav-item": NavItemComponent,
    "c-dropdown-button": DropdownButtonComponent,
    "c-dropdown-item": DropdownItemComponent
  }
};
</script>