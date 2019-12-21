<template lang="pug">
.relative
  gc-button.dropdown-btn(
    v-bind="$attrs"
    v-external-click="hide"
    @click="isOpen = !isOpen"
  )
    slot(name="button-content")
  ul.hang.absolute.rounded.bg-white.shadow.py-3(v-show="isOpen")
    slot
</template>

<script>
import ExternalClickDirective from "@/directives/ExternalClick";

export default {
  inheritAttrs: false,
  directives: {
    "external-click": ExternalClickDirective
  },
  provide() {
    return {
      dropdownMenu: this
    };
  },
  data() {
    return {
      isOpen: false
    };
  },
  methods: {
    hide() {
      this.isOpen = false;
    }
  }
};
</script>

<style lang="stylus" scoped>
.dropdown-btn:after
  display: inline-block
  content: ""
  vertical-align: .255em
  margin-left: .255em
  border-top: .3em solid
  border-right: .3em solid transparent
  border-left: .3em solid transparent

.hang
  transform: translateY(.25rem)
  z-index: 1
</style>