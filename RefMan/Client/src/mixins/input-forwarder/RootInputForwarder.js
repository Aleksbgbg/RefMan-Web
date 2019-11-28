import { createMixin } from "./InputForwarderFactory";

export default createMixin((event) => event.target.value);