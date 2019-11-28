export function createMixin(eventValueGrabber) {
  return {
    computed: {
      forwardInputListeners() {
        return Object.assign(
          {},
          this.$listeners,
          {
            // v-model compatibility
            input: (event) => {
              this.$emit("input", eventValueGrabber(event));
            }
          }
        );
      }
    }
  };
};