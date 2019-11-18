<template lang="pug">
nav.bg-gray-900.px-4.py-2
  router-link.text-white.text-xl.mr-4(to="/")
    img.inline-block(
      :src="require('@/assets/logo.png')"
      alt="logo"
      width="25"
      height="25"
    )
    span RefMan
  nav-item(:to="{ name: 'references' }") References
</template>

<script>
import NavItemComponent from "./partials/NavItem";

export default {
  components: {
    "nav-item": NavItemComponent
  }
};
</script>