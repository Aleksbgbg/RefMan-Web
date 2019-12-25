import { TabPropagator } from "@/services/tab-propagation/TabPropagator";
import { TabReceiver } from "@/services/tab-propagation/TabReceiver";
import { Tab } from "@/services/tab-propagation/Tab";

export class TabPropagatorImpl implements TabPropagator {
  private readonly _tabReceiver: TabReceiver;

  constructor(tabReceiver: TabReceiver) {
    this._tabReceiver = tabReceiver;
  }

  public openTab(tab: Tab): void {
    this._tabReceiver.open(tab);
  }
}