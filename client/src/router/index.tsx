import { createBrowserRouter } from "react-router-dom";

import routes from "~/router/routes";

const route = [
  {
    children: routes,
    path: "",
  },
];

const router = createBrowserRouter(route);

export default router;
