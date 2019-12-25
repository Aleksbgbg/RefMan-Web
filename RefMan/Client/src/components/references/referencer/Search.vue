<template lang="pug">
.relative
  input.search-icon-before.border.border-transparent.rounded-lg.bg-gray-300.placeholder-gray-600.transition.focus-outline-none.focus-border-gray-300.focus-bg-white.w-full.py-2.pl-2.pr-12(
    :placeholder="placeholder"
    v-model="query"
  )
  .flex.items-center.absolute.inset-y-0.right-0.mr-2
    c-font-awesome-button(icon="search" @click="onSearch")
</template>

<script>
import { library } from "@fortawesome/fontawesome-svg-core";
import { faSearch } from "@fortawesome/free-solid-svg-icons";
import FontAwesomeButtonComponent from "@/components/shared/buttons/FontAwesomeButton";

library.add(faSearch);

export default {
  components: {
    "c-font-awesome-button": FontAwesomeButtonComponent
  },
  props: {
    placeholder: {
      type: String,
      default: "Search"
    }
  },
  data() {
    return {
      query: ""
    };
  },
  methods: {
    onSearch() {
      this.$emit("search", this.query);
    }
  }
};
</script>

<style lang="stylus" scoped>
.transition
  transition: all 0.1s ease-in
</style>