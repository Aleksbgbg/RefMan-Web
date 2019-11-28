<template lang="pug">
c-form-input(
  name="username"
  title="Username"
  type="text"
  valid-state-message="Your username is valid."
  v-bind="$attrs"
  v-on="forwardInputListeners"
)
</template>

<script>
import NestedInputForwarderMixin from "@/mixins/input-forwarder/NestedInputForwarder";
import FormInputComponent from "@/components/shared/forms/FormInput";

export default {
  inheritAttrs: false,
  mixins: [NestedInputForwarderMixin],
  components: {
    "c-form-input": FormInputComponent
  }
};
</script>