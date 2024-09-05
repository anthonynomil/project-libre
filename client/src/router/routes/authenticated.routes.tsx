import { RouteObject } from "react-router-dom";

import RoutesPath from "~/constants/enums/routes.path.ts";
import AccountPage from "~/pages/authenticated/Account.page.tsx";
import ClientsPage from "~/pages/authenticated/Clients.page.tsx";
import DashboardPage from "~/pages/authenticated/Dashboard.page.tsx";

const authenticatedRoutes: RouteObject[] = [
  {
    element: <DashboardPage />,
    path: RoutesPath.Home,
  },
  {
    element: <DashboardPage />,
    path: RoutesPath.Dashboard,
  },
  {
    element: <ClientsPage />,
    path: RoutesPath.Clients,
  },
  {
    element: <AccountPage />,
    path: RoutesPath.Account,
  },
];

export default authenticatedRoutes;
