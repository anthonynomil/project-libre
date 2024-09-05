import { RouteObject } from "react-router-dom";

import RoutesPath from "~/constants/enums/routes.path.ts";
import LegalPage from "~/pages/authenticated/Legal.page.tsx";
import NotFoundError from "~/pages/errors/NotFound.error.tsx";

const publicRoutes: RouteObject[] = [
  {
    element: <LegalPage />,
    path: RoutesPath.Legal,
  },
  {
    element: <NotFoundError />,
    path: "*",
  },
];

export default publicRoutes;
