<template lang="pug">
c-auth-form(title="Register" @submit="submit")
  c-username-input(
    placeholder="Enter a username"
    v-model="username.value"
    :validation-state="username.isValid"
    :invalid-state-message="username.invalidMessage"
  )
  c-password-input(
    placeholder="Enter a password"
    description="Your password is not stored verbatim."
    v-model="password.value"
    :validation-state="password.isValid"
    :invalid-state-message="password.invalidMessage"
  )
  c-repeat-password-input(
    v-model="repeatPassword.value"
    :validation-state="repeatPassword.isValid"
    :invalid-state-message="repeatPassword.invalidMessage"
  )
</template>

<script>
import AuthFormComponent from "./AuthForm";
import UsernameInputComponent from "./inputs/UsernameInput";
import PasswordInputComponent from "./inputs/PasswordInput";
import RepeatPasswordInputComponent from "./inputs/RepeatPasswordInput";
import { generateStub } from "@/utilities/FormDataStubGenerator";

export default {
  components: {
    "c-auth-form": AuthFormComponent,
    "c-username-input": UsernameInputComponent,
    "c-password-input": PasswordInputComponent,
    "c-repeat-password-input": RepeatPasswordInputComponent
  },
  data() {
    return {
      username: generateStub(),
      password: generateStub(),
      repeatPassword: generateStub()
    };
  },
  methods: {
    submit() {
    }
  }
};
</script>