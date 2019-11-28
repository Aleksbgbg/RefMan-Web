<template lang="pug">
generic-password-input(
  name="repeat-password"
  title="Repeat Password"
  placeholder="Repeat the above password"
  valid-state-message="Your passwords match!"
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
    "generic-password-input": GenericPasswordInputComponent
  }
};
</script>