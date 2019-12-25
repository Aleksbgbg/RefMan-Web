import { TabPropagator } from "@/services/tab-propagation/TabPropagator";
import { TabPropagatorImpl } from "@/services/tab-propagation/TabPropagatorImpl";
import { TabReceiver } from "@/services/tab-propagation/TabReceiver";

let tabPropagator: TabPropagator;

export function createTabPropagator(tabReceiver: TabReceiver): TabPropagator {
  tabPropagator = new TabPropagatorImpl(tabReceiver);
  return tabPropagator;
}

export function acquireTabPropagator(): TabPropagator {
  return tabPropagator;
}