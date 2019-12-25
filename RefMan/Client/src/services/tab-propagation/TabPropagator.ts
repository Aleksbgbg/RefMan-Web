import { Tab } from "@/services/tab-propagation/Tab";

export interface TabPropagator {
  openTab(tab: Tab): void;
}