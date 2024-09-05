import { Box } from "@mui/material";

import Flex from "~/components/layout/Flex.tsx";
import { TabProp, TabsHeaderProps } from "~/components/tabs/Tabs.header.tsx";

export interface TabsContentProps extends TabsHeaderProps {
  height?: number | string;
}

export default function TabsContent(props: TabsContentProps) {
  return (
    <Box height={props.height ?? "100%"} width={"100%"}>
      {props.tabs.map((tab: TabProp, index: number) => (
        <Flex
          height={"100%"}
          id={`tabpanel-${index}`}
          key={index}
          role={"tabpanel"}
          sx={{ display: props.value === index ? "flex" : "none" }}
          width={"100%"}
        >
          {tab.content}
        </Flex>
      ))}
    </Box>
  );
}

// const TabsContentBody = styled(Flex)(({ height }) => ({
//   height: height ?? "100%",
//   width: "100%",
// }));
