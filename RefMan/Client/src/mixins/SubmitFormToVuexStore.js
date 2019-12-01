import { grabValues } from "@/utilities/ValueGrabber";
import { fillValidationErrors } from "@/utilities/FormValidationFiller";

export function submitFormToVuexStore(actionType) {
  return {
    methods: {
      async submit() {
        this.onSubmit();

        try {
          await this.$store.dispatch(actionType, grabValues(this.form));
        } catch (error) {
          fillValidationErrors(this.form, error);
          this.onSubmitFailure();
          return;
        }

        this.onSubmitSuccess();
      }
    }
  };
}