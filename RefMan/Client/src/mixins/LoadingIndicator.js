export default {
  methods: {
    onSubmit() {
      this.isLoading = true;
    },
    onSubmitSuccess() {
      this.isLoading = false;
    },
    onSubmitFailure() {
      this.isLoading = false;
    }
  }
};