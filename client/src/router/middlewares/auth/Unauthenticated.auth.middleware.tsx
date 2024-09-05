import { FC, ReactNode } from "react";
import { Navigate, Outlet } from "react-router-dom";

import RoutesUrl from "~/constants/enums/routes.url.ts";
import { useUserSelector } from "~/store/reducers/user.reducer.ts";

interface UnauthenticatedAuthMiddlewareProps {
  children?: ReactNode;
}

const UnauthenticatedAuthMiddleware: FC<UnauthenticatedAuthMiddlewareProps> = (props) => {
  const user = useUserSelector();

  if (user) return <Navigate to={RoutesUrl.Home} />;

  return props.children ?? <Outlet />;
};

export default UnauthenticatedAuthMiddleware;
