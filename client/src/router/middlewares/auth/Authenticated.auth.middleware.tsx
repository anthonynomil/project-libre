import { FC, ReactNode } from "react";
import { Navigate, Outlet } from "react-router-dom";

import RoutesUrl from "~/constants/enums/routes.url.ts";
import { useUserSelector } from "~/store/reducers/user.reducer.ts";

interface AuthenticatedAuthMiddlewareProps {
  children?: ReactNode;
}

const AuthenticatedAuthMiddleware: FC<AuthenticatedAuthMiddlewareProps> = (props) => {
  const user = useUserSelector();

  if (!user) return <Navigate to={RoutesUrl.Login} />;

  return props.children ?? <Outlet />;
};

export default AuthenticatedAuthMiddleware;
