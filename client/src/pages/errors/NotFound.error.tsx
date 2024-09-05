import { Button, Stack, Typography } from "@mui/material";
import { red } from "@mui/material/colors";
import { useNavigate } from "react-router-dom";

import RoutesUrl from "~/constants/enums/routes.url.ts";

const NotFoundError = () => {
  const navigate = useNavigate();

  const navigateBack = () => {
    navigate(RoutesUrl.Home);
  };

  return (
    <Stack alignItems={"center"} m={"auto"} spacing={5} width={"50%"}>
      <Typography color={red[700]} variant={"body1"}>
        404
      </Typography>
      <Typography variant={"h2"}>Page Not Found</Typography>
      <Button color={"primary"} onClick={navigateBack} variant={"contained"}>
        Go Home
      </Button>
    </Stack>
  );
};

export default NotFoundError;
