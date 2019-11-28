<template lang="pug">
div
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