<template lang="pug">
c-auth-form(title="Register" @submit="submit")
  c-username-input(
    placeholder="Enter a username"
    v-model="form.username.value"
    :validation-state="form.username.isValid"
    :invalid-state-message="form.username.invalidMessage"
  )
  c-password-input(
    placeholder="Enter a password"
    description="Your password is not stored verbatim."
    v-model="form.password.value"
    :validation-state="form.password.isValid"
    :invalid-state-message="form.password.invalidMessage"
  )
  c-repeat-password-input(
    v-model="form.repeatPassword.value"
    :validation-state="form.repeatPassword.isValid"
    :invalid-state-message="form.repeatPassword.invalidMessage"
  )
</template>

<script>
import { submitToVuexStore } from "@/mixins/FormSubmit";
import { actionTypes } from "@/store/account/Types";
import AuthFormComponent from "./AuthForm";
import UsernameInputComponent from "./inputs/UsernameInput";
import PasswordInputComponent from "./inputs/PasswordInput";
import RepeatPasswordInputComponent from "./inputs/RepeatPasswordInput";
import { generateStub } from "@/utilities/FormDataStubGenerator";

export default {
  mixins: [submitToVuexStore(actionTypes.REGISTER)],
  components: {
    "c-auth-form": AuthFormComponent,
    "c-username-input": UsernameInputComponent,
    "c-password-input": PasswordInputComponent,
    "c-repeat-password-input": RepeatPasswordInputComponent
  },
  data() {
    return {
      form: {
        username: generateStub(),
        password: generateStub(),
        repeatPassword: generateStub()
      }
    };
  }
};
</script>