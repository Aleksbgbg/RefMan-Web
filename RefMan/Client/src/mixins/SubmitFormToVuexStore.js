import { grabValues } from "@/utilities/ValueGrabber";
import { fillValidationErrors } from "@/utilities/FormValidationFiller";

export function submitFormToVuexStore(actionType) {
  return {
    methods: {
      async submit() {
        try {
          await this.$store.dispatch(actionType, grabValues(this.form));
        } catch (error) {
          fillValidationErrors(this.form, error);
        }
      }
    }
  };
}