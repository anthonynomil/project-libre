import { Box } from "@mui/material";
import { useEffect, useState } from "react";
import { useSearchParams } from "react-router-dom";

import GenericBar, { type BarButton } from "~/components/navbars/Generic.bar.tsx";
import AccountInformationsTab from "~/components/tabs/Account.informations.tab.tsx";
import NotificationSettingsTab from "~/components/tabs/Notification.settings.tab.tsx";

enum AccountPageTabs {
  Informations = "informations",
  Notifications = "notifications",
}

const tabName = "current-tab";

export default function AccountPage() {
  const [searchParams, setSearchParams] = useSearchParams();
  const [activeTab, setActiveTab] = useState<AccountPageTabs | null>(getDefaultTab());

  const barItems: BarButton[] = [
    {
      children: [
        {
          active: activeTab === AccountPageTabs.Informations,
          label: "Informations",
          onClick: changeTab(AccountPageTabs.Informations),
        },
      ],
      label: "Account",
    },
    {
      children: [
        {
          active: activeTab === AccountPageTabs.Notifications,
          label: "Notifications",
          onClick: changeTab(AccountPageTabs.Notifications),
        },
      ],
      label: "Settings",
    },
  ];

  function changeTab(tabNumber: AccountPageTabs) {
    return () => setActiveTab(tabNumber);
  }

  function getDefaultTab(): AccountPageTabs | null {
    const tabParam = searchParams.get(tabName);
    if (!tabParam) {
      return AccountPageTabs.Informations;
    }
    if (Object.values(AccountPageTabs).includes(tabParam as AccountPageTabs)) return tabParam as AccountPageTabs;
    return AccountPageTabs.Informations;
  }

  useEffect(() => {
    setSearchParams({ [tabName]: activeTab ?? AccountPageTabs.Informations });
  }, [activeTab]);

  return (
    <Box sx={{ display: "flex", flex: 1 }}>
      <GenericBar items={barItems} />
      <Box sx={{ display: "flex", flex: 1, p: 4 }}>
        {activeTab === AccountPageTabs.Informations && <AccountInformationsTab />}
        {activeTab === AccountPageTabs.Notifications && <NotificationSettingsTab />}
      </Box>
    </Box>
  );
}
