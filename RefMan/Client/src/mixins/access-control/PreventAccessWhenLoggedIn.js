import { createMixin } from "./PreventEntryFactory";

// Return false when logged in, meaning access is not allowed
export default createMixin(
  (isLoggedIn) => !isLoggedIn,
  (to, from, next) => ({ path: from.path })
);