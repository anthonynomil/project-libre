import { RouteObject } from "react-router-dom";

import PrivateLayout from "~/components/layout/Private.layout.tsx";
import AuthType from "~/constants/enums/auth.type.ts";
import AuthMiddleware from "~/router/middlewares/auth/Auth.middleware.tsx";
import authenticatedRoutes from "~/router/routes/authenticated.routes.tsx";
import publicRoutes from "~/router/routes/public.routes.tsx";
import unauthenticatedRoutes from "~/router/routes/unauthenticated.routes.tsx";

const routes: RouteObject[] = [
  {
    children: unauthenticatedRoutes,
    element: <AuthMiddleware type={AuthType.Unauthenticated} />,
  },
  {
    children: authenticatedRoutes,
    element: (
      <AuthMiddleware type={AuthType.Authenticated}>
        <PrivateLayout />
      </AuthMiddleware>
    ),
  },
  {
    children: publicRoutes,
  },
];

export default routes;
