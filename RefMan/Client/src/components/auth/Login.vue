<template lang="pug">
auth-form(title="Login" @submit="submit")
  username-input(
    placeholder="Enter your username"
    v-model="username.value"
    :validation-state="username.isValid"
    :invalid-state-message="username.invalidMessage"
  )
  password-input(
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
    "auth-form": AuthFormComponent,
    "username-input": UsernameInputComponent,
    "password-input": PasswordInputComponent
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