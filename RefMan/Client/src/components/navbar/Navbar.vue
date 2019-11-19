<template lang="pug">
nav.flex.flex-row.bg-dark-light.px-4.py-2
  router-link.text-white.text-xl.mr-4(to="/")
    img.inline-block(
      :src="require('@/assets/logo.png')"
      alt="logo"
      width="25"
      height="25"
    )
    span RefMan
  .flex.flex-grow
    nav-item(:to="{ name: 'references' }") References
    c-dropdown-button.ml-auto
      template(v-slot:button-content)
        img.inline(
          src="https://api.adorable.io/avatars/285/username.png"
          alt=""
          width="15"
          height="15"
        )
        span Username
      c-dropdown-item(:to="{ name: 'login' }") Login
      c-dropdown-item(:to="{ name: 'register' }") Register
</template>

<script>
import NavItemComponent from "./partials/NavItem";

export default {
  components: {
    "nav-item": NavItemComponent
  }
};
</script>