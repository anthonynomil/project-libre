import { ReactNode } from "react";
import { Outlet } from "react-router-dom";

import AuthType from "~/constants/enums/auth.type.ts";
import AuthenticatedAuthMiddleware from "~/router/middlewares/auth/Authenticated.auth.middleware.tsx";
import UnauthenticatedAuthMiddleware from "~/router/middlewares/auth/Unauthenticated.auth.middleware.tsx";

interface AuthMiddlewareProps {
  children?: ReactNode;
  type: AuthType;
}

const AuthMiddleware = (props: AuthMiddlewareProps) => {
  switch (props.type) {
    case AuthType.Authenticated:
      return <AuthenticatedAuthMiddleware>{props.children}</AuthenticatedAuthMiddleware>;
    case AuthType.Unauthenticated:
      return <UnauthenticatedAuthMiddleware>{props.children}</UnauthenticatedAuthMiddleware>;
    default:
      return props.children ?? <Outlet />;
  }
};

export default AuthMiddleware;
