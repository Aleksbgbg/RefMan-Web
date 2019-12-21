<template lang="pug">
.grid.h-full
  header
    c-navbar
  main
    router-view
</template>

<script>
import NavbarComponent from "./navbar/Navbar.vue";

export default {
  components: {
    "c-navbar": NavbarComponent
  }
};
</script>

<style lang="stylus" scoped>
.grid
  display: grid
  grid-template-rows: auto 1fr
</style>