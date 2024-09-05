import { Tab, TabProps, Tabs, TabsProps } from "@mui/material";
import { styled } from "@mui/system";
import { JSX, ReactNode } from "react";

export interface TabProp extends Omit<TabProps, "content"> {
  content: JSX.Element | JSX.Element[] | ReactNode;
}

export interface TabsHeaderProps extends Omit<TabsProps, "children"> {
  height?: number | string;
  tabs: TabProp[];
}

function generateProp(index: number) {
  return {
    "aria-controls": `tabpanel-${index}`,
    id: `tabpanel-${index}`,
  };
}

export default function TabsHeader(props: TabsHeaderProps) {
  return (
    <UnStyledTabsHeader {...props}>
      {props.tabs.map((tab, index) => (
        <UnStyledTab {...generateProp(index)} key={index} {...tab} content={tab.content as any} />
      ))}
    </UnStyledTabsHeader>
  );
}

const UnStyledTabsHeader = styled(Tabs)<{ height?: number | string }>(({ height, theme }) => ({
  ".MuiTabs-fixed": {
    height: "100%",
  },
  height: height ?? theme.spacing(16),
  minHeight: height ?? theme.spacing(16),
  overflow: "none",
}));

const UnStyledTab = styled(Tab)<{ height?: number | string }>(({ height, theme }) => ({
  "& .MuiTabs-flexContainer": {
    height: "100%",
  },
  height: height ?? theme.spacing(16),
  width: "100%",
}));
