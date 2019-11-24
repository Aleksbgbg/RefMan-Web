<template lang="pug">
.relative
  c-button.dropdown-btn(
    v-bind="$attrs"
    v-external-click="hide"
    @click.native="isOpen = !isOpen"
  )
    slot(name="button-content")
  ul.absolute.align-right.rounded.bg-white.shadow.py-3(v-show="isOpen")
    slot
</template>

<script>
import ExternalClick from "@/directives/ExternalClick";

export default {
  inheritAttrs: false,
  directives: {
    "external-click": ExternalClick
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

ul
  transform: translateY(.25rem)
</style>