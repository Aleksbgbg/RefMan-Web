<template lang="pug">
c-auth-form(title="Login" :isLoading="isLoading" @submit="submit")
  c-username-input(
    placeholder="Enter your username"
    :readonly="isLoading"
    v-model="form.username.value"
    :validation-state="form.username.isValid"
    :invalid-state-message="form.username.invalidMessage"
  )
  c-password-input(
    placeholder="Enter your password"
    :readonly="isLoading"
    v-model="form.password.value"
    :validation-state="form.password.isValid"
    :invalid-state-message="form.password.invalidMessage"
  )
  template(v-slot:footer)
    c-router-link(:to="{ name: 'register' }") Don't have an account? Register!
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
import RouterLinkComponent from "@/components/shared/RouterLink";
import { generateStub } from "@/utilities/FormDataStubGenerator";

export default {
  mixins: [
    PreventAccessWhenLoggedInMixin,
    LoadingIndicatorMixin,
    submitFormToVuexStore(actionTypes.LOG_IN),
    redirectOnSubmitSuccess("/")
  ],
  components: {
    "c-auth-form": AuthFormComponent,
    "c-username-input": UsernameInputComponent,
    "c-password-input": PasswordInputComponent,
    "c-router-link": RouterLinkComponent
  },
  data() {
    return {
      isLoading: false,
      form: {
        username: generateStub(),
        password: generateStub()
      }
    };
  }
};
</script>