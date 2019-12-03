import { createMixin } from "./PreventEntryFactory";

// Return true when logged in, meaning access is allowed
export default createMixin(
  (isLoggedIn) => isLoggedIn,
  (to, from, next) => ({ name: "login" })
);