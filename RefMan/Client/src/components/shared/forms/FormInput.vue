<template lang="pug">
.mb-4(role="group")
  label.block.mb-2(
    :id="labelId"
    :for="name"
  ) {{ title }}
  input.block.border.border-solid.rounded.placeholder-gray-600.focus-outline-none.focus-shadow-outline.w-full.px-3.py-2(
    :class=`{
      "border-green-500": isValid,
      "border-red-500": isInvalid,
      "border-gray-500": isNeutral
    }`
    :id="name"
    :aria-describedby="labelId"
    v-bind="$attrs"
    v-on="forwardInputListeners"
  )
  small.block.text-gray-700(v-if="description") {{ description }}
  small.block.text-green-500(v-show="isValid") {{ validStateMessage }}
  small.block.text-red-500(v-show="isInvalid") {{ invalidStateMessage }}
</template>

<script>
import RootInputForwarderMixin from "@/mixins/input-forwarder/RootInputForwarder";

export default {
  inheritAttrs: false,
  mixins: [RootInputForwarderMixin],
  props: {
    name: String,
    title: String,
    description: {
      type: String,
      default: null
    },
    validationState: {
      type: Boolean,
      default: null
    },
    validStateMessage: String,
    invalidStateMessage: String
  },
  computed: {
    labelId() {
      return `${this.name}-label`;
    },
    isValid() {
      return this.validationState === true;
    },
    isInvalid() {
      return this.validationState === false;
    },
    isNeutral() {
      return this.validationState === null;
    }
  }
};
</script>