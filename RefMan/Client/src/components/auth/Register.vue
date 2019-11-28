<template lang="pug">
auth-form(title="Register" @submit="submit")
  username-input(
    placeholder="Enter a username"
    v-model="username.value"
    :validation-state="username.isValid"
    :invalid-state-message="username.invalidMessage"
  )
  password-input(
    placeholder="Enter a password"
    description="Your password is not stored verbatim."
    v-model="password.value"
    :validation-state="password.isValid"
    :invalid-state-message="password.invalidMessage"
  )
  repeat-password-input(
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
    "auth-form": AuthFormComponent,
    "username-input": UsernameInputComponent,
    "password-input": PasswordInputComponent,
    "repeat-password-input": RepeatPasswordInputComponent
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