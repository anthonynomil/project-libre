import { RouteObject } from "react-router-dom";

import RoutesPath from "~/constants/enums/routes.path.ts";
import LoginPage from "~/pages/unauthenticated/Login.page.tsx";
import RegisterPage from "~/pages/unauthenticated/Register.page.tsx";

const unauthenticatedRoutes: RouteObject[] = [
  {
    element: <LoginPage />,
    path: RoutesPath.Login,
  },
  {
    element: <RegisterPage />,
    path: RoutesPath.Register,
  },
];

export default unauthenticatedRoutes;
