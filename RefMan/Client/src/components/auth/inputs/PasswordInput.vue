<template lang="pug">
c-generic-password-input(
  name="password"
  title="Password"
  valid-state-message="Your password is valid."
  v-bind="$attrs"
  v-on="forwardInputListeners"
)
</template>

<script>
import NestedInputForwarderMixin from "@/mixins/input-forwarder/NestedInputForwarder";
import GenericPasswordInputComponent from "./GenericPasswordInput";

export default {
  inheritAttrs: false,
  mixins: [NestedInputForwarderMixin],
  components: {
    "c-generic-password-input": GenericPasswordInputComponent
  }
};
</script>