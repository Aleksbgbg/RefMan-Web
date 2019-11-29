<template lang="pug">
c-auth-form(title="Login" @submit="submit")
  c-username-input(
    placeholder="Enter your username"
    v-model="form.username.value"
    :validation-state="form.username.isValid"
    :invalid-state-message="form.username.invalidMessage"
  )
  c-password-input(
    placeholder="Enter your password"
    v-model="form.password.value"
    :validation-state="form.password.isValid"
    :invalid-state-message="form.password.invalidMessage"
  )
</template>

<script>
import AuthFormComponent from "./AuthForm";
import UsernameInputComponent from "./inputs/UsernameInput";
import PasswordInputComponent from "./inputs/PasswordInput";
import { generateStub } from "@/utilities/FormDataStubGenerator";
import { actionTypes } from "@/store/account/Types";
import { fillValidationErrors } from "@/utilities/FormValidationFiller";
import { grabValues } from "@/utilities/ValueGrabber";

export default {
  components: {
    "c-auth-form": AuthFormComponent,
    "c-username-input": UsernameInputComponent,
    "c-password-input": PasswordInputComponent
  },
  data() {
    return {
      form: {
        username: generateStub(),
        password: generateStub()
      }
    };
  },
  methods: {
    async submit() {
      try {
        await this.$store.dispatch(actionTypes.LOG_IN, grabValues(this.form));
      } catch (error) {
        fillValidationErrors(this.form, error);
      }
    }
  }
};
</script>