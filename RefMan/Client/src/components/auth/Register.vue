<template lang="pug">
c-auth-form(title="Register" :isLoading="isLoading" @submit="submit")
  c-username-input(
    placeholder="Enter a username"
    :readonly="isLoading"
    v-model="form.username.value"
    :validation-state="form.username.isValid"
    :invalid-state-message="form.username.invalidMessage"
  )
  c-password-input(
    placeholder="Enter a password"
    description="Your password is not stored verbatim."
    :readonly="isLoading"
    v-model="form.password.value"
    :validation-state="form.password.isValid"
    :invalid-state-message="form.password.invalidMessage"
  )
  c-repeat-password-input(
    :readonly="isLoading"
    v-model="form.repeatPassword.value"
    :validation-state="form.repeatPassword.isValid"
    :invalid-state-message="form.repeatPassword.invalidMessage"
  )
  template(v-slot:footer)
    c-router-link(:to="{ name: 'login' }") Already have an account? Login instead!
</template>

<script>
import PreventAccessWhenLoggedInMixin from "@/mixins/access-control/PreventAccessWhenLoggedIn";
import LoadingIndicatorMixin from "@/mixins/LoadingIndicator";
import { submitFormToVuexStore } from "@/mixins/SubmitFormToVuexStore";
import { redirectOnSubmitSuccess } from "@/mixins/RedirectOnSubmitSuccess";
import { actionTypes } from "@/store/account/Types";
import AuthFormComponent from "./AuthForm";
import UsernameInputComponent from "./inputs/UsernameInput";
import PasswordInputComponent from "./inputs/PasswordInput";
import RepeatPasswordInputComponent from "./inputs/RepeatPasswordInput";
import RouterLinkComponent from "@/components/shared/RouterLink";
import { generateStub } from "@/utilities/FormDataStubGenerator";

export default {
  mixins: [
    PreventAccessWhenLoggedInMixin,
    LoadingIndicatorMixin,
    submitFormToVuexStore(actionTypes.REGISTER),
    redirectOnSubmitSuccess("/")
  ],
  components: {
    "c-auth-form": AuthFormComponent,
    "c-username-input": UsernameInputComponent,
    "c-password-input": PasswordInputComponent,
    "c-repeat-password-input": RepeatPasswordInputComponent,
    "c-router-link": RouterLinkComponent
  },
  data() {
    return {
      isLoading: false,
      form: {
        username: generateStub(),
        password: generateStub(),
        repeatPassword: generateStub()
      }
    };
  }
};
</script>