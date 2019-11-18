<template lang="pug">
div
  header
    navbar
  main
    router-view
</template>

<script>
import NavbarComponent from "./navbar/Navbar.vue";

export default {
  components: {
    navbar: NavbarComponent
  }
};
</script>