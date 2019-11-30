export function redirectOnSubmitSuccess(route) {
  return {
    methods: {
      onSubmitSuccess() {
        this.$router.push(route);
      }
    }
  };
}