import store from "@/store";
import { actionTypes } from "@/store/account/Types";

export async function setupStore() {
  await store.dispatch(actionTypes.CHECK_LOGIN);
}