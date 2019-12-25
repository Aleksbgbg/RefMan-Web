import { setupStore } from "@/setup/SetupStore";
import { extendArray } from "@/setup/ExtendArray";

export async function performSetup() {
  extendArray();
  await setupStore();
}