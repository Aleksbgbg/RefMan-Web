<template lang="pug">
c-auth-form(title="Login" @submit="submit")
  c-username-input(
    placeholder="Enter your username"
    v-model="username.value"
    :validation-state="username.isValid"
    :invalid-state-message="username.invalidMessage"
  )
  c-password-input(
    placeholder="Enter your password"
    v-model="password.value"
    :validation-state="password.isValid"
    :invalid-state-message="password.invalidMessage"
  )
</template>

<script>
import AuthFormComponent from "./AuthForm";
import UsernameInputComponent from "./inputs/UsernameInput";
import PasswordInputComponent from "./inputs/PasswordInput";
import { generateStub } from "@/utilities/FormDataStubGenerator";

export default {
  components: {
    "c-auth-form": AuthFormComponent,
    "c-username-input": UsernameInputComponent,
    "c-password-input": PasswordInputComponent
  },
  data() {
    return {
      username: generateStub(),
      password: generateStub()
    };
  },
  methods: {
    submit() {
    }
  }
};
</script>