<template lang="pug">
c-card.max-w-xs.mx-auto.mt-4
  h4.text-2xl {{ title }}
  c-form(@submit="$emit('submit')")
    slot
    c-form-submit-button

    c-hr

    slot(name="footer")
</template>

<script>
import CardComponent from "@/components/shared/cards/Card";
import FormComponent from "@/components/shared/forms/Form";
import FormSubmitButtonComponent from "@/components/shared/forms/FormSubmitButton";
import HorizontalRuleComponent from "@/components/shared/HorizontalRule";

export default {
  components: {
    "c-card": CardComponent,
    "c-form": FormComponent,
    "c-form-submit-button": FormSubmitButtonComponent,
    "c-hr": HorizontalRuleComponent
  },
  props: {
    title: String
  }
};
</script>