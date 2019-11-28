<template lang="pug">
c-form-input(
  type="password"
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