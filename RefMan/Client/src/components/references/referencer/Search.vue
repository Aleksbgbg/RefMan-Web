<template lang="pug">
.relative
  input.search-icon-before.border.border-transparent.rounded-lg.bg-gray-300.placeholder-gray-600.transition.focus-outline-none.focus-border-gray-300.focus-bg-white.w-full.py-2.pl-2.pr-12(
    placeholder="Enter a URL to reference"
    v-model="query"
  )
  .flex.items-center.absolute.inset-y-0.right-0.mr-2
    c-button-no-padding.group.px-2.py-1(
      variant="gray"
      @click="onSearch"
    )
      c-font-awesome-icon.text-gray-600.group-hover-text-gray-300(icon="search")
</template>

<script>
import ButtonNoPaddingComponent from "@/components/shared/buttons/ButtonNoPadding";
import { library } from "@fortawesome/fontawesome-svg-core";
import { faSearch } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";

library.add(faSearch);

export default {
  components: {
    "c-button-no-padding": ButtonNoPaddingComponent,
    "c-font-awesome-icon": FontAwesomeIcon
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