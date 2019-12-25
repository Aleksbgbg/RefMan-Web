import { Tab } from "@/services/tab-propagation/Tab";

export interface TabReceiver {
  open(tab: Tab): void;
}