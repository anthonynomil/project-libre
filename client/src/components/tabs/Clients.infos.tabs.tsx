import { type SyntheticEvent, useState } from "react";

import Flex from "~/components/layout/Flex.tsx";
import ClientsInfosPanel from "~/components/panels/Clients.infos.panel.tsx";
import InvoicesTab from "~/components/tabs/Invoices.tab.tsx";
import QuotesTab from "~/components/tabs/Quotes.tab.tsx";
import TabsContent from "~/components/tabs/Tabs.content.tsx";
import TabsHeader, { TabProp } from "~/components/tabs/Tabs.header.tsx";

export default function ClientsInfosTabs(props: { clientId: null | number }) {
  const [activeTab, setActiveTab] = useState<number>(0);

  const tabs: TabProp[] = [
    { content: <ClientsInfosPanel clientId={props.clientId} />, label: "Détails" },
    { content: <QuotesTab />, label: "Quotes" },
    { content: <InvoicesTab />, label: "Invoices" },
  ];

  function changeActiveTab(_event: SyntheticEvent, newValue: number) {
    setActiveTab(newValue);
  }

  return (
    <Flex flex={1} flexDirection={"column"}>
      <TabsHeader onChange={changeActiveTab} tabs={tabs} value={activeTab} variant={"fullWidth"} />
      <TabsContent tabs={tabs} value={activeTab} />
    </Flex>
  );
}
