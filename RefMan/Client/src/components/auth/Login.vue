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
  template(v-slot:footer)
    c-router-link(:to="{ name: 'register' }") Don't have an account? Register!
</template>

<script>
import { submitToVuexStore } from "@/mixins/FormSubmit";
import { actionTypes } from "@/store/account/Types";
import AuthFormComponent from "./AuthForm";
import UsernameInputComponent from "./inputs/UsernameInput";
import PasswordInputComponent from "./inputs/PasswordInput";
import RouterLinkComponent from "@/components/shared/RouterLink";
import { generateStub } from "@/utilities/FormDataStubGenerator";

export default {
  mixins: [submitToVuexStore(actionTypes.LOG_IN)],
  components: {
    "c-auth-form": AuthFormComponent,
    "c-username-input": UsernameInputComponent,
    "c-password-input": PasswordInputComponent,
    "c-router-link": RouterLinkComponent
  },
  data() {
    return {
      form: {
        username: generateStub(),
        password: generateStub()
      }
    };
  }
};
</script>