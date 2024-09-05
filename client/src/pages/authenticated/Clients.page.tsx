import { Box, Divider, Paper } from "@mui/material";
import { styled } from "@mui/system";
import { useState } from "react";

import ClientsPanel from "~/components/panels/Clients.panel.tsx";
import ClientsInfosTabs from "~/components/tabs/Clients.infos.tabs.tsx";

export default function ClientsPage() {
  const [clientId, setClientId] = useState<null | number>(null);

  return (
    <TabsLayout elevation={1}>
      <TabsLeftPanel>
        <ClientsPanel onClick={(id) => setClientId(id)} />
      </TabsLeftPanel>
      <Divider orientation={"vertical"} />
      <TabsRightPanel>
        <ClientsInfosTabs clientId={clientId} />
      </TabsRightPanel>
    </TabsLayout>
  );
}

export const TabsLayout = styled(Paper)({
  display: "flex",
  height: "100%",
  maxHeight: "100%",
  maxWidth: "100%",
  width: "100%",
});

export const TabsLeftPanel = styled(Box)({
  display: "flex",
  flex: 1,
  flexDirection: "column",
  maxWidth: "30%",
  minWidth: 200,
});

export const TabsRightPanel = styled(Box)({
  display: "flex",
  flex: 1,
  flexDirection: "column",
  maxWidth: "70%",
  minWidth: 500,
});
