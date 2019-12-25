import { setupStore } from "@/setup/Store";
import { extendArray } from "@/setup/ExtendArray";
import { registerGlobalComponents } from "@/setup/RegisterGlobalComponents";

export async function performSetup() {
  extendArray();
  registerGlobalComponents();
  await setupStore();
}