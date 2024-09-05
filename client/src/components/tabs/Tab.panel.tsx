import { styled } from "@mui/system";
import { ReactNode } from "react";

import Flex from "~/components/layout/Flex.tsx";

interface TabPanelProps {
  activeTab: number;
  children?: ReactNode;
  index: number;
}

export default function TabPanel(props: TabPanelProps) {
  const isActive = props.activeTab === props.index;
  return (
    <TabContent id={`tabpanel-${props.index}`} role={"tabpanel"} sx={{ display: isActive ? "flex" : "none" }}>
      {props.children}
    </TabContent>
  );
}

const TabContent = styled(Flex)({
  height: "100%",
  width: "100%",
});
